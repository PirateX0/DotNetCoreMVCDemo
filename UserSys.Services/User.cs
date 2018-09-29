using System;
using System.Collections.Generic;
using System.Text;

namespace UserSys.Services
{
    public class User
    {
        public long Id { get; set; }
        public string PhoneNum { get; set; }
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }
    }
}
