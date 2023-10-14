using UnityEngine;

namespace YohohoTest._src.CodeBase.Ecs.Components.Spawn
{
    public struct SpawnData
    {
        public GameObject Prefab;
        public Vector3 Position;
        public Quaternion Rotation;
        public Transform Parent;
    }
}