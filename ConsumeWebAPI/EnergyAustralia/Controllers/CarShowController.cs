using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyAustralia.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using EnergyAustralia.Models;
using System.Diagnostics;

namespace EnergyAustralia.Controllers
{
    public class CarShowController : Controller
    {
        private ICarShowService _carShowService;

        public CarShowController(ICarShowService carShowService)
        {
            _carShowService = carShowService;
        }

        public IActionResult GetCarShows()
        {
            List<CarViewModel> carShowsList = new List<CarViewModel>();
            try
            {
                var carShows = _carShowService.GetCarShows();
                foreach (var car in carShows.Result)
                {
                    foreach (var item in car.Cars)
                    {
                        var newCar = new CarViewModel
                        {
                            Name = car.Name,
                            Make = item.Make,
                            Model = item.Model
                        };
                        carShowsList.Add(newCar);
                    }
                }
            }
            catch (Exception e)
            {
               return StatusCode(300, "Connection is broken, please close and open app again!!"); 
            }

            var res = carShowsList.OrderBy(c => c.Make).GroupBy(x => x.Make).ToList();
            return View(res);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
