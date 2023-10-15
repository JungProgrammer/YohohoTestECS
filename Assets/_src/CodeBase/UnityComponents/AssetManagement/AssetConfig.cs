using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.ScriptableObjectsData;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement
{
    [CreateAssetMenu(fileName = "Configs", menuName = "Configs/AssetConfig")]
    public class AssetConfig : ScriptableObject
    {
        public ItemViewsDataCollection ItemViewsDataCollection;
        public HandObjectsDataCollection HandObjectsDataCollection;
    }
}