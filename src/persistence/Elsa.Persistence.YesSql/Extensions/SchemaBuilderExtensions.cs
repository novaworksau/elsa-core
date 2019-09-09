using Elsa.Persistence.YesSql.Indexes;
using YesSql.Sql;

namespace Elsa.Persistence.YesSql.Extensions
{
    public static class SchemaBuilderExtensions
    {
        public static ISchemaBuilder Setup(this ISchemaBuilder schemaBuilder)
        {
            return schemaBuilder
                .CreateMapIndexTable(
                    nameof(WorkflowDefinitionIndex),
                    table => table
                        .Column<string>("WorkflowDefinitionId")
                        .Column<int>("Version")
                        .Column<bool>("IsPublished")
                        .Column<bool>("IsLatest")
                )
                .CreateMapIndexTable(
                    nameof(WorkflowDefinitionStartActivitiesIndex),
                    table => table
                        .Column<string>("StartActivityId")
                        .Column<string>("StartActivityType")
                )
                .CreateMapIndexTable(
                    nameof(WorkflowInstanceIndex),
                    table => table
                        .Column<string>("WorkflowInstanceId")
                        .Column<string>("WorkflowDefinitionId")
                        .Column<string>("CorrelationId")
                        .Column<string>("WorkflowStatus")
                )
                .CreateMapIndexTable(
                    nameof(WorkflowInstanceBlockingActivitiesIndex),
                    table => table
                        .Column<string>("ActivityId")
                        .Column<string>("ActivityType")
                        .Column<string>("CorrelationId")
                );
        }
    }
}