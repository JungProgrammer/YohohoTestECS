using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Movement;
using YohohoTest._src.CodeBase.Ecs.Components.Objects;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;

namespace YohohoTest._src.CodeBase.Ecs.Systems.StackControlling
{
    public class HandleRemoveItemsFromStackSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        
        private EcsFilter<StackRemovingToStock> _removeFilter;
        private EcsFilter<HandItemTag, StackPlace>.Exclude<RemovedFromStackTag> _itemsInsideStackFilter;


        public void Run()
        {
            if (_itemsInsideStackFilter.IsEmpty())
                return;
            
            
            foreach (int removeIndex in _removeFilter)
            {
                ref StackRemovingToStock stackRemovingToStock = ref _removeFilter.Get1(removeIndex);

                stackRemovingToStock.CurrentRemoveDelay += Time.deltaTime;
                if (stackRemovingToStock.CurrentRemoveDelay < stackRemovingToStock.RemoveDelay)
                    continue;


                stackRemovingToStock.CurrentRemoveDelay = 0;
                EcsEntity topItem = GetTopItemFromStack();
                topItem.Del<FollowData>();
                topItem.Get<RemovedFromStackTag>() = new RemovedFromStackTag();
                topItem.Get<MoveToStockData>() = new MoveToStockData()
                {
                    StockPoint = stackRemovingToStock.StockEntity.Get<StockPoint>()
                };

                _world.NewEntity().Get<HandItemsCountChangedEvent>();
            }
        }

        private EcsEntity GetTopItemFromStack()
        {
            EcsEntity topItemEntity = default;
            int maxIndex = 0;
            
            foreach (int index in _itemsInsideStackFilter)
            {
                if (_itemsInsideStackFilter.Get2(index).PlaceIndex >= maxIndex)
                {
                    topItemEntity = _itemsInsideStackFilter.GetEntity(index);
                    maxIndex = _itemsInsideStackFilter.Get2(index).PlaceIndex;
                }
            }

            return topItemEntity;
        }
    }
}