using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.ViewModels.Pantner;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("Pantners")]
    public class Pantner : DomainEntity<int>
    {
        public Pantner()
        {
            Products = new List<Product>();
        }
        public Pantner(PantnerViewModel pantnerVm)
        {
            Name = pantnerVm.Name;
            Image = pantnerVm.Image;     
            Status = pantnerVm.Status;
        }
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public Status Status { set; get; }

        public virtual ICollection<Product> Products { set; get; }
    }
}