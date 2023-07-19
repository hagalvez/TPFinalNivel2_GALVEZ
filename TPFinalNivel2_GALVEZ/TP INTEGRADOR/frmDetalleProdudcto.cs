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
    public partial class frmDetalleProdudcto : Form
    {
        private Articulos detalle;
        private List<Articulos> listaDetalle;

        public frmDetalleProdudcto()
        {
            InitializeComponent();
        }
        public frmDetalleProdudcto(Articulos detalle)
        {
            InitializeComponent();
            this.detalle = detalle;

        }

        private void frmDetalleProdudcto_Load(object sender, EventArgs e)
        {


            // creo una lista que contiene un unico objeto detalle que recibo por parametros:

            dgvDetalle.DataSource = new List<Articulos> { detalle };
            Funciones_Validaciones.CargarImagen(detalle.UrlImagen, pbDetalle);


            dgvDetalle.Columns["Id"].Width = 20;
            dgvDetalle.Rows[0].Height = 40;
            dgvDetalle.Columns["Precio"].Width = 70;   
            dgvDetalle.Columns["Codigo"].Width = 50;
            dgvDetalle.Columns["UrlImagen"].Width = 200;
            dgvDetalle.AutoResizeRow(0);
            

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
