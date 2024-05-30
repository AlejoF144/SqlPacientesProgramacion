using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes
{
    internal class Pacientes
    {
        #region Propiedades y atributos
        private int id;
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private int idSexo;
        private int dni;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public int IdSexo
        {
            get { return idSexo; }
            set { idSexo = value; }
        }
        public int Dni
        {
            get { return dni; }
            set
            {
                dni = value;
            }
        }
        #endregion

        public Pacientes() { }

        public Pacientes(string pNombre, string pApellido, DateTime pFechaNacimiento, int pIdSexo, int pDni)
        {
            Nombre = pNombre;
            Apellido = pApellido;
            FechaNacimiento = pFechaNacimiento;
            IdSexo = pIdSexo;
            Dni = pDni;
        }

        public bool Nuevo()
        {
            bool correcto;
            string consulta = $"INSERT INTO Pacientes (Nombre,Apellido,FechaNacimiento,IdSexo,Dni)" +
                $" VALUES ('{Nombre}', '{Apellido}', '{FechaNacimiento}',{idSexo}, {Dni} ) ";
            correcto = BaseDatos.EjecutarConsulta(consulta);
            return correcto;
        }
        static public DataTable BuscarTodo()
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Pacientes.id AS IdPaciente, Pacientes.Nombre, Pacientes.Apellido, Pacientes.FechaNacimiento, Pacientes.IdSexo, Pacientes.Dni, " +
                $"Sexos.Id AS IdSexo, Sexos.Descripcion AS Sexo FROM Pacientes INNER JOIN Sexos ON Pacientes.IdSexo= Sexos.Id";
            dt = BaseDatos.Buscar(consulta);
            return dt;
        }
        static public DataTable BuscarPorId(int idbuscado)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Pacientes.id, Pacientes.Nombre, Pacientes.Apellido, Pacientes.FechaNacimiento, Pacientes.IdSexo, Pacientes.Dni, " +
                $"Sexos.Id AS IdSexo, Sexos.Descripcion AS Sexo FROM Pacientes INNER JOIN Sexos ON Pacientes.IdSexo= Sexos.Id WHERE Pacientes.Id={idbuscado} ";
            dt = BaseDatos.Buscar(consulta);
            return dt;

        }
        static public DataTable BuscarPorDNI(int DNI)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Pacientes.id, Pacientes.Nombre, Pacientes.Apellido, Pacientes.FechaNacimiento, Pacientes.IdSexo, Pacientes.Dni, " +
                $"Sexos.Id AS IdSexo, Sexos.Descripcion AS Sexo FROM Pacientes INNER JOIN Sexos ON Pacientes.IdSexo= Sexos.Id WHERE Pacientes.Dni={DNI} ";
            dt = BaseDatos.Buscar(consulta);
            return dt;

        }

        static public DataTable BuscarPorNombre(string nombrebuscar)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Pacientes.id, Pacientes.Nombre, Pacientes.Apellido, Pacientes.FechaNacimiento, Pacientes.IdSexo, Pacientes.Dni, " +
                $"Sexos.Id AS IdSexo, Sexos.Descripcion AS Sexo FROM Pacientes INNER JOIN Sexos ON Pacientes.IdSexo= Sexos.Id WHERE Pacientes.Nombre LIKE '%{nombrebuscar}%' ";
            dt = BaseDatos.Buscar(consulta);
            return dt;

        }

        static public DataTable BuscarPorApellido(string Apellidobuscado)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Pacientes.id, Pacientes.Nombre, Pacientes.Apellido, Pacientes.FechaNacimiento, Pacientes.IdSexo, Pacientes.Dni, " +
                $"Sexos.Id AS IdSexo, Sexos.Descripcion AS Sexo FROM Pacientes INNER JOIN Sexos ON Pacientes.IdSexo= Sexos.Id WHERE Pacientes.Nombre LIKE '%{Apellidobuscado}%' ";
            dt = BaseDatos.Buscar(consulta);
            return dt;

        }

        static public DataTable BuscarPorSexo(int idsexo)
        {
            DataTable dt = new DataTable();
            string consulta = $"SELECT Pacientes.id, Pacientes.Nombre, Pacientes.Apellido, Pacientes.FechaNacimiento, Pacientes.IdSexo, Pacientes.Dni, " +
                $"Sexos.Id AS IdSexo, Sexos.Descripcion AS Sexo FROM Pacientes INNER JOIN Sexos ON Pacientes.IdSexo= Sexos.Id WHERE Pacientes.IdSexo={idsexo} ";
            dt = BaseDatos.Buscar(consulta);
            return dt;

        }
        static public bool ElminarSeleccioado(int idSeleccionado)
        {
            bool correcto;
            string consulta = $"DELETE FROM Pacientes WHERE Id={idSeleccionado}";
            correcto = BaseDatos.EjecutarConsulta(consulta);
            return correcto;
        }

        public bool Modificar()
        {
            bool correcto;
            string consulta = $"UPDATE Pacientes SET  Nombre = '{Nombre}', Apellido = '{Apellido}', FechaNacimiento={FechaNacimiento},IdSexo={IdSexo},Dni={Dni} WHERE Id = {Id}";
            correcto = BaseDatos.EjecutarConsulta(consulta);
            return correcto;
        } 
    }
}
