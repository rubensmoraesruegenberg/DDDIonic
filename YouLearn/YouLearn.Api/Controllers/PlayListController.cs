using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.Api.Controllers.Base;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class PlayListController:BaseController
    {
        private readonly IServicePlayList _servicePlayList;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PlayListController(IUnitOfWork unitOfWork, IServicePlayList servicePlayList, IHttpContextAccessor httpContextAccessor) : base(unitOfWork)
        {
            _servicePlayList = servicePlayList;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("api/v1/PlayList/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                //Guid Idusuario = Guid.NewGuid(); // vai vir do Token
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarResponse usuarioResposne = JsonConvert.DeserializeObject<AutenticarResponse>(usuarioClaims);

                var response = _servicePlayList.Listar(usuarioResposne.Id);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }

        }
        [HttpPost]
        [Route("api/v1/PlayList/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarPlayListRequest request)
        {
            try
            {
                //Guid Idusuario = Guid.NewGuid();
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarResponse usuarioResposne = JsonConvert.DeserializeObject<AutenticarResponse>(usuarioClaims);


                var response = _servicePlayList.AdicionarPlayList(request, usuarioResposne.Id);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/PlayList/Excluir/{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid idPlayList)
        {
            try
            {
                Guid Idusuario = Guid.NewGuid();
                var response = _servicePlayList.ExcluirPlayList(idPlayList);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
