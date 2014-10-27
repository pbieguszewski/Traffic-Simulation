using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Traffic_Simulation
{

    static class TrafficPlan
    {
        private delegate bool check_del(int idCar, Simulation sim);
        public static List<CarInfo> trafficList = new List<CarInfo>();
        public static readonly Brush red = (Brush)new BrushConverter().ConvertFrom("Red");
        public static readonly Brush green = (Brush)new BrushConverter().ConvertFrom("Green");

        public static bool CanEntryInRoad(int idCar, WhereIsNow where)
        {
            foreach (var item in trafficList)
            {
                if (item.countMove == 0 && where == item.iAmHere)
                {
                    return false;
                }
            }
            trafficList[idCar].countMove = 0;
            return true;
        }

        public static bool CanEntryInTheCheckPoint(int idCar, Simulation sim)
        {
            return (bool)sim.Dispatcher.Invoke(new check_del(checkLight), idCar, sim);
        }

        public static bool CanMoveCar(int idCar, WhereIsNow where)
        {
            foreach (var item in trafficList)
            {
                if (item.iAmHere == where && trafficList[idCar].countMove == item.countMove - 1)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool checkLight(int idCar, Simulation sim)
        {
            switch (trafficList[idCar].iAmHere)
            {
                case WhereIsNow.Aleje_East_Entry_Rondo:

                    if (sim.light9.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Aleje_East_Exit_1:

                    if (sim.light1.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Aleje_East_Right_Bitwy:

                    if (sim.light8.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Aleje_West_Entry_2:

                    if (sim.light7.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Aleje_West_Entry_Bitwy:

                    if (sim.light6.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Aleje_West_Exit_1:

                    if (sim.light24.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Bitwy_North_Entry_2:

                    if (sim.light18.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Bitwy_North_Entry_Left_Rondo:

                    if (sim.light12.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Bitwy_North_Exit_1:

                    if (sim.light23.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Bitwy_North_Right_Aleje:

                    if (sim.light13.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Bitwy_South_Entry_2:

                    if (sim.light4.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Bitwy_South_Exit_1:

                    if (sim.light25.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Bitwy_South_Right_Aleje:

                    if (sim.light2.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_1_East_Entry_Rondo_2:

                    if (sim.light22.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_1_North_Entry_Rondo_2:

                    if (sim.light19.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_1_South_Inside_Rondo_2_Inside:

                    if (sim.light15.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_2_East_Exit:

                    if (sim.light10.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_2_Inside_Left_Entry_Rondo_3:

                    if (sim.light16.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_2_North_Entry_Rondo_3:

                    if (sim.light20.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_2_South_Exit:

                    if (sim.light4.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_2_South_Inside_Exit:

                    if (sim.light21.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_2_West_Exit:

                    if (sim.light5.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_3_Inside_Left_exit:

                    if (sim.light17.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_3_North_Exit:

                    if (sim.light11.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                case WhereIsNow.Rondo_East_Inside:

                    if (sim.light14.Fill == TrafficPlan.green)
                        return true;
                    else
                        return false;

                default:
                    return true;
            }
        }

    }

}
