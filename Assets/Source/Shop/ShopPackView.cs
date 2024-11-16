using System.Collections.Generic;
using Source.Shop.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Shop {
    public class ShopPackView : MonoBehaviour {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _icon;
        [SerializeField] private PurchaseButton _purchaseButton;
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private ShopItemView _shopItemViewPrefab;
        
        private List<ShopItemView> _itemsViews;

        public string Id => string.Empty;

        private void Awake() {
            _purchaseButton.OnClick += OnPurchaseButtonClick;
        }

        // TODO: Add data as parameter
        public void Assign(ShopPackData pack) {
            Clear();
            
            _header.text = pack.Name;
            _description.text = pack.Description;
            // Icon is optional
            _icon.gameObject.SetActive(pack.Icon != null);
            _icon.sprite = pack.Icon;
            _purchaseButton.Assign(pack.Price, pack.OldPrice);
            
            for (int i = 0; i < pack.Items?.Count; i++) {
                ShopItemView shopItemView = Instantiate(_shopItemViewPrefab, _itemsContainer);
                shopItemView.Assign(pack.Items[i].Item, pack.Items[i].Quantity);
            }
        }

        private void Clear() {
            if (_itemsViews == null || _itemsViews.Count == 0) {
                return;
            }

            for (int i = 0; i < _itemsViews.Count; i++) {
                Destroy(_itemsViews[i].gameObject);
            }
            
            _itemsViews.Clear();
        }
        
        // TODO: Handle purchase
        private void OnPurchaseButtonClick() {
            
        }
    }
}
