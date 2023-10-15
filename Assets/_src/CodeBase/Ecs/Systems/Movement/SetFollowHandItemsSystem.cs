using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Movement;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;
using YohohoTest._src.CodeBase.UnityComponents.Data;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Movement
{
    public class SetFollowHandItemsSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<HandItemTag, StackPlace>.Exclude<FollowData> _itemsFilter;
        private EcsFilter<PlayerTag, StackTag> _playerTag;

        public void Run()
        {
            foreach (int index in _itemsFilter)
            {
                StackPlace stackPlace = _itemsFilter.Get2(index);
                
                EcsEntity itemEntity = _itemsFilter.GetEntity(index);
                itemEntity.Get<FollowData>() = new FollowData()
                {
                    Speed = _staticData.BaseItemsFollowSpeed * CalculateDecreaseItemFollowCoefficient(stackPlace),
                    Target = _playerTag.Get2(0).StartStackPoint,
                    Offset = stackPlace.PlaceIndex * _staticData.HandItemsHeightValue * Vector3.up
                };
            }
        }

        private float CalculateDecreaseItemFollowCoefficient(StackPlace stackPlace)
        {
            if (stackPlace.PlaceIndex < 8)
                return 1;
            
            
            return 1 + (stackPlace.PlaceIndex + 1) / 3;
        } 
    }
}