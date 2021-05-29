using FirebirdSql.Data.FirebirdClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace APP_ATUALIZADOR_SITE.bd
{
    class ConectorBD
    {

        private static readonly ConectorBD Instancia = new ConectorBD();

        private ConectorBD() { }

        public static ConectorBD PegarInstancia()
        {
            return Instancia;
        }

        public FbConnection PegarConexao()
        {
            string con = ConfigurationManager.ConnectionStrings["StringConexao"].ToString();
            return new FbConnection(con);
        }

        public static bool TestarConexao()
        {
            bool resposta = true;
            using (FbConnection Conexao = ConectorBD.PegarInstancia().PegarConexao())
            {
                try
                {
                    Conexao.Open();
                }
                catch (FbException)
                {

                    resposta = false;
                }
                finally
                {
                    Conexao.Close();
                }

                return resposta;
            }
        }

        public static void FbBusca()
        {

            using (FbConnection conexao = ConectorBD.PegarInstancia().PegarConexao())
            {
                try
                {
                    conexao.Open();
                    string mSQL = "Select NOMEFANTASIA from TPRODUTO ";
                    FbCommand cmd = new FbCommand(mSQL, conexao);
                    FbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MessageBox.Show(dr["NOMEFANTASIA"].ToString());
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conexao.Close();
                }

            }
        }
    }
}
