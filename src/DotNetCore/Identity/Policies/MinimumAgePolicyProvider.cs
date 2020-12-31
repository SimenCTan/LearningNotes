using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Policies
{
    public class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "MinimumAge";
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
                 int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
            {
                var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
                policy.AddRequirements(new MinimumAgeRequirement(age));
                return Task.FromResult(policy.Build());
            }
            return Task.FromResult<AuthorizationPolicy>(null);
        }
    }
}
