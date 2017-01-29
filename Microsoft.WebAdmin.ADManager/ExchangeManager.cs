using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace Microsoft.WebAdmin.Exchange
{
    public class ExchangeManager
    {

        public static bool MailExist(string account)
        {
            string psUrl = string.Format("http://{0}/powershell?serializationLevel=Full", ConfigurationManager.AppSettings["ExchangeServerUrl"]);
            //PSCredential newCred = (PSCredential)null;
            System.Security.SecureString securePassword = new System.Security.SecureString();
            string ExchangePWD = ConfigurationManager.AppSettings["ExchangePassword"];
            foreach (char c in ExchangePWD.ToCharArray())
            {
                securePassword.AppendChar(c);
            }
            PSCredential newCred = new System.Management.Automation.PSCredential(ConfigurationManager.AppSettings["ExchangeAdmin"], securePassword);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(psUrl), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", newCred);
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();

            PSCommand command = new PSCommand();
            command.AddCommand("get-mailbox");
            command.AddParameter("identity", account);
            powershell.Commands = command;
            Collection<PSObject> results = new Collection<System.Management.Automation.PSObject>();
            try
            {
                runspace.Open();
                powershell.Runspace = runspace;
                results = powershell.Invoke();
            }
            catch (Exception ex)
            {
                string er = ex.InnerException.ToString();
            }
            finally
            {
                runspace.Dispose();
                runspace = null;

                powershell.Dispose();
                powershell = null;
            }
            return results.Count == 1 ? true : false;
        }

        /// <summary>
        /// create the user's mail box
        /// </summary>
        /// <param name="Name">shanghaionstar\michael</param> 
        /// <returns></returns>
        public static string EnableMailBox(string Name)
        {
            string mailAddress = string.Empty;
            string psUrl = string.Format("http://{0}/powershell?serializationLevel=Full", ConfigurationManager.AppSettings["ExchangeServerUrl"]);
            //PSCredential newCred = (PSCredential)null;
            System.Security.SecureString securePassword = new System.Security.SecureString();
            string ExchangePWD = ConfigurationManager.AppSettings["ExchangePassword"];
            foreach (char c in ExchangePWD.ToCharArray())
            {
                securePassword.AppendChar(c);
            }
            PSCredential newCred = new System.Management.Automation.PSCredential(ConfigurationManager.AppSettings["ExchangeAdmin"], securePassword);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(psUrl), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", newCred);
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();

            PSCommand command = new PSCommand();
            command.AddCommand("Enable-mailbox");
            command.AddParameter("identity", Name);
            command.AddParameter("Database", ConfigurationManager.AppSettings["ExchangeMailBoxDatabase"]);
            powershell.Commands = command;
            Collection<PSObject> results = new Collection<System.Management.Automation.PSObject>();
            try
            {
                runspace.Open();
                powershell.Runspace = runspace;
                results = powershell.Invoke();
                mailAddress = results[0].Properties["WindowsEmailAddress"].Value.ToString();
                //smtp PrimarySmtpAddress
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                runspace.Dispose();
                runspace = null;

                powershell.Dispose();
                powershell = null;
            }
            return mailAddress;
        }
        /// <summary>
        /// create the user's mail box
        /// </summary>
        /// <param name="Name">shanghaionstar\michael</param> 
        /// <returns></returns>
        public static string CreateExternalMailBox(string Name, string externalemailaddress, string alias)
        {
            //string mailAddress = string.Empty;
            string result = string.Empty;
            string psUrl = string.Format("http://{0}/powershell?serializationLevel=Full", ConfigurationManager.AppSettings["ExchangeServerUrl"]);
            //PSCredential newCred = (PSCredential)null; 
            System.Security.SecureString securePassword = new System.Security.SecureString();
            string ExchangePWD = ConfigurationManager.AppSettings["ExchangePassword"];
            foreach (char c in ExchangePWD.ToCharArray())
            {
                securePassword.AppendChar(c);
            }
            PSCredential newCred = new System.Management.Automation.PSCredential(ConfigurationManager.AppSettings["ExchangeAdmin"], securePassword);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(psUrl), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", newCred);
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();

            PSCommand command = new PSCommand();
            command.AddCommand("new-mailuser");
            command.AddParameter("name", Name);
            command.AddParameter("externalemailaddress", externalemailaddress);
            command.AddParameter("alias", alias);
            powershell.Commands = command;
            Collection<PSObject> results = new Collection<System.Management.Automation.PSObject>();
            try
            {
                runspace.Open();
                powershell.Runspace = runspace;
                results = powershell.Invoke();
                //mailAddress = results[0].Properties["WindowsEmailAddress"].Value.ToString();
                //smtp PrimarySmtpAddress
            }
            catch (Exception ex)
            {
                result = ex.Message;
                throw ex.InnerException;
            }
            finally
            {
                runspace.Dispose();
                runspace = null;

                powershell.Dispose();
                powershell = null;
            }
            return result;
        }

        /// <summary>
        /// Disable the mailbox
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool DisableMailBox(string Name)
        {
            bool f = false;
            string psUrl = string.Format("http://{0}/powershell?serializationLevel=Full", ConfigurationManager.AppSettings["ExchangeServerUrl"]);
            //PSCredential newCred = (PSCredential)null;
            System.Security.SecureString securePassword = new System.Security.SecureString();
            string ExchangePWD = ConfigurationManager.AppSettings["ExchangePassword"];
            foreach (char c in ExchangePWD.ToCharArray())
            {
                securePassword.AppendChar(c);
            }
            PSCredential newCred = new System.Management.Automation.PSCredential(ConfigurationManager.AppSettings["ExchangeAdmin"], securePassword);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(psUrl), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", newCred);
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
            System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create();

            PSCommand command = new PSCommand();
            command.AddCommand("disable-mailbox");
            command.AddParameter("identity", Name);
            command.AddParameter("confirm", false);
            powershell.Commands = command;
            Collection<PSObject> results = new Collection<System.Management.Automation.PSObject>();
            try
            {
                runspace.Open();
                powershell.Runspace = runspace;
                results = powershell.Invoke();
                f = true;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                runspace.Dispose();
                runspace = null;

                powershell.Dispose();
                powershell = null;
            }
            return f;
        } 


         
    }
}
