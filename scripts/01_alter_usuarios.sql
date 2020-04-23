update TB_USUARIOS set DS_TRADER_ENERGIA=0 where DS_TRADER_ENERGIA is null;
update TB_USUARIOS set DS_TRADER_COMBUSTIVEL=0 where DS_TRADER_COMBUSTIVEL is null;

alter table TB_USUARIOS modify( DS_TRADER_ENERGIA default(0) not null);
alter table TB_USUARIOS modify( DS_TRADER_COMBUSTIVEL default(0) not null);

-- perfil
update TB_PERFIS set ST_PROVISION_APPROVER=0 where ST_PROVISION_APPROVER is null;
alter table TB_PERFIS modify( ST_PROVISION_APPROVER default(0) not null);

-- perfil venda
update TB_PERFIS_VENDA set ST_PROVISION_APPROVER=0 where ST_PROVISION_APPROVER is null;
alter table TB_PERFIS_VENDA modify( ST_PROVISION_APPROVER default(0) not null);

update TB_PERFIS_VENDA set ST_FORECAST_APPROVER=0 where ST_FORECAST_APPROVER is null;
alter table TB_PERFIS_VENDA modify( ST_FORECAST_APPROVER default(0) not null);

update TB_PERFIS_VENDA set ST_YNOR_FROM_YCNR_APPROVER=0 where ST_YNOR_FROM_YCNR_APPROVER is null;
alter table TB_PERFIS_VENDA modify( ST_YNOR_FROM_YCNR_APPROVER default(0) not null);

update TB_PERFIS_VENDA set ST_COMPLEMENT_APPROVER=0 where ST_COMPLEMENT_APPROVER is null;
alter table TB_PERFIS_VENDA modify( ST_COMPLEMENT_APPROVER default(0) not null);

update TB_PERFIS_VENDA set ST_CONTRACT_PRICE_APPROVER=0 where ST_CONTRACT_PRICE_APPROVER is null;
alter table TB_PERFIS_VENDA modify( ST_CONTRACT_PRICE_APPROVER default(0) not null);

update TB_PERFIS_VENDA set ST_ENDOSSO_FINANCAS=0 where ST_ENDOSSO_FINANCAS is null;
alter table TB_PERFIS_VENDA modify( ST_ENDOSSO_FINANCAS default(0) not null);

-- Permissoes
update TB_PERMISSOES_GRUPO set ST_ESCRITA=0 where ST_ESCRITA is null;
alter table TB_PERMISSOES_GRUPO modify( ST_ESCRITA default(0) not null);

update TB_PERMISSOES_GRUPO set ST_LEITURA=0 where ST_LEITURA is null;
alter table TB_PERMISSOES_GRUPO modify( ST_LEITURA default(0) not null);

-- TB_CONTRATOS_VENDA

update TB_CONTRATOS_VENDA set ST_DISP_BROKER=0 where ST_DISP_BROKER is null;
alter table TB_CONTRATOS_VENDA modify( ST_DISP_BROKER default(0) not null);

update TB_CONTRATOS_VENDA set DS_ATIVO=0 where DS_ATIVO is null;
alter table TB_CONTRATOS_VENDA modify( DS_ATIVO default(0) not null);

update TB_CONTRATOS_VENDA set DS_DELETADO=0 where DS_DELETADO is null;
alter table TB_CONTRATOS_VENDA modify( DS_DELETADO default(0) not null);

update TB_CONTRATOS_VENDA set ST_FORECAST=0 where ST_FORECAST is null;
alter table TB_CONTRATOS_VENDA modify( ST_FORECAST default(0) not null);

update TB_CONTRATOS_VENDA set DS_NEGOTIATION_BC=0 where DS_NEGOTIATION_BC is null;
alter table TB_CONTRATOS_VENDA modify( DS_NEGOTIATION_BC default(0) not null);

update TB_CONTRATOS_VENDA set DS_OPERACAO_NNE=0 where DS_OPERACAO_NNE is null;
alter table TB_CONTRATOS_VENDA modify( DS_OPERACAO_NNE default(0) not null);

-- TB_PRODUTOS

update TB_PRODUTOS set ST_PRODUTO_CHAVE=0 where ST_PRODUTO_CHAVE is null;
alter table TB_PRODUTOS modify( ST_PRODUTO_CHAVE default(0) not null);

update TB_PRODUTOS set ST_PRODUTO_IMPORTADO=0 where ST_PRODUTO_IMPORTADO is null;
alter table TB_PRODUTOS modify( ST_PRODUTO_IMPORTADO default(0) not null);

update TB_PRODUTOS set ST_PERFIL_SCA=0 where ST_PERFIL_SCA is null;
alter table TB_PRODUTOS modify( ST_PERFIL_SCA default(0) not null);

update TB_PRODUTOS set ST_ATIVO=0 where ST_ATIVO is null;
alter table TB_PRODUTOS modify( ST_ATIVO default(0) not null);

update TB_PRODUTOS set ST_ANIDRO_SEM_CORANTE=0 where ST_ANIDRO_SEM_CORANTE is null;
alter table TB_PRODUTOS modify( ST_ANIDRO_SEM_CORANTE default(0) not null);

-- TB_CONDICOES_PAGAMENTO

update TB_CONDICOES_PAGAMENTO set VL_DATA_FIXA=0 where VL_DATA_FIXA is null;
alter table TB_CONDICOES_PAGAMENTO modify( VL_DATA_FIXA default(0) not null);

update TB_PRODUTTB_CONDICOES_PAGAMENTOOS set ST_ATIVO=0 where ST_ATIVO is null;
alter table TB_CONDICOES_PAGAMENTO modify( ST_ATIVO default(0) not null);

-- TB_LOCALIDADES

update TB_LOCALIDADES set ST_AGROINDUSTRIAL=0 where ST_AGROINDUSTRIAL is null;
alter table TB_LOCALIDADES modify( ST_AGROINDUSTRIAL default(0) not null);

-- TP_LOCALIDADE (PLANTA)

update TB_LOCALIDADES set TP_PLANTA=0 where TP_PLANTA is null;
alter table TB_LOCALIDADES modify( TP_PLANTA default(0) not null);

update TB_LOCALIDADES set VL_LITRO=0 where VL_LITRO is null;
alter table TB_LOCALIDADES modify( VL_LITRO default(0) not null);

update TB_LOCALIDADES set ST_POSSIBLE_ORIGIN_DESTINATION=0 where ST_POSSIBLE_ORIGIN_DESTINATION is null;
alter table TB_LOCALIDADES modify( ST_POSSIBLE_ORIGIN_DESTINATION default(0) not null);

update TB_LOCALIDADES set ST_ISENTO_PIS_COFINS=0 where ST_ISENTO_PIS_COFINS is null;
alter table TB_LOCALIDADES modify( ST_ISENTO_PIS_COFINS default(0) not null);

-- TP_CLIENT 

update TB_LOCALIDADES set ST_BLOQUEIO=0 where ST_BLOQUEIO is null;
alter table TB_LOCALIDADES modify( ST_BLOQUEIO default(0) not null);

update TB_LOCALIDADES set ST_ARMAZENAGEM=0 where ST_ARMAZENAGEM is null;
alter table TB_LOCALIDADES modify( ST_ARMAZENAGEM default(0) not null);

update TB_LOCALIDADES set ST_PERFIL_SCA=0 where ST_PERFIL_SCA is null;
alter table TB_LOCALIDADES modify( ST_PERFIL_SCA default(0) not null);


commit;