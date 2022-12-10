using System;
using System.Data;
using System.Reflection;

namespace zadanie_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Customer);

            Console.WriteLine("Fields: ");
            foreach(var field in type.GetFields())
            {
                Console.WriteLine(field);
            }
            Console.WriteLine("\n");


            FieldInfo[] NonPublicFields = type.GetFields(
                                     BindingFlags.NonPublic |
                                     BindingFlags.Instance);
            Console.WriteLine("-- Non Public: ");
            foreach (var field in NonPublicFields)
            {
                Console.WriteLine(field);
            }
            Console.WriteLine("\n");


            Console.WriteLine("Methods: "); //Lista metod
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine(method);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Nested types: "); //typy zagnieżdżone
            foreach (var field in type.GetNestedTypes())
            {
                Console.WriteLine(field);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Properties: "); //propercje
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine(prop);
            }
            Console.WriteLine("\n");


            Console.WriteLine("Members: "); //Członkowie
            foreach (var member in type.GetMembers())
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("\n");



            // Task no. 2
            Customer customer = new Customer("ostro");
            //type.GetProperty("Name").SetValue(customer, "Siema");
            // "Name" does not have setter
            type.GetProperty("Address").SetValue(customer, "Elo");
            type.GetProperty("SomeValue").SetValue(customer, 12);
            Console.WriteLine(type.GetProperty("Name"));
            Console.WriteLine(customer.Name);
            Console.WriteLine(customer.Address);
            Console.WriteLine(customer.SomeValue);
            

            Console.ReadKey();
        }
    }
}
