using System.Collections.Generic;
using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.ScriptableObjectsData;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement
{
    public class AssetProvider : IAssetsProvider
    {
        private readonly AssetConfig _assetConfig;
        

        public AssetProvider(AssetConfig assetConfig)
        {
            _assetConfig = assetConfig;
        }


        public ItemViewsDataCollection ItemViewsDataCollection => _assetConfig.ItemViewsDataCollection;
    }
}