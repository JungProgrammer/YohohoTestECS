using System.Collections.Generic;
using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.SerializableData;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages.Storages
{
    public class ItemViewsDataStorage : IStorageActions<ItemViewData, ItemType>
    {
        private Dictionary<ItemType, ItemViewData> _data;


        public ItemViewsDataStorage(IAssetsProvider assetsProvider) => 
            Load(assetsProvider);
        
        public ItemViewData GetData(ItemType id)
        {
            ItemViewData itemData = null;
            
            if (_data.ContainsKey(id)) 
                itemData = _data[id];

            return itemData;
        }

        public bool GetData(ItemType id, out ItemViewData itemData)
        {
            itemData = null;
            
            if (_data.ContainsKey(id))
            {
                itemData = _data[id];
                return true;
            }

            return false;
        }

        private void Load(IAssetsProvider assetsProvider)
        {
            List<ItemViewData> itemsData = assetsProvider.ItemViewsDataCollection.Data;
            _data = new Dictionary<ItemType, ItemViewData>();
            
            foreach (ItemViewData itemData in itemsData)
            {
                if (!_data.ContainsKey(itemData.ID))
                    _data.Add(itemData.ID, itemData);
            }
        }
    }
}