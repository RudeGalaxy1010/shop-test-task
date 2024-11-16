using System;
using System.Collections.Generic;

namespace Source.UserData {
    public class UserDataService : IUserDataService {
        private readonly List<string> _uniqueItems;
        
        private int _balance;
        
        public UserDataService(int balance, List<string> uniqueItems) {
            _balance = balance;
            _uniqueItems = uniqueItems;
        }

        public bool HasUniqueItem(string itemId) {
            return _uniqueItems.Contains(itemId);
        }

        public Exception TryPurchaseUniqueItem(string itemId, int price) {
            if (HasUniqueItem(itemId)) {
                return null;
            }

            if (price > _balance) {
                return new Exception($"Not enough money to buy '{itemId}' with price: {price}");
            }

            _balance -= price;
            _uniqueItems.Add(itemId);
            return null;
        }
    }
}
