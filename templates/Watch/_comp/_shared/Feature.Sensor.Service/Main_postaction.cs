//{[{
using Param_RootNamespace.Services;
//}]}

namespace Param_RootNamespace
{
    class TizenServiceApplication : ServiceApplication
    {
        protected override void OnCreate()
        {

            //^^
            //{[{
            // The app has to request the permission to access sensors
            RequestPermissionSensorAsync();
            //}]}
        }

        //^^
        //{[{
        /// <summary>
        /// The app has to request the permission to access sensors.
        /// </summary>
        private async void RequestPermissionSensorAsync()
        {
            var response = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.HealthInfo);
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
