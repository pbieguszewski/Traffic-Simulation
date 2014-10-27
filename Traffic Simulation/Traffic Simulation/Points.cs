using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Simulation
{

    class Point
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }

    static class Points
    {
        public static List<Point> Aleje_East_Entry_Rondo { get; private set; }
        public static List<Point> Aleje_East_Exit_1 { get; private set; }
        public static List<Point> Aleje_East_Exit_2 { get; private set; }
        public static List<Point> Aleje_East_Right_Bitwy { get; private set; }
        public static List<Point> Aleje_Entry_Left_Bitwy { get; private set; }
        public static List<Point> Aleje_West_Entry_1 { get; private set; }
        public static List<Point> Aleje_West_Entry_2 { get; private set; }
        public static List<Point> Aleje_West_Entry_Bitwy { get; private set; }
        public static List<Point> Aleje_West_Exit_1 { get; private set; }
        public static List<Point> Aleje_West_Exit_2 { get; private set; }
        public static List<Point> Bitwy_North_Entry_1 { get; private set; }
        public static List<Point> Bitwy_North_Entry_2 { get; private set; }
        public static List<Point> Bitwy_North_Entry_Left_Rondo { get; private set; }
        public static List<Point> Bitwy_North_Exit_1 { get; private set; }
        public static List<Point> Bitwy_North_Exit_2 { get; private set; }
        public static List<Point> Bitwy_North_Left_Exit { get; private set; }
        public static List<Point> Bitwy_North_Right_Aleje { get; private set; }
        public static List<Point> Bitwy_South_Entry_1 { get; private set; }
        public static List<Point> Bitwy_South_Entry_2 { get; private set; }
        public static List<Point> Bitwy_South_Exit_1 { get; private set; }
        public static List<Point> Bitwy_South_Exit_2 { get; private set; }
        public static List<Point> Bitwy_South_Right_Aleje { get; private set; }
        public static List<Point> Rondo_1_East_Entry_Rondo_2 { get; private set; }
        public static List<Point> Rondo_1_Inside_Left_Entry_Rondo_2 { get; private set; }
        public static List<Point> Rondo_1_North_Entry_Rondo_2 { get; private set; }
        public static List<Point> Rondo_1_South_Entry_Rondo_2 { get; private set; }
        public static List<Point> Rondo_1_South_Inside_Rondo_2_Inside { get; private set; }
        public static List<Point> Rondo_1_West_Entry_Rondo_2 { get; private set; }
        public static List<Point> Rondo_2_East_Exit { get; private set; }
        public static List<Point> Rondo_2_Inside_Left_Entry_Rondo_3 { get; private set; }
        public static List<Point> Rondo_2_North_Entry_Rondo_3 { get; private set; }
        public static List<Point> Rondo_2_South_Exit { get; private set; }
        public static List<Point> Rondo_2_South_Inside_Exit { get; private set; }
        public static List<Point> Rondo_2_West_Exit { get; private set; }
        public static List<Point> Rondo_3_Inside_Left_exit { get; private set; }
        public static List<Point> Rondo_3_North_Exit { get; private set; }
        public static List<Point> Rondo_East_Inside { get; private set; }

        public static void LoadTrace()//repaid
        {
            initListOfTrace();
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_East_Entry_Rondo, Aleje_East_Entry_Rondo);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_East_Exit_1, Aleje_East_Exit_1);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_East_Exit_2, Aleje_East_Exit_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_East_Right_Bitwy, Aleje_East_Right_Bitwy);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_Entry_Left_Bitwy, Aleje_Entry_Left_Bitwy);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_West_Entry_1, Aleje_West_Entry_1);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_West_Entry_2, Aleje_West_Entry_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_West_Entry_Bitwy, Aleje_West_Entry_Bitwy);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_West_Exit_1, Aleje_West_Exit_1);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Aleje_West_Exit_2, Aleje_West_Exit_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_North_Entry_1, Bitwy_North_Entry_1);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_North_Entry_2, Bitwy_North_Entry_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_North_Entry_Left_Rondo, Bitwy_North_Entry_Left_Rondo);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_North_Exit_1, Bitwy_North_Exit_1);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_North_Exit_2, Bitwy_North_Exit_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_North_Left_Exit, Bitwy_North_Left_Exit);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_North_Right_Aleje, Bitwy_North_Right_Aleje);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_South_Entry_1, Bitwy_South_Entry_1);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_South_Entry_2, Bitwy_South_Entry_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_South_Exit_1, Bitwy_South_Exit_1);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_South_Exit_2, Bitwy_South_Exit_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Bitwy_South_Right_Aleje, Bitwy_South_Right_Aleje);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_1_East_Entry_Rondo_2, Rondo_1_East_Entry_Rondo_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_1_Inside_Left_Entry_Rondo_2, Rondo_1_Inside_Left_Entry_Rondo_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_1_North_Entry_Rondo_2, Rondo_1_North_Entry_Rondo_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_1_South_Entry_Rondo_2, Rondo_1_South_Entry_Rondo_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_1_South_Inside_Rondo_2_Inside, Rondo_1_South_Inside_Rondo_2_Inside);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_1_West_Entry_Rondo_2, Rondo_1_West_Entry_Rondo_2);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_2_East_Exit, Rondo_2_East_Exit);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_2_Inside_Left_Entry_Rondo_3, Rondo_2_Inside_Left_Entry_Rondo_3);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_2_North_Entry_Rondo_3, Rondo_2_North_Entry_Rondo_3);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_2_South_Exit, Rondo_2_South_Exit);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_2_South_Inside_Exit, Rondo_2_South_Inside_Exit);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_2_West_Exit, Rondo_2_West_Exit);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_3_Inside_Left_exit, Rondo_3_Inside_Left_exit);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_3_North_Exit, Rondo_3_North_Exit);
            loadOneTrace(Traffic_Simulation.Properties.Resources.Rondo_East_Inside, Rondo_East_Inside);

        }

        private static void initListOfTrace()
        {
            Aleje_East_Entry_Rondo = new List<Point>();
            Aleje_East_Exit_1 = new List<Point>();
            Aleje_East_Exit_2 = new List<Point>();
            Aleje_East_Right_Bitwy = new List<Point>();
            Aleje_Entry_Left_Bitwy = new List<Point>();
            Aleje_West_Entry_1 = new List<Point>();
            Aleje_West_Entry_2 = new List<Point>();
            Aleje_West_Entry_Bitwy = new List<Point>();
            Aleje_West_Exit_1 = new List<Point>();
            Aleje_West_Exit_2 = new List<Point>();
            Bitwy_North_Entry_1 = new List<Point>();
            Bitwy_North_Entry_2 = new List<Point>();
            Bitwy_North_Entry_Left_Rondo = new List<Point>();
            Bitwy_North_Exit_1 = new List<Point>();
            Bitwy_North_Exit_2 = new List<Point>();
            Bitwy_North_Left_Exit = new List<Point>();
            Bitwy_North_Right_Aleje = new List<Point>();
            Bitwy_South_Entry_1 = new List<Point>();
            Bitwy_South_Entry_2 = new List<Point>();
            Bitwy_South_Exit_1 = new List<Point>();
            Bitwy_South_Exit_2 = new List<Point>();
            Bitwy_South_Right_Aleje = new List<Point>();
            Rondo_1_East_Entry_Rondo_2 = new List<Point>();
            Rondo_1_Inside_Left_Entry_Rondo_2 = new List<Point>();
            Rondo_1_North_Entry_Rondo_2 = new List<Point>();
            Rondo_1_South_Entry_Rondo_2 = new List<Point>();
            Rondo_1_South_Inside_Rondo_2_Inside = new List<Point>();
            Rondo_1_West_Entry_Rondo_2 = new List<Point>();
            Rondo_2_East_Exit = new List<Point>();
            Rondo_2_Inside_Left_Entry_Rondo_3 = new List<Point>();
            Rondo_2_North_Entry_Rondo_3 = new List<Point>();
            Rondo_2_South_Exit = new List<Point>();
            Rondo_2_South_Inside_Exit = new List<Point>();
            Rondo_2_West_Exit = new List<Point>();
            Rondo_3_Inside_Left_exit = new List<Point>();
            Rondo_3_North_Exit = new List<Point>();
            Rondo_East_Inside = new List<Point>();
        }

        private static void loadOneTrace(string path, List<Point> list)
        {
            string tmp;
            try
            {
                using (StringReader read = new StringReader(path))
                {
                    while ((tmp = read.ReadLine()) != null)
                    {
                        list.Add(new Point(int.Parse(tmp.Split(';')[0]), int.Parse(tmp.Split(';')[1])));
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                throw e;
            }
        }

    }

}
