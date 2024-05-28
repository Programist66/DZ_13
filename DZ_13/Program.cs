using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_13
{
    internal class Program
    {
        public class GenericArray<T>
        {
            private T[] array;
            private int count;

            public GenericArray()
            {
                array = new T[0];
                count = 0;
            }

            public void Add(T item)
            {
                Array.Resize(ref array, count + 1);
                array[count] = item;
                count++;
            }

            public void RemoveAt(int index)
            {
                if (index >= 0 && index < count)
                {
                    for (int i = index; i < count - 1; i++)
                    {
                        array[i] = array[i + 1];
                    }
                    Array.Resize(ref array, count - 1);
                    count--;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }
            }

            public T GetItem(int index)
            {
                if (index >= 0 && index < count)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }
            }

            public int Length
            {
                get { return count; }
            }
        }
        abstract class AbstractClass
        {
            protected int field1;
            protected int field2;

            public AbstractClass(int value1, int value2)
            {
                field1 = value1;
                field2 = value2;
            }

            public abstract int this[int index] { get; set; }
        }


        interface ICalculate
        {
            int Calculate(int value);
        }


        class DerivedClass : AbstractClass, ICalculate
        {
            public DerivedClass(int value1, int value2) : base(value1, value2)
            {
            }

            public override int this[int index]
            {
                get
                {
                    return index % 2 == 0 ? field1 : field2;
                }
                set
                {
                    if (index % 2 == 0)
                        field1 = value;
                    else
                        field2 = value;
                }
            }

            public int Calculate(int value)
            {
                return (field1 + field2) * value;
            }
        }

        public enum GovernmentType
        {
            Republic,
            Monarchy,
            Kingdom
        }
        public class Country
        {
            public string Name { get; set; }
            public GovernmentType Type { get; set; }
            public int Population { get; set; }
            public List<string> Cities { get; set; }

            public Country(string name, GovernmentType type, int population)
            {
                Name = name;
                Type = type;
                Population = population;
                Cities = new List<string>();
            }

            public void AddCity(string city)
            {
                Cities.Add(city);
            }

            public void RemoveCity(string city)
            {
                Cities.Remove(city);
            }

            public override string ToString()
            {
                return $"Country: {Name}, Type: {Type}, Population: {Population}, Cities: {string.Join(", ", Cities)}";
            }
        }


        public class Republic : Country
        {
            public string President { get; set; }

            public Republic(string name, int population, string president) : base(name, GovernmentType.Republic, population)
            {
                President = president;
            }

            public override string ToString()
            {
                return base.ToString() + $", President: {President}";
            }
        }


        public class Monarchy : Country
        {
            public string Monarch { get; set; }

            public Monarchy(string name, int population, string monarch) : base(name, GovernmentType.Monarchy, population)
            {
                Monarch = monarch;
            }

            public override string ToString()
            {
                return base.ToString() + $", Monarch: {Monarch}";
            }
        }


        public class Kingdom : Monarchy
        {
            public string King { get; set; }

            public Kingdom(string name, int population, string monarch, string king) : base(name, population, monarch)
            {
                King = king;
            }

            public override string ToString()
            {
                return base.ToString() + $", King: {King}";
            }
        }
        static void Main(string[] args)
        {

            GenericArray<int> intArray = new GenericArray<int>();
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);

            Console.WriteLine("Integer Array Length: " + intArray.Length);

            Console.WriteLine("Element at index 1: " + intArray.GetItem(1));

            intArray.RemoveAt(1);

            Console.WriteLine("Integer Array Length: " + intArray.Length);

            GenericArray<string> stringArray = new GenericArray<string>();
            stringArray.Add("Hello");
            stringArray.Add("World");

            Console.WriteLine("String Array Length: " + stringArray.Length);

            Console.WriteLine("Element at index 0: " + stringArray.GetItem(0));

            Console.ReadLine();

            DerivedClass obj = new DerivedClass(5, 10);

            Console.WriteLine("Field1: " + obj[0]);
            Console.WriteLine("Field2: " + obj[1]);

            obj[0] = 15;
            obj[1] = 20;

            Console.WriteLine("Field1: " + obj[0]);
            Console.WriteLine("Field2: " + obj[1]);

            int result = obj.Calculate(3);
            Console.WriteLine("Result: " + result);

            Console.ReadLine();

            Republic usa = new Republic("United States of America", 330000000, "Joe Biden");
            usa.AddCity("New York");
            usa.AddCity("Los Angeles");

            Monarchy uk = new Monarchy("United Kingdom", 67000000, "King Charles III");
            uk.AddCity("London");
            uk.AddCity("Manchester");

            Kingdom spain = new Kingdom("Kingdom of Spain", 47000000, "King Felipe VI", "King Felipe VI");
            spain.AddCity("Madrid");
            spain.AddCity("Barcelona");


            Console.WriteLine(usa);
            Console.WriteLine(uk);
            Console.WriteLine(spain);

            Console.ReadLine();
        }
    }
}