using System;
using System.Collections.Generic;
using System.Text;
using UserSys.DTOs;

namespace UserSys.IServices
{
    public interface IUserService: IServiceTag
    {
        void AddNew(string phoneNum, string password);
        UserDTO GetByPhoneNum(string phoneNum);
        bool CheckLogin(string phoneNum, string password);
    }
}
