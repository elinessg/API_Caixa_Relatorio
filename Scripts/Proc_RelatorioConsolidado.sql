USE [API_CaixaContext-d7f1e073-3f8e-49d3-8fe4-2884fb8f2efc]
GO

/****** Object:  StoredProcedure [dbo].[RelatorioConsolidado]    Script Date: 03/01/2024 10:46:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[RelatorioConsolidado]  @DataMovimentacao DateTime
as

select Case when TipoMovimento='E' then 'Entrada' else 'Saída' end 'Tipo de Movimento',DataMovimentacao, DescricaoMovimentacao, ValorMovimentacao,

(select SUM(case when TipoMovimento='E' then ValorMovimentacao else 0 end )- 
		SUM(case when TipoMovimento='S' then ValorMovimentacao else 0 end) from TB_FLUXO_CAIXA as t2 where t1.DataMovimentacao >= t2.DataMovimentacao) as Saldo

from TB_FLUXO_CAIXA as t1 
where CONVERT (DATE, DataMovimentacao)=CONVERT (DATE, @DataMovimentacao)
order by t1.DataMovimentacao
GO


