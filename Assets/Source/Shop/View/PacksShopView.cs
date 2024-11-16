using System;
using System.Collections.Generic;
using System.Linq;
using Source.Shop.Data;
using Source.Shop.Model;
using UnityEngine;

namespace Source.Shop.View {
    public class PacksShopView : MonoBehaviour, IShopView {
        public event Action<string, int> PurchaseRequested;

        [SerializeField] private Transform _packsContainer;
        [SerializeField] private PackView _packViewPrefab;

        private bool _wasInited;
        private IShopModel _shopModel;
        private List<PackView> _packs;
        
        public void Init(IShopModel shopModel) {
            if (_wasInited) {
                return;
            }

            _packs = new List<PackView>();
            _shopModel = shopModel;
            _shopModel.PackChanged += OnPackChanged;
            _wasInited = true;
        }

        private void OnPackChanged(ChangedData changeData) {
            if (changeData.Data == null) {
                return;
            }
            
            if (!(changeData.Data is ShopPackData shopPack)) {
                return;
            }
            
            PackView packView = _packs.FirstOrDefault(x => x.Pack != null && x.Pack.Id == shopPack.Id);

            if (packView == null) {
                packView = Instantiate(_packViewPrefab, _packsContainer);
                packView.PurchaseRequested += OnPurchaseRequested;
                _packs.Add(packView);
            }
            
            packView.Assign(shopPack, changeData.WasPurchased);
        }

        private void OnPurchaseRequested(PackView packView) {
            packView.SetInteractable(false); // Interactable returns on item change, item will change anyway 
            ShopPackData pack = packView.Pack;
            PurchaseRequested?.Invoke(pack.Id, pack.Price);
        }
    }
}
