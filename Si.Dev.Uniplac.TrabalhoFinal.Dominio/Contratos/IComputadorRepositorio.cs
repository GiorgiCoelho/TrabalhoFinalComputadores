using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using System.Collections.Generic;

namespace Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos
{
    public interface IComputadorRepositorio
    {
        Computador Adicionar(Computador computador);

        Computador Buscar(int id);

        List<Computador> BuscarTodos();

        void Editar(Computador computador);

        void Deletar(int id);
    }
}
