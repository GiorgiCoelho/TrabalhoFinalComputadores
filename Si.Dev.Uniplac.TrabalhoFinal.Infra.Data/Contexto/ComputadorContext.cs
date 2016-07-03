using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoFinal.Infra.Data.Contexto
{
    public class ComputadorContext : DbContext
    {
        public ComputadorContext() : base("ComputadorDB")
        {
        }

        public DbSet<Computador> Computadores { get; set; }
    }
}
