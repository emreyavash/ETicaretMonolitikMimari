using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class UserForLoginDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
