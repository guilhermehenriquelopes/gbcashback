using AutoMapper;
using GBCashback.DTO;
using GBCashback.Models;

namespace GBCashback.Settings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Revendedor, RevendedorDTO>();
            CreateMap<RevendedorDTO, Revendedor>();
            CreateMap<Compra, CompraDTO>();
            CreateMap<CompraDTO, Compra>();
        }
    }
}