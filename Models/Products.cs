using System.ComponentModel.DataAnnotations;
namespace MarketplaceAPI.Models;

/*
    * Product class represents a product in the marketplace.
    * It contains properties for the product's ID, name, description, price, stock quantity, image URL,
    * and a foreign key to the category it belongs to.
*/
public class Product{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
    [Required, Range(0.01, 10000)]
    public decimal Price { get; set; }
    [Required, Range(0, 10000)]
    public int Stock { get; set; }
    [Url]
    public string ImageUrl { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
}