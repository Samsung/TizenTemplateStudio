using System;
using System.Windows.Input;

using Xamarin.Forms;

using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public partial class WatchItemNameViewModel : BaseViewModel
    {
        private double _progressBarValue;

        public WatchItemNameViewModel()
        {
            ClickPlusButtonCommand = new Command(() => ClickPlusButton());
            ClickMinusButtonCommand = new Command(() => ClickMinusButton());
            ProgressBarValue = 0.7;
        }

        public ICommand ClickPlusButtonCommand { get; private set; }
        public ICommand ClickMinusButtonCommand { get; private set; }

        public double ProgressBarValue
        {
            set
            {
                Set(ref _progressBarValue, value);
            }
            get
            {
                return _progressBarValue;
            }
        }

        // Called when the plus button is clicked.
        private void ClickPlusButton()
        {
            // TODO: Insert code to handle the CircleProgressBarSurfaceItem.
            if (ProgressBarValue < 1)
            {
                ProgressBarValue += 0.01;
            }
        }

        // Called when the minus button is clicked.
        private void ClickMinusButton()
        {
            // TODO: Insert code to handle the CircleProgressBarSurfaceItem.
            if (ProgressBarValue > 0)
            {
                ProgressBarValue -= 0.01;
            }
        }
    }
}
