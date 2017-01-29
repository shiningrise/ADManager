using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace Microsoft.WebAdmin.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            RunspaceInvoke runspaceInvoke = new RunspaceInvoke(runspace);

            Pipeline pipeLine = runspace.CreatePipeline();
            pipeLine.Commands.AddScript("import-module ActiveDirectory");

           // pipeLine.Commands.AddScript("new-aduser -name aaaaaaaaaaa");
            pipeLine.Commands.AddScript("(get-aduser -identity  beifeng).name");
            pipeLine.Commands.Add("Out-String");
            Collection<PSObject> returnObjects = pipeLine.Invoke();
         
            runspace.Close();


            var s = returnObjects;
        }
    }
}