using UnityEngine;

namespace YohohoTest._src.CodeBase.Ecs.Components.Events.Physic
{
    public struct OnTriggerEnterEvent
    {
        public GameObject Sender;
        public Collider Collider;
    }
}