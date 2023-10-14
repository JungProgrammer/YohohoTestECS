using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Spawn
{
    public class SpawnerItemsInitSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private IStoragesDataKeeperService _storagesDataKeeperService;
        
        private EcsFilter<SpawnerData> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref SpawnerData spawnerData = ref _filter.Get1(index);
                
                if (spawnerData.SpawnIsForbidden)
                    continue;

                spawnerData.TimeSinceLastSpawn += Time.deltaTime;
                if (spawnerData.TimeSinceLastSpawn < spawnerData.SpawnRate)
                    continue;


                spawnerData.TimeSinceLastSpawn = 0;

                EcsEntity spawnerEntity = _filter.GetEntity(index);
                if (spawnerEntity.Has<SingleSpawnTag>())
                    spawnerData.SpawnIsForbidden = true;

                _world.NewEntity().Get<SpawnData>() = new SpawnData()
                {
                    Prefab = _storagesDataKeeperService.ItemViewsDataStorage.GetData(spawnerData.ItemType).ViewTransform.gameObject,
                    Parent = null,
                    Position = spawnerData.SpawnPosition,
                    Rotation = Quaternion.identity,
                    SpawnerEntity = _filter.GetEntity(index)
                };
            }
        }
    }
}