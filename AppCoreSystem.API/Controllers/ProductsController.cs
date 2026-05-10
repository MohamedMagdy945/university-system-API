using Microsoft.AspNetCore.Mvc;

namespace AppCoreSystem.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    /// <summary>
    /// Get all products from the system
    /// </summary>
    /// <remarks>
    /// This endpoint returns a list of all available products.
    /// You can use it for catalog display in the frontend.
    /// </remarks>
    /// <returns>List of products</returns>
    /// <response code="200">Returns list of products successfully</response>
    /// <response code="500">If something went wrong on server</response>
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new[] { "Product1", "Product2" });
    }

    /// <summary>
    /// Get product by id
    /// </summary>
    /// <param name="id">Product unique identifier</param>
    /// <returns>Single product</returns>
    /// <response code="200">Product found</response>
    /// <response code="404">Product not found</response>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        if (id == 0)
            return NotFound();

        return Ok($"Product {id}");
    }
}