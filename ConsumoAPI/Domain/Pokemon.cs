using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumoAPI.Domain
{
    class Pokemon
    {
        public string Nome { get; set; }
        public List<string> Tipos { get; set; }

        public void Show()
        {
            Console.WriteLine($"{Nome}: ");
        }
    }
}
