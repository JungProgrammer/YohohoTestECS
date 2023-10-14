using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Systems.Input;
using YohohoTest._src.CodeBase.Ecs.Systems.Movement;
using YohohoTest._src.CodeBase.Ecs.Systems.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Core
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] 
        private StaticData _staticData;
        
        
        [SerializeField] 
        private SceneData _sceneData;


        [SerializeField] 
        private AssetConfig _assetConfig;
        
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private IAssetsProvider _assetsProviderService;
        private IStoragesDataKeeperService _storagesDataKeeperService;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            InitializeAssetsServices();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            
            _systems
                .Add(new InitSpawnPlayerDataSystem())
                .Add(new InitSpawnCameraDataSystem())
                .Add(new SpawnSystem())
                .Add(new PlayerInputHandlerSystem())
                .Add(new PlayerMovementSystem())
                .Inject(_staticData)
                .Inject(_sceneData)
                .Inject(_assetsProviderService)
                .Inject(_storagesDataKeeperService)
                .Init();
        }

        private void InitializeAssetsServices()
        {
            _assetsProviderService = new AssetProvider(_assetConfig);
            _storagesDataKeeperService = new StoragesDataKeeperService(_assetsProviderService);
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}