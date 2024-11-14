using System.Collections.Generic;
using UnityEngine;

namespace Source.Pool {
    public class SimplePool<T> : IPool<T> 
        where T : MonoBehaviour {
        private const int DefaultCapacity = 10;

        private readonly Transform _container;
        private readonly T _prefab;
        private readonly List<T> _objects;
        
        private int _capacity;

        public SimplePool(T prefab, Transform container = null, int capacity = 0, string id = "") {
            _container = CreateContainer(container, id);
            _prefab = prefab;
            _capacity = capacity > 0 ? capacity : DefaultCapacity;
            _objects = new List<T>(_capacity);
            
            CreateObjects(_capacity);
        }

        public T Get() {
            T obj = null;
            
            if (_objects.Count > 0) {
                obj = _objects[0];
                obj.transform.SetParent(null);
                obj.gameObject.SetActive(true);
            }
            
            Expand();
            
            if (_objects.Count == 0) {
                Debug.LogError("Failed to expand pool");
            }
            
            obj = _objects[0];
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }

        public void Release(T obj) {
            if (_objects.Contains(obj)) {
                return;
            }
            
            obj.transform.SetParent(_container);
            obj.gameObject.SetActive(false);
            _objects.Add(obj);
        }

        private Transform CreateContainer(Transform root = null, string id = "") {
            id = string.IsNullOrEmpty(id) ? "" : $" {id}";
            GameObject containerObject = new GameObject($"Pool Container{id}");
            
            if (root != null) {
                containerObject.transform.SetParent(root, false);
            }
            
            return containerObject.transform;
        }

        private void CreateObjects(int count) {
            for (int i = 0; i < count; i++) {
                T instance = Object.Instantiate(_prefab, _container);
                instance.gameObject.SetActive(false);
                _objects.Add(instance);
            }
        }

        private void Expand() {
            CreateObjects(_capacity);
            _capacity *= 2;
        }
    }
}
