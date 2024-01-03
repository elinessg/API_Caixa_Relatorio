using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Caixa_Relatorio.Data;
using API_Caixa_Relatorio.Models;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace API_Caixa_Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TB_Fluxo_CaixaController : ControllerBase
    {
        private readonly API_CaixaContext _context;

        public TB_Fluxo_CaixaController(API_CaixaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obter todos os registros
        /// </summary>
        /// <response code="200">O Relatório foi gerado com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter o Relatório</response>
        // GET: api/TB_Fluxo_Caixa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TB_Fluxo_Caixa>>> GetTB_Fluxo_Caixa(DateTime DataMovimentacao )
        {
            List<TB_Fluxo_Caixa> lstFLuxo = new List<TB_Fluxo_Caixa>();
            var cmd = _context.Database.GetDbConnection().CreateCommand();
            //Abrir conexão com o banco.
            _context.Database.GetDbConnection().Open();
            //Chama a sua procedure.
            cmd.CommandText = "RelatorioConsolidado";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //Passar os parametros necessarios para chamar a procedure.
            cmd.Parameters.Add(new SqlParameter("@DataMovimentacao", DataMovimentacao));

            //Executar a chamada.
            using (var rd = cmd.ExecuteReader())
            {               

                while (rd.Read())
                {
                    TB_Fluxo_Caixa fluxo = new TB_Fluxo_Caixa();
                    fluxo.TipoMovimento = rd.GetValue(0).ToString();
                    fluxo.DataMovimentacao = Convert.ToDateTime(rd.GetValue(1));
                    fluxo.DescricaoMovimentacao=rd.GetValue(2).ToString();
                    fluxo.ValorMovimentacao = Convert.ToDecimal(rd.GetValue(3));
                    fluxo.Saldo = Convert.ToDecimal(rd.GetValue(4));
                    lstFLuxo.Add(fluxo);
                }

            }
             return await Task.Run(() => (lstFLuxo));
        }

      
    }
}
