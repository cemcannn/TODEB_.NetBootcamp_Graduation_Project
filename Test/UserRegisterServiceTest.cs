using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Concrete;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DTO.User;
using FluentAssertions;
using Microsoft.Extensions.Caching.Distributed;
using Models.Common;
using Models.Entities;
using Moq;
using System;
using Xunit;

namespace Test
{
    public class UserRegisterServiceTest
    {
        [Fact]
        public void UserRegisterService_Success()
        {
            //arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Add(It.IsAny<User>()));

            var userDistributedCacheMock = new Mock<IDistributedCache>();
            userDistributedCacheMock.Setup(x => x.Get(It.IsAny<string>()));

            var jobsMock = new Mock<IJobs>();
            //jobsMock.Setup(x => x.DelayedJob(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()));
            jobsMock.Setup(x => x.FireAndForget(It.IsAny<string>(), It.IsAny<string>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            var userRegisterService =
                new UserService(userRepositoryMock.Object, mapper, jobsMock.Object, userDistributedCacheMock.Object);

            var userRegisterRequest = new UserRegisterRequest()
            {
                FullName = "Ahmet Mehmet",
                Email = "ahmet@hotmail.com",
                Role = (UserRoleEnum)3,
                UserPermissions = (PermissionEnum[])Enum.GetValues(typeof(PermissionEnum))
            };

            //act
            var response = userRegisterService.Register(userRegisterRequest);

            //assert
            response.Success.Should().BeTrue();
        }
    }
}
