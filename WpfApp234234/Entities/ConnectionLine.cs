using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp234234.Entities
{ 
    public class ConnectionLine
    {
        public Connection ConnectionInfo = User.UserConnections.LastOrDefault();
        public ClassBox Class1;
        public ClassBox Class2;

        private Canvas canvas;

        public ConnectionLine(Canvas canvas) 
        {
            var class1 = ConnectionInfo.Class1;
            var class2 = ConnectionInfo.Class2;
            Class1 = User.UserClassBoxes.Where(p => p.ClassInfo.Name == class1.Name).FirstOrDefault();
            Class2 = User.UserClassBoxes.Where(p => p.ClassInfo.Name == class2.Name).FirstOrDefault();

            this.canvas = canvas;
            Draw();
        }
 
        private void Draw()
        {

            var line = new Line
            {
                X1 = Class1.X,
                Y1 = Class1.Y + Class1.Height / 2,
                X2 = Class2.X,
                Y2 = Class2.Y + Class2.Height / 2,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                StrokeEndLineCap = PenLineCap.Triangle
            };

            canvas.Children.Add(line);
        }
    }
}
