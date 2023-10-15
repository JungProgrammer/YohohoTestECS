using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags.Plants;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Spawn
{
    public class SpawnerPlantHandItemsInitSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private IStoragesDataKeeperService _storagesDataKeeperService;
        
        private EcsFilter<PlantTag, GameObjectLink, PlantPulledOutEvent> _filter;


        public void Run()
        {
            foreach (int index in _filter)
            {
                PlantTag plantTag = _filter.Get1(index);
                GameObjectLink gameObjectLink = _filter.Get2(index);

                _world.NewEntity().Get<SpawnData>() = new SpawnData()
                {
                    Prefab = _storagesDataKeeperService.HandObjectsViewsDataStorage.GetData(plantTag.ItemType).ViewTransform.gameObject,
                    Position = gameObjectLink.Value.transform.position,
                    Rotation = Quaternion.identity,
                    Parent = null
                };
            }
        }
    }
}