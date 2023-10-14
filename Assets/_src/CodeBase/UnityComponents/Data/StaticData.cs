using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.Data
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Hero")]
        public float HeroMovementSpeed;
        public float HeroRotationSpeed;
        

        [Header("Camera")] 
        public float CameraSpeed;
        public Vector3 CameraOffset;
    }
}