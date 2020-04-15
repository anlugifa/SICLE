update TB_USUARIOS set DS_TRADER_ENERGIA=0 where DS_TRADER_ENERGIA is null;
update TB_USUARIOS set DS_TRADER_COMBUSTIVEL=0 where DS_TRADER_COMBUSTIVEL is null;

alter table TB_USUARIOS modify( DS_TRADER_ENERGIA default(0) not null);
alter table TB_USUARIOS modify( DS_TRADER_COMBUSTIVEL default(0) not null);

-- perfil
update TB_PERFIS set ST_PROVISION_APPROVER=0 where ST_PROVISION_APPROVER is null;
alter table TB_PERFIS modify( ST_PROVISION_APPROVER default(0) not null);