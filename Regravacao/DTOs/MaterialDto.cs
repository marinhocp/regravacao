using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{

    [Table("TblMaterial")]
    public class MaterialModel : BaseModel
    {
        [Column("id_material")]
        public short IdMaterial { get; set; }

        [Column("material")]
        public string? Material { get; set; }
    }
}