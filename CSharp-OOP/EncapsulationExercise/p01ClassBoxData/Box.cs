


using System;

namespace p01.ClassBoxData
{

    public class Box
    {
        private const int MIN_NUMBER = 0;
        private double lenght;
        private double width;
        private double height;
        public Box(double lenght,double width,double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }
        public double Lenght
        {
            get => lenght;
            private set
            {
                if (value <= MIN_NUMBER)
                {
                    throw new ArgumentException(string.Format(Exceptions.NegativeNumber, nameof(Lenght)));
                }
                lenght = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= MIN_NUMBER)
                {
                    throw new ArgumentException(string.Format(Exceptions.NegativeNumber, nameof(Width)));
                }
                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= MIN_NUMBER)
                {
                    throw new ArgumentException(string.Format(Exceptions.NegativeNumber, nameof(Height)));
                }
                height = value;
            }
        }
        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            double area = 2 * (Lenght * Width) +
             2 * (Lenght * Height) +
             2 * (Width * Height);
            return area;

        }
        public double LateralSurfaceArea()
        {
            // 2lh + 2wh
            double lateralSurfaceArea = 2 * ((Lenght * Height) + (Width * Height));
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            //Volume = lwh
            double volume = Lenght * Width * Height;
            return volume; 
        }
    }
}