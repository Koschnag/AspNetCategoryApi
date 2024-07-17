using System.ComponentModel.DataAnnotations;

namespace CategoryModule;

public class Category
{
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; }

    [MaxLength(500)] public string Description { get; set; }
}