using System.Collections.Generic;
using Smykkeskrin.Pages;

namespace Smykkeskrin.Repo;

public interface IJewleryRepository
{
    void AddJewlery(Jewlery jewlery);
    
    void DeleteJewlery(Jewlery jewlery);
    
    void UpdateJewlery(Jewlery jewlery);
    
    Jewlery GetJewlery(string jewleryId);
    
    List<Jewlery> GetJewleries();
    
    Jewlery GetJewleryById(string jewleryId);
    
    
}