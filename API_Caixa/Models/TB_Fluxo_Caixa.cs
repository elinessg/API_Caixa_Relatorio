using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Caixa_Relatorio.Models
{
    [Table("TB_Fluxo_Caixa")]
    public class TB_Fluxo_Caixa
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(1)]
        public string TipoMovimento { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        [MaxLength(250)]
        public string DescricaoMovimentacao { get; set; }
        public  decimal Saldo { get; set; }
    }
}
