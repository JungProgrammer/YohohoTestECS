using Leopotam.Ecs;
using UnityEngine;
using YohohoTest._src.CodeBase.Ecs.Components.Events.Physic;
using YohohoTest._src.CodeBase.UnityComponents.MonoLinks.Base;

namespace YohohoTest._src.CodeBase.UnityComponents.MonoLinks.PhysicsLinks
{
    public class OnTriggerExitMonoLink : PhysicsLinkBase
    {
        private void OnTriggerExit(Collider other)
        {
            _entity.Get<OnTriggerExitEvent>() = new OnTriggerExitEvent()
            {
                Collider = other,
                Sender = gameObject
            };
        }
    }
}