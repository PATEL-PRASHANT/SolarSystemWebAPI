using Amazon.DynamoDBv2.DataModel;

namespace SolarSystemAPI.Model
{
    [DynamoDBTable("DailyUnit")]
    public class DailyUnits
    {
        [DynamoDBHashKey("ID")]
        public Int32 Id { get; set; }

        [DynamoDBRangeKey("SUBID")]
        public Int32 SubId { get; set; }

        [DynamoDBProperty("IMPORT")]
        public Int32 Import { get; set; }

        [DynamoDBProperty("EXPORT")]
        public Int32 Export { get; set; }

        [DynamoDBProperty("GENERATE")]
        public Int32 Generate { get; set; }

        [DynamoDBProperty("ENTRYDATE")]
        public string? EntryDate { get; set; }
    }
}
