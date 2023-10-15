using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.StackLogic;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Animations
{
    public class PlayerCarrierAnimatorSystem : IEcsRunSystem
    {
        private static int Carrying = Animator.StringToHash("Carrying");

        private EcsFilter<PlayerTag, AnimatorLink> _playerFilter;
        private EcsFilter<HandItemTag, StackPlace>.Exclude<RemovedFromStackTag> _stackFilter;
        private EcsFilter<HandItemsCountChangedEvent> _eventFilter;


        public void Run()
        {
            if (_eventFilter.IsEmpty())
                return;


            foreach (int index in _playerFilter)
            {
                ref AnimatorLink animatorLink = ref _playerFilter.Get2(index);
                animatorLink.Value.SetBool(Carrying, _stackFilter.GetEntitiesCount() > 0);
            }
        }
    }
}