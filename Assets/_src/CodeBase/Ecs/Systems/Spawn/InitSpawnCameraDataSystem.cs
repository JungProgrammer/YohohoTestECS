using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Spawn
{
    public class InitSpawnCameraDataSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private IAssetsProvider _assetsProvider;
        
        public void Init()
        {
            _world.NewEntity().Get<SpawnData>() = new SpawnData()
            {
                Prefab = _assetsProvider.GetPrefab(AssetPath.Camera),
                Position = _assetsProvider.GetPrefab(AssetPath.Camera).transform.position,
                Rotation = _assetsProvider.GetPrefab(AssetPath.Camera).transform.rotation,
                Parent = null
            };
        }
    }
}