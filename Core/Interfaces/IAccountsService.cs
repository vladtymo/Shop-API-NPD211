﻿using Core.Models;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task Register(RegisterModel model);
        Task<LoginResponse> Login(LoginModel model);
        Task Logout();
    }
}
