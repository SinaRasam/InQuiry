using AutoMapper;
using Core;
using InQuiry.Dto;



namespace InQuiry
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
          
            #region Balance
            CreateMap<BalanceDto, Balance>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.token_url))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.balance))
                .ForMember(dest => dest.TokenName, opt => opt.MapFrom(src => src.token_name));
            #endregion

        }
    }
}
