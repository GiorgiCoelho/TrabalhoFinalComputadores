using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoFinal.Aplicacao.ComputadorService
{
    public interface IComputadorService
    {
        Computador CriarComputador(Computador computador);

        void DeletarComputador(int id);

        Computador BuscarComputador(int id);

        List<Computador> BuscarTodosComputadores();

        void EditarComputador(Computador computador);
    }
}
