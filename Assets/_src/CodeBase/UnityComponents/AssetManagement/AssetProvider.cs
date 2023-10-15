using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.ScriptableObjectsData;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement
{
    public class AssetProvider : IAssetsProvider
    {
        private readonly AssetConfig _assetConfig;


        public ItemViewsDataCollection ItemViewsDataCollection => _assetConfig.ItemViewsDataCollection;
        public HandObjectsDataCollection HandObjectsViewsDataCollection => _assetConfig.HandObjectsDataCollection;

        public AssetProvider(AssetConfig assetConfig)
        {
            _assetConfig = assetConfig;
        }

        public GameObject GetPrefab(string path) =>
            Resources.Load<GameObject>(path);
    }
}