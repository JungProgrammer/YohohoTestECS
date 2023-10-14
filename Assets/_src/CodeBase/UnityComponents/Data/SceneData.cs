using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement;

namespace YohohoTest._src.CodeBase.UnityComponents.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] 
        private Transform _heroSpawnPoint;

        
        [SerializeField]
        private PrefabFactory _prefabFactory;


        public Transform HeroSpawnPoint => _heroSpawnPoint;
        public PrefabFactory PrefabFactory => _prefabFactory;
    }
}