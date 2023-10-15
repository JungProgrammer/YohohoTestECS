using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.ScriptableObjectsData;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement
{
    public interface IAssetsProvider
    {
        ItemViewsDataCollection ItemViewsDataCollection { get; }
        HandObjectsDataCollection HandObjectsViewsDataCollection { get; }

        GameObject GetPrefab(string path);
    }
}