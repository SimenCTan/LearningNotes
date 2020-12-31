using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Policies
{
    internal class MinimumAgeAuthorizeAttribute: AuthorizeAttribute
    {
        const string POLICY_PREFIX = "MinimumAge";
        public MinimumAgeAuthorizeAttribute(int age) => Age = age;

         // Get or set the Age property by manipulating the underlying Policy property
        public int Age
        {
            get
            {
                if (int.TryParse(Policy.Substring(POLICY_PREFIX.Length), out var age))
                {
                    return age;
                }
                return default(int);
            }
            set
            {
                Policy = $"{POLICY_PREFIX}{value.ToString()}";
            }
        }
    }
}
