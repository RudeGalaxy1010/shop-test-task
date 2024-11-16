using System;
using Source.Shop.Data;
using Source.Shop.Model;
using Source.Shop.View;
using Source.UserData;
using UnityEngine;

namespace Source.Shop.Controller {
    public class PacksShopController {
        private readonly IUserDataService _userDataService;
        private readonly PacksShopModel _shopModel;
        private readonly PacksShopView _packsShopView;

        public PacksShopController(IUserDataService userDataService, PacksShopModel shopModel, 
            PacksShopView packsShopView) {
            _userDataService = userDataService;
            _shopModel = shopModel;
            _packsShopView = packsShopView;

            _packsShopView.PurchaseRequested += OnPurchaseRequested;
            _shopModel.UpdateItems(_userDataService);
        }

        private void OnPurchaseRequested(ShopPackData pack) {
            Exception purchaseException = _userDataService.TryPurchaseUniqueItem(pack.Id, pack.Price);

            if (purchaseException != null) {
                Debug.LogError(purchaseException.Message);
            }
            
            _shopModel.UpdateItems(_userDataService);
        }
    }
}
