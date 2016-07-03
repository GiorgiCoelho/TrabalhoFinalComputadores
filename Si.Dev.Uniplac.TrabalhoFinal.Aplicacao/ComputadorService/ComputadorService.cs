using System.Collections.Generic;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoFinal.Aplicacao.PostService;
using Si.Dev.Uniplac.TrabalhoFinal.Infra.Twitter.Repositorios;

namespace Si.Dev.Uniplac.TrabalhoFinal.Aplicacao.ComputadorService
{
    public class ComputadorService : IComputadorService
    {
        private IComputadorRepositorio _repositorio;
        private ITwitterPostService _postRepositorio;

        public ComputadorService(IComputadorRepositorio repositorio)
        {
            _repositorio = repositorio;
            _postRepositorio = new TwitterPostService(new TwitterPostRepositorio());
        }

        public void EditarComputador(Computador computador)
        {
            _repositorio.Editar(computador);
        }

        public Computador BuscarComputador(int id)
        {
            return _repositorio.Buscar(id);
        }

        public List<Computador> BuscarTodosComputadores()
        {
            return _repositorio.BuscarTodos();
        }

        public Computador CriarComputador(Computador computador)
        {
            var response = _repositorio.Adicionar(computador);
            _postRepositorio.SaveOrUpdate(computador);
            return response;
        }

        public void DeletarComputador(int id)
        {
            _repositorio.Deletar(id);
        }
    }
}
