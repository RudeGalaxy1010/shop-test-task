using System;

namespace Source.UserData {
    public interface IUserDataService : IPurchasedItemsStorage {
        Exception TryPurchaseUniqueItem(string itemId, int price);
    }
}
