using UnityEngine;

namespace Source.Shop.Data {
    [CreateAssetMenu(menuName = "Data/" + nameof(ShopItemData), fileName = nameof(ShopItemData))]
    public class ShopItemData : ScriptableObject {
        public string Id;
        public Sprite Icon;
    }
}
