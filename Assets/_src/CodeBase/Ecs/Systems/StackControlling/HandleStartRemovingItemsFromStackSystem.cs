using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.Events.Physic;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Tags;

namespace YohohoTest._src.CodeBase.Ecs.Systems.StackControlling
{
    public class HandleStartRemovingItemsFromStackSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<ItemsStockTag, OnTriggerEnterEvent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                OnTriggerEnterEvent triggerEnterEvent = _filter.Get2(index);
                
                if (!triggerEnterEvent.Collider.TryGetComponent(out StackTagMonoLink stackTagMonoLink))
                    continue;


                _world.NewEntity().Get<StackRemovingToStock>() = new StackRemovingToStock()
                {
                    StockEntity = _filter.GetEntity(index),
                    RemoveDelay = _filter.Get1(index).CollectItemsDelay,
                    CurrentRemoveDelay = 0
                };
            }
        }
    }
}