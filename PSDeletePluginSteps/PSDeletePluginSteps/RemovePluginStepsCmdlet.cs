using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Management.Automation;

namespace PSMGCRM
{
    [Cmdlet(VerbsCommon.Remove, "PluginSteps")]
    [OutputType(typeof(string))]
    public class RemovePluginStepsCmdlet : Cmdlet
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
                    repo.DeletePluginExecutionSteps(DllName);
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
