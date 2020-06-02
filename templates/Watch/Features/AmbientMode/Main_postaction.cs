    class TizenWatchFace : FormsWatchface
    {
//^^
//{[{
        // Called when ambient mode state is changed.
        // The AmbientChanged event can also be used for the same effect.
        protected override void OnAmbientChanged(AmbientEventArgs mode)
        {
            base.OnAmbientChanged(mode);
        }

        // Called every tick when ambient mode is enabled.
        // You can get the duration of each tick by GetAmbientTickType().
        // The AmbientTick event can also be used for the same effect.
        protected override void OnAmbientTick(TimeEventArgs time)
        {
            base.OnAmbientTick(time);
        }
//}]}

        static void Main(string[] args)
