using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class ShotsFiredEventArgs : EventArgs
    {
        public DateTime TimeOfKill { get; set; }

        public ShotsFiredEventArgs()
        {
            TimeOfKill = DateTime.Now;
        }

        public ShotsFiredEventArgs(DateTime time)
        {
            this.TimeOfKill = time;
        }
    }
}
