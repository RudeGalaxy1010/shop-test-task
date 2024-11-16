using System;

namespace Source.UserData {
    public interface IUserDataService : IPurchasedItemsStorage {
        event Action<int> BalanceChanged;
        int Balance { get; }
        Exception TryPurchaseUniqueItem(string itemId, int price);
    }
}
