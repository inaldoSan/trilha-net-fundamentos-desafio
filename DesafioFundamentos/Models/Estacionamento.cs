namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine());
        }

        public void RemoverVeiculo()
        {
            if (veiculos.Any()) 
            {
                //Chamando o metodo "ListarVeiculos" para o usuário ter uma referência dos veículos estacionados.  
                ListarVeiculos();
                Console.WriteLine("Digite a placa do veículo para remover: ");
                string placa = "";
                placa = Console.ReadLine();

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                int horas = 0;

                //Um loop até o usuário retorna uma hora valida.
                while (true)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    string _horas = Console.ReadLine();

                    if (int.TryParse(_horas, out int _horasInt))
                    {
                        horas = _horasInt;
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número inteiro válido.");
                    }
                }

                decimal valorTotal = 0;
                valorTotal = precoInicial + (precoPorHora * horas);

                Console.WriteLine($"O valor total é: {valorTotal}");

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }            
            else
            {
                Console.WriteLine("Não há veículos estacionados para remover");
            }

        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }   
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
