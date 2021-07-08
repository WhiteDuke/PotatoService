using System;

namespace PotatoPlace
{
    public class Potato
    {
        public bool IsNew() => Id <= 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? typeId { get; set; }

        public string typeName { get; set; }

        public Models.Type Type { get; set; }
    }
}