using System;
using IKVM.Reflection;
using java.net;

namespace JavaParserExample
{
    //https://tomassetti.me/parsing-in-csharp/
    public class JavaModelParser
    {
        //https://www.reddit.com/r/dotnet/comments/v0mh69/ikvm_is_back_now_with_net_core/
        static void Run(string[] args)
        {
            // Load the Java file using IKVM.Reflection
            // https://www.reddit.com/r/dotnet/comments/vqqpqb/ikvm_820/
            var javaFile = new URLClassLoader("MyClass.jar");

            // Extract class and field information
            foreach (var type in javaFile.GetTypes())
            {
                Console.WriteLine("Class name: " + type.Name);
                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    var fieldName = field.Name;
                    var fieldType = field.FieldType.Name;

                    Console.WriteLine("Field name: " + fieldName);
                    Console.WriteLine("Field type: " + fieldType);
                    Console.WriteLine("Field modifiers: public");
                }
            }
        }
    }
}