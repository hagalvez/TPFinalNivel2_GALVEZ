using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriasNegocio
    {
        public List<Categorias> ListarCategorias()
        {
            List<Categorias> lista = new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Id,Descripcion from CATEGORIAS ");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

    }
}
