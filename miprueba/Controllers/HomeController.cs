using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using miprueba.Models; 
using Microsoft.AspNetCore.Mvc.RazorPages; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json; 
using System.Text.Json.Serialization;


namespace miprueba.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



[HttpPost] 
     public ActionResult Index(Models.Cliente sm)
     {
        var handler = new HttpClientHandler();  
        Cliente cliente = new Cliente();
        string miurl = "https://localhost:7260/api/InformacionUsuario" + sm.ID_CONTADOR;
        ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        WebRequest myWebRequest = WebRequest.Create(miurl); 
        WebResponse response = myWebRequest.GetResponse(); 
        using (Stream stream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(stream);
            String json = reader.ReadToEnd();      
            if (json !="")
            {
                cliente = JsonSerializer.Deserialize<Cliente>(json);
            }              
        }
         if (cliente.ID_CONTADOR !=0)
         {
             ViewBag._DPI = cliente.DPI;
             ViewBag._NOMBRES  = cliente.NOMBRES;
             ViewBag._APELLIDOS = cliente.APELLIDOS;
             ViewBag._TELEFONO = cliente.TELEFONO;
             ViewBag._EMAIL = cliente.EMAIL;
             ViewBag._ID_CONTADOR = cliente.ID_CONTADOR;
             ViewBag._NOMBRE_TIPO_CONTADOR = cliente.NOMBRE_TIPO_CONTADOR;
             ViewBag._TIPO_TARIFA = cliente.TIPO_TARIFA;
             ViewBag._DIRECCION_DESTINO = cliente.DIRECCION_DESTINO;
             ViewBag._NOMBRE_MUNICIPIO = cliente.NOMBRE_MUNICIPIO;
             ViewBag._NOMBRE_DEPARTAMENTO = cliente.NOMBRE_DEPARTAMENTO;    
         }                
        return View();
    }
    


   
}
