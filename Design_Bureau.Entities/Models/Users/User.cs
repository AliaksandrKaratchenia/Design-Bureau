using Design_Bureau.Entities;
using System.ComponentModel.DataAnnotations;

namespace Design_Bureau.BLL.Authentication__Authorization.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
