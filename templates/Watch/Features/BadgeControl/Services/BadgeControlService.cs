using System;
using Tizen.Applications;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// For more information about using the BadgeControl API, see https://samsung.github.io/TizenFX/latest/api/Tizen.Applications.BadgeControl.html
    /// </summary>
    public static class BadgeControlService
    {
        private static string _appId = Application.Current.ApplicationInfo.ApplicationId;
        private static Badge _badge;

        /// <summary>
        /// Set the number of events or notifications to show on the badge.
        /// </summary>
        /// <param name="count">Number of events or notifications</param>
        public static void SetCount(uint count)
        {
            if (_badge == null)
            {
                try
                {
                    _badge = BadgeControl.Find(_appId);
                }
                catch (InvalidOperationException)
                {
                    // An exception is thrown when the app tries to access a badge before it is added.
                    _badge = new Badge(_appId, count: 0, visible: true);
                    BadgeControl.Add(_badge);
                }
            }

            _badge.Count = (int)count;
            BadgeControl.Update(_badge);
        }
    }
}
