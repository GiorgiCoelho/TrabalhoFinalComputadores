using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Exceptions;

namespace Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades
{
    public class Computador
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Preco { get; set; }
        public double Polegadas { get; set; }
        public double Peso { get; set; }

        public Computador()
        {

        }

        public Computador(string marca, string modelo, double preco, double polegadas, double peso)
        {
            if (string.IsNullOrEmpty(marca.Trim()))
                throw new BusinessException("A marca é inválida!");
            if (string.IsNullOrEmpty(modelo.Trim()))
                throw new BusinessException("O modelo é inválido!");
            if (preco <= 0)
                throw new BusinessException("O preço é inválido!");
            if (polegadas <= 0)
                throw new BusinessException("A polegada é inválida!");
            if (peso <= 0)
                throw new BusinessException("O peso é inválido!");

            Marca = marca;
            Modelo = modelo;
            Preco = preco;
            Polegadas = polegadas;
            Peso = peso;
        }

        public override string ToString()
        {
            return string.Format("Marca: {0} - Modelo: {1} - Preço: {2} - Polegadas: {3} - Peso: {4}", Marca, Modelo, Preco, Polegadas, Peso);
        }
    }
}
