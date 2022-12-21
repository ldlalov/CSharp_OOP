using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties().Any(x => x.GetCustomAttribute(MyValidationAttribute));
            foreach (var property in properties)
            {
            }
            return true;
        }
    }
}
