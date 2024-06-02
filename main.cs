using System;

class Trapezia
{
    private double[] x = new double[4];
    private double[] y = new double[4];

    public Trapezia(double[] xCoordinates, double[] yCoordinates)
    {
        if (xCoordinates.Length != 4 || yCoordinates.Length != 4)
        {
            throw new ArgumentException("Trapezoid must have 4 vertices");
        }

        xCoordinates.CopyTo(x, 0);
        yCoordinates.CopyTo(y, 0);
    }

    public bool IsIsosceles()
    {
        double c = Math.Sqrt(Math.Pow(x[2] - x[1], 2) + Math.Pow(y[2] - y[1], 2));
        double d = Math.Sqrt(Math.Pow(x[3] - x[0], 2) + Math.Pow(y[3] - y[0], 2));
    
        double a = Math.Abs((x[1] - x[0]) * (y[3] - y[0]) - (y[1] - y[0]) * (x[3] - x[0]));
        double b = Math.Abs((x[2] - x[3]) * (y[0] - y[3]) - (y[2] - y[3]) * (x[0] - x[3]));
    
        return a == b && c != d;
    }


    public double SideLength(int side)
    {
        int next = (side + 1) % 4;
        return Math.Sqrt(Math.Pow(x[next] - x[side], 2) + Math.Pow(y[next] - y[side], 2));
    }

    public double Perimeter()
    {
        double perimeter = 0;
        for (int i = 0; i < 4; i++)
        {
            perimeter += SideLength(i);
        }
        return perimeter;
    }

    public double Area()
    {
        double a = SideLength(0);
        double b = SideLength(2);
        double c = Math.Sqrt(Math.Pow(x[2] - x[1], 2) + Math.Pow(y[2] - y[1], 2));
        double d = Math.Sqrt(Math.Pow(x[3] - x[0], 2) + Math.Pow(y[3] - y[0], 2));
    
        double p = (a + b + c + d) / 2; // Полупериметр
        double area = ((a + b) / Math.Abs(a - b)) * Math.Sqrt((p - a) * (p - b) * (p - a - c) * (p - a - d));
        return area;
    }

}

class Program
{
    static void Main(string[] args)
    {
        // Создаем массив трапеций
        Trapezia[] trapezias = new Trapezia[3];
        trapezias[0] = new Trapezia(new double[] { 0, 2, 4, 6 }, new double[] { 0, 4, 4, 0 });
        trapezias[1] = new Trapezia(new double[] { 1, 3, 5, 7 }, new double[] { 0, 3, 3, 0 });
        trapezias[2] = new Trapezia(new double[] { 0, 2, 6, 8 }, new double[] { 0, 4, 4, 0 });

        // Находим среднюю площадь
        double totalArea = 0;
        foreach (Trapezia trapezia in trapezias)
        {
            totalArea += trapezia.Area();
        }
        double averageArea = totalArea / trapezoids.Length;

        // Считаем количество трапеций с площадью больше средней
        int count = 0;
        foreach (Trapezia trapezia in trapezias)
        {
            if (trapezia.Area() > averageArea)
            {
                count++;
            }
        }

        Console.WriteLine($"Количество трапеций с площадью больше средней: {count}");
    }
}
