
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
    using flc.FrontDoor.Data;
class SecuritySelectionViewModel:BaseViewModel
    {

        // Fields...
        private IEnumerable<ProductSearchViewModel> _searchList;

        public IEnumerable<ProductSearchViewModel> SearchList
        {
            get { return _searchList; }
            set { _searchList = value; }
        }

        	public SecuritySelectionViewModel ()
	{
       this.SearchList = HierarchyViewModel.products.Select(product=> new ProductSearchViewModel{Product=product,Name=product.Name}) ;
               
	}	 

        }
    }
