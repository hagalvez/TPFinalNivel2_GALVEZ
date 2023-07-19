using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;



namespace Helpers
{
    public static class Funciones
    {

        public static void CargarImagen(string url, object pBox)
        {
            string cadena;
            string cadena2;
            string cadena3;
            try
            {
               cadena = $" {pBox}.Load{url}) ";
                cadena.ToString();
                
                

            }
            catch (Exception)
            {
                cadena2 = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Image_not_available.png";

               cadena3 = $"{pBox}.Load{cadena2}";

                cadena3.ToString();

            }

            // Funciones.CargarImagen(listaArticulos[0].UrlImagen, pbLoad.ToString());

        }

        
        
            public static void CargarImagen(string url, Control control)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBox.Load(url);
                }
                else
                {
                    throw new ArgumentException("El control no es un PictureBox válido.");
                }
            }
        
}
