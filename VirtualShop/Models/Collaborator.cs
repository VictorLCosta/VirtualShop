using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualShop.Models
{
    public class Collaborator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char Type { get; set; }

        public Collaborator()
        {

        }

    }
}
