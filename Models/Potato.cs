using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PotatoPlace
{
    public class Potato
    {
        public bool IsNew() => Id <= 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

        [DefaultValue(null)]
        public int? typeId { get; set; }

        [JsonIgnore]
        public string typeName { get; set; }

        [JsonIgnore]
        public Models.Type Type { get; set; }
    }
}