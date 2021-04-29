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
            Console.WriteLine("Acessando a PkTrainer API...");
            UsuarioRepository repositorio = new UsuarioRepository();
            var usuarioTask = repositorio.GetUsuariosAsync();

            usuarioTask.ContinueWith(task =>
            {
                var usuarios = task.Result;
                foreach(var u in usuarios)
                {
                    Console.WriteLine(u.Show());
                }
                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );
            Console.ReadLine();

        }
    }
}
