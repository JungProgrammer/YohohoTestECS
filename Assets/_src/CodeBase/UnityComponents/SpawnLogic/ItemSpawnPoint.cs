using UnityEngine;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.SerializableData;

namespace YohohoTest._src.CodeBase.UnityComponents.SpawnLogic
{
    public class ItemSpawnPoint : MonoBehaviour
    {
        [SerializeField] 
        private ItemType _itemType;


        public ItemType ItemType => _itemType;
    }
}