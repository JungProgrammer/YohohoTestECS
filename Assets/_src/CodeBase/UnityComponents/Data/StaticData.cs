using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.Data
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        public float HeroSpeed;
    }
}