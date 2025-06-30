using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Results.CarResults
{
    public class GetCarByIdQueryResult
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public int Km { get; set; }
        public short Seats { get; set; }
        public string Gear { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
