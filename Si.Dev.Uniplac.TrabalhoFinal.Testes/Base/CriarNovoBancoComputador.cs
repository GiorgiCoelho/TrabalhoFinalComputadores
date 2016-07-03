using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoFinal.Infra.Data.Contexto;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoFinal.Testes.Base
{
    public class CriarNovoBancoComputador<T> : DropCreateDatabaseAlways<ComputadorContext>
    {
        protected override void Seed(ComputadorContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                //Criar computador
                Computador computador = new Computador("Dell", "Inspiron 14r", 2200.50 + (i * 10), 14.0 + i, 2.37 + i);

                //Adicionar no contexto
                context.Computadores.Add(computador);
            }

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
