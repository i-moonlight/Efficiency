namespace Efficiency.Data.Requests;

public class SellersArray
{
    public List<int> SellersIDs { get; set; }

    public SellersArray(List<int> sellersIDs)
    {
        SellersIDs = sellersIDs;
    }
}