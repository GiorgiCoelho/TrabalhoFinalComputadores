using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Exceptions;

namespace Si.Dev.Uniplac.TrabalhoFinal.Testes.Dominio
{
    [TestClass]
    public class ComputadorTeste
    {
        [TestMethod]
        public void CriarComputadorTeste()
        {
            Computador computador = new Computador("Dell", "Inspiron 14r", 2200.50, 14.0, 2.37);
            Assert.AreEqual("Marca: Dell - Modelo: Inspiron 14r - Preço: 2200,5 - Polegadas: 14 - Peso: 2,37", computador.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CriarComputadorCom_MarcaInvalidaTeste()
        {
            Computador computador = new Computador(string.Empty, "Inspiron 14r", 2200.50, 14.0, 2.37);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CriarComputadorComModeloInvalidoTeste()
        {
            Computador computador = new Computador("Dell", string.Empty, 2200.50, 14.0, 2.37);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CriarComputadorComPrecoInvalidoTeste()
        {
            Computador computador = new Computador("Dell", "Inspiron 14r", -1, 14.0, 2.37);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CriarComputadorComPolegadasInvalidaTeste()
        {
            Computador computador = new Computador("Dell", "Inspiron 14r", 2200.50, -1, 2.37);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CriarComputadorComPesoInvalidoTeste()
        {
            Computador computador = new Computador("Dell", "Inspiron 14r", 2200.50, 14.0, 0);
        }
    }
}
