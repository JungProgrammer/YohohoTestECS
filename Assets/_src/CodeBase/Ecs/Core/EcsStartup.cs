using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Events.Physic;
using YohohoTest._src.CodeBase.Ecs.Systems.Animations;
using YohohoTest._src.CodeBase.Ecs.Systems.DestroyControlling;
using YohohoTest._src.CodeBase.Ecs.Systems.Input;
using YohohoTest._src.CodeBase.Ecs.Systems.Movement;
using YohohoTest._src.CodeBase.Ecs.Systems.Physic;
using YohohoTest._src.CodeBase.Ecs.Systems.PlantsControlling;
using YohohoTest._src.CodeBase.Ecs.Systems.Rotation;
using YohohoTest._src.CodeBase.Ecs.Systems.Spawn;
using YohohoTest._src.CodeBase.Ecs.Systems.StackControlling;
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
                .Add(new InitPlantsSpawnerSystem())
                .Add(new SetFollowCameraSystem())
                .Add(new SpawnerItemsInitSystem())
                .Add(new SpawnSystem())
                .Add(new PlayerInputHandlerSystem())
                .Add(new PlayerMovementSystem())
                .Add(new PlayerRotationSystem())
                .Add(new PlayerRunAnimatorSystem())
                .Add(new MoveFollowsObjectsSystem())
                .Add(new PullingOutPlantsSystem())
                .Add(new PlantPullOutHandlerSystem())
                .Add(new GrowSystem())
                .Add(new SpawnerPlantHandItemsInitSystem())
                .Add(new HandAddItemsToStackSystem())
                .Add(new SetFollowHandItemsSystem())
                .Add(new DeactivateColliderSystem())
                .Add(new DestroyObjectsSystem())
                .OneFrame<PlantPulledOutEvent>()
                .OneFrame<OnTriggerEnterEvent>()
                .OneFrame<DeactivateColliderEvent>()
                .OneFrame<DestroyEvent>()
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