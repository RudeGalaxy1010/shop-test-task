using System;
using Source.UserData;

namespace Source.Shop.Model {
    public interface IShopModel {
        event Action<ChangedData> PackChanged;
        void UpdateItems(IPurchasedItemsStorage purchasedItemsStorage);
    }
}
