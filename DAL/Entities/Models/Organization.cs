using DAL.Entities.Models;
using System.ComponentModel.DataAnnotations;
namespace DAL.Entities.Models
{
    public class Organization : BaseEntity
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Slug { get; set; } // url subdomain or identifier

        [MaxLength(500)]
        public string LogoUrl { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public ICollection<OrganizationUser> Users { get; set; }
    }
}