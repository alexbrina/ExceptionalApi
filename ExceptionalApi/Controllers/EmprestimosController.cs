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
    public class EmprestimosController : ControllerBase
    {
        private const string RequestUri = "http://localhost:20850/Emprestimos/Solicitacoes";

        [HttpPost("Solicitacoes")]
        public IActionResult SolicitacoesCreate()
        {
            return (new Random()).Next(1, 5) switch
            {
                1 => throw new ClienteBloqueadoException(),
                2 => throw ValorLimiteExcedido(),
                3 => throw new ServicoProtecaoCreditoIndisponivelException(),
                _ => base.Ok(),
            };

            static ValorLimiteExcedidoException ValorLimiteExcedido()
            {
                var ex = new ValorLimiteExcedidoException();
                ex.Data.Add("limite", 1000);
                return ex;
            }
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
