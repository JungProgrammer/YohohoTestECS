using UnityEngine;

namespace YohohoTest._src.CodeBase.Ecs.Components.Movement
{
    public struct MovementData
    {
        public Transform MovementTransform;
        public Vector3 TargetPosition;
        public float MovementSpeed;
    }
}