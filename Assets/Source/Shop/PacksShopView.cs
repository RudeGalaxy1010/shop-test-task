using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.Shop {
    public class PacksShopView : MonoBehaviour {
        [SerializeField] private Transform _packsContainer;
        [SerializeField] private ShopPackView _packViewPrefab;

        private bool _wasInited;
        private PacksShopModel _shopModel;
        private List<ShopPackView> _packs;

        // TODO: Add IModel as parameter
        public void Init(PacksShopModel shopModel) {
            if (_wasInited) {
                return;
            }

            _packs = new List<ShopPackView>();
            _shopModel = shopModel;
            _shopModel.PackChanged += OnPackChanged;
            _wasInited = true;
        }

        private void OnPackChanged(ChangedPackData packChangeData) {
            ShopPackView packView = _packs.FirstOrDefault(x => x.Id == packChangeData.Pack.Id);

            if (packView == null) {
                packView = Instantiate(_packViewPrefab, _packsContainer);
                _packs.Add(packView);
            }
            
            packView.Assign(packChangeData.Pack);
        }
    }
}
