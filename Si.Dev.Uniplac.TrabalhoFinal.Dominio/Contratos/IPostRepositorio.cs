using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos
{
    public interface IPostRepositorio
    {
        void SaveOrUpdate(Computador computador);
    }
}
