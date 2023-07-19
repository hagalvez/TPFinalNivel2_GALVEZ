select * from ARTICULOS
select * from CATEGORIAS
select * from MARCAS

select a.Id,Codigo,Nombre,a.Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio,c.Descripcion as Categoria, m.Descripcion as Marca 
from ARTICULOS a, CATEGORIAS c, MARCAS m
where a.IdMarca = m.Id and a.IdCategoria = c.Id


--Select A.Id, Codigo,Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, precio, IdCategoria, IdMarca 
--from ARTICULOS A, CATEGORIAS C, MARCAS M
--where A.IdMarca = M.Id and A.IdCategoria = C.Id

insert into ARTICULOS (Codigo,Nombre,Descripcion,ImagenUrl,Precio,IdMarca,IdCategoria) values ()

update ARTICULOS set Codigo = @codigo   where @id=id

Select A.Id, Codigo,Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, precio, IdCategoria, IdMarca
from ARTICULOS A, CATEGORIAS C, MARCAS M 
where A.IdMarca = M.Id and A.IdCategoria = C.Id 

select a.Id,Codigo,Nombre,a.Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio,c.Descripcion as Categoria, m.Descripcion as Marca
from ARTICULOS a, CATEGORIAS c, MARCAS m 
where a.IdMarca = m.Id and a.IdCategoria = c.Id
and c.Descripcion like '%Celulares%'
and m.Descripcion like '%Motorola%'

select a.Id,Codigo,Nombre,a.Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio,c.Descripcion as Categoria, m.Descripcion as Marca
from ARTICULOS a, CATEGORIAS c, MARCAS m 
where a.IdMarca = m.Id and a.IdCategoria = c.Id
and m.Descripcion like '%Sony%'
and Nombre like '%%'

select a.Id,Codigo,Nombre,a.Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio,c.Descripcion as Categoria, m.Descripcion as Marca 
from ARTICULOS a, CATEGORIAS c, MARCAS m 
where a.IdMarca = m.Id and a.IdCategoria = c.Id 
and c.Descripcion like '%Celulares%' and m.Descripcion like '%Motorola%' and Nombre like '%g%'