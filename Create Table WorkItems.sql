drop table WorkItems
CREATE TABLE WorkItems (
    ID bigint,
    Tipo varchar(255),
    Titulo varchar(600),
    DataCriacao DateTime
);

CREATE  INDEX ID_workitemIdx
ON WorkItems(ID);

select * from WorkItems