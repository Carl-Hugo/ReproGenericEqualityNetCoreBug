using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReproProject
{
    public class MyClass<T>
        where T : class
    {
        public MyClass() { }

        public MyClass(T value)
        {
            Value = value;
        }

        public virtual T Value { get; set; }
    }
}
