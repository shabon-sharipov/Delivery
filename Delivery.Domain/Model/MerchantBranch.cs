using Delivery.Domain.Abstract;
using Delivery.Domain.Model;

public class MerchantBranch : EntityBase
{
    public ulong MerchantId { get; set; }
    public virtual Merchant Merchant { get; set; }

    public string Open { get; set; }
    public string Close { get; set; }
    public MerchantStatus MerchantStatus { get; set; }
    public string Location { get; set; }
    public double PointLat { get; set; }
    public double PointLng { get; set; }

    public string MerchantCoverage { get; set; }
}

//public class Сircle
//{
//    private readonly double _centerx;
//    private readonly double _centery;
//    private readonly double _radius;

//    private const double onedegree = (Math.PI / 180.0);
//    private const int earthradius = 6371;

//    private Сircle(double centerx, double centery, double radius)
//    {
//        _centerx = centerx;
//        _centery = centery;
//        _radius = radius;
//    }

//    public static igeocomponent create(double centerx, double centery, double radius)
//    {
//        return new circle(centerx, centery, radius);
//    }


//    public bool containspoint(double pointlat, double pointlng)
//    {
//        double result = getdistanceinkm(
//            _centerx,
//            _centery,
//            pointlat,
//            pointlng);

//        return result <= _radius;
//    }

//    public static double getdistanceinkm(double sourcelat, double sourcelng, double destlat, double destlng)
//    {
//        var sourcelatrad = toradians(sourcelat);
//        var destlatrad = toradians(destlat);

//        var longitudedelta = toradians(destlng - sourcelng);
//        var latitudedelta = toradians(destlat - sourcelat);

//        var angle = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(latitudedelta / 2), 2) +
//                        Math.Cos(sourcelatrad) * Math.Cos(destlatrad) * Math.Pow(Math.Sin(longitudedelta / 2), 2)));

//        return angle * earthradius;
//    }
//    private static double toradians(double angle) => angle * Math.PI / 180.0;
//}