using System;
using System.Windows.Input;

using Param_RootNamespace.Mvvm;

using Xamarin.Forms;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        public ICommand ClickButtonCommand { get; private set; }

        public WatchItemNameViewModel()
        {
            ClickButtonCommand = new Command(() => ClickButton());
        }

        // Called when the button is clicked.
        private void ClickButton()
        {
            // TODO: Insert code to handle the button clicked.
            //
            // To perform page navigation, use the GoToAsync method in Xamarin.Forms Shell API.
            // await Shell.Current.GoToAsync("newpage");
            //
            // For more details, see https://docs.microsoft.com/ko-kr/xamarin/xamarin-forms/app-fundamentals/shell/navigation
        }
    }
}
