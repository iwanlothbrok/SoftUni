﻿

using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width
        {
            get => this.width;
            set => this.width = value;
        }
        public int Height
        {
            get => this.height;
            set => this.height = value;
        }
        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.Height - 1; i++)
            {
                DrawLine(this.Width, ' ', '*');
            }
            DrawLine(this.Width, '*', '*');
        }

        private void DrawLine(int width, char mid, char end)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}