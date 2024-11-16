using Source.UserData;
using TMPro;
using UnityEngine;

namespace Source.Shop.View {
    public class UserBalanceView : MonoBehaviour {
        [SerializeField] private TMP_Text _balanceText;

        public void Init(IUserDataService userDataService) {
            userDataService.BalanceChanged += OnBalanceChanged;
            OnBalanceChanged(userDataService.Balance);
        }

        private void OnBalanceChanged(int value) {
            _balanceText.text = $"$ {value}";
        }
    }
}
