using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1.  Программа должна быть разработана в виде консольного приложения на языке C#.
2.  Программа осуществляет ввод с клавиатуры коэффициентов А, В, С, вычисляет дискриминант и корни уравнения (в зависимости от дискриминанта).
3.  Если коэффициент А, В, С введен некорректно, то необходимо проигнорировать некорректное значение и ввести коэффициент повторно.
4.  Первой строкой программа выводит ФИО разработчика и номер группы. 
5.  Корни уравнения выводятся зеленым цветом. Если корней нет, то сообщение выводится красным цветом.
6.  ДОПОЛНИТЕЛЬНОЕ ТРЕБОВАНИЕ. Коэффициенты А, В, С задаются в виде параметров командной строки. Если они не указаны, то вводятся с клавиатуры в соответствии с пунктом 2. Проверка из пункта 3 в этом случае производится для параметров командной строки без повторного ввода с клавиатуры.
 */


namespace laba1

{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1 -10 9 // 3 -3 1 -1
            1 -5 4 // 2 -2 1 -1
            1 -25 144 // 4 -4 3 -3
            */
            double A, B, C;


            if (args.Length == 0)
            {
                Console.WriteLine("Ilya Nyrkov Alexeevich IU5-32B");
                Console.Write("Enter A = ");
                while (!double.TryParse(Console.ReadLine(), out A)) { };
                Console.Write("Enter B = ");
                while (!double.TryParse(Console.ReadLine(), out B)) { };
                Console.Write("Enter C = ");
                while (!double.TryParse(Console.ReadLine(), out C)) { };
            }
            else
            {
                A = Convert.ToInt32(args[0]);
                B = Convert.ToInt32(args[1]);
                C = Convert.ToInt32(args[2]);
            }
            Coefficient_output(biquadratic_equation(A, B, C));
        }

        public static List<double> biquadratic_equation(double A, double B, double C)
        {
            List<double> coef = new List<double>();
            if (A != 0)
            {
                double D = B * B - 4 * A * C;
                double y1 = (-B + Math.Sqrt(D)) / (2 * A);
                double y2 = (-B - Math.Sqrt(D)) / (2 * A);
                if (y1 > 0)
                {
                    coef.Add(Math.Sqrt(y1));
                    coef.Add(-1 * Math.Sqrt(y1));
                }
                if (y2 > 0 && y2 != y1)
                {
                    coef.Add(Math.Sqrt(y2));
                    coef.Add(-1 * Math.Sqrt(y2));
                }
            }
            else
            {
                //Bx^2 + C = 0 => x^2 = - C / B
                if (B * C < 0)
                {
                    coef.Add(Math.Sqrt(-1 * (C / B)));
                    coef.Add(-1 * Math.Sqrt(-1 * (C / B)));
                }
            }
            return coef;
        }

        public static void Coefficient_output(List<double> coef)
        {
            if (coef.Count() != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < coef.Count(); i++)
                {
                    Console.Write("x" + (i + 1) + " = " + coef[i] + "");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("No coefficients\n");
            }
            Console.ResetColor();
        }

    }
}