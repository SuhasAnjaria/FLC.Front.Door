using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Threading;
using System.ComponentModel;
using flc.FrontDoor.Assets;


namespace flc.FrontDoor.Models
{
    /// <summary>
    /// Generic Interface for Authentication. Will be used for DB/Bloomberg/Cloud authentication
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IAuthenticate<T>
    {
        /// <summary>
        /// Authenticates me.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns></returns>
        T AuthenticateMe(params string[] credentials);
    }

    #region DataBaseAuthentication

    /// <summary>
    /// DataBase Authentication Model
    /// </summary>
    /// 

    class AuthenticationModel : IAuthenticate<CustomID>
    {
        /// <summary>
        /// Authenticates me.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>CustomID object which is System.Security.Identity object to be tied to Current Principal</returns>
        /// <exception cref="UnauthorizedAccessException">Access Denied. Recheck Credentials or contact Admin</exception>
        public CustomID AuthenticateMe(params string[] credentials)
        {
            string password = credentials[1];
            const string salt = "#FLC^FRONT^DOOR#";
            string HashedPassword = GetHashCode(password, salt);


            //TODO: CustomID CALLWCF(username,HASHEDPassword) 



            if (BCrypt.CheckPassword(password + salt, GetHashCode(password, salt)))
            {
                return new CustomID(new Guid(), credentials[0], credentials[0], new string[] { "Role1" });
            }
            else
            {

                throw new UnauthorizedAccessException("Access Denied. Recheck credentials or contact Admin");
            }

        }

        /// <summary>
        /// Gets the hash code. Uses BCrypt Blowfish Hashing Algorithm
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        private static string GetHashCode(string password, string salt)
        {
            string passtohash = password + salt;
            return BCrypt.HashPassword(passtohash, BCrypt.GenerateSalt());
        }

    }
}

    #endregion
