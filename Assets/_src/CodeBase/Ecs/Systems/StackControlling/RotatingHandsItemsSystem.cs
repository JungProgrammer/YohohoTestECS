using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;

namespace YohohoTest._src.CodeBase.Ecs.Systems.StackControlling
{
    public class RotatingHandsItemsSystem : IEcsRunSystem
    {
        private EcsFilter<StackTag, GameObjectLink> _stackFilter;
        private EcsFilter<HandItemTag, GameObjectLink, StackPlace> _itemsFilter;

        public void Run()
        {
            if (_stackFilter.IsEmpty())
                return;
            
            
            foreach (int index in _itemsFilter)
            {
                GameObjectLink stackGameObjectLink = _stackFilter.Get2(0);
                ref GameObjectLink itemGameObjectLink = ref _itemsFilter.Get2(index);

                itemGameObjectLink.Value.transform.rotation = Quaternion.LookRotation(stackGameObjectLink.Value.transform.forward);
            }
        }
    }
}