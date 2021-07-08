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
        [JsonPropertyName("typeId")]
        public int? TypeId { get; set; }

        [JsonIgnore]
        [JsonPropertyName("typeName")]
        public string TypeName { get; set; }

        [JsonIgnore]
        public Models.Type Type { get; set; }
    }
}