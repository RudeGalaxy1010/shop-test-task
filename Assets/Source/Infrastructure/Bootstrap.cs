using Source.Pool;
using Source.Shop;
using Source.Shop.Data;
using UnityEngine;

namespace Source.Infrastructure {
    public class Bootstrap : MonoBehaviour {
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private ItemsPackView _itemPackViewPrefab;
        [SerializeField] private ItemView _itemViewPrefab;
        [SerializeField] private ShopView _shopView;
        [SerializeField] private AllPacksData _allPacksData;

        private void Start() {
            IShopPacksProvider shopPacksProvider = new DirectLinkShopPacksProvider(_allPacksData);
            _shopView.Init(new SimplePool<ItemsPackView>(_itemPackViewPrefab, container: _canvasTransform),
                new SimplePool<ItemView>(_itemViewPrefab, container: _canvasTransform));
        }
    }
}
