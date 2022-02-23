using Microsoft.AspNetCore.Identity;
using System;

namespace LonShop.BaseCore.Entities.UserAggregate
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name) : base(name) { }
    }
}