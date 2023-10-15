using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StockLogic;

namespace YohohoTest._src.CodeBase.Ecs.Systems.StockLogic
{
    public class SetStockPlaceForItemsSystem : IEcsRunSystem
    {
        private EcsFilter<HandItemTag, StockPlace> _insideStokeItemsFilter;
        private EcsFilter<HandItemTag, ItemReadyToStockMoveEvent>.Exclude<StockPlace> _outsideStokeItemsFilter;


        public void Run()
        {
            foreach (int index in _outsideStokeItemsFilter)
            {
                int secondStokePlaceIndex = GetSecondStokePlaceIndex();
                
                _outsideStokeItemsFilter.GetEntity(index).Get<StockPlace>() = new StockPlace()
                {
                    PlaceIndex = secondStokePlaceIndex,
                    StockEntity = _outsideStokeItemsFilter.Get2(index).StockEntity
                };
            }
        }

        private int GetSecondStokePlaceIndex()
        {
            int maxIndex = 0;

            foreach (int insideItemIndex in _insideStokeItemsFilter)
            {
                StockPlace stackPlace = _insideStokeItemsFilter.Get2(insideItemIndex);

                if (stackPlace.PlaceIndex >= maxIndex)
                    maxIndex = stackPlace.PlaceIndex + 1;
            }

            return maxIndex;
        }
    }
}