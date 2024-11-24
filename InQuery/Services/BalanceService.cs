using AutoMapper;
using Core;
using Infrastracture.Repository;
using InQuiry.Dto;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InQuiry.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        public BalanceService(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<APIResult<List<BalanceDto>>> GetApiAsync(string address)
        {
            var result = new APIResult<List<BalanceDto>>();

            var baseUrl = "https://apilist.tronscanapi.com";
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/account/wallet", Method.Get);
            request.AddQueryParameter("address", address);
            request.AddQueryParameter("asset_type", 0);

            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JsonData>(response.Content);
                if (content.data.Any())
                {
                    //Add To Balance Table
                    await _repository.AddRangeAsync(_mapper.Map<List<Balance>>(content.data));
                }

                result.Success = true;
                result.Result = content.data;
                result.Messages.Add("Done");
                result.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                result.Success = false;
                result.Messages.Add(response.ErrorMessage);
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;

            //? address = TSTVYwFDp7SBfZk7Hrz3tucwQVASyJdwC7 & asset_type = 0

        }
    }
}
