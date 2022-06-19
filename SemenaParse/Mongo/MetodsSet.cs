using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace SemenaParse.Mongo
{
    internal class MetodsSet : MethodsWithSpecificationAttributes
    {
        public static void SettingProductSpecificationAtributesToSemeNow()
        {
            IMongoCollection<ProductModel> productsCollection =
                StringsDefault.DatabaseSemeNow.GetCollection<ProductModel>("Product");

            var filter = new BsonDocument();
            var productModels = productsCollection.Find(filter).ToList();
            foreach (var productModel in productModels)
            {
                if (productModel.ProductSpecificationAttributes.Count == 0)
                {
                    int i = ProductPageCategory(productModel.MetaTitle);

                    IMongoCollection<BaseProductInfo> baseProductsCollection =
                       StringsDefault.Database.GetCollection<BaseProductInfo>(StringsDefault.Categorys[i]);
                    
                    var baseFilter = Builders<BaseProductInfo>.Filter.Eq(e => e.Id, productModel.Mpn.ToString());

                    var filtredModels = baseProductsCollection.Find(baseFilter).ToList();
                    foreach (var baseProductModel in filtredModels)
                    {
                        if (productModel.Mpn.ToString() == baseProductModel.Id)
                        {
                            if (baseProductModel.Culture != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Культура", baseProductModel.Culture);
                            if (baseProductModel.RipeningPeriodStr != null)

                                AddingSpecificationAttribute(productModel.Mpn, "Период созревания", baseProductModel.RipeningPeriodStr);
                            if (baseProductModel.RipeningPeriodDays != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Срок созревания (дней)", baseProductModel.RipeningPeriodDays);
                            if (baseProductModel.DiseaseResistance != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Устойчивость к болезням", baseProductModel.DiseaseResistance);
                            if (baseProductModel.PulpColor != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Цвет мякоти", baseProductModel.PulpColor);
                            if (baseProductModel.Shape != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Форма плода", baseProductModel.Shape);
                            if (baseProductModel.HeatDroughtTolerance != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Устойчивость к жаре и засухе", baseProductModel.HeatDroughtTolerance);
                            if (baseProductModel.KeepingQuality != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Хорошая лёжкость", baseProductModel.KeepingQuality);
                            if (baseProductModel.Transportability != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Хорошая транспортабельность", baseProductModel.Transportability);
                            if (baseProductModel.Color != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Цвет плода", baseProductModel.Color);
                            if (baseProductModel.NumberOfSeeds != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Количество семян", baseProductModel.NumberOfSeeds);
                            if (baseProductModel.Lenght != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Длинна плода", baseProductModel.Lenght);
                            if (baseProductModel.Height != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Высота растения", baseProductModel.Height);
                            if (baseProductModel.Weight != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Вес плода", baseProductModel.Weight);
                            if (baseProductModel.Width != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Ширина плода", baseProductModel.Width);
                            if (baseProductModel.NumberOfGrainsInPod != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Количество зерен в стручке", baseProductModel.NumberOfGrainsInPod);
                            if (baseProductModel.ResilienceToStressfulConditions != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Устойчивость к стрессовым условиям", baseProductModel.ResilienceToStressfulConditions);
                            if (baseProductModel.ColorResistance != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Устойчивость к цветению", baseProductModel.ColorResistance);
                            if (baseProductModel.VegetationPeriodDays != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Вегетационный период (дней)", baseProductModel.VegetationPeriodDays);
                            if (baseProductModel.Type != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Вид", baseProductModel.Type);
                            if (baseProductModel.SortType != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Сортотип", baseProductModel.SortType);
                            if (baseProductModel.WallThickness != null)
                                AddingSpecificationAttribute(productModel.Mpn, "Толщина стенок", baseProductModel.WallThickness);
                            _ = 1;
                        }
                    }
                }
            }
        }
    }
}
