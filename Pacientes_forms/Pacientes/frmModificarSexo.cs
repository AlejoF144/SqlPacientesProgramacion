using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacientes
{
    public partial class frmModificarSexo : Form
    {
        Sexos sexo = new Sexos();
        public frmModificarSexo(int id)
        {
            InitializeComponent();
            if (id > 0)
            {
                DataTable dt = Sexos.BuscarPorId(id);
                if (dt.Rows.Count > 0)
                {
                    sexo.Id = dt.Rows[0].Field<int>("Id");
                    sexo.Descripcion = dt.Rows[0].Field<string>("Descripcion");


                    txtId.Text= sexo.Id.ToString();
                    txtDescripcion.Text=sexo.Descripcion;
                }
                else
                {
                    MessageBox.Show("No se encontro producto con ese codigo");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool correcto = true;
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son obligatorios");
                correcto = false;
            }
            if (correcto)
            {
                sexo.Id= Convert.ToInt32(txtId.Text);
                sexo.Descripcion= txtDescripcion.Text;
            }
            if (sexo.Modificar())
            {
                MessageBox.Show("Producto guardado correctamente");
                Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al guarda");

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}