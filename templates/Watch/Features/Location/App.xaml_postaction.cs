//{[{
using Param_RootNamespace.Services;
//}]}

namespace Param_RootNamespace
{
    public partial class App : Application
    {
        protected override void OnStart()
        {

            //^^
            //{[{
            // The app has to request the permission to obtain the location information
            RequestPermissionLocationAsync();
            //}]}
        }

        //^^
        //{[{
        /// <summary>
        /// The app has to request the permission to obtain the location information.
        /// </summary>
        private async void RequestPermissionLocationAsync()
        {
            var response = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.Location);
            if (response == PrivacyPermissionStatus.Granted)
            {
                // TODO: The permission was granted
            }
            else
            {
                // TODO: The user denied the permission
            }
        }
        //}]}
    }
}
