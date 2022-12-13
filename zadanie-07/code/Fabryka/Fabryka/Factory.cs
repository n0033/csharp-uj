using System;
using System.IO;
using System.Reflection;

namespace Factory
{
    public class Factory
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                var argument = args[i].Split(';');
                FileInfo file = new FileInfo(argument[0]);
                Assembly assembly = Assembly.LoadFrom(file.FullName);

                String className = "";
                if (argument[0].ToLower().Contains("sandwich"))
                {
                    className = "SandwichProcessor.ZlecenieKanapka";
                }
                
                if (argument[0].ToLower().Contains("beer"))
                {
                    className = "BeerProcessor.ZleceniePiwo";
                }

                Type t = assembly.GetType(className);
                MethodInfo method = t.GetMethod("process");
                object o = Activator.CreateInstance(t);
                method.Invoke(o, new object[] { argument[1] });
                Console.Write('\n');

            }


        }
    }
}