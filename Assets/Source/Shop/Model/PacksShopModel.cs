using System;
using System.Collections.Generic;
using Source.Shop.Data;
using Source.UserData;

namespace Source.Shop.Model {
    public class PacksShopModel : IShopModel {
        public event Action<ChangedData> PackChanged;

        private readonly IShopPacksProvider _shopPacksProvider;

        private List<ShopPackData> _packs;

        public PacksShopModel(IShopPacksProvider shopPacksProvider) {
            _shopPacksProvider = shopPacksProvider;
        }

        public void UpdateItems(IPurchasedItemsStorage purchasedItemsStorage) {
            // TODO: Improve: Invoke change for actually changed items instead of full items list 
            _packs = _shopPacksProvider.GetAvailablePacks();

            for (int i = 0; i < _packs.Count; i++) {
                PackChanged?.Invoke(new ChangedData {
                    Data = _packs[i],
                    WasPurchased = purchasedItemsStorage.HasUniqueItem(_packs[i].Id)
                });
            }
        }
    }
}
