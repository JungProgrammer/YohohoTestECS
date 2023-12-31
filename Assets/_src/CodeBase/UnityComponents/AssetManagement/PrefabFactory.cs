using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Objects;
using YohohoTest._src.CodeBase.Ecs.Components.Spawn;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement
{
    public class PrefabFactory : MonoBehaviour
    {
        private EcsWorld _world;
		
        public void SetWorld(EcsWorld world)
        {
            _world = world;
        }
		
        public void Spawn(SpawnData spawnData)
        {
            GameObject prefabInstance = Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation, spawnData.Parent);
            var monoEntity = prefabInstance.GetComponent<MonoEntity>();
            if (monoEntity == null) 
                return;
            
            
            EcsEntity ecsEntity = _world.NewEntity();
            if (!spawnData.SpawnerEntity.IsNull())
            {
                ecsEntity.Get<SpawnerEntity>() = new SpawnerEntity()
                {
                    Value = spawnData.SpawnerEntity
                };
            }
            monoEntity.Make(ref ecsEntity);
        }
    }
}