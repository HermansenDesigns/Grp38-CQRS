using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure
{
    public class PrivateReflectionDynamicObject
    {
        private static IDictionary<Type, IDictionary<string, IProperty>> _propertiesType =
            new ConcurrentDictionary<Type, IDictionary<string, IProperty>>();

        interface IProperty
        {
            string Name { get; }
            object GetValue(object obj, object[] index);
            void SetValue(object obj, object val, object[] index);
        }

        private class Property : IProperty
        {
            internal PropertyInfo PropertyInfo { get; set; }

            public string Name => PropertyInfo.Name;

            public object GetValue(object obj, object[] index)
            {
                return PropertyInfo.GetValue(obj, index);
            }

            public void SetValue(object obj, object val, object[] index)
            {
                PropertyInfo.SetValue(obj, val, index);
            }
        }

        private class Field : IProperty
        {
            internal FieldInfo FieldInfo;

            string IProperty.Name => FieldInfo.Name;

            public object GetValue(object obj, object[] index)
            {
                return FieldInfo.GetValue(obj);
            }

            public void SetValue(object obj, object val, object[] index)
            {
                FieldInfo.SetValue(obj, val);
            }
        }

        private object RealObject { get; set; }
        private const BindingFlags bindingFalgs = BindingFlags.Instance;

        internal static object WrapObjectIfNeeded(object o)
        {

        }
    }
}
