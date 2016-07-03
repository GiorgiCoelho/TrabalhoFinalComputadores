using System;
using System.Collections.Generic;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoFinal.Infra.Data.Contexto;
using System.Linq;

namespace Si.Dev.Uniplac.TrabalhoFinal.Infra.Data.Repositorios
{
    public class ComputadorRepositorio : IComputadorRepositorio
    {
        private ComputadorContext _contexto;

        public ComputadorRepositorio()
        {
            _contexto = new ComputadorContext();
        }

        public Computador Adicionar(Computador computador)
        {
            var resultado = _contexto.Computadores.Add(computador);
            _contexto.SaveChanges();
            return resultado;
        }

        public Computador Buscar(int id)
        {
            return _contexto.Computadores.Find(id);
        }

        public List<Computador> BuscarTodos()
        {
            return _contexto.Computadores.ToList();
        }

        public void Deletar(int id)
        {
            var entry = _contexto.Entry(Buscar(id));
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public void Editar(Computador computador)
        {
            var dbComputador = _contexto.Computadores.Single(c => c.Id == computador.Id);

            _contexto.Entry(dbComputador).CurrentValues.SetValues(computador);

            _contexto.SaveChanges();
        }
    }
}
