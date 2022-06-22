using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CarInputModel, Car>();
            this.CreateMap<PartInputModel, Part>();
            this.CreateMap<SupplierInputModel, Supplier>();
            this.CreateMap<CustomerInputModel, Customer>();
            this.CreateMap<SaleInputModel, Sale>();

            CreateMap<Supplier, LocalSupplierOutputDto>()
                .ForMember(dest => dest.PartsCount, opt =>
                    opt.MapFrom(s => s.Parts.Count));
        }
    }
}
