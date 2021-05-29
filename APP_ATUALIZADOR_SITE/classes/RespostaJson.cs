using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ATUALIZADOR_SITE.classes
{
    class RespostaJson
    {
               
         public Error? error { get; set; }
         public string? error_message { get; set; }
   

        public class Error
        {
            public string? produto { get; set; }
        }


    }
}
