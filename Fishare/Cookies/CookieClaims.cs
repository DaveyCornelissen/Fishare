using System;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Fishare.Cookies
{
    public static class CookieClaims 
    {
        /// <summary>
        /// get the userId to a string
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetCookieID(this IPrincipal user)
        {
            try
            {
                var claim = ((ClaimsIdentity)user.Identity).FindFirst("Id");
                return claim?.Value;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Get the users email to a string
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetCookieEmail(this IPrincipal user)
        {
            try
            {
                var claim = ((ClaimsIdentity)user.Identity).FindFirst("Email");
                return claim?.Value;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Get the username to a string for the navbar
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetCookieUserName(this IPrincipal user)
        {
            try
            {
                var claim = ((ClaimsIdentity)user.Identity).FindFirst("UserName");
                return claim?.Value;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Get the path to a string for the users profile picture
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetCookiePhoto(this IPrincipal user)
        {
            try
            {
                var claim = ((ClaimsIdentity)user.Identity).FindFirst("UserPicture");
                return claim?.Value;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public static void AddUpdateClaim(this IPrincipal user, string key, string value)
        {
            var Identity = ((ClaimsIdentity)user.Identity);
            if (Identity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = Identity.FindFirst(key);
            if (existingClaim != null)
                Identity.RemoveClaim(existingClaim);
        }
    }
}
