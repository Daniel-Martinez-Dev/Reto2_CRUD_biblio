CREATE DATABASE DB_RETO2
GO

USE DB_RETO2
GO

create table libros(
   codigo varchar(50),
   titulo varchar(40),
   autor varchar(30),
   editorial varchar(20),
   precio int,
   cantidad smallint,
   primary key(codigo)  
  );
GO

CREATE PROC pa_listar_libros
as
select * from libros order by codigo
go

create proc ap_buscar_libros
@titulo varchar(40)
as
select * from libros where titulo like @titulo + '%'
go

create proc ap_mantenimiento_libros
@codigo varchar(50),
@titulo varchar(40),
@autor varchar(30),
@editorial varchar(20),
@precio int,
@cantidad smallint,
@accion  varchar(50) output
as
if (@accion='1')
begin
	declare @codnuevo varchar(5), @codmax varchar(5)
	set @codmax = (select max(codigo)from libros)
	set @codmax = ISNULL(@codmax,'A0000')
	set @codnuevo = 'A'+ RIGHT(RIGHT(@codmax,4)+10001,4)
	insert into libros (codigo,titulo,autor,editorial,precio,cantidad)
	values (@codnuevo,@titulo,@autor,@editorial,@precio,@cantidad)
	set @accion ='Se generó el codigo: '+ @codnuevo
end
else if (@accion='2')
begin
	update libros set
	titulo = @titulo,
	autor = @autor,
	editorial = @editorial,
	precio =  @precio,
	cantidad = @cantidad where
	codigo = @codigo
	set @accion ='Se modificó el código: '+ @codigo
end 
else if (@accion = '3')
begin
delete from libros where codigo = @codigo
set @accion = 'Se elimino el código: ' +@codigo
end
go




