using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes
{
    internal class Sexos
    {
 #region Propiedades y atributos
        private int id;
        private string descripcion;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        #endregion
        public Sexos() { }
        
        public Sexos(string pDescripcion)
        {
            Descripcion = pDescripcion;
        }
       public  bool Nuevo()
        {
            bool correcto;
            string consulta = $"INSERT INTO Sexos (Descripcion) VALUES ('{Descripcion}')";
            correcto = BaseDatos.EjecutarConsulta(consulta);
            return correcto;
        }

        static public DataTable BuscarTodo()
        {
            DataTable dt = new DataTable();
            string consulta =$"SELECT Sexos.id, Sexos.Descripcion FROM Sexos ";
            dt=BaseDatos.Buscar(consulta) ;
            return dt;
        }

        static public DataTable BuscarPorId(int idbuscado)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Sexos.id, Sexos.Descripcion FROM Sexos WHERE Sexos.Id={idbuscado}";
            dt = BaseDatos.Buscar(consulta);
            return dt;

        }

        static public DataTable BuscarPorDescripcion(string descripcionabuscar)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Sexos.id, Sexos.Descripcion FROM Sexos WHERE Sexos.Descripcion LIKE '%{descripcionabuscar}%'";
            dt = BaseDatos.Buscar(consulta);
            return dt;
        }
        static public bool ElminarSeleccioado(int idSeleccionado)
        {
            bool correcto;
            string consulta = $"DELETE FROM Sexos WHERE Id={idSeleccionado}";
            correcto = BaseDatos.EjecutarConsulta(consulta);
            return correcto;
        }
        public bool Modificar()
        {
            bool correcto;
            string consulta = $"UPDATE Sexos SET Descripcion = '{Descripcion}' WHERE Id={Id} ";
            correcto = BaseDatos.EjecutarConsulta(consulta);
            return correcto;
        }
    }
}
