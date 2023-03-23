select C.Nome as 'Cliente comprador', I.Nome as 'Nome do Imovel', CII.ClienteOferta, CID.Nome as 'Proprietario'
from 
CLIENTEINTERESSEIMOVEIS CII
join CLIENTES C on CII.ClienteId = C.Id
join IMOVEIS I on CII.ImovelId = I.Id
join CLIENTEIMOVEIS CI on CII.ImovelId = CI.ImovelId
join CLIENTES CID on CI.ClienteId = CID.Id