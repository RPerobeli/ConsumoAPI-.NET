using ConsumoAPI.Domain;
using ConsumoAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumoAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("pokeAPI ou pkTrainer?");
            string escolha = Console.ReadLine();
            if (escolha == "pkTrainer")
            {
                Console.WriteLine("Acessando a PkTrainer API...");
                UsuarioRepository repositorio = new UsuarioRepository();
                Task<List<Usuario>> usuarioTask = repositorio.GetUsuariosAsync();
                usuarioTask.ContinueWith(task =>
                {
                    var usuarios = task.Result;
                    foreach (var u in usuarios)
                    {
                        Console.WriteLine(u.Show());
                    }
                    Environment.Exit(0);
                },
                TaskContinuationOptions.OnlyOnRanToCompletion
                );
                //Task<List<string>> usernameTask = repositorio.GetUsernameAsync();
                //usernameTask.ContinueWith(task =>
                //{
                //    var usernames = task.Result;
                //    foreach (var u in usernames)
                //    {
                //        Console.WriteLine($"{u}");
                //    }
                //    Environment.Exit(0);
                //},
                //TaskContinuationOptions.OnlyOnRanToCompletion
                //);

                Console.ReadLine();
            }
            else if (escolha == "pokeAPI")
            {
                Console.WriteLine("Acessando a PokeAPI...");
                PokemonRepository repositorio = new PokemonRepository();
                Console.WriteLine("Qual o nome do pokemon?");
                string nomePokemon = Console.ReadLine();
                Task<List<Pokemon2>> pokemonTask = repositorio.GetPokemonAsync(nomePokemon);

                pokemonTask.ContinueWith(task =>
                {
                    List<Pokemon2> pokemon = task.Result;
                    foreach (var p in pokemon)
                    {
                        p.Show();
                    }
                    Environment.Exit(0);
                },
                TaskContinuationOptions.OnlyOnRanToCompletion
                );
                Console.ReadLine();
            }

        }
    }
}
