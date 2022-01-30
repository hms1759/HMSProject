
using Application.Share;
using HotelMgt.Application.Shared;
using HotelMgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgt.Services.IService
{
   public interface ILoginService
    {
        Task<UserManagmentResponse> RegistrationASync(RegistrationViewModel model);
        Task<UserManagmentResponse> LoginAsync(LoginViewModel model);
    }
}
