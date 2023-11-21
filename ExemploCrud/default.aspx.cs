using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            Server.Transfer("Pages/ClienteCAD.aspx");
        }

        protected void btnConsultarCliente_Click(object sender, EventArgs e)
        {
            Server.Transfer("Pages/ClienteCON.aspx");
        }

        protected void btnAtualizarCliente_Click(object sender, EventArgs e)
        {
            Server.Transfer("Pages/ClienteATU.aspx");
        }
    }
}