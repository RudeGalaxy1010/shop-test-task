using System.Collections.Generic;
using System.Linq;
using Source.Exceptions;
using Source.Shop;
using Source.Shop.Controller;
using Source.Shop.Data;
using Source.Shop.Model;
using Source.Shop.View;
using Source.UserData;
using UnityEngine;

namespace Source.Infrastructure {
    public class Bootstrap : MonoBehaviour {
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private AllPacksData _allPacksData;
        [SerializeField] private PacksShopView _shopViewPrefab;
        [SerializeField] private UserBalanceView _userBalanceViewPrefab;
        [SerializeField] private ExceptionPopup _exceptionPopupPrefab;

        [Header("Test values")]
        [SerializeField] private int _startBalance;
        [SerializeField] private List<ShopPackData> _purchasedPacks;

        private void Start() {
            // Create scene objects
            IShopView shopView = Instantiate(_shopViewPrefab, _canvasTransform);
            UserBalanceView userBalanceView = Instantiate(_userBalanceViewPrefab, _canvasTransform);
            ExceptionPopup exceptionPopup = Instantiate(_exceptionPopupPrefab, _canvasTransform);
            
            // Setup user data
            List<string> purchasedItemsIds = _purchasedPacks?.Where(x => x != null).Select(x => x.Id).ToList();
            IUserDataService userDataService = new UserDataService(_startBalance, purchasedItemsIds);
            
            // Setup shop
            IShopPacksProvider shopPacksProvider = new DirectLinkShopPacksProvider(_allPacksData);
            IShopModel shopModel = new PacksShopModel(shopPacksProvider);
            
            shopView.Init(shopModel);

            IShopController shopController = new PacksShopController(
                userDataService, 
                shopModel, 
                shopView, 
                exceptionPopup);
            
            userBalanceView.Init(userDataService);
        }
    }
}
