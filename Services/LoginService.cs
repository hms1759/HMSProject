using Application.Share;
using AutoMapper;
using HotelMgt.Application.Shared;
using HotelMgt.Models;
using HotelMgt.Models.AppDbContext;
using HotelMgt.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgt.Services
{
    public class LoginService : ILoginService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        private ApplicationDbContext _dbContext;

        private readonly IMapper _mapper;
        public LoginService(UserManager<IdentityUser> userManager , IConfiguration  configuration, IMapper mapper, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
            _configuration = configuration;
        }

       
        public async Task<UserManagmentResponse> RegistrationASync(RegistrationViewModel model)
        {
            if(model == null)
            throw new NullReferenceException("register model is null");

            if (model.Password != model.ConfirmPassword)
            {
               
                return new UserManagmentResponse
                {
                    Message = "Confirm Password doesnt Match",
                    IsSuccessful = false
                };

            }

            var identityUser = new IdentityUser
            {
                Email = model.VisitorEmail,
                UserName = model.VisitorEmail,
                PhoneNumber= model.VisitoPhone
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);
            if(result.Succeeded)
            {
               var visitor = _mapper.Map<Visitors>(model);
                _dbContext.DbVisitor.Add(visitor);
                int count = _dbContext.SaveChanges();
                //if (count < 1)
                //{
                //    return null;

                //}


                return new UserManagmentResponse
                {
                    Message = "User creatwed Successfully",
                    IsSuccessful = true
                };
            }


            return new UserManagmentResponse
            {
                Message = "User did not create",
                IsSuccessful = false,
                Error = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagmentResponse> LoginAsync(LoginViewModel model)  
        {
            var user = await _userManager.FindByEmailAsync(model.Username);
            if(user==null)
                {
                return new UserManagmentResponse
                {
                    Message = "Username Not Found",
                    IsSuccessful = false

                };

            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if(!result)
            {
                return new UserManagmentResponse
                {
                    Message = "Invalid Password",
                    IsSuccessful = false

                };
            }
            var claims = new[]
            {
                new Claim("Email", model.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
          // new Claim(ClaimTypes.MobilePhone, user.PhoneNumber?)
       //new Claim(ClaimTypes.Email, userInfo.Email),
       //new Claim(ClaimTypes.NameIdentifier, userInfo.AppCode),
       //new Claim(ClaimTypes.DateOfBirth, userInfo.AddedDate.ToString("yyyy-MM-dd")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:issuer"],
                audience: _configuration["Jwt:issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

                );
            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagmentResponse
            {
                Message = tokenAsString,
                IsSuccessful = true,
                ExpireDate = token.ValidTo
            };
        }
    }
}
