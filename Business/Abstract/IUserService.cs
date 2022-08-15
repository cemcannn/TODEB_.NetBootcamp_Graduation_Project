using Business.Configuration.Response;
using DTO.User;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IEnumerable<UserGetResponse> GetAll();
        UserGetResponse GetById(int id);
        CommandResponse Register(UserRegisterRequest register);
        CommandResponse Update(UserUpdateRequest request);
        CommandResponse Delete(User user);
    }
}
