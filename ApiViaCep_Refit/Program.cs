using ApiViaCep_Refit.Repository;
using Refit;
using System;
using System.Threading.Tasks;

namespace ApiViaCep_Refit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu cep");
                var cep = Console.ReadLine().ToString();
                Console.WriteLine($"Consultando informações do CEP: {cep}");

                var address = await cepClient.GetCep(cep);

                Console.WriteLine($"\nLogradouro:{address.Logradouro}.\nBairro:{address.Bairro}.\nCidade:{address.Localidade}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta cep. " + e.Message);
            }

        }
    }
}
