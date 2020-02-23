using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Design_Bureau.BLL.Authentication__Authorization.Models;
using Design_Bureau.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Design_Bureau.BLL.Authentication__authorization
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public ClaimsIdentity Authenticate(User user)
        {
            var dbUser = _repository
                .Find(x => x.Username == user.Username && x.Password == user.Password)
                .ToList()
                .FirstOrDefault();
  
            if (dbUser != null)
            {
                return new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, dbUser.Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return null;
        }

        public async Task<ClaimsIdentity> RegisterAsync(User user)
        {
            var dbUser = _repository
                .Find(x => x.Username == user.Username && x.Password == user.Password)
                .ToList()
                .FirstOrDefault();

            if (dbUser != null)
            {
                return null;
            }
            await _repository.Insert(user);

            return Authenticate(user);
        }
    }
}
