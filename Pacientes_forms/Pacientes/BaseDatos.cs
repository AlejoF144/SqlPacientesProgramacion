using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Pacientes
{
    static internal class BaseDatos
    {
        static SqlConnection conn = new SqlConnection();
        static bool Conectar()
        {
            try
            {
                conn.ConnectionString = @"Data Source=LAPTOP-M9U4K2HM;Initial Catalog=EjPacientes;Integrated Security=True";
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        static public void Desconectar()
        {
            conn.Close();
        }

        static public bool EjecutarConsulta(string CadenaSQL)
        {
            bool Correcto = false;
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(CadenaSQL, conn);
                da.Fill(dt);
                Correcto = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return Correcto;
        }
        static public DataTable Buscar(string CadenaSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();

                SqlDataAdapter da = new SqlDataAdapter(CadenaSQL, conn);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dt = null;
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }

    }
}
