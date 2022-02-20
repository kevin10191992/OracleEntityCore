using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class VariablesOtorgamiento
    {
        public decimal SqParticipante { get; set; }
        public decimal SqSolicitud { get; set; }
        public string Llave { get; set; } = null!;
        public string? Valor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal NroEjecucion { get; set; }
    }
}
