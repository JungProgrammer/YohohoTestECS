using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.Data
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Hero")]
        public float HeroMovementSpeed;
        public float HeroRotationSpeed;
        

        [Space(20)]
        [Header("Camera")]
        public float CameraSpeed;
        public Vector3 CameraOffset;


        [Space(20)]
        [Header("Plants")]
        public Vector2 SpawnRateRange;


        [Space(20)] 
        [Header("Stack items settings")]
        public float BaseItemsFollowSpeed;
        public float HandItemsHeightValue;


        [Space(20)] 
        [Header("Stocks settings")]
        public float MovementSpeedItemsForMoveToStocks;
    }
}