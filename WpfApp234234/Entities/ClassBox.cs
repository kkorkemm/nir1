using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp234234.Entities
{
    public class ClassBox
    {
        public NewClass ClassInfo = User.UserClasses.LastOrDefault();

        public double X { get; private set; }
        public double Y { get; private set; }
        public int Width = 250;
        public int Height = 200;

        private Canvas canvas;
        private Rectangle rect;
        private List<UIElement> elements = new List<UIElement>();
        private bool isDragging = false;
        private Point dragStartPoint;

        public ClassBox(Canvas canvas)
        {
            this.canvas = canvas;
            X = new Random().Next(50, (int)canvas.ActualWidth - Width);
            Y = new Random().Next(50, (int)canvas.ActualHeight - Height);

            Draw();
        }

        private void Draw()
        {
            rect = new Rectangle
            {
                Width = Width,
                Height = Height,
                Fill = Brushes.White
            };

            Canvas.SetLeft(rect, X);
            Canvas.SetTop(rect, Y);
            canvas.Children.Add(rect);
            elements.Add(rect);

            rect.MouseLeftButtonDown += Rect_MouseLeftButtonDown;
            rect.MouseMove += Rect_MouseMove;
            rect.MouseLeftButtonUp += Rect_MouseLeftButtonUp;

            var className = new TextBlock
            {
                Text = ClassInfo.Name,
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                Width = rect.Width,
                Height = 50
            };

            Canvas.SetLeft(className, X);
            Canvas.SetTop(className, Y);
            canvas.Children.Add(className);
            elements.Add(className);

            //var line = new Line
            //{
            //    X1 = X,
            //    Y1 = Y + Height / 2,
            //    X2 = X + Width,
            //    Y2 = Y + Height / 2,
            //    Stroke = Brushes.Black,
            //    StrokeThickness = 1
            //};

            //canvas.Children.Add(line);
            //elements.Add(line);

            var attributes = new List<string> { "attribute1", "attribute2", "attribute3" };
            var methods = new List<string> { "method1()", "method2()", "method3()" };

            for (int i = 0; i < attributes.Count; i++)
            {
                var textBlock = new TextBlock
                {
                    Text = attributes[i],
                    Foreground = Brushes.Black
                };
                Canvas.SetLeft(textBlock, X + 10);
                Canvas.SetTop(textBlock, Y + 10 + i * 20);
                canvas.Children.Add(textBlock);
                elements.Add(textBlock);
            }

            for (int i = 0; i < methods.Count; i++)
            {
                var textBlock = new TextBlock
                {
                    Text = methods[i],
                    Foreground = Brushes.Black
                };
                Canvas.SetLeft(textBlock, X + 10);
                Canvas.SetTop(textBlock, Y + Height / 2 + 10 + i * 20);
                canvas.Children.Add(textBlock);
                elements.Add(textBlock);
            }
        }

        private void Rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            dragStartPoint = e.GetPosition(canvas);
            rect.CaptureMouse();
        }

        private void Rect_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPoint = e.GetPosition(canvas);
                double offsetX = currentPoint.X - dragStartPoint.X;
                double offsetY = currentPoint.Y - dragStartPoint.Y;

                double newX = X + offsetX;
                double newY = Y + offsetY;

                // Проверка на выход за пределы Canvas
                if (newX < 0) newX = 0;
                if (newY < 0) newY = 0;
                if (newX + Width > canvas.ActualWidth) newX = canvas.ActualWidth - Width;
                if (newY + Height > canvas.ActualHeight) newY = canvas.ActualHeight - Height;

                offsetX = newX - X;
                offsetY = newY - Y;

                X = newX;
                Y = newY;

                foreach (var element in elements)
                {
                    Canvas.SetLeft(element, Canvas.GetLeft(element) + offsetX);
                    Canvas.SetTop(element, Canvas.GetTop(element) + offsetY);
                }

                dragStartPoint = currentPoint;

            }
        }

        private void Rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            rect.ReleaseMouseCapture();
        }
    }
}
