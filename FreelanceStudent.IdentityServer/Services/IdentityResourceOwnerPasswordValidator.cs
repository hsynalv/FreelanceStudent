using System.Threading.Tasks;
using FreelanceStudent.IdentityServer.Models;
using IdentityServer4.Validation;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace FreelanceStudent.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            if (existUser == null)
                return;
            var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);
            if (!passwordCheck)
                return;
            context.Result =
                new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
