
using Application.Share;
using HotelMgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgt.Services.IService
{
   public interface IVisitorService
    {
        Task<UserManagmentResponse> RegistrationASync(RegistrationViewModel model);
    }
}
