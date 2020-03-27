using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class SistemaOperacional
    {
        public int SistemaOperacionalID { get; set; }
        public string NomeSistemaOperacional { get; set; }
        public string Versao { get; set; }
        public string Distribuicao { get; set; }
    }
}
