using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.UI
{
    public partial class ClienteCAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Cliente Cliente = new BLL.Cliente();
                Cliente.Nome = txtNome.Text;
                Cliente.Email = txtEmail.Text;
                Cliente.DtNascimento = Convert.ToDateTime(txtDtNascimento.Value);
                Cliente.CEP = txtCEP.Text;
                Cliente.Rua = txtRua.Text;
                Cliente.Bairro = txtBairro.Text;
                Cliente.Cidade = txtCidade.Text;
                Cliente.Estado = txtEstado.Text;


                DAL.ClienteDAL ClienteDAL = new DAL.ClienteDAL();

                ClienteDAL.Cadastrar(Cliente);

                lblMsg.Text = "Cliente cadastrado";
                Cliente.Id = 0;
                Cliente.Nome = "";
                txtEmail.Text = "";
                txtDtNascimento.Value = "";
                txtCEP.Text = "";
                txtRua.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtEstado.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}