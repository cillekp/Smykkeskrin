using Smykkeskrin.Pages;
using Smykkeskrin.model;
using Smykkeskrin.Repo;
using System.Collections.Generic;
using Smykkeskrin.Model;

namespace Smykkeskrin.Service;

public class JewleryService
{
    private readonly IJewleryRepository _jewleryRepository;
   

    public JewleryService(IJewleryRepository jewleryRepository)
    {
        _jewleryRepository = jewleryRepository;
    }
    
    public List<Jewlery> GetAllJewleries()
    {
        return _jewleryRepository.GetJewleries();
    }
    
    // her skal angives id for at finde/se smykket

    public Jewlery GetJewleryById(string jewleryId)
    {
        if (string.IsNullOrWhiteSpace(jewleryId))
        {
            throw new Exception("Du skal angive et id.");
        }

        return _jewleryRepository.GetJewleryById(jewleryId);
    }
    
    // det samme som update

    public void AddJewlery(Jewlery jewlery)
    {
        if (jewlery == null)
        {
            throw new Exception("Smykket mangler.");
        }

        if (string.IsNullOrWhiteSpace(jewlery.Name))
        {
            throw new Exception("Smykket skal have et navn.");
        }

        if (jewlery.Price < 0)
        {
            throw new Exception("Prisen må ikke være negativ.");
        }

        _jewleryRepository.AddJewlery(jewlery);
    }
    // opdatere smykket hvis den er 0 er det ugyldigt, den skal have et navn, og pris 

    public void UpdateJewlery(Jewlery jewlery)
    {
        if (jewlery == null || jewlery.Jewleryid <= 0)
        {
            throw new Exception("Ugyldigt smykke.");
        }

        if (string.IsNullOrWhiteSpace(jewlery.Name))
        {
            throw new Exception("Smykket skal have et navn.");
        }

        if (jewlery.Price < 0)
        {
            throw new Exception("Prisen må ikke være negativ.");
        }

        _jewleryRepository.UpdateJewlery(jewlery);
    }
    
    // hvis der ikke er noget smykke kan det ikke slettes

    public void DeleteJewlery(Jewlery jewlery)
    {
        if (jewlery == null)
        {
            throw new Exception("Smykket mangler.");
        }

        _jewleryRepository.DeleteJewlery(jewlery);
    }
}
   
    

