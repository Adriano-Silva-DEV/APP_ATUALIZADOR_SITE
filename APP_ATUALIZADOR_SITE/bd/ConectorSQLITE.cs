using APP_ATUALIZADOR_SITE.classes;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace APP_ATUALIZADOR_SITE.bd
{
    class ConectorSQLITE
    {

        private static SQLiteConnection conexao;


        private static SQLiteConnection ConexaoBanco()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

            conexao =
                new SQLiteConnection($"Data Source= {path}\\base_dados\\BSSOLUCAO.db  ");
            conexao.Open();
            return conexao;
        }

        public static DataTable testaConexao()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM TPRODUTO";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());

                    da.Fill(dt);

                    MessageBox.Show(dt.Rows[0].Field<string>("NOMEFANTASIA"));
                    return dt;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void InsereProduto(ObjectsProdutoResponse produto)
        {


            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO TPRODUTO (NOMEFANTASIA, sku, id_externo, id) VALUES ( @NOMEFANTASIA, @sku, @id_externo, @id )";
                    cmd.Parameters.AddWithValue("@NOMEFANTASIA", produto.Nome);
                    cmd.Parameters.AddWithValue("@sku", produto.Sku);
                    cmd.Parameters.AddWithValue("@id_externo", produto.Id_externo);
                    cmd.Parameters.AddWithValue("@id", produto.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {


            }
        }

        public static void InsereLogInternoProduto( int  id)
        {
       
          
            try
            {
                using (var cmd =  new SQLiteCommand(ConexaoBanco()))
                {
                    cmd.CommandText = "UPDATE TPRODUTO SET UltimaAtt=@UltimaAtt WHERE id=@id ";
                   // cmd.CommandText = "UPDATE TPRODUTO SET UltimaAtt=12 WHERE id = 100594597 )";
                   cmd.Parameters.AddWithValue("@UltimaAtt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e )
            {
                MessageBox.Show("ereeer"+e);
                throw;
            }
        }

        public static void InsereLog(string erro, string messageLog )
        {
            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO LOG (Erro, MessageLog, Time ) VALUES (@erro, @MessageLog, @Time)";
                    cmd.Parameters.AddWithValue("@erro", erro);
                    cmd.Parameters.AddWithValue("@MessageLog", messageLog);
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }


}
