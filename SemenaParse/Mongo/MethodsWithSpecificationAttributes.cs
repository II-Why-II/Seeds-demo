using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace SemenaParse.Mongo
{
    class MethodsWithSpecificationAttributes
    {
        public static void AddingSpecificationAttribute(int productMpn, string nameSpecAttribute, string valueSpecAttributeOptions)
        {
            ProductSpecificationAttributes product = new ProductSpecificationAttributes();
            product._id = MyExtensions.RandomValueString();
            product.AttributeTypeId = 0;
            product.SpecificationAttributeId = GetSpecificationAttributeId(nameSpecAttribute);
            product.SpecificationAttributeOptionId = GetSpecAttributeOptionsId(nameSpecAttribute, valueSpecAttributeOptions);
            product.CustomValue = DefinitionCustomValueSpecAttributeOption(nameSpecAttribute, valueSpecAttributeOptions);
            if (nameSpecAttribute == "Культура" || nameSpecAttribute == "Количество семян")
                product.AllowFiltering = false;
            else
                product.AllowFiltering = true;
            product.ShowOnProductPage = true;
            product.DisplayOrder = 0;

            var filter = new BsonDocument("Mpn", productMpn.ToString());
            FieldDefinition<ProductModel> field = "ProductSpecificationAttributes";
            var update = Builders<ProductModel>.Update.Push(field, product);
            
            IMongoCollection<ProductModel> collectionProducts = 
                StringsDefault.DatabaseSemeNow.GetCollection<ProductModel>("Product");
            collectionProducts.FindOneAndUpdate(filter, update);
            _ = 1;
        }
        public static string GetSpecificationAttributeId(string nameAttribute)
        {
            var filter = new BsonDocument();
            IMongoCollection<SpecificationAttributeModel> collectionAttributes =
                StringsDefault.DatabaseSemeNow.GetCollection<SpecificationAttributeModel>("SpecificationAttribute");

            var arrayAttributes = collectionAttributes.Find(filter).ToList();
            foreach (var attribute in arrayAttributes)
                if (attribute.Name == nameAttribute)
                    return attribute._id;
            return "";
        }
        public static string GetSpecAttributeOptionsId(string nameAttribute, string valueOptions)
        {
            var filter = new BsonDocument();
            IMongoCollection<SpecificationAttributeModel> collectionAttributes =
                StringsDefault.DatabaseSemeNow.GetCollection<SpecificationAttributeModel>("SpecificationAttribute");

            var arrayAttributes = collectionAttributes.Find(filter).ToList();
            foreach(var attribute in arrayAttributes)
            {
                if (attribute.Name == nameAttribute)
                {
                    foreach(var specificationAttributeOption in attribute.SpecificationAttributeOptions)
                    {
                        if (specificationAttributeOption.Name == DefinitionCustomValueSpecAttributeOption(nameAttribute, valueOptions))
                            return specificationAttributeOption._id;
                    }
                    return CreateNewSpecificationAttributeOptions(attribute._id, valueOptions);//DefinitionSpecificationAttributes.DefinitionNameSpecAttributeOption(nameAttribute, valueOptions)
                }
            }
            return "";
        }
        public static string CreateNewSpecificationAttributeOptions(string attribute_id, string nameOption)
        {
            Object obj = new Object
            {
                _id = MyExtensions.RandomValueString(),
                Name = nameOption,
                SeName = MyExtensions.GetSeName(nameOption),
                DisplayOrder = 0
            };

            var filter = Builders<SpecificationAttributeModel>
                .Filter.Eq(e => e._id, attribute_id);
            var update = Builders<SpecificationAttributeModel>
                .Update.Push(e => e.SpecificationAttributeOptions, obj);

            IMongoCollection<SpecificationAttributeModel> collectionAttributes = 
                StringsDefault.DatabaseSemeNow.GetCollection<SpecificationAttributeModel>("SpecificationAttribute");
            collectionAttributes.FindOneAndUpdate(filter, update);
            return obj._id;
        }
        public static string DefinitionNameSpecAttributeOption(string nameSpecAttribute, string inputValueSpecAttributeOptions)
        {
            if (nameSpecAttribute == "Высота растения" || nameSpecAttribute == "Длинна плода" 
                                                && inputValueSpecAttributeOptions is not null)
                if (!inputValueSpecAttributeOptions.Contains("см")) 
                    return inputValueSpecAttributeOptions + "см";

            if (nameSpecAttribute == "Период созревания" && inputValueSpecAttributeOptions is not null)
                return inputValueSpecAttributeOptions.Replace("ее", "ий").Replace("яя", "ий");

            if (nameSpecAttribute == "Вес плода" && inputValueSpecAttributeOptions is not null)
            {
                if (!inputValueSpecAttributeOptions.Contains("гр") && inputValueSpecAttributeOptions.Contains("кг"))
                    return inputValueSpecAttributeOptions.Replace("гр", "").Replace(" ", "");
                
                if (inputValueSpecAttributeOptions.Contains("кг"))
                {
                    string output = inputValueSpecAttributeOptions.Replace("кг", "").Replace(" ", "");
                    if (inputValueSpecAttributeOptions.Contains("-"))
                    {
                        string[] inputValues = output.Split("-");
                        int i = 0;
                        double[] outputDouble = new double[2];
                        foreach (string inputValue in inputValues)
                        {
                            outputDouble[i] = Convert.ToDouble(inputValue) * 1000;
                            i++;
                        }
                        return outputDouble[0] + "-" + outputDouble[1];
                    }
                    else
                    {
                        double prom = Convert.ToDouble(output) * 1000;
                        return prom.ToString();
                    }
                }
            }
            return inputValueSpecAttributeOptions;
        }
        public static string DefinitionCustomValueSpecAttributeOption(string nameSpecAttribute, string inputValueSpecAttributeOptions)
        {
            if (nameSpecAttribute == "Высота растения" || nameSpecAttribute == "Длинна плода")
                if (inputValueSpecAttributeOptions.Contains("см"))
                    return inputValueSpecAttributeOptions.Replace("см", "").Replace(" ", "");

            if (nameSpecAttribute == "Срок созревания (дней)")
                if (inputValueSpecAttributeOptions.Contains("высадки рассады"))
                    return inputValueSpecAttributeOptions.Replace(" (от высадки рассады)", "");

            if (nameSpecAttribute == "Вес плода")
            {
                if (inputValueSpecAttributeOptions.Contains("гр"))
                    return inputValueSpecAttributeOptions.Replace("гр", "").Replace(" ", "");

                if (inputValueSpecAttributeOptions.Contains("кг"))
                {
                    string output = inputValueSpecAttributeOptions.Replace("кг", "").Replace(" ", "");
                    if (inputValueSpecAttributeOptions.Contains("-"))
                    {
                        string[] inputValues = output.Split("-");
                        int i = 0;
                        double[] outputDouble = new double[2];
                        foreach (string inputValue in inputValues)
                        {
                            outputDouble[i] = Convert.ToDouble(inputValue) * 1000;
                            i++;
                        }
                        return outputDouble[0] + "-" + outputDouble[1];
                    }
                    else
                    {
                        double prom = Convert.ToDouble(output) * 1000;
                        return prom.ToString();
                    }
                }
            }
            return inputValueSpecAttributeOptions;
        }
        public static int ProductPageCategory(string category)
        {
            switch (category)
            {
                case "Арбуз":
                    return 0;
                case "Артишок":
                    return 1;
                case "Баклажан":
                    return 2;
                case "Бобы":
                    return 3;
                case "Брюква":
                    return 4;
                case "Горох":
                    return 5;
                case "Грибы":
                    return 6;
                case "Дайкон":
                    return 7;
                case "Дыня":
                    return 8;
                case "Земляника":
                    return 9;
                case "Кабачок":
                    return 10;
                case "Капуста":
                    return 11;
                case "Картофель":
                    return 12;
                case "Кукуруза":
                    return 13;
                case "Лук":
                    return 14;
                case "Микрозелень":
                    return 15;
                case "Морковь":
                    return 16;
                case "Огурец":
                    return 17;
                case "Патиссон":
                    return 18;
                case "Перец":
                    return 19;
                case "Петрушка":
                    return 20;
                case "Пряность":
                    return 21;
                case "Редис":
                    return 22;
                case "Редька":
                    return 23;
                case "Репа":
                    return 24;
                case "Салат":
                    return 25;
                case "Свекла":
                    return 26;
                case "Томат":
                    return 27;
                case "Тыква":
                    return 28;
                case "Укроп":
                    return 29;
                case "Фасоль":
                    return 30;
                case "Физалис":
                    return 31;
                case "Щавель":
                    return 32;
                default:
                    return -1;
            }
        }
    }
}
