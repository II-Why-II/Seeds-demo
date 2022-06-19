using IronXL;
using MongoDB.Bson;
using MongoDB.Driver;
using SemenaParse.Mongo;
using System.Linq;

namespace SemenaParse.Excel
{
    class OperationsWithBaseProducts
    {
        public static WorkBook Workbook = WorkBook.Create();
        public WorkSheet Sheet = Workbook.CreateWorkSheet("BaseProduct");
        public int str = 1;
        public void ExcelStartString()
        {
            Sheet["A" + str].Value = "Culture";
            Sheet["B" + str].Value = "Id";
            Sheet["C" + str].Value = "Name";
            Sheet["D" + str].Value = "Manufacturer";
            Sheet["E" + str].Value = "Price";
            Sheet["F" + str].Value = "PriceCurrency";
            Sheet["G" + str].Value = "NumberOfSeeds";
            Sheet["H" + str].Value = "RipeningPeriodDays";
            Sheet["I" + str].Value = "RipeningPeriodStr";
            Sheet["J" + str].Value = "Weight";
            Sheet["K" + str].Value = "Shape";
            Sheet["L" + str].Value = "Lenght";
            Sheet["M" + str].Value = "Width";
            Sheet["N" + str].Value = "Height";
            Sheet["O" + str].Value = "Color";
            Sheet["P" + str].Value = "PulpColor";
            Sheet["Q" + str].Value = "KeepingQuality";
            Sheet["R" + str].Value = "Transportability";
            Sheet["S" + str].Value = "DiseaseResistance";
            Sheet["T" + str].Value = "HeatDroughtTolerance";
            Sheet["U" + str].Value = "ResilienceToStressfulConditions";
            Sheet["V" + str].Value = "Type";
            Sheet["W" + str].Value = "SortType";
            Sheet["X" + str].Value = "NumberOfGrainsInPod";
            Sheet["Y" + str].Value = "VegetationPeriodDays";
            Sheet["Z" + str].Value = "WallThickness";
            Sheet["AA" + str].Value = "Description";
            str++;
        }
        public void MongoToExcel(int page)
        {
            var collection = StringsDefault.Database.GetCollection<BaseProductInfo>(StringsDefault.Categorys[page]);
            var filter = new BsonDocument();
            var semena = collection.Find(filter).ToList();

            foreach (var semka in semena)
            {
                Sheet["A" + str].Value = semka.Culture;
                Sheet["B" + str].Value = semka.Id;
                Sheet["C" + str].Value = semka.Name;
                Sheet["D" + str].Value = semka.Manufacturer;
                Sheet["E" + str].Value = semka.Price;
                Sheet["F" + str].Value = semka.PriceCurrency;
                Sheet["G" + str].Value = semka.NumberOfSeeds;
                Sheet["H" + str].Value = semka.RipeningPeriodDays;
                Sheet["I" + str].Value = semka.RipeningPeriodStr;
                Sheet["J" + str].Value = semka.Weight;
                Sheet["K" + str].Value = semka.Shape;
                Sheet["L" + str].Value = semka.Lenght;
                Sheet["M" + str].Value = semka.Width;
                Sheet["N" + str].Value = semka.Height;
                Sheet["O" + str].Value = semka.Color;
                Sheet["P" + str].Value = semka.PulpColor;
                Sheet["Q" + str].Value = semka.KeepingQuality;
                Sheet["R" + str].Value = semka.Transportability;
                Sheet["S" + str].Value = semka.DiseaseResistance;
                Sheet["T" + str].Value = semka.HeatDroughtTolerance;
                Sheet["U" + str].Value = semka.ResilienceToStressfulConditions;
                Sheet["V" + str].Value = semka.Type;
                Sheet["W" + str].Value = semka.SortType;
                Sheet["X" + str].Value = semka.NumberOfGrainsInPod;
                Sheet["Y" + str].Value = semka.VegetationPeriodDays;
                Sheet["Z" + str].Value = semka.WallThickness;
                Sheet["AA" + str].Value = semka.Description;
                str++;
                _ = 1;
            }
        }
        public void SaveExcelFile()
        {
            Workbook.SaveAs("BaseSemena.xlsx");
        }
    }
}
