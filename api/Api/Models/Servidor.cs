using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Servidor
    {
        public int ServidorID { get; set; }
        public string IP { get; set; }
        public string Hostname { get; set; }
        public string Observacao { get; set; }
        public bool Status { get; set; }
        public string TipoServidor { get; set; }
        public int EspacoDisco { get; set; }
        public int Cpu { get; set; }
        public int Memoria { get; set; }
        public string Conteudo { get; set; }
        public int AmbienteID { get; set; }
        public int CategoriaBackupID { get; set; }
        public int DatacenterID { get; set; }
        public int FinalidadeID { get; set; }
        public int ResponsabilidadeID { get; set; }
        public int SistemaOperacionalID { get; set; }
        public string NomeDataCenter { get; set; }
        public string NomeFinalidade { get; set; }
        public string NomeSistemaOperacional { get; set; }
        public string Distribuicao { get; set; }
        public string Versao { get; set; }
        public string NomeResponsabilidade { get; set; }
        public string NomeCategoriaBackup { get; set; }
        public string Descricao { get; set; }
        public string NomeAmbiente { get; set; }
    }
}
