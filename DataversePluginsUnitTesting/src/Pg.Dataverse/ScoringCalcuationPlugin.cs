using Microsoft.Xrm.Sdk;
using Pg.Dataverse.Model;
using System;

namespace Pg.Dataverse
{
    public class ScoringCalcuationPlugin : PluginBase
    {
        public ScoringCalcuationPlugin(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(ScoringCalcuationPlugin))
        {
        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;
            if (context.InputParameters.Contains(Target) && context.InputParameters[Target] is Entity)
            {
                var entity = (Entity)context.InputParameters[Target];
                if (entity.LogicalName == Account.EntityLogicalName)
                {
                    var account = entity.ToEntity<Account>();
                    var scoringPoints = 0;

                    if (account.NumberOfEmployees > 500) scoringPoints++; 
                    if(account.Revenue?.Value > 10000000m) scoringPoints++;

                    var orgServiceFactory = localPluginContext.InitiatingUserService;
                    if (account.pg_areaId != null && orgServiceFactory != null)
                    {
                        var area = orgServiceFactory.Retrieve(
                            pg_area.EntityLogicalName,
                            account.pg_areaId.Id,
                            new Microsoft.Xrm.Sdk.Query.ColumnSet(pg_area.Fields.pg_isimportant));

                        if (area?.ToEntity<pg_area>()?.pg_isimportant == true)
                        {
                            scoringPoints++;
                        }
                    }

                    if (scoringPoints == 3)
                    {
                        account.pg_scoring = pg_scoring.High;
                    }
                    else if (scoringPoints >= 2 && scoringPoints < 3) 
                    {
                        account.pg_scoring = pg_scoring.Medium;
                    }
                    else
                    {
                        account.pg_scoring = pg_scoring.Low; 
                    }
                }
                else
                {
                    localPluginContext.Trace("Target is not an account");
                }
            }
            else
            {
                localPluginContext.Trace("Missing target"); 
            }
        }
    }
}
