using Application.Share;
using AutoMapper;
using HotelMgt.Models;
using HotelMgt.Models.AppDbContext;
using HotelMgt.Services.IService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgt.Services
{
    public class VisitorService : IVisitorService
    {
        private UserManager<IdentityUser> _userManager;

        private ApplicationDbContext _dbContext;

        private readonly IMapper _mapper;
        public VisitorService(UserManager<IdentityUser> userManager , IMapper mapper, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
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
    }
}
