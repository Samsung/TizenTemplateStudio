using System;
using System.Windows.Input;

using Xamarin.Forms;

using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        public ICommand ClickFirstButtonCommand { get; private set; }
        public ICommand ClickSecondButtonCommand { get; private set; }


        public WatchItemNameViewModel()
        {
            ClickFirstButtonCommand = new Command(() => ClickFirstButton());
            ClickSecondButtonCommand = new Command(() => ClickSecondButton());
        }

        // When the FirstButton is clicked, the command below is invoked.
        private void ClickFirstButton()
        {
            // TODO: Insert code to handle the first button click.
        }

        // When the SecondButton is clicked, the command below is invoked.
        private void ClickSecondButton()
        {
            // TODO: Insert code to handle the second button click.
        }
    }
}
