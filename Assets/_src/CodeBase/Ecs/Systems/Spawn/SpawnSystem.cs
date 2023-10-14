using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Spawn
{
    public class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private SceneData _sceneData;

        private EcsFilter<SpawnData> _filter;

        private PrefabFactory _factory;
        
        public void PreInit()
        {
            _factory = _sceneData.PrefabFactory;
            _factory.SetWorld(_world);
        }

        public void Run()
        {
            if (_filter.IsEmpty())
                return;

            
            foreach (int index in _filter)
            {
                ref EcsEntity spawnEntity = ref _filter.GetEntity(index);
                var spawnPrefabData = spawnEntity.Get<SpawnData>();
                _factory.Spawn(spawnPrefabData);
                spawnEntity.Del<SpawnData>();
            }
        }
    }
}