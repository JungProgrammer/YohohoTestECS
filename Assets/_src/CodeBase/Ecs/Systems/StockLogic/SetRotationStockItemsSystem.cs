using DG.Tweening;
using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StockLogic;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.StockLogic
{
    public class SetRotationStockItemsSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<HandItemTag, ItemReadyToStockMoveEvent>.Exclude<StockPlace> _filter;

        
        public void Run()
        {
            foreach (int index in _filter)
            {
                GameObjectLink itemGameObjectLink = _filter.GetEntity(index).Get<GameObjectLink>();
                StockPoint stockPoint = _filter.Get2(index).StockEntity.Get<StockPoint>();

                itemGameObjectLink.Value.transform.DORotateQuaternion(stockPoint.Point.rotation, _staticData.RotationItemsTimeAfterSetToStocks);
            }
        }
    }
}