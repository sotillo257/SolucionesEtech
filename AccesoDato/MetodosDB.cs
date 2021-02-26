using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDato
{
    public class MetodosDB
    {
        // Objetos de base de datos
        private string strCadenaDeConexionSQL;
        public SqlConnection sqlConexion;
        public SqlCommand sqlComando;
        private string strNombreConexion;
        public string strCadenaDeConexionOLAP;

        public MetodosDB()
        {

            //
            // TODO: Add constructor logic here
            //
            this.strNombreConexion = "dbPortal";

            this.strCadenaDeConexionSQL = ConfigurationManager.ConnectionStrings[this.strNombreConexion].ToString();
            this.sqlConexion = new SqlConnection(this.strCadenaDeConexionSQL);

        }
        public MetodosDB(string NombreConexion)
        {

            //
            // TODO: Add constructor logic here
            //
            this.strNombreConexion = NombreConexion;
            this.strCadenaDeConexionSQL = ConfigurationManager.ConnectionStrings[this.strNombreConexion].ToString();
            this.sqlConexion = new SqlConnection(this.strCadenaDeConexionSQL);

        }

        #region "Funciones públicas"
        public DataSet RetornaDataSet(string strSQL)
        {
            if (this.sqlConexion == null)
                this.sqlConexion = new SqlConnection(this.strCadenaDeConexionSQL);

            SqlDataAdapter sadAdaptador;
            DataSet dsDataSet = new DataSet();
            try
            {
                if (this.sqlConexion.State == ConnectionState.Closed)
                    this.sqlConexion.Open();

                sadAdaptador = new SqlDataAdapter(strSQL, this.sqlConexion);
                sadAdaptador.Fill(dsDataSet);
                this.sqlConexion.Close();
            }
            catch (Exception ex)
            {
                if (this.sqlConexion.State == ConnectionState.Open)
                    this.sqlConexion.Close();
            }
            return dsDataSet;
        }

        public DataTable RetornaDataTable(string strSQL, ref string strError)
        {
            if (this.sqlConexion == null)
                this.sqlConexion = new SqlConnection(this.strCadenaDeConexionSQL);

            SqlDataAdapter sadAdaptador;
            DataTable dsDataTable = new DataTable();
            try
            {
                if (this.sqlConexion.State == ConnectionState.Closed)
                    this.sqlConexion.Open();

                sadAdaptador = new SqlDataAdapter(strSQL, this.sqlConexion);
                sadAdaptador.Fill(dsDataTable);
                this.sqlConexion.Close();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                if (this.sqlConexion.State == ConnectionState.Open)
                    this.sqlConexion.Close();
            }
            return dsDataTable;
        }

        public DataSet Retorna_DataSet_Sp(string strNombreSp, SqlParameter[] sqlParametros, bool bolTieneParametros, ref string strError)
        {
            if (this.sqlConexion == null)
                this.sqlConexion = new SqlConnection(this.strCadenaDeConexionSQL);

            SqlDataAdapter sadAdaptador;
            DataSet dsDataSet = new DataSet();
            SqlCommand sqlComandoSP = new SqlCommand();
            sqlComandoSP.Connection = this.sqlConexion;
            try
            {
                if (this.sqlConexion.State == ConnectionState.Closed)
                    this.sqlConexion.Open();

                sqlComandoSP.CommandType = CommandType.StoredProcedure;
                sqlComandoSP.CommandText = strNombreSp;
                if (bolTieneParametros)
                    foreach (SqlParameter Parametro in sqlParametros)
                        sqlComandoSP.Parameters.Add(Parametro);


                sadAdaptador = new SqlDataAdapter(sqlComandoSP);
                sadAdaptador.Fill(dsDataSet);
                this.sqlConexion.Close();

                sqlComandoSP.Parameters.Clear();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                if (this.sqlConexion.State == ConnectionState.Open)
                    this.sqlConexion.Close();
            }
            return dsDataSet;
        }
        public bool EjecutarSQL(string strSQL)
        {
            SqlCommand Comando = new SqlCommand();
            int intRegistrosAfectados = 0;

            try
            {
                if (this.sqlConexion.State == ConnectionState.Closed)
                    this.sqlConexion.Open();
                Comando.CommandType = CommandType.Text;
                Comando.Connection = this.sqlConexion;
                Comando.CommandText = strSQL;

                intRegistrosAfectados = Comando.ExecuteNonQuery();

                this.sqlConexion.Close();

            }
            catch (Exception ex)
            {
                if (this.sqlConexion.State == ConnectionState.Open)
                    this.sqlConexion.Close();

                return false;
            }
            return true;
        }


        #endregion
    }
}
