using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpGet]
        [Route("")]
        public object Versao3()
        {
            return new { Desenvolvedor = "Paulo Rogério versao 3", VersaoApi = "0.0.1" };
        }
        [HttpGet]
        [Route("versao")]
        public object Versao()
        {
            return new { Desenvolvedor = "Paulo Rogério", VersaoApi = "0.0.1" };
        }

        [HttpGet]
        [Route("Listar/versao")]
        public object Versao2()
        {
            return new { Desenvolvedor = "Paulo Rogério Versao 2", VersaoApi = "0.0.1" };
        }


        //Executa get quando quer obter uma nova informação
        [HttpGet]
        [Route("Obter/versao")]
        public string Get()
        {
            return "Get obter informação servidor";
        }

        //Executa post quando quer inseri uma nova informação
        [HttpPost]
        [Route("Inserir/versao")]
        public string Post()
        {
            return "post inserir nova informação";
        }


        //Executa post quando quer atualizar uma nova informação
        [HttpPut]
        [Route("Atualizar/versao")]
        public string Put()
        {
            return "post Atualizar  informação";
        }

        //Executa post quando quer inseri uma nova informação
        [HttpDelete]
        [Route("Delete/versao")]
        public string Delete()
        {
            return "post delete informação";
        }
    }
}
