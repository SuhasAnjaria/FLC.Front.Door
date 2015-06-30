
namespace flc.FrontDoor.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using flc.FrontDoor.Views;
    using Framework.ComponentModel;
    using Framework.ComponentModel.Rules;
    using Framework.UI.Input;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
class SecuritySelectionViewModel:BaseViewModel
    {
    
    private  string _selectedproduct;
        
    public string SelectedProduct
     {
        get{ return this._selectedproduct;}

         set { this.SetProperty(ref this._selectedproduct, value);
        }
        	
      }	

        	public SecuritySelectionViewModel ()
	{
                
	}	 

        }
    }
