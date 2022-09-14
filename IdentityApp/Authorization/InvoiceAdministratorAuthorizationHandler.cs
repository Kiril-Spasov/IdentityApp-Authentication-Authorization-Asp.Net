using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using IdentityApp.Models;

namespace IdentityApp.Authorization
{
    public class InvoiceAdministratorAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Invoice>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Invoice invoice)
        {
            if (context.User == null)
                return Task.CompletedTask;

            if (context.User.IsInRole(Constants.InvoiceAdministratorRole))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
