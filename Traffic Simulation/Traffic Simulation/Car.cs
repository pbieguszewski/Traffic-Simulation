using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Traffic_Simulation
{

    class Car
    {
        public int id { get; private set; }
        public Image picture { get; private set; }

        public Car(int id, string path)
        {
            this.id = id;
            this.picture = new Image();
            picture.Width = 20;
            picture.Height = 20;
            picture.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

    }

}
