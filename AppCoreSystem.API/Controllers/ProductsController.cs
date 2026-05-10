using AppCoreSystem.Application.Common.Bases;
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
    /// Returns a list of all available products.
    /// </remarks>
    /// <response code="402">Products retrieved successfully</response>
    [HttpGet]
    [ProducesResponseType(typeof(Response<List<string>>), 200)]
    public IActionResult GetAll()
    {
        var products = new List<string>
        {
            "Product1",
            "Product2"
        };

        var response = new Response<List<string>>
        {
            Data = products,
            StatusCode = 200
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {

        if (id == 10)
        {
            var notFound = new Response<string>
            {
                Message = "Product not found",
                StatusCode = 404
            };

            return NotFound(notFound);
        }

        var response = new Response<string>
        {
            Data = $"Product {id}",
            StatusCode = 200
        };

        return Ok(response);
    }
}