using System;
using System.Windows.Input;

using Xamarin.Forms;

using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        private const string FullStar = "WatchItemNameFullStar.png";
        private const string EmptyStar = "WatchItemNameEmptyStar.png";

        private string _poorImage;
        private string _averageImage;
        private string _excellentImage;

        public WatchItemNameViewModel()
        {
            ClickImageButtonCommand = new Command<string>(ClickImageButton);
            PoorImage = FullStar;
            AverageImage = ExcellentImage = EmptyStar;
        }

        public ICommand ClickImageButtonCommand { get; private set; }

        public string PoorImage
        {
            get
            {
                return _poorImage;
            }
            set
            {
                Set(ref (_poorImage), value);
            }
        }

        public string AverageImage
        {
            get
            {
                return _averageImage;
            }
            set
            {
                Set(ref (_averageImage), value);
            }
        }

        public string ExcellentImage
        {
            get
            {
                return _excellentImage;
            }
            set
            {
                Set(ref (_excellentImage), value);
            }
        }

        // Called when the image buttons is clicked.
        private void ClickImageButton(string button)
        {
            switch (button)
            {
                case "Poor":
                    AverageImage = ExcellentImage = EmptyStar;
                    break;
                case "Average":
                    AverageImage = FullStar;
                    ExcellentImage = EmptyStar;
                    break;
                default:
                    AverageImage = ExcellentImage = FullStar;
                    break;
            }
            // TODO: Insert code to handle the image buttons click.
        }
    }
}
