//{[{
using Tizen.Applications;
using Tizen.Wearable.CircularUI.Forms;
using Tizen.Wearable.CircularUI.Forms.Renderer.Watchface;
//}]}

namespace Param_RootNamespace
{
//{[{
    class TizenWatchFace : FormsWatchface
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadWatchface(new App());
        }

        // Called at least once per second.
        // The TimeTick event can also be used for the same effect.
        protected override void OnTick(TimeEventArgs time)
        {
            base.OnTick(time);
        }

        static void Main(string[] args)
        {
            using (var tizenWatchFace = new TizenWatchFace())
            {
                Forms.Init(tizenWatchFace);
                FormsCircularUI.Init();
                tizenWatchFace.Run(args);
            }
        }
    }
//}]}
}
