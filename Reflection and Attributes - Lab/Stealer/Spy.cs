using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public void StealFieldInfo(object nameOfTheClass)
        {
            StringBuilder sb = new StringBuilder();
            FieldInfo[] fields = nameOfTheClass.GetType().GetFields();
            PropertyInfo[] properties = nameOfTheClass.GetType().GetProperties();
            sb.AppendLine($"Class under investigation: {nameOfTheClass.GetType()}");
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(nameOfTheClass)}");

            }

            foreach (var prop in properties)
            {
                if (prop.Name == "Password")
                {
                sb.AppendLine($"password = {prop.GetValue(nameOfTheClass)}");
                }
            }
            Console.WriteLine(sb.ToString());

        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            FieldInfo[] fields = className.GetType().GetFields();
            MethodInfo[] methods = className.GetType().GetMethods();
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private");
            }
            foreach (var method in methods)
            {
                if (method.Name.Contains("get"))
                {
                    sb.AppendLine($"{method.Name} have to be public");
                }
                else
                {
                    sb.AppendLine($"{method.Name} have to be private");
                }
            }
            return sb.ToString();
        }
    }
}
