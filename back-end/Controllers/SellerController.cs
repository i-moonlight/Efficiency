using Efficiency.Data.DTO.Seller;
using Efficiency.Data.DTO.SellerServiceResult;
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
    public IActionResult GetAll(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
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
    public IActionResult Post([FromBody] PostSellerDTO SellerDTO)
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
    public IActionResult Put([FromBody] PutSellerDTO SellerDTO)
    {
        IActionResult result = NotFound("The informed Seller was not found");

        bool updateSucceeded = _service.Put(SellerDTO);

        if (updateSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{sellerID}")]
    public IActionResult Delete(int sellerID)
    {
        IActionResult result = NotFound("The informed Seller was not found");

        bool deleteSucceeded = _service.Delete(sellerID);

        if (deleteSucceeded)
        {
            result = NoContent();
        }

        return result;
    }

    [HttpPut("{sellerID}/deactivate")]
    public IActionResult Deactivate(int sellerID)
    {
        IActionResult result = StatusCode(500);

        bool deactivationSucceeded = _service.Deactivate(sellerID);

        if (deactivationSucceeded)
        {
            result = NoContent();
        }

        return result;
    }
}