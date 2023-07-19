using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_INTEGRADOR
{

    public static class Funciones_Validaciones
    {

        public static void CargarImagen(string url, PictureBox pictureBox)
        {
            try
            {
                pictureBox.Load(url);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("La imagen no fue encontrada" + ex.ToString());

                pictureBox.Load("https://upload.wikimedia.org/wikipedia/commons/d/d1/Image_not_available.png");
            }
        }

        public static void OcultarColumnas(DataGridView dgv)
        {

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["UrlImagen"].Visible = false;
            dgv.Columns["Categoria"].Visible = false;
            dgv.Columns["Marca"].Visible = false;
            dgv.Columns["Descripcion"].Visible = false;


            dgv.Columns["Codigo"].Width = 60;
            dgv.Columns["Nombre"].Width = 150;
            dgv.Columns["Precio"].Width = 131;

            //dgv.Columns["Precio"].DefaultCellStyle.Format = "0.00";


        }

        public static void Eliminar(DataGridView dgv)
        {
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();


            try
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("¿Estás seguro que deseas eliminar de forma permanente ?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                Articulos seleccionado = new Articulos();
                seleccionado = (Articulos)dgv.CurrentRow.DataBoundItem;



                if (respuesta == DialogResult.Yes)
                {
                    articulosNegocio.EliminarArticuloFisca(seleccionado.Id);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public static void CargarDesplegables(ComboBox cboCategorias, ComboBox cboMarca)
        {
            try
            {
                if (cboCategorias != null)
                {
                    string opcionSeleccionada = cboCategorias.SelectedItem.ToString();


                    if (opcionSeleccionada == "Celulares")
                    {
                        cboMarca.Items.Clear();
                        cboMarca.Items.Add("Samsung");
                        cboMarca.Items.Add("Apple");
                        cboMarca.Items.Add("Huawei");
                        cboMarca.Items.Add("Motorola");
                    }
                    else if (opcionSeleccionada == "Televisores")
                    {
                        cboMarca.Items.Clear();
                        cboMarca.Items.Add("Samsung");
                        cboMarca.Items.Add("Sony");

                    }
                    else if (opcionSeleccionada == "Media")
                    {
                        cboMarca.Items.Clear();
                        cboMarca.Items.Add("Samsung");
                        cboMarca.Items.Add("Apple");
                        cboMarca.Items.Add("Sony");

                    }
                    else
                    {
                        cboMarca.Items.Clear();
                        cboMarca.Items.Add("Samsung");
                        cboMarca.Items.Add("Apple");
                        cboMarca.Items.Add("Huawei");

                    }
                }
            }
            catch (Exception)
            {

                // prefiero no mostrar nada
            }


        }

        public static bool ValidarDesplegables(ComboBox cboCategorias, ComboBox cboMarca, Label lblCategoria, Label lblMarca)
        {
            if (cboCategorias.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar una Categoria  para usar el Filtro Avanzado");
                lblCategoria.ForeColor = Color.Red;

                return true;
            }
            else { lblCategoria.ForeColor = SystemColors.ControlText; }

            if (cboMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar una Marca para usar el Filtro Avanzado");
                lblMarca.ForeColor = Color.Red;

                return true;
            }
            else { lblMarca.ForeColor = SystemColors.ControlText; }



            return false;
        }

        public static bool ValidarCamposAgregar(TextBox txtNombre, TextBox txtDescripcion, TextBox txtCodigo, TextBox txtURL, TextBox txtPrecio)
        {
            if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtCodigo.Text == "" || txtURL.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos vacíos.");
                return true;
            }

            foreach (char caracter in txtPrecio.Text)
                if (!(char.IsNumber(caracter)))

                {

                    try
                    {
                        decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El campo 'Precio:' solo admite números", "Precio:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }


                }

            //decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);

            return false;

            // MAX, si lees esto, no encontré forma de hacer que cuando escribo en el dgv algun numero con '.' (punto)  me le agregue 2 ceros , estimo que es regional. Queda bien cuando le pasas los centavos con una ' , ' (coma)  .

        }



    }










}

