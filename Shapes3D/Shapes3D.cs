using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

// RectangleAreaCalculator.Program.Main();

namespace Shapes3D
{
    public class Placeholder
    {
        public static void Main(string[] args)
        {

        }
    }
    public class Polygon
    {
        public static double rectangle(double length, double width)
        {
            return length * width;
        }
    }
    
    public class Prism 
    {
        public static double cuboid(double width, double height, double depth, bool area)
        {
            switch (area)
            {
                case true:
                    return 2 * (width * depth + width * height + height * depth);
                case false:
                    return width * height * depth;
            }
        }

        public static double cube(double sideLength, bool area)
        {
            switch (area)
            {
                case true:
                    return 6 * Math.Pow(sideLength, 2);
                case false:
                    return Math.Pow(sideLength, 3.0);
            }
        }

        public static double cylinder(double radius, double height, bool area)
        {
            switch (area)
            {
                case true:
                    return (2 * Math.PI * radius * height) + (2 * Math.PI * Math.Pow(radius, 2));
                case false:
                    return Math.PI * Math.Pow(radius, 2.0) * height;
            }
        }

        public static double sphere(double radius, bool area)
        {
            switch (area)
            {
                case true:
                    return 4 * Math.PI * Math.Pow(radius, 2);
                case false:
                    return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3.0);
            }
        }

        public static double prism(double sideLength, int faces, double height, bool area)
        {
            double apothem = sideLength / (2.0 * Math.Tan(180.0 / faces));
            double baseArea = (faces * sideLength * apothem) / 2.0;
            switch (area)
            {
                case true:
                    return (2 * baseArea) + (sideLength * faces * height);
                case false:
                    return baseArea * height;
            }
        }
    }
}