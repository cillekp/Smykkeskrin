namespace Smykkeskrin.Pages;

public class Jewlery
{
    public int Jewleryid { get; set; }
    public string Name { get; set; }
    public string Material { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
    public bool IsActive { get; set; }
    public string PictureSti { get; set; }
    public JewleryType Type { get; set; }




    public Jewlery(int jewleryid, string name, string material, string brand, double price, bool isActive,
        string pictureSti, JewleryType type)
    {
        Jewleryid = jewleryid;
        Name = name;
        Material = material;
        Brand = brand;
        Price = price;
        IsActive = isActive;
        PictureSti = pictureSti;
        Type = type;
    }

  
  
    public enum JewleryType 
    {                       
        earring,        
        bracelet,       
        necklace,       
        diverse         
    }                       
  
  
  
  
}








