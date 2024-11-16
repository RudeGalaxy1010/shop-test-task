using System.Collections.Generic;
using Source.Shop.Data;

namespace Source.Shop {
    public class DirectLinkShopPacksProvider : IShopPacksProvider {
        private readonly AllPacksData _allPacksData;

        public DirectLinkShopPacksProvider(AllPacksData allPacksData) {
            _allPacksData = allPacksData;
        }

        public List<ShopPackData> GetAvailablePacks() {
            return _allPacksData.AllPacks;
        }
    }
}