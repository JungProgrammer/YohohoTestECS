using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.Events.Physic;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Tags;

namespace YohohoTest._src.CodeBase.Ecs.Systems.StackControlling
{
    public class HandleStopRemovingItemsFromStackSystem : IEcsRunSystem
    {
        private EcsFilter<ItemsStockTag, OnTriggerExitEvent> _triggerFilter;
        private EcsFilter<StackRemovingToStock> _removingFilter;
        
        
        public void Run()
        {
            foreach (int triggerIndex in _triggerFilter)
            {
                OnTriggerExitEvent onTriggerExitEvent = _triggerFilter.Get2(triggerIndex);
                
                if (!onTriggerExitEvent.Collider.TryGetComponent(out StackTagMonoLink stackTagMonoLink))
                    continue;


                foreach (int removeIndex in _removingFilter)
                {
                    if (_triggerFilter.GetEntity(triggerIndex) != _removingFilter.Get1(removeIndex).StockEntity)
                        continue;
                    
                    
                    _removingFilter.GetEntity(removeIndex).Del<StackRemovingToStock>();
                }
            }
        }
    }
}