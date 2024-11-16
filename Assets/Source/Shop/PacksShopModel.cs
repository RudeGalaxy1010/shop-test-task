using System;
using System.Collections.Generic;
using Source.Shop.Data;
using Source.UserData;

namespace Source.Shop {
    public class PacksShopModel {
        public event Action<ChangedPackData> PackChanged;

        private readonly IShopPacksProvider _shopPacksProvider;

        private List<ShopPackData> _packs;

        public PacksShopModel(IShopPacksProvider shopPacksProvider) {
            _shopPacksProvider = shopPacksProvider;
        }

        public void UpdateItems(IPurchasedItemsStorage purchasedItemsStorage) {
            // TODO: Improve: Invoke change for actually changed items instead of full items list 
            _packs = _shopPacksProvider.GetAvailablePacks();

            for (int i = 0; i < _packs.Count; i++) {
                PackChanged?.Invoke(new ChangedPackData {
                    Pack = _packs[i],
                    WasPurchased = purchasedItemsStorage.HasUniqueItem(_packs[i].Id)
                });
            }
        }
    }
}