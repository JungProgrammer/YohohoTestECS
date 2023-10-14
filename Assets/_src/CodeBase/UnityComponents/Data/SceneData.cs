using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] 
        private Transform _heroSpawnPoint;


        public Transform HeroSpawnPoint => _heroSpawnPoint;
    }
}