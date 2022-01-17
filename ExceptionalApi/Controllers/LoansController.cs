using CoreDomain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExceptionalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoansController : ControllerBase
    {
        private const string RequestUri = "http://localhost:20850/Loans/Applications";

        [HttpPost("Applications")]
        public IActionResult ApplicationCreate()
        {
            return (new Random()).Next(1, 5) switch
            {
                1 => throw new RegistrationPendingException(),
                2 => throw LoanLimitExceeded(),
                3 => throw new ScoreServiceUnavailableException(),
                _ => base.Ok(),
            };

            static LoanLimitExceededException LoanLimitExceeded()
            {
                var ex = new LoanLimitExceededException();
                ex.Data.Add("limit", 1000);
                return ex;
            }
        }

        [HttpPost("SimulateClientRequest")]
        public async Task<IActionResult> SimulateClientRequest(
            [FromServices] IHttpClientFactory httpClientFactory)
        {
            using var httpClient = httpClientFactory.CreateClient();
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, RequestUri);
            using var response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Success!");
            }
            else
            {
                using var contentStream =
                    await response.Content.ReadAsStreamAsync();

                var result = await JsonSerializer
                    .DeserializeAsync<ProblemDetails>(contentStream);

                return Ok(result);
            }
        }
    }
}
