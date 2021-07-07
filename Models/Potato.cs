using System;

namespace PotatoPlace
{
    public class Potato
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public Models.Type Type { get; set; }
    }
}