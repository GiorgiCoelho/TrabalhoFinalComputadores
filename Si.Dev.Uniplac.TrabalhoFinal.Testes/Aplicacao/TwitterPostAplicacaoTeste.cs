using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Si.Dev.Uniplac.TrabalhoFinal.Aplicacao.PostService;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoFinal.Testes.Aplicacao
{
    [TestClass]
    public class TwitterPostAplicacaoTeste
    {
        [TestMethod]
        public void CriarPostAplicacaoTeste()
        {
            Computador computador = new Computador("Teste", "Inspiron 14r", 2200.50, 14.0, 2.30);

            var repositorioFake = new Mock<IPostRepositorio>();
            repositorioFake.Setup(x => x.SaveOrUpdate(computador));
            ITwitterPostService servico = new TwitterPostService(repositorioFake.Object);
            servico.SaveOrUpdate(computador);
            repositorioFake.Verify(x => x.SaveOrUpdate(computador));
        }
    }
}
