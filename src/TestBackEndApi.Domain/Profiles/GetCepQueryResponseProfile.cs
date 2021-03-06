using AutoMapper;
using TestBackEndApi.Domain.Queries.Cep.Get;
using TestBackEndApi.Infrastructure.Data.Dto;
using TestBackEndApi.Infrastructure.Services.Contract;

namespace TestBackEndApi.Domain.Profiles
{
    public class GetCepQueryResponseProfile : Profile
    {
        public GetCepQueryResponseProfile()
        {
            CreateMap<CepResponse, GetCepQueryResponse>();
			CreateMap<MensagemResponse, MensagemQueryResponse>();
			CreateMap<GetCepQuery, CepRequest>();
            CreateMap<CepResponse, GetCepQueryResponse>();
            CreateMap<GetCepQueryResponse, CepResponseDTO>();
            CreateMap<MensagemQueryResponse, MensagemQueryResponseDTO>();
        }
    }
}
