using System.Collections.Generic;
using Source.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Shop {
    public class ItemsPackView : MonoBehaviour {
        public struct ViewData {
            public string Header;
            public string Description;
            public Sprite Icon;
            public List<ItemView.ViewData> ItemsData;
            public int OldPrice;
            public int Price;
        }
        
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _icon;
        [SerializeField] private PurchaseButton _purchaseButton;
        [SerializeField] private Transform _itemsContainer;

        private IPool<ItemView> _itemsPool;
        private List<ItemView> _items;

        private void Awake() {
            _purchaseButton.OnClick += OnPurchaseButtonClick;
        }

        // TODO: Add data as parameter
        public void Assign(IPool<ItemView> itemsPool, ViewData data) {
            Clear();
            _itemsPool = itemsPool;
            
            _header.text = data.Header;
            _description.text = data.Description;
            // Icon is optional
            _icon.gameObject.SetActive(data.Icon != null);
            _icon.sprite = data.Icon;
            _purchaseButton.Assign(data.Price, data.OldPrice);

            for (int i = 0; i < data.ItemsData?.Count; i++) {
                ItemView itemView = _itemsPool.Get();
                itemView.transform.SetParent(_itemsContainer);
                itemView.Assign(data.ItemsData[i]);
            }
        }

        private void Clear() {
            if (_items == null || _items.Count == 0 || _itemsPool == null) {
                return;
            }

            for (int i = 0; i < _items.Count; i++) {
                _itemsPool.Release(_items[i]);
            }
            
            _items.Clear();
        }
        
        // TODO: Handle purchase
        private void OnPurchaseButtonClick() {
            
        }
    }
}
