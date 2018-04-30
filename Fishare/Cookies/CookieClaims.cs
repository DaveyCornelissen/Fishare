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
    }
}
