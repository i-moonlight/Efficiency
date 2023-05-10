using Efficiency.Data.DTO.Seller;
using Efficiency.Data.DTO.SellerResults;
using Efficiency.Services;
using Microsoft.AspNetCore.Mvc;

namespace Efficiency.Controllers;

[ApiController]
[Route("[controller]")]
public class SellerController : ControllerBase
{
    private SellerService _service;

    public SellerController(SellerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllSellers(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 0)
    {
        IActionResult result = NoContent();

        ICollection<GetSellerDTO>? Sellers = _service.GetAll(skip, take);

        if (Sellers != null)
        {
            result = Ok(Sellers);
        }

        return result;
    }

    [HttpGet("{sellerID}")]
    public IActionResult GetSeller(int sellerID)
    {
        IActionResult result = NotFound();

        GetSellerDTO? Seller = _service.Get(sellerID);

        if (Seller != null)
        {
            result = Ok(Seller);
        }

        return result;
    }

    [HttpPost]
    public IActionResult PostSeller([FromBody] PostSellerDTO SellerDTO)
    {
        IActionResult result = StatusCode(500);

        GetSellerDTO? createdSeller = _service.Post(SellerDTO);

        if (createdSeller != null)
        {
            result = CreatedAtAction(
                nameof(GetSeller),
                new { sellerID = createdSeller.ID },
                createdSeller
            );
        }

        return result;
    }

    [HttpPut]
    public IActionResult PutSeller([FromBody] PutSellerDTO SellerDTO)
    {
        IActionResult result = NotFound("Seller not found");

        bool updateSucceeded = _service.Put(SellerDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{sellerID}")]
    public IActionResult DeleteSeller(int sellerID)
    {
        IActionResult result = NotFound("Seller not found");

        bool deleteSucceeded = _service.Delete(sellerID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpPut("{sellerID}/deactivate")]
    public IActionResult DeactivateSeller(int sellerID)
    {
        IActionResult result = NotFound("Seller not found");

        bool deactivationSucceeded = _service.Deactivate(sellerID);

        if (deactivationSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}