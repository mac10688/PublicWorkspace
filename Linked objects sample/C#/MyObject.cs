using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LinkedObjectSample
{
    public class MyObject
    {
        private MyObject parent;
        private int id;
        private static int idCounter = 0;
        private static Random random = new Random();
        private static Canvas space;
        private double heading;
        private Point point;
        private double speed = 0.18;
        private Action go;
        private Shape s = new Ellipse() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Red) };
        private MyObject nearest=null;
        private Line line = new Line() { Stroke = new SolidColorBrush(Colors.Purple), StrokeThickness = 1 };

        public MyObject(Canvas space, double x, double y, MyObject parent)
        {
            this.parent = parent;
            MyObject.space = space;
            this.heading = random.Next(0, 360);
            this.id = idCounter++;
            point = new Point(x, y);
            s.SetValue(Canvas.LeftProperty, this.point.X);
            s.SetValue(Canvas.TopProperty, this.point.Y);
            MyObject.space.Children.Add(s);
            MyObject.space.Children.Add(line);
            go = new Action(Go);
            Move();
        }

        private void Move()
        {
            space.Dispatcher.InvokeAsync(go, DispatcherPriority.Background);
        }

        private void Go()
        {
            double angle = heading * (Math.PI / 180);
            point.X = point.X + Math.Cos(angle) * speed;
            point.Y = point.Y - Math.Sin(angle) * speed;
            Bounce();
            nearest = GetNearest();
            if (nearest != null)
            {
                line.X1 = this.point.X+5;
                line.Y1 = this.point.Y+5;
                line.X2 = nearest.point.X+5;
                line.Y2 = nearest.point.Y+5;
            }
            s.SetValue(Canvas.LeftProperty, this.point.X);
            s.SetValue(Canvas.TopProperty, this.point.Y);
            Move();
        }

        private void Bounce()
        {
            #region Bounce

            if (point.X < 0)
            {
                if (heading > 90 & heading <= 180)
                {
                    heading = 90 - (heading - 90);
                }
                else
                {
                    heading = 360 - (heading - 180);
                }
            }
            else if (point.X > space.ActualWidth - 10)
            {
                if (heading >= 0 & heading < 90)
                {
                    heading = 180 - heading;
                }
                else
                {
                    heading = 180 + (360 - heading);
                }
            }

            if (point.Y < 0)
            {
                if (heading > 0 & heading <= 90)
                {
                    heading = 270 + (90 - heading);
                }
                else
                {
                    heading = 180 + (180 - heading);
                }
            }
            else if (point.Y > space.ActualHeight - 10)
            {
                if (heading >= 180 & heading < 270)
                {
                    heading = 180 - (heading - 180);
                }
                else
                {
                    heading = 360 - heading;
                }
            }

            #endregion
        }
        
        private double Square(double value) { return value * value; }

        private double DistanceTo(MyObject other)
        {
            return Math.Sqrt(Square(this.point.X - other.point.X) + Square(this.point.Y - other.point.Y));
        }

        private MyObject GetNearest()
        {
            MyObject other = MainWindow.top;
            MyObject rv = null;
            double d = int.MaxValue;
            double n = d;

            while (other != null)
            {
                if (other.id != this.id)
                {
                    d = DistanceTo(other);
                    if (d < n)
                    {
                        n = d;
                        rv = other;
                    }
                }
                other = other.parent;
            }
            return rv;
        }

    }
}
