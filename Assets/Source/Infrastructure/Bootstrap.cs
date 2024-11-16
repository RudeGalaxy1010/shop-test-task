using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private ShopItemView shopItemViewPrefab;
        [SerializeField] private PacksShopView shopView;
        [SerializeField] private AllPacksData _allPacksData;

        [Header("Test values")]
        [SerializeField] private int _startBalance;
        [SerializeField] private List<ShopPackData> _purchasedPacks;

        private void Start() {
            List<string> purchasedItemsIds = _purchasedPacks?.Where(x => x != null).Select(x => x.Id).ToList();
            IUserDataService userDataService = new UserDataService(_startBalance, purchasedItemsIds);
            IShopPacksProvider shopPacksProvider = new DirectLinkShopPacksProvider(_allPacksData);
            IShopModel shopModel = new PacksShopModel(shopPacksProvider);
            
            shopView.Init(shopModel);
            
            IShopController shopController = new PacksShopController(userDataService, shopModel, shopView);
        }
    }
}
