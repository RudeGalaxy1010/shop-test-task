using System.Collections.Generic;
using Source.Shop;
using Source.Shop.Data;
using Source.UserData;
using UnityEngine;

namespace Source.Infrastructure {
    public class Bootstrap : MonoBehaviour {
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private ShopItemView shopItemViewPrefab;
        [SerializeField] private PacksShopView _packsShopView;
        [SerializeField] private AllPacksData _allPacksData;

        private void Start() {
            IUserDataService userDataService = new UserDataService(0, new List<string>());
            IShopPacksProvider shopPacksProvider = new DirectLinkShopPacksProvider(_allPacksData);
            PacksShopModel shopModel = new PacksShopModel(shopPacksProvider);
            
            _packsShopView.Init(shopModel);
            
            PacksShopController shopController = new PacksShopController(userDataService, shopModel, _packsShopView);
        }
    }
}
