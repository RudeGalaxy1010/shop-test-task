using System.Collections.Generic;
using Source.Shop.Data;

namespace Source.Shop {
    public interface IShopPacksProvider {
        List<ShopPackItemData> GetAvailablePacks();
    }
}