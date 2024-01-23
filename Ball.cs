﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
namespace WpfApp7 {
    public class Ball : ICanvasObject {
        public double X { get; set; }
        public double Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Canvas Canvas { get; set; }
        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
        public double Speed { get; set; }
        public double Angle { get; set; }
        public Ellipse Shape { get; set; }

        public Ball(int width, int height, Canvas canvas) {
            Width = width;
            Height = height;
            Canvas = canvas;
            Shape = new() {
                Width = width,
                Height = height,
                Fill=new SolidColorBrush(Colors.White)
            };
            DirectionX = 1;
            DirectionY = 1;
            X = canvas.Width / 2 - width / 2;
            Y=canvas.Height/2 - height / 2;
            Speed = 3f;
            Random r = new();
            Angle = r.Next(30, 60) * Math.PI / 180;
            canvas.Children.Add(Shape);
        }

        public void Move() {
            X += Math.Cos(Angle) * Speed * DirectionX;
            Y += Math.Cos(Angle) * Speed * DirectionY;
            if(Y<=0||Y>=Canvas.Height)
                DirectionY*=-1;

            Draw();
        }

        public void Draw() {
            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
        }

        public void Reset() {
            throw new NotImplementedException();
        }
    }
}
