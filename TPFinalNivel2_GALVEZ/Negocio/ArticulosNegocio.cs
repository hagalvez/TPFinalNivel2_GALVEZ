using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticulosNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Articulos> ListarArticulos()
        {
            List<Articulos> lista = new List<Articulos>();
            try
            {
                datos.SetearConsulta("select a.Id,Codigo,Nombre,a.Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio,c.Descripcion as Categoria, m.Descripcion as Marca from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca = m.Id and a.IdCategoria = c.Id");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    }

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }
        }

        public void AgregarArticulo(Articulos nuevoArticulo)
        {

            try
            {

                datos.SetearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,ImagenUrl,Precio,IdMarca,IdCategoria) values (@Codigo,@Nombre,@Descripcion,@ImagenUrl,@Precio,@IdMarca,@Idcategoria)");

                datos.SetearParametros("@Codigo", nuevoArticulo.Codigo);
                datos.SetearParametros("@Nombre", nuevoArticulo.Nombre);
                datos.SetearParametros("@Descripcion", nuevoArticulo.Descripcion);
                datos.SetearParametros("@ImagenUrl", nuevoArticulo.UrlImagen);
                datos.SetearParametros("@Precio", nuevoArticulo.Precio);
                datos.SetearParametros("@IdMarca", nuevoArticulo.Marca.Id);
                datos.SetearParametros("@IdCategoria", nuevoArticulo.Categoria.Id);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.CerrarConexion(); }

        }

        public void ModificarArticulo(Articulos modificaArticulo)
        {
            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion=@Descripcion, ImagenUrl=@Imagen, Precio=@Precio, IdMarca=@IdMarca, IdCategoria=@IdCategoria where @Id=id");

                datos.SetearParametros("@Codigo", modificaArticulo.Codigo);
                datos.SetearParametros("@Nombre", modificaArticulo.Nombre);
                datos.SetearParametros("@Descripcion", modificaArticulo.Descripcion);
                datos.SetearParametros("@Imagen", modificaArticulo.UrlImagen);
                datos.SetearParametros("@Precio", modificaArticulo.Precio);
                datos.SetearParametros("@IdMarca", modificaArticulo.Marca.Id);
                datos.SetearParametros("@IdCategoria", modificaArticulo.Categoria.Id);
                datos.SetearParametros("@Id", modificaArticulo.Id);

                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }
        }

        public void EliminarArticuloFisca(int id)
        {
            try
            {
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id");
                datos.SetearParametros("@Id", id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }
        }

        public List<Articulos> Filtrar(string categoria, string marca, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();


            try
            {
                string consulta = "select a.Id,Codigo,Nombre,a.Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio,c.Descripcion as Categoria, m.Descripcion as Marca from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca = m.Id and a.IdCategoria = c.Id and ";

                if (categoria == "Celulares")
                {
                    switch (marca)
                    {

                        case "Samsung":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                        case "Apple":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                        case "Huawei":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                        default:
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;
                    }
                }
                else if (categoria == "Televisores")
                {
                    switch (marca)
                    {
                        case "Samsung":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;


                        default:
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;
                    }
                }
                else if (categoria == "Media")
                {
                    switch (marca)
                    {

                        case "Samsung":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                        case "Apple":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                        case "Sony":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                    }

                }
                else if (categoria == "Audio")
                {
                    switch (marca)
                    {

                        case "Samsung":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                        case "Apple":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                        case "Huawei":
                            consulta += $"c.Descripcion like '%{categoria}%' and m.Descripcion like '%{marca}%' and Nombre like '%{filtro}%'";
                            break;

                    }

                }


                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);

                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
