using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebBasicsExercise.Interfaces;

namespace WebBasicsExercise.Models
{

    public class Chronometer : IChronometer
    {
        
        private long milliseconds;
        private bool isRunning;

        public Chronometer()
        {
            this.Reset();
        }

        public string GetTime => $"{milliseconds / 60000:D2}:{(milliseconds % 60000) / 1000:D2}:{(milliseconds % 60000 % 1000):D4}";
        public List<string> Laps { get; private set; }

        public string Lap()
        {
            var lap = this.GetTime;
            Laps.Add(lap);
            return lap;
        }
        public void Reset()
        {
            this.Stop();
            this.milliseconds = 0;
            this.Laps = new List<string>();
        }

        public void Start()
        {
            this.isRunning = true;

            Task.Run(() =>
            {
                while (isRunning)
                {
                    Thread.Sleep(1);
                    this.milliseconds += 2;
                }
            });
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}

