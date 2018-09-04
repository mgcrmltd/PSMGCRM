using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
namespace PSMGCRM
{
    public class Repository
    {
        private readonly CrmServiceClient _crmSvc;

        public Repository(CrmServiceClient crmSvc)
        {
            _crmSvc = crmSvc;
        }

        public void DeletePluginExecutionSteps(string dll)
        {
            var pluginsteps = RetrievePluginstepsFromDll(dll);
            foreach (var step in pluginsteps)
            {
                _crmSvc.Delete("sdkmessageprocessingstep", step.Id);
            }
        }

        public void DeletePlugin(string name)
        {
            var plugin = GetPlugin(name);
            if (plugin == null) return;
            _crmSvc.Delete("pluginassembly", plugin.Id);
        }

        public Entity GetPlugin(string name)
        {
            var plugins = RetrieveByAttribute("pluginassembly", "name", name, new ColumnSet(true));
            return plugins != null && plugins.Count > 0 ? plugins[0] : null;
        }

        public List<Entity> RetrievePluginstepsFromDll(string dll)
        {
            var sdkStepsQuery = new QueryExpression("sdkmessageprocessingstep");
            sdkStepsQuery.ColumnSet = new ColumnSet(true);
            var le = new LinkEntity("sdkmessageprocessingstep", "plugintype", "plugintypeid", "plugintypeid", JoinOperator.Inner);
            var filterAssemblyName = new FilterExpression(LogicalOperator.And);
            filterAssemblyName.AddCondition("assemblyname", ConditionOperator.Equal, dll);
            le.LinkCriteria.AddFilter(filterAssemblyName);
            sdkStepsQuery.LinkEntities.Add(le);
            var filterEventHandler = new FilterExpression(LogicalOperator.And);
            filterEventHandler.AddCondition("eventhandlertypecode", ConditionOperator.Equal, 4602);
            sdkStepsQuery.Criteria.AddFilter(filterEventHandler);
            var ret = _crmSvc.RetrieveMultiple(sdkStepsQuery);
            return ret?.Entities?.ToList();
        }

        public List<Entity> RetrieveByAttribute(string entity, string attribute, object attributeValue)
        {
            return RetrieveByAttribute(entity, attribute, attributeValue, new ColumnSet(true));
        }

        public List<Entity> RetrieveByAttribute(string entity, string attribute, object attributeValue,
            ColumnSet columns)
        {
            var query = new QueryByAttribute(entity);
            query.AddAttributeValue(attribute, attributeValue);
            query.ColumnSet = columns;
            return _crmSvc.RetrieveMultiple(query)?.Entities?.ToList();
        }
    }
}
