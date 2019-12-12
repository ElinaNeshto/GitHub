using to.Models;

namespace to.Storage
{
    public class StorageService
    {
        private readonly IStorage<lr1Data> _storage;

        public StorageService(IStorage<lr1Data> storage)
        {
            _storage = storage;
        }

        public string GetStorageType()
        {
            return _storage.StorageType;
        }

        public int GetNumberOfItems()
        {
            return _storage.All.Count;
        }
    }
}