using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Spawn
{
    public class InitSpawnStockSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private IAssetsProvider _assetsProvider;
        
        
        public void Init()
        {
            GameObject spawnPrefab = _assetsProvider.GetPrefab(AssetPath.ItemsStock);
            
            _world.NewEntity().Get<SpawnData>() = new SpawnData()
            {
                Prefab = spawnPrefab,
                Position = spawnPrefab.transform.position,
                Rotation = spawnPrefab.transform.rotation,
                Parent = null,
            };
        }
    }
}