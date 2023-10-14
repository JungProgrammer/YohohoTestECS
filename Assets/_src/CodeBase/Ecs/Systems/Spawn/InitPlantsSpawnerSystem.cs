using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.Data;
using YohohoTest._src.CodeBase.UnityComponents.SpawnLogic;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Spawn
{
    public class InitPlantsSpawnerSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        
        private SceneData _sceneData;
        private StaticData _staticData;
        
        public void Init()
        {
            foreach (ItemSpawnPoint itemSpawnPoint in _sceneData.PlantsSpawnPoints)
            {
                _world.NewEntity().Get<SpawnerData>() = new SpawnerData()
                {
                    ItemType = itemSpawnPoint.ItemType,
                    SpawnPosition = itemSpawnPoint.transform.position,
                    SpawnRate = Random.Range(_staticData.SpawnRateRange.x, _staticData.SpawnRateRange.y),
                    TimeSinceLastSpawn = 0
                };
            }
        }
    }
}