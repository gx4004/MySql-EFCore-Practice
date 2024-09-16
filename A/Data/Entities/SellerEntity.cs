namespace A.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SellerEntity
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public string Surname { get; set; } = String.Empty;
    
    public int SellerId { get; set; }
    
    [ForeignKey(nameof(SellerId))]
    public ProductEntity Seller { get; set; }
    
}