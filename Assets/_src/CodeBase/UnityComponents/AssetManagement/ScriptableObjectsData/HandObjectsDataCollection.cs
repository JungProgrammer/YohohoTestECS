using System.Collections.Generic;
using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.SerializableData;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement.ScriptableObjectsData
{
    [CreateAssetMenu(fileName = "HandObjectsCollectionConfig", menuName = "Configs/HandObjectsCollectionConfig")]
    public class HandObjectsDataCollection : ScriptableObject
    {
        [SerializeField] 
        private List<ItemViewData> _data;

        public List<ItemViewData> Data => _data;
    }
}