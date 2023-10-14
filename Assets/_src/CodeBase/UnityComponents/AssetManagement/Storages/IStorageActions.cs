namespace YohohoTest._src.CodeBase.UnityComponents.AssetManagement.Storages
{
    public interface IStorageActions<T, TID>
    {
        T GetData(TID id);
        bool GetData(TID id, out T data);
    }
}