
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class CanalController : Base.BaseController
    {
        private readonly IServiceCanal _serviceCanal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CanalController(IUnitOfWork unitOfWork, IServiceCanal serviceCanal, IHttpContextAccessor httpContextAccessor) : base(unitOfWork)
        {
            _serviceCanal = serviceCanal;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("api/v1/Canal/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                //Guid Idusuario = Guid.NewGuid(); // vai vir do Token
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarResponse usuarioResposne = JsonConvert.DeserializeObject<AutenticarResponse>(usuarioClaims);

                var response = _serviceCanal.Listar(usuarioResposne.Id);
                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }

        }
        [HttpPost]
        [Route("api/v1/Canal/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarCanalRequest request)
        {
            try
            {
                //Guid Idusuario = Guid.NewGuid();
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarResponse usuarioResposne = JsonConvert.DeserializeObject<AutenticarResponse>(usuarioClaims);
                

                var response = _serviceCanal.AdicionarCanal(request, usuarioResposne.Id);
                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/Canal/Excluir/{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid idCanal)
        {
            try
            {
                Guid Idusuario = Guid.NewGuid();
                var response = _serviceCanal.ExcluirCanal(idCanal);
                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

    }
}