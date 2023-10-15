using Leopotam.Ecs;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;

namespace YohohoTest._src.CodeBase.Ecs.Systems.StackControlling
{
    public class HandAddItemsToStackSystem : IEcsRunSystem
    {
        private EcsFilter<HandItemTag, StackPlace> _itemsInsideStackFilter;
        private EcsFilter<HandItemTag>.Exclude<StackPlace, RemovedFromStackTag> _itemsOutsideStackFilter;


        public void Run()
        {
            foreach (int outsideItemIndex in _itemsOutsideStackFilter)
            {
                int newStackPlaceIndex = GetSecondStackPlaceIndex();

                _itemsOutsideStackFilter.GetEntity(outsideItemIndex).Get<StackPlace>() = new StackPlace()
                {
                    PlaceIndex = newStackPlaceIndex
                };
            }
        }

        private int GetSecondStackPlaceIndex()
        {
            int maxIndex = 0;

            foreach (int insideItemIndex in _itemsInsideStackFilter)
            {
                StackPlace stackPlace = _itemsInsideStackFilter.Get2(insideItemIndex);

                if (stackPlace.PlaceIndex >= maxIndex)
                    maxIndex = stackPlace.PlaceIndex + 1;
            }

            return maxIndex;
        }
    }
}