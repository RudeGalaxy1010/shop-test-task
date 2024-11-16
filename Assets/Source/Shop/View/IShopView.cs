using System;
using Source.Shop.Model;

namespace Source.Shop.View {
    public interface IShopView {
        event Action<string, int> PurchaseRequested;
        void Init(IShopModel shopModel);
    }
}
