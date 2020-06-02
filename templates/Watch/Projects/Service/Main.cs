using System;
using System.Resources;
using Tizen.Applications;

// TODO: Define the default culture of your app.
// This improves lookup performance for the first resource to load.
// For more details, see https://docs.microsoft.com/dotnet/api/system.resources.neutralresourceslanguageattribute.
[assembly: NeutralResourcesLanguage("en-US")]

namespace Param_RootNamespace
{
    class TizenServiceApplication : ServiceApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
        }

        static void Main(string[] args)
        {
            using (var app = new TizenServiceApplication())
            {
                app.Run(args);
            }
        }
    }
}
