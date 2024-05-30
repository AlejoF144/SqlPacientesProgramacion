using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacientes
{
    public partial class frmModificarPaciente : Form
    {
        Pacientes pc = new Pacientes();
        public frmModificarPaciente(int id)
        {
            InitializeComponent();
            cmbSexo.ValueMember = "Id";
            cmbSexo.DisplayMember = "Descripcion";
            cmbSexo.DataSource = Sexos.BuscarTodo();
            if (id > 0)
            {
                DataTable dt = Pacientes.BuscarPorId(id);
                if (dt.Rows.Count > 0)
                {
                    pc.Id = dt.Rows[0].Field<int>("Id");
                    pc.Nombre = dt.Rows[0].Field<string>("Nombre");
                    pc.Apellido = dt.Rows[0].Field<string>("Apellido");
                    pc.FechaNacimiento = dt.Rows[0].Field<DateTime>("FechaNacimiento");
                    pc.Dni = dt.Rows[0].Field<int>("Dni");
                    pc.IdSexo = dt.Rows[0].Field<int>("IdSexo");

                    cmbSexo.SelectedValue = pc.IdSexo;
                    txtId.Text = pc.Id.ToString();
                    txtNombre.Text = pc.Nombre;
                    txtApellido.Text = pc.Apellido;
                    txtFechaNacimiento.Text = pc.FechaNacimiento.ToString();
                    txtDni.Text = pc.Dni.ToString();      
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
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son obligatorios");
                correcto = false;
            }
            if (correcto)
            {
                pc.Id = Convert.ToInt32(txtId.Text);
                pc.Nombre = txtNombre.Text;
                pc.Apellido=txtApellido.Text;
                DateTime fecha = Convert.ToDateTime(txtFechaNacimiento.Text);
                pc.FechaNacimiento = fecha;
                pc.Dni = Convert.ToInt32(txtDni.Text);
                pc.IdSexo= Convert.ToInt32(cmbSexo.SelectedValue);
                if (pc.Modificar()) //devuelve true
                {
                    MessageBox.Show("Producto guardado correctamente");
                    Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al guarda");

                }
            }
        }

        private void frmModificarPaciente_Load(object sender, EventArgs e)
        {

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
