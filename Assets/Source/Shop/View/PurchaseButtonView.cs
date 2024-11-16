using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Shop.View {
    public class PurchaseButtonView : MonoBehaviour {
        public event Action OnClick;
        
        [SerializeField] private Button _button;
        [SerializeField] private TextLayout _textLayout;
        [SerializeField] private PriceLayout _priceLayout;
        [SerializeField] private SaleLayout _saleLayout;

        // Button lifetime = script lifetime, so don't care about OnEnable/OnDisable
        private void Awake() {
            _button.onClick.AddListener(() => OnClick?.Invoke());
        }
        
        public void Assign(int price, int oldPrice = 0) {
            _textLayout.gameObject.SetActive(false);
            
            if (oldPrice > 0 && oldPrice > price) {
                _priceLayout.gameObject.SetActive(false);
                _saleLayout.gameObject.SetActive(true);
                _saleLayout.Assign(price, oldPrice);
                return;
            }
            
            _saleLayout.gameObject.SetActive(false);
            _priceLayout.gameObject.SetActive(true);
            _priceLayout.Assign(price);
        }

        public void SetInteractable(bool isInteractable, string overrideText = "") {
            _button.interactable = isInteractable;

            if (!string.IsNullOrEmpty(overrideText)) {
                _saleLayout.gameObject.SetActive(false);
                _priceLayout.gameObject.SetActive(false);
                _textLayout.gameObject.SetActive(true);
                
                _textLayout.Assign(overrideText);
            }
        }
    }
}
