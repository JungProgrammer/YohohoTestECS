using YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages.Storages;

namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages
{
    public class StoragesDataKeeperService : IStoragesDataKeeperService
    {
        private readonly ItemViewsDataStorage _itemViewsDataStorage;
        private readonly HandObjectsViewsDataStorage _handObjectsViewsDataStorage;

        public ItemViewsDataStorage ItemViewsDataStorage => _itemViewsDataStorage;
        public HandObjectsViewsDataStorage HandObjectsViewsDataStorage => _handObjectsViewsDataStorage;


        public StoragesDataKeeperService(IAssetsProvider assetsProvider)
        {
            _itemViewsDataStorage = new ItemViewsDataStorage(assetsProvider);
            _handObjectsViewsDataStorage = new HandObjectsViewsDataStorage(assetsProvider);
        }
    }
}