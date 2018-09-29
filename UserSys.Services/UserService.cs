using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserSys.Commons;
using UserSys.DTOs;
using UserSys.IServices;
using System.Linq;

namespace UserSys.Services
{
    public class UserService : IUserService
    {
        public void AddNew(string phoneNum, string password)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                if(ctx.Users.Any(u => u.PhoneNum == phoneNum))
                {
                    throw new ApplicationException("手机号已经存在");
                }
                User user = new User();
                user.PasswordHash = MD5Helper.Md5(password);
                user.PhoneNum = phoneNum;
                user.IsDeleted = false;
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }

        public bool CheckLogin(string phoneNum, string password)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                User user = ctx.Users.SingleOrDefault(u => u.PhoneNum == phoneNum);
                if(user==null)
                {
                    return false;
                }
                string inputPwdHash = MD5Helper.Md5(password);
                return user.PasswordHash == inputPwdHash;
            }
        }

        public UserDTO GetByPhoneNum(string phoneNum)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                User user = ctx.Users.SingleOrDefault(u => u.PhoneNum == phoneNum);
                if(user==null)
                {
                    return null;
                }
                return new UserDTO { Id=user.Id,PasswordHash=user.PasswordHash,PhoneNum=phoneNum};
            }
        }
    }
}
