/* 
    DROP TABLE T_USER_ROLE
    DROP TABLE T_USER 
    DROP TABLE T_ROLE
*/
CREATE TABLE T_USER
(
    codUser bigint not null Identity,
    dscName nvarchar(max) not null,
    dscEmail nvarchar(max) not null,
    dscPassword nvarchar(max) not null,
    dscPhone nvarchar(max) not null,
    flgStatus int not null default(0),
    datRegister datetime not null default(GetDate()),

    constraint PK_T_USER primary key (codUser)
)

CREATE TABLE T_ROLE
(
    codRole int not null Identity,
    dscRole nvarchar(max) not null,
    
    constraint PK_T_ROLE primary key (codRole)
)

CREATE TABLE T_USER_ROLE
(
    codUser bigint not null,
    codRole int not null,
    
    constraint PK_T_USER_ROLE primary key (codUser, codRole),
    constraint FK_T_USER_codUser foreign key (codUser) references T_USER(codUser) on delete cascade,
    constraint FK_T_ROLE_codRole foreign key (codRole) references T_ROLE(codRole) on delete cascade
)

