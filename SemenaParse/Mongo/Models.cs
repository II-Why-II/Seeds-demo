using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SemenaParse.Mongo
{
    class BaseProductInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string CategoryPack { get; set; }
        public List<string> Imga { get; set; } = new List<string>();
        public string Description { get; set; }
        public string Price { get; set; }
        public string PriceCurrency { get; set; }
        public string Culture { get; set; }
        public string Manufacturer { get; set; }
        public string RipeningPeriodStr { get; set; }
        public string RipeningPeriodDays { get; set; }
        public string DiseaseResistance { get; set; }
        public string PulpColor { get; set; }
        public string Shape { get; set; }
        public string HeatDroughtTolerance { get; set; }
        public string KeepingQuality { get; set; }
        public string Transportability { get; set; }
        public string Color { get; set; }
        public string NumberOfSeeds { get; set; }
        public string Lenght { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Width { get; set; }
        public string NumberOfGrainsInPod { get; set; }
        public string ResilienceToStressfulConditions { get; set; }
        public string ColorResistance { get; set; }
        public string VegetationPeriodDays { get; set; }
        public string Type { get; set; }
        public string SortType { get; set; }
        public string WallThickness { get; set; }
    }
    class ProductModel
    {
        public string Id { get; set; }
        public string[] UserFields { get; set; }
        public int ProductTypeId { get; set; }
        public string ParentGroupedProductId { get; set; }
        public bool VisibleIndividually { get; set; } = true;
        public string Name { get; set; }
        public string SeName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string AdminComment { get; set; }
        public string ProductLayoutId { get; set; }
        public string BrandId { get; set; }
        public string VendorId { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool BestSeller { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public int ApprovedRatingSum { get; set; }
        public int NotApprovedRatingSum { get; set; }
        public int ApprovedTotalReviews { get; set; }
        public int NotApprovedTotalReviews { get; set; }
        public bool LimitedToGroups { get; set; }
        public string[] CustomerGroups { get; set; }
        public bool LimitedToStores { get; set; }
        public string[] Stores { get; set; }
        public string ExternalId { get; set; }
        public string Sku { get; set; }
        public int Mpn { get; set; }
        public string Gtin { get; set; }
        public bool IsGiftVoucher { get; set; }
        public int GiftVoucherTypeId { get; set; }
        public int OverGiftAmount { get; set; }
        public bool RequireOtherProducts { get; set; }
        public string RequiredProductIds { get; set; }
        public bool AutoAddRequiredProducts { get; set; }
        public bool IsDownload { get; set; }
        public string DownloadId { get; set; }
        public bool UnlimitedDownloads { get; set; }
        public int MaxNumberOfDownloads { get; set; }
        public string DownloadExpirationDays { get; set; }
        public int DownloadActivationTypeId { get; set; }
        public bool HasSampleDownload { get; set; }
        public string SampleDownloadId { get; set; }
        public bool HasUserAgreement { get; set; }
        public string UserAgreementText { get; set; }
        public bool IsRecurring { get; set; }
        public int RecurringCycleLength { get; set; }
        public int RecurringCyclePeriodId { get; set; }
        public int RecurringTotalCycles { get; set; }
        public bool IncBothDate { get; set; }
        public int Interval { get; set; }
        public int IntervalUnitId { get; set; }
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool ShipSeparately { get; set; }
        public int AdditionalShippingCharge { get; set; }
        public string DeliveryDateId { get; set; }
        public bool IsTaxExempt { get; set; }
        public string TaxCategoryId { get; set; }
        public bool IsTele { get; set; }
        public int ManageInventoryMethodId { get; set; }
        public bool UseMultipleWarehouses { get; set; }
        public string WarehouseId { get; set; }
        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public bool StockAvailability { get; set; }
        public bool DisplayStockQuantity { get; set; }
        public int MinStockQuantity { get; set; }
        public bool LowStock { get; set; }
        public int LowStockActivityId { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public int BackorderModeId { get; set; }
        public bool AllowOutOfStockSubscriptions { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public string AllowedQuantities { get; set; }
        public bool NotReturnable { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool DisableWishlistButton { get; set; }
        public bool AvailableForPreOrder { get; set; }
        public string PreOrderDateTimeUtc { get; set; }
        public bool CallForPrice { get; set; }
        public int Price { get; set; }
        public int OldPrice { get; set; }
        public int CatalogPrice { get; set; }
        public int ProductCost { get; set; }
        public bool EnteredPrice { get; set; }
        public int MinEnteredPrice { get; set; }
        public int MaxEnteredPrice { get; set; }
        public bool BasepriceEnabled { get; set; }
        public int BasepriceAmount { get; set; }
        public string BasepriceUnitId { get; set; }
        public int BasepriceBaseAmount { get; set; }
        public string BasepriceBaseUnitId { get; set; }
        public string UnitId { get; set; }
        public string CourseId { get; set; }
        public bool MarkAsNew { get; set; }
        public string MarkAsNewStartDateTimeUtc { get; set; }
        public string MarkAsNewEndDateTimeUtc { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string AvailableStartDateTimeUtc { get; set; }
        public string AvailableEndDateTimeUtc { get; set; }
        public int StartPrice { get; set; }
        public int HighestBid { get; set; }
        public string HighestBidder { get; set; }
        public bool AuctionEnded { get; set; }
        public BsonType DisplayOrder { get; set; }
        public int DisplayOrderCategory { get; set; }
        public int DisplayOrderBrand { get; set; }
        public int DisplayOrderCollection { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int Sold { get; set; }
        public int Viewed { get; set; }
        public int OnSale { get; set; }
        public string Flag { get; set; }
        public string Coordinates { get; set; }
        public string[] Locales { get; set; }
        public BsonArray ProductCategories { get; set; }
        public string[] ProductCollections { get; set; }
        public BsonArray ProductPictures { get; set; }
        [BsonElement("ProductSpecificationAttributes")]
        public List<ProductSpecificationAttributes> ProductSpecificationAttributes { get; set; }
        public string[] ProductTags { get; set; }
        public string[] ProductAttributeMappings { get; set; }
        public string[] ProductAttributeCombinations { get; set; }
        public string[] ProductPrices { get; set; }
        public string[] TierPrices { get; set; }
        public string[] AppliedDiscounts { get; set; }
        public string[] ProductWarehouseInventory { get; set; }
        public string[] CrossSellProduct { get; set; }
        public string[] RecommendedProduct { get; set; }
        public string[] RelatedProducts { get; set; }
        public string[] SimilarProducts { get; set; }
        public string[] BundleProducts { get; set; }
    }
    class ProductSpecificationAttributes
    {
        public string _id { get; set; }
        public BsonType AttributeTypeId { get; set; }
        public string SpecificationAttributeId { get; set; }
        public string SpecificationAttributeOptionId { get; set; }
        public string CustomName { get; set; }
        public string CustomValue { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public BsonType DisplayOrder { get; set; }
    }
    class SpecificationAttributeModel
    {
        public string _id { get; set; }
        public string[] UserFields { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }
        public int DisplayOrder { get; set; }
        public bool LimitedToStores { get; set; }
        public string[] Stores { get; set; }
        public string[] Locales { get; set; }
        public List<Object> SpecificationAttributeOptions { get; set; } = new List<Object>();
    }
    class Object
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }
        public string ColorSquaresRgb { get; set; }
        public int DisplayOrder { get; set; }
        public string[] Locales { get; set; } = new string[0];
    }
}
