using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Models
{
    public class YouBikeSite
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="站點代號")]
        [JsonProperty("sno")]
        public int SiteNumber { get; set; }
        [Display(Name = "場站名稱")]
        [JsonProperty("sna")]
        public string SiteName { get; set; }
        [Display(Name = "場站總停車格")]
        [JsonProperty("tot")]
        public int ParkingSpaceCount { get; set; }
        [Display(Name = "可借車位數")]
        [JsonProperty("sbi")]
        public int IdelBikeCount { get; set; }
        [Display(Name = "資料更新時間")]
        [JsonProperty("mday")]
        public string UpdatedAt { get; set; }
        [Display(Name = "場站區域")]
        [JsonProperty("sarea")]
        public string Area { get; set; }
        [Display(Name = "緯度")]
        [JsonProperty("lat")]
        public float Latitude { get; set; }
        [Display(Name = "經度")]
        [JsonProperty("lng")]
        public float Longtitude { get; set; }
        [Display(Name = "地址")]
        [JsonProperty("ar")]
        public string Address { get; set; }
        [Display(Name = "場站是否暫停營運")]
        [JsonProperty("act")]
        public int IsActive { get; set; }
    }
}
