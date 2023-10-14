using System.Collections.Generic;
using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement;
using YohohoTest._src.CodeBase.UnityComponents.SpawnLogic;

namespace YohohoTest._src.CodeBase.UnityComponents.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] 
        private Transform _heroSpawnPoint;
        
        
        [SerializeField]
        private PrefabFactory _prefabFactory;
        
        
        [SerializeField] 
        private List<ItemSpawnPoint> _plantsSpawnPoints;
        
        
        public Transform HeroSpawnPoint => _heroSpawnPoint;
        public PrefabFactory PrefabFactory => _prefabFactory;
        public List<ItemSpawnPoint> PlantsSpawnPoints => _plantsSpawnPoints;
    }
}