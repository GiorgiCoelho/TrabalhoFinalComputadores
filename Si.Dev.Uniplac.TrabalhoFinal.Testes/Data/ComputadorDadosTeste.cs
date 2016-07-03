using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoFinal.Infra.Data.Contexto;
using Si.Dev.Uniplac.TrabalhoFinal.Infra.Data.Repositorios;
using Si.Dev.Uniplac.TrabalhoFinal.Testes.Base;
using System.Collections.Generic;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoFinal.Testes.Data
{
    [TestClass]
    public class ComputadorDadosTeste
    {
        private ComputadorContext _contexto;
        private IComputadorRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoComputador<ComputadorContext>());

            _contexto = new ComputadorContext();
            _repositorio = new ComputadorRepositorio();

            _contexto.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            _contexto.Database.Initialize(true);
        }

        [TestCleanup]
        public void Clear()
        {
        }


        [TestMethod]
        public void CriarComputadorRepositorioTeste()
        {
            Computador computador = new Computador("Dell", "Inspiron 14r", 2200.50, 14.0, 2.37);

            _repositorio.Adicionar(computador);

            Computador novoComputador = _contexto.Computadores.Find(computador.Id);

            Assert.IsTrue(novoComputador.Id > 0);
        }

        [TestMethod]
        public void RetornarComputadorRepositorioTeste()
        {
            Computador computador = _repositorio.Buscar(1);

            Assert.IsNotNull(computador);
        }

        [TestMethod]
        public void RetornarTodosComputadoresRepositorioTeste()
        {
            List<Computador> computador = _repositorio.BuscarTodos();

            Assert.AreEqual(10, computador.Count);
        }

        [TestMethod]
        public void EditarComputadorRepositorioTeste()
        {
            Computador computador = _contexto.Computadores.Find(1);

            computador.Marca = "Lenovo";

            _repositorio.Editar(computador);

            Computador computadorAtualizado = _contexto.Computadores.Find(1);

            Assert.AreEqual("Lenovo", computadorAtualizado.Marca);
        }

        [TestMethod]
        public void DeletarComputadorRepositorioTeste()
        {
            Computador computador = _contexto.Computadores.Find(1);

            _repositorio.Deletar(computador.Id);

            _contexto.Entry(computador).Reload();

            Computador computadorDeletado = _contexto.Computadores.Find(1);
            Assert.IsNull(computadorDeletado);
        }
    }
}
