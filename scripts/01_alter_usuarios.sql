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