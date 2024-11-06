using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace FinalProject
{
    public static class Solver
    {
        public static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "shapes.csv");
            NumberFormatInfo numberFormatInfo = new();
            numberFormatInfo.NumberGroupSeparator = ",";
            numberFormatInfo.NumberDecimalDigits = 2;
            Console.WriteLine("Final result is: " + ProcessFile(filePath).ToString("N", numberFormatInfo) + "\nPress ENTER to exit.");
            Console.ReadLine();
        }
        
        public static double ProcessFile(string filePath)
        {
            if (!File.Exists(filePath)) {
                Console.WriteLine("File not found.");
                return 0;
            }
            List<string[]> shapeData = [];
            double scaleFactor = 1.0;
            double fullTotal = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');   


                    if (parts[0] == "volume")
                    {
                        scaleFactor = double.Parse(parts[1]);
                        double total = 0;

                        foreach (string[] shapeInfo in shapeData)
                        {
                            double shapeValue = CalculateShapeVolume(shapeInfo);
                            total += shapeValue;
                        }

                        fullTotal += total * scaleFactor;
                        shapeData = [];
                    }
                    else if (parts[0] == "area")
                    {
                        scaleFactor = double.Parse(parts[1]);
                        double total = 0;

                        foreach (string[] shapeInfo in shapeData)
                        {
                            double shapeValue = CalculateShapeArea(shapeInfo);
                            total += shapeValue;
                        }

                        fullTotal += total * scaleFactor;
                        shapeData = [];
                    }
                    else
                    {
                        shapeData.Add(parts);
                    }
                }
            }

            return fullTotal;
        }

        private static double CalculateShapeVolume(string[] shapeInfo)
        {
            string shapeType = shapeInfo[0];
            double[] dimensions = shapeInfo.Skip(1).Select(double.Parse).ToArray();

            switch (shapeType)
            {
                case "cube":
                    return Shapes3D.Prism.cube(dimensions[0], false);
                case "cuboid":
                    return Shapes3D.Prism.cuboid(dimensions[0], dimensions[1], dimensions[2], false);
                case "sphere":
                    return Shapes3D.Prism.sphere(dimensions[0], false);
                case "cylinder":
                    return Shapes3D.Prism.cylinder(dimensions[0], dimensions[1], false);
                case "prism":
                    return Shapes3D.Prism.prism(dimensions[0], (int)dimensions[1], dimensions[2], false);
                default:
                    throw new ArgumentException("Invalid shape type: " + shapeType);
            }
        }

        private static double CalculateShapeArea(string[] shapeInfo)
        {
            string shapeType = shapeInfo[0];
            double[] dimensions = shapeInfo.Skip(1).Select(double.Parse).ToArray();

            switch (shapeType)
            {
                case "cube":
                    return Shapes3D.Prism.cube(dimensions[0], true);
                case "cuboid":
                    return Shapes3D.Prism.cuboid(dimensions[0], dimensions[1], dimensions[2], true);
                case "sphere":
                    return Shapes3D.Prism.sphere(dimensions[0], true);
                case "cylinder":
                    return Shapes3D.Prism.cylinder(dimensions[0], dimensions[1], true);
                case "prism":
                    return Shapes3D.Prism.prism(dimensions[0], (int)dimensions[1], dimensions[2], true);
                default:
                    throw new ArgumentException("Invalid shape type: " + shapeType);
            }
        }
    }
}