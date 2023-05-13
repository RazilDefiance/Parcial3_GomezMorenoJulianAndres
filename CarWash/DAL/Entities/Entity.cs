using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWash.DAL.Entities
{
    public class Entity
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Display(Name = "Fecha Creación")]
        public virtual DateTime? CreateDate { get; set; }

        [Display(Name = "Fecha Modificación")]
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
