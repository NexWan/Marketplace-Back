using System.ComponentModel.DataAnnotations;
namespace MarketplaceAPI.Models;

/*
    * Category class represents a product category in the marketplace.
    * It contains properties for the category's ID, name, and description.
*/

public class Category
{
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
}