using System;

namespace Assets.Scripts
{
    public interface ObjectSave
    {
        public void Save(object objToSave);

        public T Load<T>();
    }
}
