namespace SemenaParse.Parse
{
    class StartPage
    {
        private const string href = "https://hiden-link";
        public string CategoryPack = "plastic-pack";
        public int NumPage { get; set; }
        private int numCat { get; set; }
        string Endpoint => "?limit=120&page=" + NumPage; // limits: // 12, 24, 36, 60, 120
        string Rref => CategoryPack + "/" + SuiteParser.Categorys[numCat] + Endpoint;
        public string Link { get; set; }
        public string BaseLink =>  href + "/" + CategoryPack;
        public StartPage() { }
        public StartPage(int num, int cat)
        {
            NumPage = num;
            numCat = cat;
            Link = href + "/" + Rref;
        }
        public StartPage(string rref)
        {
            Link = href + "/" + rref;
        }
    }
}
