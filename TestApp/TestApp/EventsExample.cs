using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace TestApp
{
    public class EventsExample
    {
        static int score = 0;

        public static void Test()
        {
            Shooter shooter = new Shooter();

            shooter.ShotsFired += KilledEnemy;
            shooter.ShotsFired += AddScore;

            shooter.OnShoot();
        }

        public static void KilledEnemy(object sender, ShotsFiredEventArgs e)
        {
            var tempSender = sender as Shooter;

            Console.WriteLine($"{tempSender.Name} killed an enemy!");
            Console.WriteLine($"{tempSender.Name} score is now {score}");
            Console.WriteLine($"Time of kill is: {e.TimeOfKill}");
        }

        public static void AddScore(object sender, EventArgs e)
        {
            score += 1;
        }
    }
}
