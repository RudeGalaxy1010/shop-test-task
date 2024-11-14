using Source.Pool;
using UnityEngine;

namespace Source.Shop {
    public class ShopView : MonoBehaviour {
        [SerializeField] private Transform _itemsContainer;

        private bool _wasInited;
        private IPool<ItemsPackView> _packsPool;
        private IPool<ItemView> _itemsPool;

        // TODO: Add IModel as parameter
        public void Init(IPool<ItemsPackView> packsPool, IPool<ItemView> itemsPool) {
            if (_wasInited) {
                return;
            }
            
            _packsPool = packsPool;
            _itemsPool = itemsPool;
            _wasInited = true;
        }
    }
}
