using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.SerializableData;

namespace YohohoTest._src.CodeBase.Ecs.Components.Spawn
{
    public struct SpawnerData
    {
        public ItemType ItemType;
        public Vector3 SpawnPosition;
        public float SpawnRate;
        public float TimeSinceLastSpawn;
        public bool SpawnIsForbidden;
    }
}