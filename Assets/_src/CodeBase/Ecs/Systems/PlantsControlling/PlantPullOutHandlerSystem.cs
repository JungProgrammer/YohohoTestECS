using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Objects;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags.Plants;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;

namespace YohohoTest._src.CodeBase.Ecs.Systems.PlantsControlling
{
    public class PlantPullOutHandlerSystem : IEcsRunSystem
    {
        private EcsFilter<PlantTag, PlantPulledOutEvent, SpawnerEntity> _plantsFilter;
        private EcsFilter<SpawnerData> _spawnersFilter;

        public void Run()
        {
            foreach (int plantIndex in _plantsFilter)
            {
                SpawnerEntity spawnerEntity = _plantsFilter.Get3(plantIndex);

                foreach (int spawnerIndex in _spawnersFilter)
                {
                    if (spawnerEntity.Value != _spawnersFilter.GetEntity(spawnerIndex))
                        continue;


                    ref SpawnerData spawnerData = ref spawnerEntity.Value.Get<SpawnerData>();
                    spawnerData.SpawnIsForbidden = false;
                }
            }
        }
    }
}