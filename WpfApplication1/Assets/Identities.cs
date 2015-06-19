using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace flc.FrontDoor.Assets
{
    /// <summary>
    /// Custom Identity class for each User
    /// </summary>
    class CustomID:IIdentity
    {
        #region Properties
        public string Name { get; private set; }

        public string Email { get; private set; }

        public Guid EmployeeID { get; private set; }

        public string[] Roles { get; private set; }
        #endregion


        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomID"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="roles">The roles.</param>
        public CustomID( Guid employeeid, string name, string email, string[] roles)
        {
            this.Name = name;
            this.Email = email;
            this.Roles = roles;
            this.EmployeeID = employeeid;
        }

        #endregion


        #region InterfaceFunctions

        public string AuthenticationType
        {
            get { { return "CustomAuthentication"; } }
        }
        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated. User is Authenticated when CustomId Name is set. 
        /// </summary>
        public bool IsAuthenticated
        {
            get { { return !string.IsNullOrEmpty(Name); } }

        }

        #endregion

    }
       



    /// <summary>
    /// Empty ID to indicate error in login
    /// </summary>

    class AnonID : CustomID
    {
        #region Ctor
        public AnonID():base( new Guid(),string.Empty,string.Empty, new string[]{})
        {

        }
        #endregion
    }




    class Principal : IPrincipal
    {
        #region Private Methods
        CustomID _id; 
        #endregion

        #region Properties
        public CustomID ID
        {
            get { return _id ?? new AnonID(); }
            set { _id = value; }
        }
        
        #endregion


        #region InterfaceFunctions
         IIdentity IPrincipal.Identity
        {
            get { return this.ID; }
        }

        public bool IsInRole(string role)
        {
            return this.ID.Roles.Contains(role);
        }
    } 
        #endregion


}


