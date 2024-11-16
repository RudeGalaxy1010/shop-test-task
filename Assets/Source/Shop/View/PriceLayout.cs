using TMPro;
using UnityEngine;

namespace Source.Shop.View {
    public class PriceLayout : MonoBehaviour {
        [SerializeField] private TMP_Text _priceText;

        public void Assign(int price) {
            _priceText.text = price.ToString();
        }
    }
}
