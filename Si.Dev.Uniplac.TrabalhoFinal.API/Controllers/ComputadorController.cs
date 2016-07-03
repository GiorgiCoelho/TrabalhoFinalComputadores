using Si.Dev.Uniplac.TrabalhoFinal.Aplicacao.ComputadorService;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoFinal.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Si.Dev.Uniplac.TrabalhoFinal.API.Controllers
{
    public class ComputadorController : ApiController
    {
        private static readonly IComputadorService repository = new ComputadorService(new ComputadorRepositorio());

        [HttpGet]
        public IEnumerable<Computador> Get()
        {
            return repository.BuscarTodosComputadores();
        }

        public Computador Get(int id)
        {
            Computador computador = repository.BuscarComputador(id);
            if (computador == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return computador;
        }

        public HttpResponseMessage Post(Computador computador)
        {
            if (ModelState.IsValid)
            {
                repository.CriarComputador(computador);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, computador);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(Computador computador)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            try
            {
                repository.EditarComputador(computador);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            Computador computador = repository.BuscarComputador(id);
            if (computador == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                repository.DeletarComputador(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, computador);
        }
    }
}
