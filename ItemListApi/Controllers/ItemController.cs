using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
//using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;



[Route("api/items")]
[ApiController]
public class ItemsController : ControllerBase
{

//      Get items
    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get()
    {
        return Ok(ItemManager.Instance.GetAllItems());
    }

//      Create new item
    [HttpPost]
    [Consumes("application/json")]
    public ActionResult<IEnumerable<Item>> Post([FromBody] string inputText)
    {
    if (inputText == null)
    {
        return BadRequest("Item data is invalid.");
    }
    ItemManager.Instance.AddItem(inputText);

    return Ok(ItemManager.Instance.GetAllItems());
    }

//      Factorial calculations
    [HttpGet("calculate-factorials/{id}")]
    public async Task<IActionResult> CalculateFactorial(int id)
    {
        if (id < 0)
        {
            return BadRequest("Invalid input for factorial calculation.");
        }

        int factorialResult = await CalculateFactorialAsync(id);

        return Ok(factorialResult);
    }

    private async Task<int> CalculateFactorialAsync(int n)
    {
        if (n < 0)
        {
            return -1; // Handle invalid input
        }
        if (n == 0)
        {
            return 1;
        }

        int result = 1;
        Parallel.For(1, n + 1, i =>
        {
            result *= i;
        });

        return result;
    }
}
