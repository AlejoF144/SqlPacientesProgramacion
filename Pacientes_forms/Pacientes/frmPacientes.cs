using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pacientes
{
    public partial class frmPacientes : Form
    {
        public frmPacientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoPaciente frm = new frmNuevoPaciente();
            frm.Show();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            DataTable dt = Pacientes.BuscarTodo();
            LlenarGrilla(dt);
        }
        private void LlenarGrilla(DataTable dt)
        {
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = dt;
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscarPorId_Click(object sender, EventArgs e)
        {
            int idbuscado;
            if (!Int32.TryParse(txtId.Text.Trim(), out idbuscado))
            {
                MessageBox.Show("El codigo ingresado no es valido");
            }
            else
            {
                DataTable dt = Pacientes.BuscarPorId(idbuscado);
                LlenarGrilla(dt);
            }
        }

        private void btnBuscarPorDni_Click(object sender, EventArgs e)
        {
            int dnibuscado;
            if (!Int32.TryParse(txtDni.Text.Trim(), out dnibuscado))
            {
                MessageBox.Show("El codigo ingresado no es valido");
            }
            else
            {
                DataTable dt = Pacientes.BuscarPorDNI(dnibuscado);
                LlenarGrilla(dt);
            }
        }

        private void btnBuscarPorNombre_Click(object sender, EventArgs e)
        {
            string Nombrebuscado = txtNombre.Text.Trim();
            if (Nombrebuscado != "")
            {
                DataTable dataTable =Pacientes.BuscarPorNombre(Nombrebuscado);
                LlenarGrilla(dataTable);
            }
            else
            {
                MessageBox.Show("Ingrese algo valido");
            }
        }

        private void btnBuscarPorApellido_Click(object sender, EventArgs e)
        {
            string Apellidobuscado = txtApellido.Text.Trim();
            if (Apellidobuscado != "")
            {
                DataTable dataTable = Pacientes.BuscarPorApellido(Apellidobuscado);
                LlenarGrilla(dataTable);
            }
            else
            {
                MessageBox.Show("Ingrese algo valido");
            }
        }

        private void btnBuscarPorSexo_Click(object sender, EventArgs e)
        {
            int idsexo =Convert.ToInt32(cmbSexo.SelectedValue);
            DataTable dt = Pacientes.BuscarPorSexo(idsexo); 
            LlenarGrilla(dt);
            
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            cmbSexo.ValueMember = "Id";
            cmbSexo.DisplayMember = "Descripcion";
            cmbSexo.DataSource = Sexos.BuscarTodo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvPacientes.CurrentRow.Cells[0].Value);
                DialogResult Borrar = MessageBox.Show("Seguro que quiere borrar?", "Advertencia", MessageBoxButtons.YesNo);
                if (Borrar == DialogResult.Yes)
                {
                    Pacientes.ElminarSeleccioado(id);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 0)
            {
                int id;
                id = Convert.ToInt32(dgvPacientes.CurrentRow.Cells[0].Value);
                frmModificarPaciente frm = new frmModificarPaciente(id);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
           
        }
    }
}
