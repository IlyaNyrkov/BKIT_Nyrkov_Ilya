using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace reflection
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        public class NewAttribute : Attribute
    {
        public NewAttribute() { }
        public NewAttribute(string DiscriptionParam)
        {
            Discription = DiscriptionParam;
        }
        public string Discription { get; set; }
    }

    public class student : IComparable
    {
        public student() { }

        public student(List<double> marks)
        {
            this.marks = marks;
        }
        private int _age;

        [NewAttribute("Student age - restrictions:" +
            " can't be negative\n")]
        public int age{
            get
            {
                return _age;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("age can't be negative");
                } 
                else
                {
                    _age = value;
                }
            }
        }
        public double height { get; set; }

        public List<double> marks =
            new List<double>();

        private double AvgMarks;
        public double GetAvgMarks()
        {
            if (marks.Count == 0)
                return 0;

            double sum = 0;
            foreach(int x in marks)
            {
                sum += x;
            }
            return sum / marks.Count;
        }
        public void AddMarks(double mark)
        {
            marks.Add(mark);
            AvgMarks = GetAvgMarks();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Average score: " + AvgMarks.ToString() + "\n");
            foreach (var x in marks)
            {
                str.Append(x.ToString() + "\n");
            }
            return str.ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public int CompareTo(object obj)
        {
            student obj2 = (student)obj;
            if (this.AvgMarks == obj2.AvgMarks) 
                return 0;
            if (this.AvgMarks < obj2.AvgMarks)
                return -1;
            else
                return 1;
        }
        
    };
    class Program
    {

        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }
        static void Main(string[] args)
        {
            student John = new student();
            student Mike = new student();
            Type John_type = John.GetType();
            for (int i = 0; i < 5; i++)
            {
                John.AddMarks(i);
                Mike.AddMarks(i + 1);
            }

            Console.WriteLine("++++++++++++Constructors++++++++");
            foreach (var x in John_type.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("++++++++++++Properties+++++++++");
            foreach (var x in John_type.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("++++++++++++Methods+++++++++++");
            foreach (var x in John_type.GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("++++++++++++Attributed_Properties+++++++++++++");
            foreach (var x in John_type.GetProperties())
            {
                if (GetPropertyAttribute(x, typeof(NewAttribute), out object attribute))
                {
                    NewAttribute attr = (NewAttribute)attribute;
                    Console.WriteLine(x.Name + " - " + attr.Discription);
                }
            }

            Console.WriteLine("++++++++++++Invoked_method-GetAvgMarks");
            object Result = John_type.InvokeMember("GetAvgMarks", BindingFlags.InvokeMethod, null, John, null);
            Console.WriteLine(Result);


        }
    }
}
