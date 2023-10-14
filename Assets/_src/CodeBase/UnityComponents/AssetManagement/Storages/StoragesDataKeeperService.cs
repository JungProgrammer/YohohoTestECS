using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages.Storages;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages
{
    public class StoragesDataKeeperService : IStoragesDataKeeperService
    {
        private readonly ItemViewsDataStorage _itemViewsDataStorage;
        
        public ItemViewsDataStorage ItemViewsDataStorage => _itemViewsDataStorage;


        public StoragesDataKeeperService(IAssetsProvider assetsProvider)
        {
            _itemViewsDataStorage = new ItemViewsDataStorage(assetsProvider);
        }
    }
}