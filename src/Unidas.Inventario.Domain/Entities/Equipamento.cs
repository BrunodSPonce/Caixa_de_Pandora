using System;


namespace Unidas.Inventario.Domain.Entities
{
    public class Equipamento
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Ip { get; set; }
        public string Finalindade { get; set; }
        public string Ambiente { get; set; }
        public string SistemaOperacional { get; set; }


        public bool VerificarFinalidadeTeste()
        {
            return Finalindade == "Teste";
        }
    }
}
