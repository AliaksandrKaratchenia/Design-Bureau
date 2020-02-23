using Design_Bureau.BLL.Authentication__Authorization.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Design_Bureau.BLL.Authentication__authorization
{
    public interface IUserService
    {
        Task<ClaimsIdentity> RegisterAsync(User user);

        ClaimsIdentity Authenticate(User user);
    }
}
