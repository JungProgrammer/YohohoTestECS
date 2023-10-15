using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.UI
{
    public class HeadUpDisplay : MonoBehaviour
    {
        [SerializeField]
        private InventoryPanel _inventoryPanel;

        
        public InventoryPanel InventoryPanel => _inventoryPanel;
    }
}