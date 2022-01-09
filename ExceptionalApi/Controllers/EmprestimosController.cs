using CoreDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExceptionalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private const string RequestUri = "http://localhost:20850/Emprestimos/Solicitacoes";
        private readonly ILogger<EmprestimosController> _logger;

        public EmprestimosController(ILogger<EmprestimosController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Solicitacoes")]
        public IActionResult SolicitacoesCreate()
        {
            return (new Random()).Next(1, 4) switch
            {
                2 => throw new ValorLimiteExcedidoException(
                    new Dictionary<string, string>(){
                        { "limite", "1000" }
                    }),
                3 => throw new ServicoProtecaoCreditoIndisponivelException(),
                _ => Ok(),
            };
        }

        [HttpPost("SimularClientRequest")]
        public async Task<IActionResult> DomainExceptionClientPost(
            [FromServices] IHttpClientFactory httpClientFactory)
        {
            using var httpClient = httpClientFactory.CreateClient();
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, RequestUri);
            using var response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Sucesso!");
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
