using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTDD.Security
{
    public class WebApiTddClaimAuthenticationManager : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            return base.Authenticate(resourceName, incomingPrincipal);
        }
    }
}
