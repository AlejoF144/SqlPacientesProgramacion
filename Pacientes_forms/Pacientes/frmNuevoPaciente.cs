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
    public partial class frmNuevoPaciente : Form
    {
        public frmNuevoPaciente()
        {
            InitializeComponent();
            cmbSexo.ValueMember = "Id";
            cmbSexo.DisplayMember = "Descripcion";
            cmbSexo.DataSource = Sexos.BuscarTodo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool correcto = true;
            if (txtNombre.Text.Trim()=="")
            {
                MessageBox.Show("Todos los campos son obligatorios");
                correcto = false;
            }
            if (txtApellido.Text.Trim() == "") 
            {

                MessageBox.Show("Todos los campos son obligatorios");
                correcto = false;
            }
            DateTime Fecha;
            if (!DateTime.TryParse(txtFechaNacimiento.Text.Trim(), out Fecha))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                correcto = false;
            }
            if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son obligatorios");
                correcto = false;
            }

            if (correcto)
            {
                Pacientes actual = new Pacientes(txtNombre.Text.Trim(),txtApellido.Text.Trim(),Fecha,Convert.ToInt32(cmbSexo.SelectedValue),Convert.ToInt32(txtDni.Text.Trim()));
                if (actual.Nuevo())
                {
                    MessageBox.Show("Paciente guardado correctamente");
                    Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al guarda");

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
