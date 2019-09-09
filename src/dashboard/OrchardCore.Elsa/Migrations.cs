using Elsa.Persistence.YesSql.Extensions;
using OrchardCore.Data.Migration;

namespace OrchardCore.Elsa
{
    public class Migrations : DataMigration
    {
        public int Create()
        {
            SchemaBuilder.Setup();

            return 1;
        }
    }
}