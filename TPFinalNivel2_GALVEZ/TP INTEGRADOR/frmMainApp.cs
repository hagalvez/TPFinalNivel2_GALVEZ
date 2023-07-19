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
    public partial class frmMainApp : Form
    {

        private List<Articulos> listaArticulos;


        public frmMainApp()
        {
            InitializeComponent();

        }

        private void frmMainApp_Load(object sender, EventArgs e)
        {
            cboCategorias.Items.Add("Celulares");
            cboCategorias.Items.Add("Televisores");
            cboCategorias.Items.Add("Media");
            cboCategorias.Items.Add("Audio");


            CargarGrillaArticulos();

            Funciones_Validaciones.CargarImagen(listaArticulos[0].UrlImagen, pbLoad);
            Funciones_Validaciones.OcultarColumnas(dgvArticulos);

        }

        private void CargarGrillaArticulos()
        {
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();

            listaArticulos = articulosNegocio.ListarArticulos();
            dgvArticulos.DataSource = listaArticulos;
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvArticulos.CurrentRow != null)
            {
                Articulos seleccionado = new Articulos();

                seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulos;

                Funciones_Validaciones.CargarImagen(seleccionado.UrlImagen, pbLoad);

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar_Modificar agregar = new frmAgregar_Modificar();

            agregar.ShowDialog();

            CargarGrillaArticulos(); //Actualiza
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos seleccionado = new Articulos();
            seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulos;


            frmAgregar_Modificar modificar = new frmAgregar_Modificar(seleccionado);
            modificar.ShowDialog();

            CargarGrillaArticulos(); //Actualiza
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Funciones_Validaciones.Eliminar(dgvArticulos);
            CargarGrillaArticulos();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Articulos seleccionado = new Articulos();
            seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulos;


            frmDetalleProdudcto detalles = new frmDetalleProdudcto(seleccionado);
            detalles.ShowDialog();

            CargarGrillaArticulos(); //Actualiza
        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> listatFiltrada;
            string filtrar = txtFiltroRapido.Text;

            try
            {
                if (filtrar != "")
                {
                    listatFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtrar.ToUpper()) || x.Codigo.ToUpper().Contains(filtrar.ToUpper()) || x.Precio.ToString().ToUpper().Contains(filtrar.ToUpper()));
                }
                else
                {
                    listatFiltrada = listaArticulos;

                }

                dgvArticulos.DataSource = null;                 // la limpio 
                dgvArticulos.DataSource = listatFiltrada;
                Funciones_Validaciones.OcultarColumnas(dgvArticulos);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {


            Funciones_Validaciones.CargarDesplegables(cboCategorias, cboMarca);

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            if (Funciones_Validaciones.ValidarDesplegables(cboCategorias, cboMarca, lblCategoria, lblMarca))
            {

                return; // hago un stop
            }

            try
            {

                ArticulosNegocio articulosNegocio = new ArticulosNegocio();

                string categoria = cboCategorias.SelectedItem.ToString();
                string marca = cboMarca.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                dgvArticulos.DataSource = articulosNegocio.Filtrar(categoria, marca, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }



        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {

            cboMarca.SelectedIndex = -1;
            cboCategorias.SelectedIndex = -1;
            txtFiltroAvanzado.Text = null;


            Funciones_Validaciones.CargarDesplegables(cboCategorias, cboMarca);

            lblCategoria.ForeColor = SystemColors.ControlText;
            lblMarca.ForeColor = SystemColors.ControlText;


            CargarGrillaArticulos();

        }
    }
}