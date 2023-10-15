using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Events.Physic;
using YohohoTest._src.CodeBase.Ecs.Components.Links;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Physic
{
    public class DeactivateColliderSystem : IEcsRunSystem
    {
        private EcsFilter<ColliderLink, DeactivateColliderEvent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref ColliderLink colliderLink = ref _filter.Get1(index);
                colliderLink.Value.enabled = false;
            }
        }
    }
}