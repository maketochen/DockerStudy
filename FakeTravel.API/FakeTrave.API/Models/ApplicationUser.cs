using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        //shopingCart
        public ShoppingCart ShoppingCart { get; set; }
        //Orders

        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
        // 用户的权限信息
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        // 第三方登录信息
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        // 用户登录的Token信息
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    }
}
