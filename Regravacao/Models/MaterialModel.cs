using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.Models
{
    [Table("TblMaterial")]
    public class MaterialDto : BaseModel
    {
        [Column("id_material")]
        public short IdMaterial { get; set; }

        [Column("material")]
        public string? Material { get; set; }
    }
}