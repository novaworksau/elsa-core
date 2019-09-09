using System.Threading;
using System.Threading.Tasks;
using Elsa.Persistence.YesSql.Extensions;
using Elsa.Persistence.YesSql.Indexes;
using Elsa.Runtime;
using YesSql;
using YesSql.Sql;

namespace Elsa.Persistence.YesSql.StartupTasks
{
    public class StoreInitializationTask : IStartupTask
    {
        private readonly IStore store;

        public StoreInitializationTask(IStore store)
        {
            this.store = store;
        }
        
        public Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            CreateTables();
            return Task.CompletedTask;
        }

        private void CreateTables()
        {
            using (var connection = store.Configuration.ConnectionFactory.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction(store.Configuration.IsolationLevel))
                {
                    new SchemaBuilder(store.Configuration, transaction, false).Setup();
                    transaction.Commit();
                }
            }
        }
    }
}