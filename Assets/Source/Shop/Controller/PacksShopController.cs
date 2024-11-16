using System;
using Source.Shop.Model;
using Source.Shop.View;
using Source.UserData;
using UnityEngine;

namespace Source.Shop.Controller {
    public class PacksShopController : IShopController {
        private readonly IUserDataService _userDataService;
        private readonly IShopModel _shopModel;
        private readonly IShopView _shopView;

        public PacksShopController(IUserDataService userDataService, IShopModel shopModel, IShopView shopView) {
            _userDataService = userDataService;
            _shopModel = shopModel;
            _shopView = shopView;

            _shopView.PurchaseRequested += OnPurchaseRequested;
            _shopModel.UpdateItems(_userDataService);
        }

        private void OnPurchaseRequested(string id, int price) {
            Exception purchaseException = _userDataService.TryPurchaseUniqueItem(id, price);

            if (purchaseException != null) {
                Debug.LogError(purchaseException.Message);
                // No return to update item anyway for correct 'interactable' value
            }
            
            _shopModel.UpdateItems(_userDataService);
        }
    }
}
