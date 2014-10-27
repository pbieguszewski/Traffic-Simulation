using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Traffic_Simulation
{
    class Light
    {
        private Simulation sim = null;

        public void StartLight(Simulation sim)
        {
            this.sim = sim;
            System.Timers.Timer changeLight = new System.Timers.Timer();
            changeLight.Elapsed += new ElapsedEventHandler(SetLight);
            changeLight.Interval = 2000;
            changeLight.Enabled = true;
        }

        private void SetLight(object o, ElapsedEventArgs e)
        {
            sim.Dispatcher.BeginInvoke(new Action(changeLight), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void changeLight()
        {
            if (TrafficPlan.green == sim.light1.Fill)
            {
                sim.light1.Fill = TrafficPlan.red;
                sim.light2.Fill = TrafficPlan.green;
                sim.light3.Fill = TrafficPlan.green;
                sim.light4.Fill = TrafficPlan.red;
                sim.light5.Fill = TrafficPlan.green;
                sim.light6.Fill = TrafficPlan.red;
                sim.light7.Fill = TrafficPlan.red;
                sim.light8.Fill = TrafficPlan.red;
                sim.light9.Fill = TrafficPlan.red;
                sim.light10.Fill = TrafficPlan.green;
                sim.light11.Fill = TrafficPlan.red;
                sim.light12.Fill = TrafficPlan.green;
                sim.light13.Fill = TrafficPlan.green;
                sim.light14.Fill = TrafficPlan.green;
                sim.light15.Fill = TrafficPlan.red;
                sim.light16.Fill = TrafficPlan.green;
                sim.light17.Fill = TrafficPlan.green;
                sim.light18.Fill = TrafficPlan.green;
                sim.light19.Fill = TrafficPlan.red;
                sim.light20.Fill = TrafficPlan.red;
                sim.light21.Fill = TrafficPlan.red;
                sim.light22.Fill = TrafficPlan.green;
                sim.light23.Fill = TrafficPlan.green;
                sim.light24.Fill = TrafficPlan.red;
                sim.light25.Fill = TrafficPlan.green;
            }
            else
            {
                sim.light1.Fill = TrafficPlan.green;
                sim.light2.Fill = TrafficPlan.red;
                sim.light3.Fill = TrafficPlan.red;
                sim.light4.Fill = TrafficPlan.green;
                sim.light5.Fill = TrafficPlan.red;
                sim.light6.Fill = TrafficPlan.green;
                sim.light7.Fill = TrafficPlan.green;
                sim.light8.Fill = TrafficPlan.green;
                sim.light9.Fill = TrafficPlan.green;
                sim.light10.Fill = TrafficPlan.red;
                sim.light11.Fill = TrafficPlan.green;
                sim.light12.Fill = TrafficPlan.red;
                sim.light13.Fill = TrafficPlan.red;
                sim.light14.Fill = TrafficPlan.red;
                sim.light15.Fill = TrafficPlan.green;
                sim.light16.Fill = TrafficPlan.red;
                sim.light17.Fill = TrafficPlan.red;
                sim.light18.Fill = TrafficPlan.red;
                sim.light19.Fill = TrafficPlan.green;
                sim.light20.Fill = TrafficPlan.green;
                sim.light21.Fill = TrafficPlan.green;
                sim.light22.Fill = TrafficPlan.red;
                sim.light23.Fill = TrafficPlan.red;
                sim.light24.Fill = TrafficPlan.green;
                sim.light25.Fill = TrafficPlan.red;
            }
        }
    }

}
