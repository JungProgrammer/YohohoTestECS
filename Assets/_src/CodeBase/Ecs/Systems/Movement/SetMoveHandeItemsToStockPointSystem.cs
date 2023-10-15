using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Movement;
using YohohoTest._src.CodeBase.Ecs.Components.Objects;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StockLogic;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Movement
{
    public class SetMoveHandeItemsToStockPointSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<HandItemTag, GameObjectLink, StockPlace, ItemReadyToStockMoveEvent> _filter;
        
        public void Run()
        {
            foreach (int index in _filter)
            {
                EcsEntity stockEntity = _filter.Get3(index).StockEntity;
                
                EcsEntity itemEntity = _filter.GetEntity(index);
                itemEntity.Get<MovementData>() = new MovementData()
                {
                    MovementTransform = _filter.Get2(index).Value.transform,
                    TargetPosition = stockEntity.Get<StockPoint>().Value.position + _filter.Get3(index).PlaceIndex * _staticData.HandItemsHeightValue * Vector3.up,
                    MovementSpeed = _staticData.MovementSpeedItemsForMoveToStocks,
                    MaxOffsetDistance = .5f
                };
            }
        }
    }
}