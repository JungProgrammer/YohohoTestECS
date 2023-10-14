using UnityEngine;

namespace _src.CodeBase.UnityComponents.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] 
        private Transform _heroSpawnPoint;


        public Transform HeroSpawnPoint => _heroSpawnPoint;
    }
}