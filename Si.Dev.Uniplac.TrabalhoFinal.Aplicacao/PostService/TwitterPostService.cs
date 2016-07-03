using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoFinal.Infra.Twitter.Repositorios;

namespace Si.Dev.Uniplac.TrabalhoFinal.Aplicacao.PostService
{
    public class TwitterPostService : ITwitterPostService
    {
        private IPostRepositorio _repositorio;

        public TwitterPostService(IPostRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void SaveOrUpdate(Computador computador)
        {
            _repositorio.SaveOrUpdate(computador);
        }
    }
}
