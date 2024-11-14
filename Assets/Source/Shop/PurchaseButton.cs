using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Shop {
    public class PurchaseButton : MonoBehaviour {
        public event Action OnClick;
        
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _priceText;

        // Button lifetime = script lifetime, so don't care about OnEnable/OnDisable
        private void Awake() {
            _button.onClick.AddListener(() => OnClick?.Invoke());
        }

        // TODO: Add sales support
        public void Assign(int price, int oldPrice = 0) {
            _priceText.text = price.ToString();
        }

        public void SetInteractable(bool isInteractable) {
            _button.interactable = isInteractable;
        }
    }
}
