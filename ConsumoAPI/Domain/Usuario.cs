using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumoAPI.Domain
{
    class Usuario
    {
        public string Email { get; set; }
        public string Username { get; set; }

        public string Show()
        {
            return string.Format($"{Username} - {Email}");
        }
    }
}
