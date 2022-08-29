using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Abstract;
using Business.Configuration.Auth;
using Business.Configuration.Helper;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.UserValidation;
using DAL.Abstract;
using DTO.User;
using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        private readonly IJobs _jobs;

        public UserService(IUserRepository repository, IMapper mapper, IJobs jobs, IDistributedCache distributedCache)
        {
            _repository = repository;
            _mapper = mapper;
            _jobs = jobs;
            _distributedCache = distributedCache;
        }

        //Register Method
        public CommandResponse Register(UserRegisterRequest register)
        {
            //Validation codes
            var validator = new UserRegisterRequestValidator();
            validator.ValidateAndThrow(register);

            //Generate Password
            string generatedPassword = Generator.PasswordGenerator(6);

            //Mail Password
            _jobs.FireAndForget("cmcan@windowslive.com", generatedPassword);
            Console.WriteLine(generatedPassword);

            //Hashing password
            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(generatedPassword, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(register);

            //User Password Hash and Salt is set
            user.Password = new UserPassword()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            //User Permission is defaulted to User
            user.Permissions = register.UserPermissions.Select(x => new UserPermission()
            {
                Permission = x
            }).ToList();

            //Add user to database and save changes
            _repository.Add(user);
            _repository.SaveChanges();

            //Cache permission
            var key = StringHelper.CreateCacheKey(user.FullName, user.Id);
            var cachePermission = System.Text.Json.JsonSerializer.Serialize(register.UserPermissions);

            _distributedCache.SetString(key, cachePermission);

            return new CommandResponse
            {
                Success = true,
                Message = $"User registered successfully. Id={user.Id}"
            };
        }

        //GetAll method
        public IEnumerable<UserGetResponse> GetAll()
        {
            var data = _repository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<UserGetResponse>(x)).ToList();
            return mappedData;
        }

        public UserGetResponse GetById(int id)
        {
            var data = _repository.Get(x => x.Id == id);
            var mappedData = _mapper.Map<UserGetResponse>(data);
            return mappedData;
        }

        public CommandResponse Delete(User user)
        {
            _repository.Delete(user);
            return new CommandResponse
            {
                Success = true,
                Message = $"Revenue deleted successfully."
            };
        }

        public CommandResponse Update(UserUpdateRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
