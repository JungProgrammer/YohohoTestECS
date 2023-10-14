using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Spawn
{
    public class InitSpawnPlayerDataSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private SceneData _sceneData;
        private IAssetsProvider _assetsProvider;

        public void Init()
        {
            _world.NewEntity().Get<SpawnData>() = new SpawnData()
            {
                Prefab = _assetsProvider.GetPrefab(AssetPath.Hero),
                Position = _sceneData.HeroSpawnPoint.position,
                Rotation = Quaternion.identity,
                Parent = null
            };
        }
    }
}