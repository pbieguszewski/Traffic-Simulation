using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Traffic_Simulation
{

    public partial class Simulation : Window
    {
        private int numberOfCars;
        private List<Car> listCar = new List<Car>();
        private Light lights = new Light();
        private int speedCar = 200;
        private int stopCar_nextPoint = 150;
        private int stopCar_entryInRoad = 150;
        private int stopCar_ExitCheckPoint = 150;
        private int timeDriveByTunnel = 4000;
        private int timeDriveUnderViaductWest = 800;
        private int timeDriveUndeViaductInsideRondoNorth = 800;
        private int timeDriveUnderViaductInsideRondoEast = 800;
        private readonly object lock_object = new object();
        private int done = 0;

        public Simulation(int countCar)
        {
            InitializeComponent();
            this.numberOfCars = countCar;
            Thread end = new Thread(this.endSimulation);
            end.IsBackground = true;
            end.Start();
        }

        private void endSimulation()
        {
            while (true)
            {
                if (done == this.numberOfCars)
                {
                    MessageBox.Show("Simulation has been done!");
                    Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => this.Close()));
                }
                Thread.Sleep(2000);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Points.LoadTrace();
            this.createCar();
            this.lights.StartLight(this);
            this.startThread();
        }

        private void createCar()
        {
            Random rnd = new Random();
            int choise;
            for (int i = 0; i < this.numberOfCars; i++)
            {
                choise = rnd.Next(1, 5);
                if (1 == choise)
                {
                    this.listCar.Add(new Car(i, "Picture/mario.png"));
                    TrafficPlan.trafficList.Add(new CarInfo(i));
                }
                else if (2 == choise)
                {
                    this.listCar.Add(new Car(i, "Picture/pikachu.png"));
                    TrafficPlan.trafficList.Add(new CarInfo(i));
                }
                else if (3 == choise)
                {
                    this.listCar.Add(new Car(i, "Picture/star.png"));
                    TrafficPlan.trafficList.Add(new CarInfo(i));
                }
                else
                {
                    this.listCar.Add(new Car(i, "Picture/pic.png"));
                    TrafficPlan.trafficList.Add(new CarInfo(i));
                }
            }
        }

        private void startThread()
        {
            for (int i = 0; i < this.numberOfCars; i++)
            {
                Thread thread = new Thread(this.animate);
                thread.IsBackground = true;
                thread.Name = i.ToString();
                thread.Start(i);
            }
        }

        private void animate(object idCar)
        {
            Car car = this.listCar[(int)idCar];
            Random rnd = new Random();
            List<Point> list = null;
            int choiseTrace = 0;

            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => this.SomeWhere.Children.Add(car.picture)));
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => Canvas.SetTop(car.picture, -30)));
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => Canvas.SetLeft(car.picture, -30)));

            while (true)
            {
                switch (TrafficPlan.trafficList[car.id].iAmHere)
                {
                    case WhereIsNow.Aleje_East_Entry_Rondo:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_1_North_Entry_Rondo_2;
                        list = Points.Rondo_1_North_Entry_Rondo_2;

                        break;
                    case WhereIsNow.Aleje_East_Exit_1:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_East_Exit_2;
                        list = Points.Aleje_East_Exit_2;

                        break;
                    case WhereIsNow.Aleje_East_Exit_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Done;
                        list = null;

                        break;
                    case WhereIsNow.Aleje_East_Right_Bitwy:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_North_Exit_2;
                        list = Points.Bitwy_North_Exit_2;

                        break;
                    case WhereIsNow.Aleje_Entry_Left_Bitwy:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_North_Left_Exit;
                        list = Points.Bitwy_North_Left_Exit;
                        this.driveByViaduct(car, this.timeDriveByTunnel);

                        break;
                    case WhereIsNow.Aleje_West_Entry_1:

                        choiseTrace = rnd.Next(1, 3);

                        if (choiseTrace == 1)
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_West_Entry_2;
                            list = Points.Aleje_West_Entry_2;
                        }
                        else
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_West_Entry_Bitwy;
                            list = Points.Aleje_West_Entry_Bitwy;
                        }

                        break;
                    case WhereIsNow.Aleje_West_Entry_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_1_South_Entry_Rondo_2;
                        list = Points.Rondo_1_South_Entry_Rondo_2;

                        break;
                    case WhereIsNow.Aleje_West_Entry_Bitwy:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_South_Exit_2;
                        list = Points.Bitwy_South_Exit_2;

                        break;
                    case WhereIsNow.Aleje_West_Exit_1:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_West_Exit_2;
                        list = Points.Aleje_West_Exit_2;

                        break;
                    case WhereIsNow.Aleje_West_Exit_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Done;
                        list = null;

                        break;
                    case WhereIsNow.Bitwy_North_Entry_1:

                        choiseTrace = rnd.Next(1, 3);

                        if (choiseTrace == 1)
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_North_Right_Aleje;
                            list = Points.Bitwy_North_Right_Aleje;
                        }
                        else
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_North_Entry_2;
                            list = Points.Bitwy_North_Entry_2;
                        }

                        break;
                    case WhereIsNow.Bitwy_North_Entry_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_1_West_Entry_Rondo_2;
                        list = Points.Rondo_1_West_Entry_Rondo_2;

                        break;
                    case WhereIsNow.Bitwy_North_Entry_Left_Rondo:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_1_Inside_Left_Entry_Rondo_2;
                        list = Points.Rondo_1_Inside_Left_Entry_Rondo_2;

                        break;
                    case WhereIsNow.Bitwy_North_Exit_1:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_North_Exit_2;
                        list = Points.Bitwy_North_Exit_2;

                        break;
                    case WhereIsNow.Bitwy_North_Exit_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Done;
                        list = null;

                        break;
                    case WhereIsNow.Bitwy_North_Left_Exit:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Done;
                        list = null;

                        break;
                    case WhereIsNow.Bitwy_North_Right_Aleje:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_West_Exit_2;
                        list = Points.Aleje_West_Exit_2;

                        break;
                    case WhereIsNow.Bitwy_South_Entry_1:

                        choiseTrace = rnd.Next(1, 3);

                        if (choiseTrace == 1)
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_South_Right_Aleje;
                            list = Points.Bitwy_South_Right_Aleje;
                        }
                        else
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_South_Entry_2;
                            list = Points.Bitwy_South_Entry_2;
                        }

                        break;
                    case WhereIsNow.Bitwy_South_Entry_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_1_East_Entry_Rondo_2;
                        list = Points.Rondo_1_East_Entry_Rondo_2;


                        break;
                    case WhereIsNow.Bitwy_South_Exit_1:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_South_Exit_2;
                        list = Points.Bitwy_South_Exit_2;

                        break;
                    case WhereIsNow.Bitwy_South_Exit_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Done;
                        list = null;

                        break;
                    case WhereIsNow.Bitwy_South_Right_Aleje:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_East_Exit_2;
                        list = Points.Aleje_East_Exit_2;

                        break;
                    case WhereIsNow.Rondo_1_East_Entry_Rondo_2:

                        choiseTrace = rnd.Next(1, 3);

                        if (1 == choiseTrace)
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_East_Exit;
                            list = Points.Rondo_2_East_Exit;
                        }
                        else
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_East_Inside;
                            list = Points.Rondo_East_Inside;
                        }

                        this.driveByViaduct(car, this.timeDriveUnderViaductInsideRondoEast);

                        break;
                    case WhereIsNow.Rondo_1_Inside_Left_Entry_Rondo_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_Inside_Left_Entry_Rondo_3;
                        list = Points.Rondo_2_Inside_Left_Entry_Rondo_3;
                        this.driveByViaduct(car, this.timeDriveUndeViaductInsideRondoNorth);

                        break;
                    case WhereIsNow.Rondo_1_North_Entry_Rondo_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_North_Entry_Rondo_3;
                        list = Points.Rondo_2_North_Entry_Rondo_3;

                        break;
                    case WhereIsNow.Rondo_1_South_Entry_Rondo_2:

                        choiseTrace = rnd.Next(1, 3);

                        if (1 == choiseTrace)
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_South_Exit;
                            list = Points.Rondo_2_South_Exit;
                        }
                        else
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_1_South_Inside_Rondo_2_Inside;
                            list = Points.Rondo_1_South_Inside_Rondo_2_Inside;
                        }

                        break;
                    case WhereIsNow.Rondo_1_South_Inside_Rondo_2_Inside:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_South_Inside_Exit;
                        list = Points.Rondo_2_South_Inside_Exit;

                        break;
                    case WhereIsNow.Rondo_1_West_Entry_Rondo_2:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_West_Exit;
                        list = Points.Rondo_2_West_Exit;
                        this.driveByViaduct(car, this.timeDriveUnderViaductWest);

                        break;
                    case WhereIsNow.Rondo_2_East_Exit:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_North_Exit_1;
                        list = Points.Bitwy_North_Exit_1;

                        break;
                    case WhereIsNow.Rondo_2_Inside_Left_Entry_Rondo_3:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_3_Inside_Left_exit;
                        list = Points.Rondo_3_Inside_Left_exit;

                        break;
                    case WhereIsNow.Rondo_2_North_Entry_Rondo_3:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_3_North_Exit;
                        list = Points.Rondo_3_North_Exit;

                        break;
                    case WhereIsNow.Rondo_2_South_Exit:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_East_Exit_1;
                        list = Points.Aleje_East_Exit_1;

                        break;
                    case WhereIsNow.Rondo_2_South_Inside_Exit:

                        choiseTrace = rnd.Next(1, 3);

                        if (choiseTrace == 1)
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_East_Exit;
                            list = Points.Rondo_2_East_Exit;
                        }
                        else
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_East_Inside;
                            list = Points.Rondo_East_Inside;
                        }

                        this.driveByViaduct(car, this.timeDriveUnderViaductInsideRondoEast);

                        break;
                    case WhereIsNow.Rondo_2_West_Exit:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Bitwy_South_Exit_1;
                        list = Points.Bitwy_South_Exit_1;

                        break;
                    case WhereIsNow.Rondo_3_Inside_Left_exit:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_East_Exit_1;
                        list = Points.Aleje_East_Exit_1;

                        break;
                    case WhereIsNow.Rondo_3_North_Exit:

                        choiseTrace = rnd.Next(1, 3);

                        if (choiseTrace == 1)
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Aleje_West_Exit_1;
                            list = Points.Aleje_West_Exit_1;
                        }
                        else
                        {
                            TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_1_West_Entry_Rondo_2;
                            list = Points.Rondo_1_West_Entry_Rondo_2;
                        }

                        break;
                    case WhereIsNow.Rondo_East_Inside:

                        TrafficPlan.trafficList[car.id].iAmHere = WhereIsNow.Rondo_2_North_Entry_Rondo_3;
                        list = Points.Rondo_2_North_Entry_Rondo_3;

                        break;
                    case WhereIsNow.Beginning:

                        lock (lock_object)
                        {
                            list = this.choiseStartTrace(car.id);
                            this.canEntryToScene(car);
                        }

                        break;
                    case WhereIsNow.Done:

                        Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => this.SomeWhere.Children.Remove(car.picture)));
                        this.done++;

                        return;
                    default:
                        throw new Exception("xD");
                }

                if (TrafficPlan.trafficList[car.id].iAmHere != WhereIsNow.Done)
                {
                    this.moveCar(car, list);
                    this.canExitCheckpoint(car);
                }
            }

        }

        private List<Point> choiseStartTrace(int idCar)
        {
            Random rnd = new Random();
            int choise = rnd.Next(1, 8);

            if (1 == choise)
            {
                TrafficPlan.trafficList[idCar].iAmHere = WhereIsNow.Bitwy_South_Entry_1;
                return Points.Bitwy_South_Entry_1;
            }
            else if (2 == choise)
            {
                TrafficPlan.trafficList[idCar].iAmHere = WhereIsNow.Bitwy_North_Entry_Left_Rondo;
                return Points.Bitwy_North_Entry_Left_Rondo;
            }
            else if (3 == choise)
            {
                TrafficPlan.trafficList[idCar].iAmHere = WhereIsNow.Bitwy_North_Entry_1;
                return Points.Bitwy_North_Entry_1;
            }
            else if (4 == choise)
            {
                TrafficPlan.trafficList[idCar].iAmHere = WhereIsNow.Aleje_West_Entry_1;
                return Points.Aleje_West_Entry_1;
            }
            else if (5 == choise)
            {
                TrafficPlan.trafficList[idCar].iAmHere = WhereIsNow.Aleje_Entry_Left_Bitwy;
                return Points.Aleje_Entry_Left_Bitwy;
            }
            else if (6 == choise)
            {
                TrafficPlan.trafficList[idCar].iAmHere = WhereIsNow.Aleje_East_Entry_Rondo;
                return Points.Aleje_East_Entry_Rondo;
            }
            else
            {
                TrafficPlan.trafficList[idCar].iAmHere = WhereIsNow.Aleje_East_Right_Bitwy;
                return Points.Aleje_East_Right_Bitwy;
            }
        }

        private void canEntryToScene(Car car)
        {
            while (!TrafficPlan.CanEntryInRoad(car.id, TrafficPlan.trafficList[car.id].iAmHere))
            {
                Thread.Sleep(this.stopCar_entryInRoad);
            }
        }

        private void moveCar(Car car, List<Point> list)
        {
            int countMove = 0;
            foreach (var item in list)
            {
                while (!TrafficPlan.CanMoveCar(car.id, TrafficPlan.trafficList[car.id].iAmHere))
                {
                    Thread.Sleep(this.stopCar_nextPoint);
                }
                Thread.Sleep(this.speedCar);
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => Canvas.SetTop(car.picture, item.x)));
                Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => Canvas.SetLeft(car.picture, item.y)));
                countMove++;
                TrafficPlan.trafficList[car.id].countMove = countMove;
            }
        }

        private void canExitCheckpoint(Car car)
        {
            while (!TrafficPlan.CanEntryInTheCheckPoint(car.id, this))
            {
                Thread.Sleep(this.stopCar_ExitCheckPoint);
            }
        }

        private void driveByViaduct(Car car, int how_long)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => Canvas.SetTop(car.picture, -30)));
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => Canvas.SetLeft(car.picture, -30)));
            Thread.Sleep(how_long);
        }

    }

}
