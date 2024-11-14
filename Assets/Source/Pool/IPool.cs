using UnityEngine;

namespace Source.Pool {
    public interface IPool<T> where T : MonoBehaviour {
        T Get();
        void Release(T obj);
    }
}
