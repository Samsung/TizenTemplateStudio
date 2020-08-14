using System;
using System.Collections.Generic;
using System.Windows.Input;

using Param_RootNamespace.Models;
using Param_RootNamespace.Services;
using Param_RootNamespace.Mvvm;

using Xamarin.Forms;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        public WatchItemNameViewModel()
        {
            SelectedItemCommand = new Command<SampleColor>(SelectedItem);
            TappedItemCommand = new Command<SampleColor>(TappedItem);
        }

        public ICommand SelectedItemCommand { get; private set; }
        public ICommand TappedItemCommand { get; private set; }

        public IEnumerable<SampleColor> AllColors => SampleDataService.AllColors();

        // Called once when an item is selected.
        private void SelectedItem(SampleColor color)
        {
            // TODO: Insert code to handle a list item selected command.
            // if (color != null)
            // {
            //     Logger.Info($"Selected Item : {color.Name}");
            // }
        }

        // Called every time an item is tapped.
        private void TappedItem(SampleColor color)
        {
            // TODO: Insert code to handle a list item tapped command.
            // if (color != null)
            // {
            //     Logger.Info($"Tapped Item : {color.Name}");
            // }
        }
    }
}
