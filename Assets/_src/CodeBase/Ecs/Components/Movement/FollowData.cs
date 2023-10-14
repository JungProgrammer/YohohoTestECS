using UnityEngine;

namespace YohohoTest._src.CodeBase.Ecs.Components.Movement
{
    public struct FollowData
    {
        public float Speed;
        public Transform Target;
        public Vector3 CurrentVelocity;
        public Vector3 Offset;
    }
}