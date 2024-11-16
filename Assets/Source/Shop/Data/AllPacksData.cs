using System.Collections.Generic;
using UnityEngine;

namespace Source.Shop.Data {
    [CreateAssetMenu(menuName = "Data/" + nameof(AllPacksData), fileName = nameof(AllPacksData))]
    public class AllPacksData : ScriptableObject {
        public List<ShopPackData> AllPacks;
    }
}
