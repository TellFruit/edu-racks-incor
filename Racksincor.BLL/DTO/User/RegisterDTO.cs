﻿namespace Racksincor.BLL.DTO.User
{
    public class RegisterDTO : UserDTO
    {
        public string PasswordConfirm { get; set; }

        public string Role { get; set; }
    }
}
