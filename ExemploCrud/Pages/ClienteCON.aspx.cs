using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.UI
{
    public partial class ClienteCON : System.Web.UI.Page
    {

        DAL.ClienteDAL ClienteDAL = new DAL.ClienteDAL();
        BLL.Cliente Cliente = new BLL.Cliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                gvResultado.DataSource = ClienteDAL.Consultar();
                gvResultado.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            Cliente.Nome = txtFiltro.Text;
            gvResultado.DataSource = ClienteDAL.Consultar(Cliente);
            gvResultado.DataBind();
        }

        protected void gvResultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Cliente.Id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "cmdExcluir")
            {
                ClienteDAL.Excluir(Cliente);
                Response.Write("<script>alert('Cliente Id: " + Cliente.Id + " excluido')</script>");
                btnFiltrar_Click(null, null);
            }
            else
            {
                if (e.CommandName == "cmdAtualizar")
                {
                    Response.Redirect("ClienteATU.aspx?cod=" + Cliente.Id);
                }
            }
        }
    }
}