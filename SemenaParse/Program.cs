using System;
using SemenaParse.Parse;
using SemenaParse.Excel;

namespace SemenaParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Others.GetProductsFromMongoDB();
            Others.DownloadImg();
            Excel.GetExcel();
            //SpecificationAttribute.GetData();
            Others.SettingProductSpecificationAttributesInMongoDbSemeNow();
            Others.ReplaceMongoField();
        }

        public class Excel
        {
            public static void GetExcel()
            {
                OperationsWithBaseProducts edit = new OperationsWithBaseProducts();
                edit.ExcelStartString();
                for (int categoryPage = 0; categoryPage < 33; categoryPage++)
                    edit.MongoToExcel(categoryPage);
                _ = 1;
                edit.SaveExcelFile();
            }
        }
        public class Others
        {
            public static void GetProductsFromMongoDB()
            {
                SuiteParser parse = new SuiteParser();
                parse.GetBasePageInfo();

                for (int cats = 0; cats < 33; cats++)
                {
                    parse.GetPageInfo(cats);
                    for (int number = 0; number < parse.BasePaga.Count && parse.BasePaga.Count != 0; number++)
                    {
                        Console.WriteLine($"Loading {number} seed in {cats} category list.");
                        parse.GetProductInfo(number);
                        _ = 1;
                    }
                    if (parse.BasePaga.Count == 0)
                        Console.WriteLine("Error01");
                    _ = 1;
                }
            }
            public static void DownloadImg()
            {
                OperationsWithMongo download = new OperationsWithMongo();
                for (int categoryPage = 0; categoryPage < 33; categoryPage++)
                    download.DownloadImagines(categoryPage);
            }
            public static void SettingProductSpecificationAttributesInMongoDbSemeNow()
            {
                OperationsWithMongo edit = new OperationsWithMongo();
                edit.AdditionProductAttributesToSemeNowProductCollection();
            }
            public static void ReplaceMongoField()
            {
                OperationsWithMongo edit = new OperationsWithMongo();
                edit.ReplaceProductField("VisibleIndividually", false, true);
            }
        }
    }
}

