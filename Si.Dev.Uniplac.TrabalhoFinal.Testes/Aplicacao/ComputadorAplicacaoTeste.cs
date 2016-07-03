using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Moq;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoFinal.Aplicacao.ComputadorService;
using System.Collections.Generic;

namespace Si.Dev.Uniplac.TrabalhoFinal.Testes.Aplicacao
{
    [TestClass]
    public class ComputadorAplicacaoTeste
    {
        [TestMethod]
        public void CriarCarroAplicacaoTeste()
        {
            Computador computador = new Computador("Dell", "Inspiron 14r", 2200.50, 14.0, 2.30);

            var repositorioFake = new Mock<IComputadorRepositorio>();
            repositorioFake.Setup(x => x.Adicionar(computador)).Returns(new Computador());

            IComputadorService servico = new ComputadorService(repositorioFake.Object);
            Computador novoComputador = servico.CriarComputador(computador);

            repositorioFake.Verify(x => x.Adicionar(computador));
        }

        [TestMethod]
        public void RetornarComputadorAplicacaoTeste()
        {
            var repositorioFake = new Mock<IComputadorRepositorio>();
            repositorioFake.Setup(x => x.Buscar(1)).Returns(new Computador());

            IComputadorService servico = new ComputadorService(repositorioFake.Object);
            Computador novoComputador = servico.BuscarComputador(1);

            repositorioFake.Verify(x => x.Buscar(1));
        }

        [TestMethod]
        public void RetornarComputadoresAplicacaoTeste()
        {
            var repositorioFake = new Mock<IComputadorRepositorio>();
            repositorioFake.Setup(x => x.BuscarTodos()).Returns(new List<Computador>());

            IComputadorService servico = new ComputadorService(repositorioFake.Object);
            List<Computador> novosComputadores = servico.BuscarTodosComputadores();

            repositorioFake.Verify(x => x.BuscarTodos());
        }

        [TestMethod]
        public void EditarComputadoresAplicacaoTeste()
        {
            Computador computador = new Computador("Dell", "Inspiron 14r", 2200.50, 14.0, 2.30);

            var repositorioFake = new Mock<IComputadorRepositorio>();
            IComputadorService servico = new ComputadorService(repositorioFake.Object);

            servico.EditarComputador(computador);

            repositorioFake.Verify(x => x.Editar(computador));
        }

        [TestMethod]
        public void DeletarComputadoresAplicacaoTeste()
        {
            var repositorioFake = new Mock<IComputadorRepositorio>();
            IComputadorService servico = new ComputadorService(repositorioFake.Object);

            servico.DeletarComputador(1);

            repositorioFake.Verify(x => x.Deletar(1));
        }
    }
}
