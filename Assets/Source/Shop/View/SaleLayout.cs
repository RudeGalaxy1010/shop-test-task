using TMPro;
using UnityEngine;

namespace Source.Shop.View {
    public class SaleLayout : MonoBehaviour {
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _oldPriceText;
        [SerializeField] private TMP_Text _saleText;

        public void Assign(int price, int oldPrice) {
            _priceText.text = price.ToString();
            _oldPriceText.text = oldPrice.ToString();

            float discountPercent = oldPrice == 0 ? 0 : Mathf.CeilToInt((1 - (float)price / oldPrice) * 100f);
            string sign = discountPercent > 0 ? "-" : "+";
            _saleText.text =$"{sign}{discountPercent:0.}%";
        }
    }
}
