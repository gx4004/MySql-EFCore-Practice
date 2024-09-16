using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A.Data.Entities;

public class ProductEntity
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required,MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(50)]
    
    public string Description { get; set; }
    
    [Range(0,int.MaxValue,ErrorMessage = "Only Positive")]
    
    public int Stock { get; set; }
}