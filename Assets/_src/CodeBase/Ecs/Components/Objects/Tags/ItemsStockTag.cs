using System;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.SerializableData;

namespace YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags
{
    [Serializable]
    public struct ItemsStockTag
    {
        public ItemType ItemType;
        public float CollectItemsDelay;
    }
}