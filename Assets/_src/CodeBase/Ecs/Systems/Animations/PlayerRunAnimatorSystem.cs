using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Links;
using YohohoTest._src.CodeBase.Ecs.Components.Objects.Tags;
using YohohoTest._src.CodeBase.Ecs.Components.PlayerInput;

namespace YohohoTest._src.CodeBase.Ecs.Systems.Animations
{
    public class PlayerRunAnimatorSystem : IEcsRunSystem
    {
        private static int SpeedAnimatorKey = Animator.StringToHash("Speed");
        
        private EcsFilter<PlayerTag, AnimatorLink, MovementInputData> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref AnimatorLink animatorLink = ref _filter.Get2(index);
                MovementInputData movementInputData = _filter.Get3(index);
                
                animatorLink.Value.SetFloat(SpeedAnimatorKey, movementInputData.Direction.magnitude);
            }
        }
    }
}