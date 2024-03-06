using Immortal.Generic;

namespace Immortal.GenericImplementation
{
    public class Factory<T1, T2> : IFactory<T2> where T1 : T2, new()
    {
        public T2 Make()
        {
            return new T1();
        }
    }
}