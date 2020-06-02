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
        public IEnumerable<SampleColor> AllColors => SampleDataService.AllColors();

        public ICommand SelectedItemCommand { get; private set; }
        public ICommand TappedItemCommand { get; private set; }

        public WatchItemNameViewModel()
        {
            SelectedItemCommand = new Command<SampleColor>((o) => SelectedItem(o));
            TappedItemCommand = new Command<SampleColor>((o) => TappedItem(o));
        }

        // Called once when an item is selected.
        private void SelectedItem(object value)
        {
            // TODO: Insert code to handle a list item selected command.
            // var selectedValue = value as SampleColor;
            // if (selectedValue != null)
            // {
            //     Logger.Info($"Selected Item : {selectedValue.Name}");
            // }
        }

        // Called every time an item is tapped.
        private void TappedItem(object value)
        {
            // TODO: Insert code to handle a list item tapped command.
            // var tappedValue = value as SampleColor;
            // if (tappedValue != null)
            // {
            //     Logger.Info($"Tapped Item : {tappedValue.Name}");
            // }
        }
    }
}
