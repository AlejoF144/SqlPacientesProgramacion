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
    public partial class frmNuevoSexo : Form
    {
        public frmNuevoSexo()
        {
            InitializeComponent();
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
                Sexos actual = new Sexos(txtDescripcion.Text);
                if (actual.Nuevo())
                {
                    MessageBox.Show("Sexo guardado correctamente");
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
