using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Linq;
using System.Net;
using SemenaParse.Mongo;

namespace SemenaParse
{
    class InternalOperations
    {
        public static string GetManufacturerId(string manufacturerName)
        {
            if (manufacturerName != null)
            {
                StringsDefault.ManufacterNameToId.TryGetValue(manufacturerName, out string result);
                return result;
            }
            else
            {
                StringsDefault.ManufacterNameToId.TryGetValue("Lost manufacturer", out string result);
                return result;
            }
        }
        public static string GetCategoryId(string cultureName)
        {
            if (StringsDefault.CultureNameToCategoryId.TryGetValue(cultureName, out string result))
                return result;
            else
            {
                StringsDefault.CultureNameToCategoryId.TryGetValue("Lost category", out string resulte);
                return resulte;
            }
        }
        public static string GetPicturePath(string productId, int numberOfPicture)
        {
            string path = @"C:\Users\Vladimir\Desktop\ProductImgs\" + productId + "_" + numberOfPicture + ".jpg";
            if (File.Exists(path))
                return path;
            else
                return "";
        }
    }
    class OperationsWithMongo
    {
        public void DownloadImagines(int page)
        {
            var collection = StringsDefault.Database.GetCollection<BaseProductInfo>(StringsDefault.Categorys[page]);
            var filter = new BsonDocument();
            var products = collection.Find(filter).ToList();
            foreach (var product in products)
            {
                int multyImg = 0;
                foreach (string imgUrl in product.Imga)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(imgUrl, product.Id + "_" + multyImg + ".jpg");
                        multyImg++;
                    }
                }
            }
        }
        public void AdditionProductAttributesToSemeNowProductCollection()
        {
             MetodsSet.SettingProductSpecificationAtributesToSemeNow();
        }
        public void ReplaceProductField(string field, object searchingValue, object insertedValue)
        {
            var filter = Builders<ProductModel>
                .Filter.Eq(field, searchingValue);
            var update = Builders<ProductModel>
                .Update.Set(field, insertedValue);

            IMongoCollection<ProductModel> collectionProducts =
                StringsDefault.DatabaseSemeNow.GetCollection<ProductModel>("Product");
            collectionProducts.UpdateMany(filter, update);
        }
        public void ReplaceField(string field, object searchingValue, object insertedValue)
        {
            var filter = Builders<BaseProductInfo>
                .Filter.Eq(field, searchingValue);
            var update = Builders<BaseProductInfo>
                .Update.Set(field, insertedValue);

            for (int i = 0; i < 33; i++) 
            {
                IMongoCollection<BaseProductInfo> collectionProducts =
                    StringsDefault.DatabaseSemeNow.GetCollection<BaseProductInfo>(StringsDefault.Categorys[i]);
                collectionProducts.UpdateMany(filter, update);
            }
        }
        public void BackupProductInfo()
        {
            var filter = new BsonDocument();
            for (int i = 0; i < 33; i++)
            {
                IMongoCollection<BaseProductInfo> collectionSeedInfoBase =
                    StringsDefault.Database.GetCollection<BaseProductInfo>(StringsDefault.Categorys[i]);
                IMongoCollection<BaseProductInfo> collectionSeedInfoCopy =
                    StringsDefault.Database.GetCollection<BaseProductInfo>(StringsDefault.Categorys[i]);
            }
        }
    }
}
