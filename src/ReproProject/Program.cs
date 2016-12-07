using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReproProject
{
    public class Program
    {
        private static MyClassEqualityComparer<string> Comparer { get; } = new MyClassEqualityComparer<string>();

        public static void Main(string[] args)
        {
            EqualsWithoutSerialization();
            EqualsWithSerialization();
            AlternateEqualsWithoutSerialization();
            AlternateEqualsWithSerialization();
            Console.Read();
        }

        private static void EqualsWithoutSerialization()
        {
            var object1 = new MyClass<string>("My value 1");
            var object2 = new MyClass<string>("My value 1");

            var valuesAreEquals = Comparer.Equals(object1, object2);
            WriteLine(
                $"Values ({object1.Value}|{object2.Value}), without serialization, should be equals: {valuesAreEquals}", 
                ConsoleColor.Green
            );
        }

        private static void EqualsWithSerialization()
        {
            var object1 = new MyClass<string>("My value 1");
            var object2 = new MyClass<string>("My value 1");

            var serializedObject1 = JsonConvert.SerializeObject(object1);
            var serializedObject2 = JsonConvert.SerializeObject(object2);

            var deserializedObject1 = JsonConvert.DeserializeObject<MyClass<string>>(serializedObject1);
            var deserializedObject2 = JsonConvert.DeserializeObject<MyClass<string>>(serializedObject2);

            var valuesAreEquals = Comparer.Equals(deserializedObject1, deserializedObject2);
            WriteLine(
                $"Values ({deserializedObject1.Value}|{deserializedObject2.Value}), with serialization, should be equals: {valuesAreEquals}",
                ConsoleColor.Red
            );
        }

        private static void AlternateEqualsWithoutSerialization()
        {
            var object1 = new MyClass<string>("My value 1");
            var object2 = new MyClass<string>("My value 1");

            var valuesAreEquals = Comparer.AlternateEquals(object1, object2);
            WriteLine(
                $"Values ({object1.Value}|{object2.Value}), without serialization, should be equals: {valuesAreEquals}",
                ConsoleColor.Green
            );
        }

        private static void AlternateEqualsWithSerialization()
        {
            var object1 = new MyClass<string>("My value 1");
            var object2 = new MyClass<string>("My value 1");

            var serializedObject1 = JsonConvert.SerializeObject(object1);
            var serializedObject2 = JsonConvert.SerializeObject(object2);

            var deserializedObject1 = JsonConvert.DeserializeObject<MyClass<string>>(serializedObject1);
            var deserializedObject2 = JsonConvert.DeserializeObject<MyClass<string>>(serializedObject2);

            var valuesAreEquals = Comparer.AlternateEquals(deserializedObject1, deserializedObject2);
            WriteLine(
                $"Values ({deserializedObject1.Value}|{deserializedObject2.Value}), with serialization, should be equals: {valuesAreEquals}", 
                ConsoleColor.Green
            );
        }

        private static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
