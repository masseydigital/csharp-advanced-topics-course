using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestApp
{
    public class Shooter
    {
        private Random rng = new Random();

        public delegate void ShootingHandler(object sender, ShotsFiredEventArgs e);

        //public event ShootingHandler ShotsFired;
        public event EventHandler<ShotsFiredEventArgs> ShotsFired;

        public string Name { get; set; } = "Billy";

        public void OnShoot()
        {
            while (true)
            {
                if (rng.Next(0, 100) % 2 == 0)
                {
                    ShotsFired?.Invoke(this, new ShotsFiredEventArgs());
                }
                else
                {
                    Console.WriteLine("Missed!");
                }

                Thread.Sleep(500);
            }
        }
    }
}
