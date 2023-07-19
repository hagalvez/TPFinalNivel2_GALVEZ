using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;


namespace TP_INTEGRADOR
{
    public partial class frmAgregar_Modificar : Form
    {
        private Articulos articulos = null;


        public frmAgregar_Modificar()
        {
            InitializeComponent();
        }

        public frmAgregar_Modificar(Articulos articulos)
        {
            InitializeComponent();
            this.articulos = articulos;
            Text = "Modificar Artículo";
        }


        private void frmNuevo_Modificar_Load(object sender, EventArgs e)
        {
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            CategoriasNegocio categoriasNegocio = new CategoriasNegocio();

            try
            {
                cboCategoria.DataSource = categoriasNegocio.ListarCategorias();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                cboMarca.DataSource = marcasNegocio.ListarMarcas();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";


                // es nuevo o modificado ? 


                if (articulos != null)
                {
                    txtNombre.Text = articulos.Nombre;
                    txtCodigo.Text = articulos.Codigo;
                    txtDescripcion.Text = articulos.Descripcion;
                    txtPrecio.Text = articulos.Precio.ToString("0.00");

                    txtURL.Text = articulos.UrlImagen;

                    // elijo cual muestro precargado:

                    cboCategoria.SelectedValue = articulos.Categoria.Id;
                    cboMarca.SelectedValue = articulos.Marca.Id;

                    Funciones_Validaciones.CargarImagen(articulos.UrlImagen, pbxAgregar_Modificar);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                MessageBox.Show("Error inesperado, de persistir contactese con su proveedor.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.BackColor = Color.Beige;

            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Estás seguro deseas cancelar? Se perderá el progreso", "Cancelar", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                this.Close();

            }
            else { this.BackColor = Color.LightSteelBlue; }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();



            try
            {
                if (articulos == null)  // si pasa esto es que apretó Agregar y necesito instanciar.
                {
                    articulos = new Articulos();
                }

                if (Funciones_Validaciones.ValidarCamposAgregar(txtNombre, txtDescripcion, txtCodigo, txtURL, txtPrecio))
                {
                    return;   // valido campos vacíos.
                }

                articulos.Precio = decimal.Parse(txtPrecio.Text);
                articulos.Nombre = txtNombre.Text;
                articulos.Descripcion = txtDescripcion.Text;
                articulos.Codigo = txtCodigo.Text;
                articulos.UrlImagen = txtURL.Text;
                articulos.Categoria = (Categorias)cboCategoria.SelectedItem;
                articulos.Marca = (Marcas)cboMarca.SelectedItem;


                if (articulos.Id != 0)
                {

                    articulosNegocio.ModificarArticulo(articulos);
                    MessageBox.Show("Modificado con éxito!");
                }
                else
                {
                    articulosNegocio.AgregarArticulo(articulos);
                    MessageBox.Show("Agregado con éxito!");
                }

                Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtURL_Leave(object sender, EventArgs e)
        {
            Funciones_Validaciones.CargarImagen(txtURL.Text, pbxAgregar_Modificar);
            
            
        }
    }
}
