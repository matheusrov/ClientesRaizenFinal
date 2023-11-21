using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Cliente.DAL
{
    public class ClienteDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Cliente a)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"INSERT INTO Cliente(
                                    Nome,
                                    email,
                                    dtnascimento,
                                    cep,
                                    rua,
                                    bairro,
                                    cidade,
                                    estado)
                                VALUES(@nome,@email,@dtnascimento,@cep,@rua,@bairro,@cidade,@estado)";

            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@email", a.Email);
            cmd.Parameters.AddWithValue("@dtnascimento", a.DtNascimento);
            cmd.Parameters.AddWithValue("@cep", a.CEP);
            cmd.Parameters.AddWithValue("@rua", a.Rua);
            cmd.Parameters.AddWithValue("@bairro", a.Bairro);
            cmd.Parameters.AddWithValue("@cidade", a.Cidade);
            cmd.Parameters.AddWithValue("@estado", a.Estado);

            cmd.ExecuteNonQuery();

            con.Desconectar();
        }

        public DataTable Consultar()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT 
                                    Id,
                                    Nome,
                                    Email,
                                    DtNascimento,
                                    CEP,
                                    Rua,
                                    Bairro,
                                    Cidade,
                                    Estado
                                FROM
                                    Cliente";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public void Excluir(BLL.Cliente a)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"DELETE
                                FROM 
                                    Cliente
                                WHERE
                                    Id = @id";
            cmd.Parameters.AddWithValue("@id", a.Id);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable Consultar(BLL.Cliente a)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT 
                                    Id,
                                    Nome,
                                    Email,
                                    DtNascimento,
                                    CEP,
                                    Rua,
                                    Bairro,
                                    Cidade,
                                    Estado
                                FROM
                                    Cliente
                                WHERE
                                    Nome like @nome";
            cmd.Parameters.AddWithValue("@nome", "%" + a.Nome + "%");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Desconectar();

            return dt;
        }

        public void Atualizar(BLL.Cliente a)
        { 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE
                                    Cliente
                                SET
                                    Nome = @nome,
                                    Email = @email,
                                    DtNascimento = @dtnascimento,
                                    CEP = @cep,
                                    Rua = @rua,
                                    Bairro = @bairro,
                                    Cidade = @cidade,
                                    Estado = @estado                                    
                                WHERE
                                    Id = @id";
            cmd.Parameters.AddWithValue("@id", a.Id);
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@email", a.Email);
            cmd.Parameters.AddWithValue("@dtnascimento", a.DtNascimento);
            cmd.Parameters.AddWithValue("@cep", a.CEP);
            cmd.Parameters.AddWithValue("@rua", a.Rua);
            cmd.Parameters.AddWithValue("@bairro", a.Bairro);
            cmd.Parameters.AddWithValue("@cidade", a.Cidade);
            cmd.Parameters.AddWithValue("@estado", a.Estado);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Cliente Selecionar(BLL.Cliente a)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT 
                                   Id,
                                    Nome,
                                    Email,
                                    DtNascimento,
                                    CEP,
                                    Rua,
                                    Bairro,
                                    Cidade,
                                    Estado
                                FROM
                                    Cliente
                                WHERE 
                                    Id = @Id";
            cmd.Parameters.AddWithValue("@Id", a.Id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                a.Id = Convert.ToInt32(dr["Id"]);
                a.Nome = dr["Nome"].ToString();
                a.Email = dr["Email"].ToString();
                a.DtNascimento = Convert.ToDateTime(dr["DtNascimento"]);
                a.CEP = dr["CEP"].ToString();
                a.Rua = dr["Rua"].ToString();
                a.Bairro = dr["Bairro"].ToString();
                a.Cidade = dr["Cidade"].ToString();
                a.Estado = dr["Estado"].ToString();
                dr.Close();
            }
            else
            {
                a.Id = 0;
            }
            con.Desconectar();

            return a;
        }
    }
}