using System;
using System.Collections.Generic;
using Source.Shop.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Shop.View {
    public class PackView : MonoBehaviour {
        private const string SoldOutText = "Sold out";
        
        public event Action<PackView> PurchaseRequested; 

        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _icon;
        [SerializeField] private PurchaseButton _purchaseButton;
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private ShopItemView _shopItemViewPrefab;
        
        private List<ShopItemView> _itemsViews = new List<ShopItemView>();
        private ShopPackData _pack;

        public ShopPackData Pack => _pack;

        private void Awake() {
            _purchaseButton.OnClick += OnPurchaseButtonClick;
        }
        
        public void Assign(ShopPackData pack, bool wasPurchased) {
            Clear();
            
            _pack = pack;

            if (pack == null) {
                gameObject.SetActive(false);
                return;
            }
            
            _header.text = _pack.Name;
            _description.text = _pack.Description;
            _icon.gameObject.SetActive(_pack.Icon != null); // Icon is optional
            _icon.sprite = _pack.Icon;
            _purchaseButton.Assign(_pack.Price, _pack.OldPrice);
            
            for (int i = 0; i < _pack.Items?.Count; i++) {
                ShopItemView itemView = Instantiate(_shopItemViewPrefab, _itemsContainer);
                itemView.Assign(_pack.Items[i].Item, _pack.Items[i].Quantity);
                _itemsViews.Add(itemView);
            }
            
            SetInteractable(!wasPurchased, wasPurchased);
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

        public void SetInteractable(bool isInteractable, bool wasPurchased = false) {
            if (!wasPurchased) {
                _purchaseButton.SetInteractable(isInteractable);
                return;
            }
            
            _purchaseButton.SetInteractable(isInteractable, overrideText: SoldOutText);
        }
        
        private void OnPurchaseButtonClick() {
            PurchaseRequested?.Invoke(this);
        }
    }
}
