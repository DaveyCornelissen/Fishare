using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Clients.ActiveDirectory;


namespace Fishare.Cookies
{
    public class CookieClaims : ClaimsPrincipal
    {
        private ClaimsIdentity identity;

        /// <summary>
        /// A list of added claims
        /// </summary>
        public List<Claim> ClaimList { get; private set; }

        public CookieClaims()
        {
            ClaimList = new List<Claim>();
        }

        /// <summary>
        /// To add a new claim to the Cookies
        /// </summary>
        /// <param name="claimType"></param>
        /// <param name="claimValue"></param>
        public void addClaims(string claimType, string claimValue)
        {
            ClaimList.Add(new Claim(claimType, claimValue));
        }

        /// <summary>
        /// To create the principals of the selected cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public ClaimsPrincipal CreateCookieAuth(string cookieName)
        {
            var claimsIdentity = new ClaimsIdentity(
                ClaimList, cookieName);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Set current principal
            Thread.CurrentPrincipal = claimsPrincipal;

            return claimsPrincipal;
        }
    }
}
