namespace Efficiency.Data.Requests;

public class GetSellersResults
{
    public List<int> SellersIDs { get; set; }

    public GetSellersResults(List<int> sellersIDs)
    {
        SellersIDs = sellersIDs;
    }
}