using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcasNegocio
    {

        public List<Marcas> ListarMarcas()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marcas> lista = new List<Marcas>();

            try
            {
                datos.SetearConsulta("Select Id,Descripcion from MARCAS ");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.Id = (int)datos.Lector["ID"];
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
