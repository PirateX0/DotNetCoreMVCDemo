using System;

namespace UserSys.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string PhoneNum { get; set; }
        public string PasswordHash { get; set; }
    }
}
