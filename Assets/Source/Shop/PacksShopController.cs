using Source.UserData;

namespace Source.Shop {
    public class PacksShopController {
        private readonly IUserDataService _userDataService;
        private readonly PacksShopModel _shopModel;
        private readonly PacksShopView _packsShopView;

        public PacksShopController(IUserDataService userDataService, PacksShopModel shopModel, 
            PacksShopView packsShopView) {
            _userDataService = userDataService;
            _shopModel = shopModel;
            _packsShopView = packsShopView;
            
            _shopModel.UpdateItems(_userDataService);
        }
    }
}
