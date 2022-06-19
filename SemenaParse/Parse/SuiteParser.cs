using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using SemenaParse.Mongo;

namespace SemenaParse.Parse
{
    class SuiteParser
    {
        string[] BasePageDiv { get; set; }
        public static List<string> Categorys = new List<string>();
        public void GetBasePageInfo()
        {
            StartPage startPage = new StartPage();
            Console.WriteLine("Start search pages");
            WebRequest request = WebRequest.Create(startPage.BaseLink);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                BasePageDiv = reader.ReadToEnd().Split("<div");
            foreach (string str in BasePageDiv)
            {
                if (str.Contains("refine_categories clearfix"))
                {
                    string[] BasePa = str.Split("</a>");
                    foreach (string ss in BasePa)
                    {
                        if (str.Contains("col-xs-6 col-sm-4 col-md-3 col-lg-2"))
                        {
                            HtmlAgilityPack.HtmlDocument paga = new HtmlAgilityPack.HtmlDocument();
                            using (TextReader sspreader = new StringReader(ss))
                                paga.Load(sspreader);
                            try
                            {
                                Categorys.Add(paga.DocumentNode.SelectSingleNode(".//a").Attributes["href"].Value.Replace("https://hiden-adress/semena-ovoshchey/", string.Empty));
                            }
                            catch { }
                        }
                    }
                }
            }
            _ = 1;
        }
        string BasePage { get; set; }
        string[] BasePageInfo { get; set; }
        public HtmlAgilityPack.HtmlDocument BasePageHtml = new HtmlAgilityPack.HtmlDocument();
        public List<string> BasePaga = new List<string>();
        public void GetPageInfo(int cats)
        {
            BasePaga.Clear();
            int i = 1;
            for (bool can = true; can != false; i++)
            {
                _ = 1;
                try
                {
                    StartPage p = new StartPage(i, cats);
                    Console.WriteLine($"Loading {p.NumPage} page");
                    WebRequest req = WebRequest.Create(p.Link);
                    WebResponse res = req.GetResponse();
                    using (Stream stream = res.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                        BasePage = reader.ReadToEnd();
                    if (!BasePage.Contains("В этой категории нет товаров"))
                    {
                        BasePageInfo = BasePage.Split("</div>");
                        if (BasePageInfo != null)
                            foreach (string one in BasePageInfo)
                                if (one.Contains("caption product-info clearfix"))
                                {
                                    using (TextReader bpreader = new StringReader(one))
                                        BasePageHtml.Load(bpreader);

                                    BasePaga.Add(BasePageHtml.DocumentNode.SelectSingleNode(".//div[@class='caption product-info clearfix']//a").Attributes["href"].Value.RemoveHref());
                                }
                    }
                    else
                        can = false;
                    res.Close();
                }
                catch
                {
                    Console.WriteLine("Error loading page");
                    can = false;
                }
            }
            _ = 1;
        }
        public string[] LiPage { get; set; }
        public string[] DivPage { get; set; }
        public HtmlAgilityPack.HtmlDocument MultyPageHtml = new HtmlAgilityPack.HtmlDocument();
        public HtmlAgilityPack.HtmlDocument MultyPageHtmlDiv = new HtmlAgilityPack.HtmlDocument();

        public void GetProductInfo(int o)
        {
            StartPage url = new StartPage(BasePaga[o]);

            WebRequest request = WebRequest.Create(url.Link);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                LiPage = reader.ReadToEnd().Split("<li ");
            response.Close();
            _ = 1;

            BaseProductInfo product = new BaseProductInfo();
            if (LiPage != null && LiPage[0] != string.Empty)
            {
                foreach (string li in LiPage)
                {
                    if (!li.Contains("Описание"))
                    {
                        using (TextReader lireader = new StringReader(li))
                            MultyPageHtml.Load(lireader);

                        if (li.Contains("inbreadcrumb"))
                            product.Name = MultyPageHtml.DocumentNode.SelectSingleNode(".//h1").InnerText;
                        if (li.Contains("Производитель:") && !li.Contains("Описание"))
                            product.Manufacturer = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Код товара:"))
                            product.Id = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']//span").InnerText;
                        if (li.Contains("Культура:"))
                            product.Culture = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Количество семян:"))
                            product.NumberOfSeeds = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;

                        if (li.Contains("Хорошая лёжкость:") || li.Contains("Хорошая лежкость:"))
                            product.KeepingQuality = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Хорошая транспортабельность:"))
                            product.Transportability = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Устойчивость к болезням:"))
                            product.DiseaseResistance = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Устойчивость к жаре и засухе:"))
                            product.HeatDroughtTolerance = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Устойчивость к стрессовым условиям:"))
                            product.ResilienceToStressfulConditions = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Вид плода:") || li.Contains("Вид лука:") || li.Contains("Вид салата:") || li.Contains("Вид петрушки:") || li.Contains("Вид пряности:") || li.Contains("Вид свеклы:") || li.Contains("Вид тыквы:"))
                            product.Type = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Сортотип:") || li.Contains("Тип:") || li.Contains("Тип перца:"))
                            product.SortType = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Количество зерен в стручке:"))
                            product.NumberOfGrainsInPod = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Вегетационный период:") || li.Contains("Вегетационный период(дней):"))
                            product.VegetationPeriodDays = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;
                        if (li.Contains("Толщина стенок:"))
                            product.WallThickness = MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='dotted-line_right']").InnerText;


                        if (li.Contains("<div class=\"thumbnails\">"))
                        {
                            product.Imga.Add(MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='main_img_box']//div[@id='imageWrap']/a").Attributes["href"].Value);
                            product.Imga.Add(MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='main_img_box']//div[@id='imageWrap']//a/img").Attributes["src"].Value);
                        }
                        if (li.Contains("owl-carousel images-additional"))
                        {
                            if (product.Imga.Count != 0)
                            {
                                product.Imga.Clear();
                                product.Imga.Add(MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='owl-carousel images-additional']//div[@class='item']/a").Attributes["href"].Value);
                                product.Imga.Add(MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='owl-carousel images-additional']//div[@class='item']/a").Attributes["id"].Value);
                                product.Imga.Add(MultyPageHtml.DocumentNode.SelectSingleNode(".//div[@class='owl-carousel images-additional']//div[@class='item']//a/img").Attributes["src"].Value);
                            }
                            _ = 1;
                        }
                    }
                }
            }

            
            if (product.Culture == null)
                product.Culture = product.Category.CategoryToCulture();
            if (product.Category.CategoryToCulture().Contains(product.Culture))
            {
                var collect = StringsDefault.Database.GetCollection<BaseProductInfo>(product.Category);
                try
                {
                    collect.InsertOne(product);
                }
                catch { Console.WriteLine("Error with adding to db"); }
                _ = 1;
            }
        }
    }
}
