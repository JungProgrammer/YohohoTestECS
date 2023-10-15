using System;
using Leopotam.Ecs;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.SerializableData;

namespace YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags.Plants
{
    [Serializable]
    public struct PlantTag : IEcsIgnoreInFilter
    {
        public ItemType ItemType;
    }
}