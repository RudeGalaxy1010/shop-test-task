using System.Collections.Generic;
using UnityEngine;

namespace Source.Shop.Data {
    [CreateAssetMenu(menuName = "Config/" + nameof(ShopPackData), fileName = nameof(ShopPackData))]
    public class ShopPackData : ScriptableObject {
        public string Id;
        public string Name;
        public string Description;
        public Sprite Icon;
        public int Price;
        public int OldPrice;
        public List<PackItem> Items;
    }
}
