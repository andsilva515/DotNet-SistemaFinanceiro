using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _InterfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _IUsuarioSistemaFinanceiroServico;
        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro InterfaceUsuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroServico IUsuarioSistemaFinanceiroServico)
        {
            _InterfaceUsuarioSistemaFinanceiro = InterfaceUsuarioSistemaFinanceiro;
            _IUsuarioSistemaFinanceiroServico = IUsuarioSistemaFinanceiroServico;
        }

        [HttpGet("/api/ListarUsuariosSistema")]
        [Produces("application/json")]
        private async Task<object> ListaSistemasUsuario(int idSistema)
        {
            return await _InterfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadatrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _IUsuarioSistemaFinanceiroServico.CadastrarUsuarioNoSistema(
                    new UsuarioSistemaFinanceiro
                    {
                        IdSistema = idSistema,
                        EmailUsuario = emailUsuario,
                        Administrador = false,
                        SistemaAtual = true
                    });
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

    }
}
