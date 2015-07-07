using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using flc.FrontDoor.ViewModels;
namespace flc.FrontDoor.Common
{
    /// <summary>
    /// /Behavior for Autocompletebox suggestion handling
    /// </summary>
    public class AutocompleteBoxBehavior:Behavior<AutoCompleteBox>
    {
         
                  protected override void OnAttached()
            {
                base.OnAttached();

                AssociatedObject.FilterMode = AutoCompleteFilterMode.Custom;
                AssociatedObject.ItemFilter = ProductSearchViewModel.IsAutocompleteSuggestion;

                AssociatedObject.LostFocus += OnFocusLost;
            }

            private void OnFocusLost(object sender, RoutedEventArgs e)
            {
                AssociatedObject.Text = "";
            }

            protected override void OnDetaching()
            {
                base.OnDetaching();

                AssociatedObject.FilterMode = AutoCompleteFilterMode.StartsWith;
                AssociatedObject.ItemFilter = null;

                AssociatedObject.LostFocus -= OnFocusLost;
            }
        }
    }

