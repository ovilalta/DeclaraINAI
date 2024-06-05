using System.Data.SqlClient;
using System;
using System.Data;

namespace DeclaraINAI
{
    public static class BitacoraAdmin
    {
        public static void RegistraBitacoraAdmin(string usuarioAdmin, string opcionUtilizada, string detalleConsulta)
        {

            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            string connString = db.Database.Connection.ConnectionString;

            string sql = "Sp_InsertaBitacoraAdmin";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        cmd.Parameters.Add(new SqlParameter("@usuarioAdmin", usuarioAdmin));
                        cmd.Parameters.Add(new SqlParameter("@opcionUtilizada", opcionUtilizada));
                        cmd.Parameters.Add(new SqlParameter("@detalleConsulta", detalleConsulta));
                        cmd.Parameters.Add(new SqlParameter("@fechaEjecucion", DateTime.Now));

                        // Abrir conexión
                        conn.Open();

                        // Ejecutar el procedimiento almacenado
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Mostrar el resultado si es necesario
                        Console.WriteLine("Rows affected: " + rowsAffected);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}