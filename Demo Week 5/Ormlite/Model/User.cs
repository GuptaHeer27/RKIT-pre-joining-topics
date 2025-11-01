using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Ormlite.Model
{
    internal class User
    {

        [AutoIncrement]
       public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

    }
}
