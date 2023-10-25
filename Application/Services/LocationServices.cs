using Application.ViewModels;
using Newtonsoft.Json.Linq;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LocationServices
    {
        public int count = 0;
        public int pages = 0;
        private LocationRepository repository;

        public LocationServices()
        {
            repository = new();
        }
        public async Task getInfo()
        {
            int[] info = await repository.getInfo();
            count = info[0];
            pages = info[1];
        }

        public async Task<List<LocationViewModel>> getAllLocations(int pages)
        {
            List<Location> data = await repository.getAll(pages);
            List<LocationViewModel> locations = new();

            foreach (var item in data)
            {
                LocationViewModel location = new();
                location.id = item.id;
                location.name = item.name;
                location.type = item.type;
                location.dimension = item.dimension;
                locations.Add(location);
            }
            return locations;
        }

        public async Task<List<LocationViewModel>> filterLocations(string search)
        {
            List<Location> data = await repository.filter(search);
            List<LocationViewModel> searchLocations = new();

            foreach (var item in data)
            {
                LocationViewModel location = new();
                location.id = item.id;
                location.name = item.name;
                location.type = item.type;
                location.dimension = item.dimension;
                searchLocations.Add(location);
            }
            return searchLocations;
        }
    }
}
