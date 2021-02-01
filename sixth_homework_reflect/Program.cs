using System;
using System.Reflection;

namespace sixth_homework_reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sixth task!");

            var assembly = Assembly.LoadFile(Environment.CurrentDirectory + "/sixth_homework_convert.dll");
            string typeName = string.Empty;
            foreach(var type in assembly.GetTypes())
                typeName = type.FullName;
            object convertor = Activator.CreateInstance(assembly.GetType(typeName));
            MethodInfo convertFromCtoF = assembly.GetType(typeName).GetMethod("ConvertFromCtoF");
            MethodInfo convertFromFtoC = assembly.GetType(typeName).GetMethod("ConvertFromFtoC");

            Console.WriteLine($"C to F: {convertFromCtoF.Invoke(convertor, new object[] {32})}");
            Console.WriteLine($"F to C: {convertFromFtoC.Invoke(convertor, new object[] {32})}");
        }
    }
}
