using System;
using System.Collections.Generic;
using System.Linq;
using Source.Shop.Data;
using Source.Shop.Model;
using UnityEngine;

namespace Source.Shop.View {
    public class PacksShopView : MonoBehaviour {
        public event Action<ShopPackData> PurchaseRequested;

        [SerializeField] private Transform _packsContainer;
        [SerializeField] private PackView _packViewPrefab;

        private bool _wasInited;
        private PacksShopModel _shopModel;
        private List<PackView> _packs;

        // TODO: Add IModel as parameter
        public void Init(PacksShopModel shopModel) {
            if (_wasInited) {
                return;
            }

            _packs = new List<PackView>();
            _shopModel = shopModel;
            _shopModel.PackChanged += OnPackChanged;
            _wasInited = true;
        }

        private void OnPackChanged(ChangedPackData packChangeData) {
            PackView packView = _packs.FirstOrDefault(x => x.Pack != null && x.Pack.Id == packChangeData.Pack.Id);

            if (packView == null) {
                packView = Instantiate(_packViewPrefab, _packsContainer);
                packView.PurchaseRequested += OnPurchaseRequested;
                _packs.Add(packView);
            }
            
            packView.Assign(packChangeData.Pack, packChangeData.WasPurchased);
        }

        private void OnPurchaseRequested(PackView packView) {
            packView.SetInteractable(false); // Interactable returns on item change, item will change anyway 
            ShopPackData pack = packView.Pack;
            PurchaseRequested?.Invoke(pack);
        }
    }
}
