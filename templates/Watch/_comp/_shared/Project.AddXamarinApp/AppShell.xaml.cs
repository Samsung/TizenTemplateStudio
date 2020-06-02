using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Param_RootNamespace
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // By default, Shell displays a flyout icon when it contains more than one item.
            // If you want to hide it, set FlyoutBehavior.Disabled as shown below.
            // FlyoutBehavior = FlyoutBehavior.Disabled
        }

        protected override bool OnBackButtonPressed()
        {
            if (FlyoutIsPresented)
            {
                FlyoutIsPresented = false;
                return true;
            }
            return base.OnBackButtonPressed();
        }
    }
}
