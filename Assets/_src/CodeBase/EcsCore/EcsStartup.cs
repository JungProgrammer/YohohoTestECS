using _src.CodeBase.UnityComponents.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace _src.CodeBase.EcsCore
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] 
        private SceneData _sceneData;
        
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
		
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);

#endif
            _systems
                .Inject(_sceneData)
                .Init();
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