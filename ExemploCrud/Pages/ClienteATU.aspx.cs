using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.UI
{
    public partial class ClienteATU : System.Web.UI.Page
    {
        BLL.Cliente Cliente = new BLL.Cliente();
        DAL.ClienteDAL ClienteDAL = new DAL.ClienteDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            int idRecibido = 0;

            btnAtualizar.Enabled = false;
            if (!IsPostBack)
            {
                //Validar se está recebendo a variável cod na URL
                if (Request.QueryString["cod"] != null)
                {
                    //Validar se a variável veio com o valor preenchido
                    if (Request.QueryString["cod"].ToString() != "")
                    {
                        int.TryParse(Request.QueryString["cod"].ToString(), out idRecibido);
                        Cliente.Id = idRecibido;
                        Cliente = ClienteDAL.Selecionar(Cliente);
                        if (Cliente.Id != 0)
                        {
                            txtID.Text = Cliente.Id.ToString();
                            txtNome.Text = Cliente.Nome;
                            txtEmail.Text = Cliente.Email;
                            txtDtNascimento.Value = Cliente.DtNascimento.ToString("yyyy-MM-dd");
                            txtCEP.Text = Cliente.CEP;
                            txtRua.Text = Cliente.Rua;
                            txtBairro.Text = Cliente.Bairro;
                            txtCidade.Text = Cliente.Cidade;
                            txtEstado.Text = Cliente.Estado;

                            btnAtualizar.Enabled = true;
                        }
                        else
                        {
                            Response.Write("<script>alert('ID não localizado')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('ID de Cliente vazio')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('ID de Cliente não recebido')</script>");
                }
            }

        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Cliente Cliente = new BLL.Cliente();
                Cliente.Id = int.Parse(txtID.Text);
                Cliente.Nome = txtNome.Text;
                Cliente.Email = txtEmail.Text;
                Cliente.DtNascimento = Convert.ToDateTime(txtDtNascimento.Value);
                Cliente.CEP = txtCEP.Text;
                Cliente.Rua = txtRua.Text;
                Cliente.Bairro = txtBairro.Text;
                Cliente.Cidade = txtCidade.Text;
                Cliente.Estado = txtEstado.Text;

                ClienteDAL.Atualizar(Cliente);

                Cliente.Id = 0;
                Cliente.Nome = "";
                txtEmail.Text = "";
                txtDtNascimento.Value = "";
                txtCEP.Text = "";
                txtRua.Text = "";
                txtBairro.Text =    "";
                txtCidade.Text = "";
                txtEstado.Text = "" ;

                Response.Write("<script>alert('Atualizado')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Erro')</script>");
                Response.Write("<div>" + ex.Message + "</div>");
            }
        }
    }
}