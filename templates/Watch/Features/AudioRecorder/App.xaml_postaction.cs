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
            // The app has to request permissions to use audio recorder
            RequestPermissionAudioRecorderAsync();
            RequestPermissionSharedStorageAsync();
            //}]}
        }

        //^^
        //{[{
        /// <summary>
        /// The app has to request the permission to access the recorder.
        /// </summary>
        private async void RequestPermissionAudioRecorderAsync()
        {
            var response = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.Recorder);
            if (response == PrivacyPermissionStatus.Granted)
            {
                // TODO: The permission was granted
            }
            else
            {
                // TODO: The user denied the permission
            }
        }

        /// <summary>
        /// The app has to request the permission to access the shared storage.
        /// </summary>
        private async void RequestPermissionSharedStorageAsync()
        {
            var response = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.MediaStorage);
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
