using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Movement;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Movement
{
    public class SetMoveHandeItemsToStockPointSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<HandItemTag, GameObjectLink, MoveToStockData> _filter;
        
        public void Run()
        {
            foreach (int index in _filter)
            {
                EcsEntity itemEntity = _filter.GetEntity(index);
                itemEntity.Get<MovementData>() = new MovementData()
                {
                    MovementTransform = _filter.Get2(index).Value.transform,
                    TargetPosition = _filter.Get3(index).StockPoint.Value.position,
                    MovementSpeed = _staticData.MovementSpeedItemsForMoveToStocks,
                    MaxOffsetDistance = .2f
                };

                itemEntity.Del<MoveToStockData>();
            }
        }
    }
}