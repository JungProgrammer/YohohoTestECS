using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Links;

namespace YohohoTest._src.CodeBase.Ecs.Systems.DestroyControlling
{
    public class DestroyObjectsSystem : IEcsRunSystem
    {
        private EcsFilter<GameObjectLink, DestroyEvent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref GameObjectLink gameObjectLink = ref _filter.Get1(index);
                Object.Destroy(gameObjectLink.Value);
                
                _filter.GetEntity(index).Destroy();
            }
        }
    }
}