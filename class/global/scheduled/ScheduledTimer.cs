using System.Timers;

namespace Elanat
{
    public static class ScheduledTimer
    {
        public static System.Timers.Timer StaticScheduledTimer = new System.Timers.Timer(10000);
        public static bool IsLoaded = false;

        public static void Main()
        {
            if (IsLoaded)
                return;

            IsLoaded = true;

            StaticScheduledTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            StaticScheduledTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            ScheduledTasks st = new ScheduledTasks();
            st.Start("timer");
        }
    }
}