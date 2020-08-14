using System;

using Xamarin.Forms;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        private const string FullStar = "WatchItemNameFullStar.png";
        private const string EmptyStar = "WatchItemNameEmptyStar.png";

        public WatchItemNamePage()
        {
            InitializeComponent();
            Poor.Source = FullStar;
            Average.Source = Excellent.Source = EmptyStar;
        }

        // Called when the image buttons is clicked.
        private void OnImageButtonClicked(object sender, EventArgs e)
        {
            if (sender.Equals(Poor))
            {
                Average.Source = Excellent.Source = EmptyStar;
            }
            else if (sender.Equals(Average))
            {
                Poor.Source = Average.Source = FullStar;
                Excellent.Source = EmptyStar;
            }
            else
            {
                Poor.Source = Average.Source = Excellent.Source = FullStar;
            }
            // TODO: Insert code to handle the image buttons click.
        }
    }
}
