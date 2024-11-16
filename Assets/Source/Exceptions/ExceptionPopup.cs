using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Exceptions {
    public class ExceptionPopup : MonoBehaviour {
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _text;

        private void Awake() {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        public void Show(string message) {
            gameObject.SetActive(true);
            _text.text = message;
        }

        private void OnCloseButtonClick() {
            gameObject.SetActive(false);
        }
    }
}
