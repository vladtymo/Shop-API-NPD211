using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Core.Models;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Core.Services
{
    public class AccountsService(
        ShopDbContext context, 
        IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager) : IAccountsService
    {
        public async Task Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);
            }

            await signInManager.SignInAsync(user, true);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task Register(RegisterModel model)
        {
            var user = mapper.Map<User>(model);

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                throw new HttpException(result.Errors.First().Description, HttpStatusCode.BadRequest);
        }
    }

}
