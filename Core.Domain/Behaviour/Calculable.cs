using System;

namespace Core.Domain.Behaviour
{
    public class Calculable<T>
    {
        public Type Type { get; }
        public Calculable()
        {
            Type = typeof(T);
        }
    }
}