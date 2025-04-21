using Amazon.DynamoDBv2.DataModel;

namespace SolarSystemAPI.Model
{
    [DynamoDBTable("LightBill")]
    public class LightBills
    {
        [DynamoDBHashKey("id")]
        public string? Id { get; set; }

        [DynamoDBRangeKey("SUBID")]
        public Int32 SubId { get; set; }

        [DynamoDBProperty("IMPORT")]
        public string? Import { get; set; }

        [DynamoDBProperty("EXPORT")]
        public string? Export { get; set; }

        [DynamoDBProperty("GENERATE")]
        public string? Generate { get; set; }

        [DynamoDBProperty("BILLDATE")]
        public string? BillDate { get; set; }
    }
}
