using TMPro;
using UnityEngine;

namespace Source.Shop.View {
    public class TextLayout : MonoBehaviour {
        [SerializeField] private TMP_Text _text;

        public void Assign(string text) {
            _text.text = text;
        }
    }
}
