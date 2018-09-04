using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Management.Automation;


namespace PSMGCRM
{
    [Cmdlet(VerbsCommon.Remove, "Plugin")]
    [OutputType(typeof(string))]
    public class RemovePluginCmdlet : Cmdlet
    {
        [Parameter]
        public string ConnectionString { get; set; }
        [Parameter]
        public string DllName { get; set; }

        private CrmServiceClient crmSvc;
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            try
            {
                crmSvc = new CrmServiceClient(ConnectionString);
                if (!crmSvc.IsReady)
                {
                    this.WriteObject(crmSvc.LastCrmError);
                }
                else
                {
                    var repo = new Repository(crmSvc);
                    repo.DeletePlugin(DllName);
                }

            }
            catch (Exception e)
            {
                WriteObject(e.Message);
            }

            base.ProcessRecord();
        }
    }
}
