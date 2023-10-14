using System;
using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement.SerializableData
{
    [Serializable]
    public class ItemViewData
    {
        [SerializeField] 
        private ItemType _id;


        [SerializeField] 
        private Transform _viewTransform;


        public ItemType ID => _id;
        public Transform ViewTransform => _viewTransform;
    }
}