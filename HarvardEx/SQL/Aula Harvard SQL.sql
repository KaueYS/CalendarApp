/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000)
      [BENEFICIARIO]
      ,[DATA_ATENDIMENTO]
      ,[NOME_PROCEDIMENTO]
      ,[HONORARIO]
      ,[PRESTADOR_ARQUIVO]
  FROM [Auditoria].[dbo].[KAUE_YORINORI_SOUZA_ANALITICO_1032341433_20230129_63D6C6CF99F9Dnv]


  SELECT DISTINCT(BENEFICIARIO) FROM KAUE_YORINORI_SOUZA_ANALITICO_1032341433_20230129_63D6C6CF99F9Dnv

  SELECT BENEFICIARIO FROM KAUE_YORINORI_SOUZA_ANALITICO_1032341433_20230129_63D6C6CF99F9Dnv WHERE BENEFICIARIO = 'ANTENOR BALAN';

  SELECT CONVENIO FROM dbo.demonstrativo0123 WHERE CONVENIO = '%UNIMED%';

  SELECT CONVENIO = "UNIMED" FROM demonstrativo01-23;