using System.Collections.Generic;
using UnityEngine;

namespace Source.Shop.Data {
    [CreateAssetMenu(menuName = "Config/" + nameof(ShopPackItemData), fileName = nameof(ShopPackItemData))]
    public class ShopPackItemData : ScriptableObject {
        public string Name;
        public string Description;
        public Sprite Icon;
        public int Price;
        public int Oldrice;
        public List<PackData> Items;
    }
}
