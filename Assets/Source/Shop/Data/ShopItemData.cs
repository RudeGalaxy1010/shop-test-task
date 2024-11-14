using UnityEngine;

namespace Source.Shop.Data {
    [CreateAssetMenu(menuName = "Config/" + nameof(ShopItemData), fileName = nameof(ShopItemData))]
    public class ShopItemData : ScriptableObject {
        public string Name;
        public Sprite Icon;
    }
}
