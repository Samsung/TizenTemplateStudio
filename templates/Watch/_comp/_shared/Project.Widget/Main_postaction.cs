//{[{
using Tizen.Applications;
using Tizen.Wearable.CircularUI.Forms;
using Tizen.Wearable.CircularUI.Forms.Renderer.Widget;
//}]}

namespace Param_RootNamespace
{
//{[{
    class TizenWidget : FormsWidgetBase
    {
        public override void OnCreate(Bundle content, int w, int h)
        {
            base.OnCreate(content, w, h);
            LoadApplication(new App());
        }
    }

    class TizenWidgetApplication : FormsWidgetApplication
    {
        public TizenWidgetApplication(Type type) : base(type)
        {
        }

        static void Main(string[] args)
        {
            using (var tizenWidgetApplication = new TizenWidgetApplication(typeof(TizenWidget)))
            {
                Forms.Init(tizenWidgetApplication);
                FormsCircularUI.Init();
                tizenWidgetApplication.Run(args);
            }
        }
    }
//}]}
}
