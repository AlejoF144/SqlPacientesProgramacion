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
    public partial class frmSexos : Form
    {
        public frmSexos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoSexo nuevo= new frmNuevoSexo();
            nuevo.ShowDialog();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            DataTable dt = Sexos.BuscarTodo();
            LlenarGrilla(dt);
        }
        private void LlenarGrilla(DataTable dt)
        {
            dgvSexos.DataSource = null;
            dgvSexos.DataSource = dt;
        }

        private void btnBuscarPorId_Click(object sender, EventArgs e)
        {
            int idbuscado;
            if (!Int32.TryParse(txtId.Text.Trim(), out idbuscado ) )
            {
                MessageBox.Show("El codigo ingresado no es valido");
            }
            else 
            {
                DataTable dt = Sexos.BuscarPorId(idbuscado);
                LlenarGrilla(dt);
            }
           
        }

        private void btnBuscarPorDescripcion_Click(object sender, EventArgs e)
        {
            string DescripcionAbuscar = txtDescripcion.Text.Trim();
            if (DescripcionAbuscar != "")
            {
                DataTable dataTable = Sexos.BuscarPorDescripcion(DescripcionAbuscar);
                LlenarGrilla(dataTable);
            }
            else
            {
                MessageBox.Show("Ingrese algo valido");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvSexos.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvSexos.CurrentRow.Cells[0].Value);
                DialogResult Borrar = MessageBox.Show("Seguro que quiere borrar?", "Advertencia", MessageBoxButtons.YesNo);
                if(Borrar == DialogResult.Yes)
                {
                    Sexos.ElminarSeleccioado(id);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvSexos.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvSexos.CurrentRow.Cells[0].Value);
                frmModificarSexo frmModificarSexo = new frmModificarSexo(id);
                frmModificarSexo.Show();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
            
    }
}
