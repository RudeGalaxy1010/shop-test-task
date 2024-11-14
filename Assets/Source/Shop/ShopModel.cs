namespace Source.Shop {
    public class ShopModel {
        private readonly IShopPacksProvider _shopPacksProvider;

        public ShopModel(IShopPacksProvider shopPacksProvider) {
            _shopPacksProvider = shopPacksProvider;
        }
    }
}
