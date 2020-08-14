using System;
using System.Windows.Input;

using Xamarin.Forms;

using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    /// <summary>
    /// Xamarin.Forms Entry is used for single-line text input. Entry supports various keyboard types.
    /// For more details, see https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/text/entry.
    /// </summary>
    public class WatchItemNameViewModel : BaseViewModel
    {
        private string _phoneNumber = string.Empty;
        private string _password = string.Empty;
        private string _homePage = "https://";
        private string _comment = string.Empty;

        public WatchItemNameViewModel()
        {
            CompleteEntryCommand = new Command(() => CompleteEntry());
            ClickButtonCommand = new Command(() => ClickButton());
        }

        /// <summary>
        /// Invoked when the user finalizes the text in an Entry with the return key.
        /// </summary>
        public ICommand CompleteEntryCommand { get; private set; }

        /// <summary>
        /// Invoked when the BottomButton is clicked.
        /// </summary>
        public ICommand ClickButtonCommand { get; private set; }

        /// <summary>
        /// The text that the user inputs in PhoneNumber Entry.
        /// </summary>
        public string PhoneNumberText
        {
            set => Set(ref _phoneNumber, value);
            get => _phoneNumber;
        }

        /// <summary>
        /// The text that the user inputs in Password Entry.
        /// </summary>
        public string PasswordText
        {
            set => Set(ref _password, value);
            get => _password;
        }

        /// <summary>
        /// The text that the user inputs in HomePage Entry.
        /// </summary>
        public string HomePageText
        {
            set => Set(ref _homePage, value);
            get => _homePage;
        }

        /// <summary>
        /// The text that the user inputs in Comment Entry.
        /// </summary>
        public string CommentText
        {
            set => Set(ref _comment, value);
            get => _comment;
        }

        // Called when CompleteEntryCommand is invoked.
        private void CompleteEntry()
        {
            // TODO: Implement the command to run the user presses the return key.
        }

        // Called when ClickButtonCommand is invoked.
        private void ClickButton()
        {
            // TODO: Insert code to handle the bottom button click.
        }
    }
}
