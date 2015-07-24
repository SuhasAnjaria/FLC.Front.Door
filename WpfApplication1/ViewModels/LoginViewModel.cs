
namespace flc.FrontDoor.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Media;
    using System.Threading.Tasks;
    using Framework.UI.Controls;
    using Framework.UI.Input;
    using System.ComponentModel;
    using Framework.ComponentModel;
    using Framework.ComponentModel.Rules;
    using FrontDoor.Models;
    using FrontDoor.Assets;
    using System.Windows.Controls;
    using System.Security;
internal class LoginViewModel : BaseViewModel
    {

        #region PrivateMembers
        private string _username;
        private PasswordBox _pass;
        private bool _isbusy = true;
        private IAuthenticate<CustomID> _loginAuthenticate;
        private CustomID _currentuser;
        #endregion

        #region Ctor
        public LoginViewModel(IAuthenticate<CustomID> loginAuthenticate, object pass)
        {

            _loginAuthenticate = loginAuthenticate;

            Pass = pass as PasswordBox;
            this.loginCommand = new DelegateCommand<string>(this.Login);

        }
        #endregion

        #region Properties
        public string Username
        {

            set { this.SetProperty(ref this._username, value); }
            get { return this._username; }
        }

        public bool IsBusy
        {
            get { return this._isbusy; }
            set { this.SetProperty(ref this._isbusy, value); }
        }

        private PasswordBox Pass
        {
            get { return this._pass; }
            set { this.SetProperty(ref this._pass, value); }
        }
        #endregion

        #region Model Methods
        private void Login(string message)
        {
            this.IsBusy = false;

            try
            {
                _currentuser = _loginAuthenticate.AuthenticateMe(this._username, this._pass.Password);
                Principal MyUser = Thread.CurrentPrincipal as Principal;
                MyUser.ID = new CustomID(_currentuser.EmployeeID, _currentuser.Name, _currentuser.Email, _currentuser.Roles);

                if (!string.IsNullOrEmpty(_currentuser.Name))
                {

                    MessageDialog.ShowAsync("Welcome", _currentuser.Name);
                }
                Username = String.Empty;
                Pass.Password = String.Empty;



            }
            catch (UnauthorizedAccessException ex)
            {
                MessageDialog.ShowAsync("Error", ex.Message);

            }

        }
        #endregion

        #region Delegate Commands and Validation Rules
        private DelegateCommand<string> loginCommand;
        public DelegateCommand<string> LoginCommand
        {
            get
            {
                return this.loginCommand;
            }

        }
        static LoginViewModel()
        {
            Rules.Add(new DelegateRule<BaseViewModel>("Username", "Username cannot be empty", x =>
            {
                /*<interaction logic> 
                 Casting Base class to derived class and implementing validation rule
                 </interaction logic>*/
                var cast = (LoginViewModel)x; return !string.IsNullOrWhiteSpace(cast.Username);
            }));

            Rules.Add(new DelegateRule<BaseViewModel>("Password", "Password cannot be empty", x =>
                 {
                     /*<interaction logic> 
                      Casting Base class to derived class and implementing validation rule
                      </interaction logic>*/
                     var cast = (LoginViewModel)x; return !string.IsNullOrWhiteSpace(cast.Pass.Password);
                 }));
        }

        #endregion

    }
}
