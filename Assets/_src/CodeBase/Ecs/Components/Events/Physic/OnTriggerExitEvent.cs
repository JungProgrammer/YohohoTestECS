using UnityEngine;

namespace YohohoTest._src.CodeBase.Ecs.Components.Events.Physic
{
    public struct OnTriggerExitEvent
    {
        public GameObject Sender;
        public Collider Collider;
    }
}