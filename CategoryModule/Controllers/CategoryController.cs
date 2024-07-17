using Microsoft.AspNetCore.Mvc;

namespace CategoryModule.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ApplicationDbContext context, ILogger<CategoryController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet(Name = "GetCategories")]
    public IEnumerable<Category> Get()
    {
        var categories = new List<Category>
        {
            new() {Id = 1, Name = "Category 1", Description = "Description 1"},
            new() {Id = 2, Name = "Category 2", Description = "Description 2"},
            new() {Id = 3, Name = "Category 3", Description = "Description 3"},
            new() {Id = 4, Name = "Category 4", Description = "Description 4"},
            new() {Id = 5, Name = "Category 5", Description = "Description 5"}
        };

        return categories;
    }

    [HttpPost(Name = "CreateCategory")]
    public async Task<IActionResult> Post([FromBody] Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return Ok();
    }
}