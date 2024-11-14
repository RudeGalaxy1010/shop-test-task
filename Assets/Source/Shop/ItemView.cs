using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Shop {
    public class ItemView : MonoBehaviour {
        public struct ViewData {
            public Sprite Icon;
            public int Amount;
        }
        
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _value;

        // TODO: Fallback icon
        public void Assign(ViewData data) {
            _icon.sprite = data.Icon;
            // Amount label is optional
            _value.gameObject.SetActive(data.Amount > 0);
            _value.text = data.Amount.ToString();
        }
    }
}
