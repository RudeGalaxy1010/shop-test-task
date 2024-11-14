using Source.Pool;
using Source.Shop;
using UnityEngine;

namespace Source.Infrastructure {
    public class Bootstrap : MonoBehaviour {
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private ItemsPackView _itemPackViewPrefab;
        [SerializeField] private ItemView _itemViewPrefab;
        [SerializeField] private ShopView _shopView;

        private void Start() {
            _shopView.Init(new SimplePool<ItemsPackView>(_itemPackViewPrefab, container: _canvasTransform),
                new SimplePool<ItemView>(_itemViewPrefab, container: _canvasTransform));
        }
    }
}
