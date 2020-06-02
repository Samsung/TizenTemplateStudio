using System;
using System.Windows.Input;

using Xamarin.Forms;

using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        public ICommand ClickButtonCommand { get; private set; }


        public WatchItemNameViewModel()
        {
            ClickButtonCommand = new Command(() => ClickButton());
        }

        // The ActionButton provides a Clicked event and occurs when clicked the ActionButton.
        private void ClickButton()
        {
            // TODO: Insert code to handle the bottom button click.
        }
    }
}
