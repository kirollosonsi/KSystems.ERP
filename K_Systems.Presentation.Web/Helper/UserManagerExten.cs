using K_Systems.Data.Core.Domain;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_Systems.Presentation.Web.Helper
{
    public static class UserManagerExten
    {
        public static UserERP FindByEmailAndPassword(this UserManager<UserERP> userManager, string email , string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

           UserERP user =  userManager.FindByEmail(email);

            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
                return null;

           PasswordVerificationResult pResult =  userManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, password);
            return pResult == PasswordVerificationResult.Failed ? null : user;
        }
    }
}