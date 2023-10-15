using TMPro;
using UnityEngine;

namespace YohohoTest._src.CodeBase.UnityComponents.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] 
        private string _textPrefix;
        
        
        [SerializeField] 
        private TextMeshProUGUI _itemsCountText;


        public void UpdateItemsCount(int count) =>
            _itemsCountText.text = $"{_textPrefix} {count.ToString()}";
    }
}