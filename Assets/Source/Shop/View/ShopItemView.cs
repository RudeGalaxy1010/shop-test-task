using Source.Shop.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Shop.View {
    public class ShopItemView : MonoBehaviour {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _value;
        
        public void Assign(ShopItemData item, int quantity) {
            if (item == null) {
                gameObject.SetActive(false);
                return;
            }
            
            _icon.sprite = item.Icon;
            // Amount label is optional
            _value.gameObject.SetActive(quantity > 0);
            _value.text = quantity.ToString();
        }
    }
}
