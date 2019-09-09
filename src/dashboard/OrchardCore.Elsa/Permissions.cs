using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace OrchardCore.Elsa
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageElsaWorkflows = new Permission(
            "ManageElsaWorkflows",
            "Manage Elsa workflows"
        );

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageElsaWorkflows }.AsEnumerable());
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ManageElsaWorkflows }.AsEnumerable();
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageElsaWorkflows }
                }
            };
        }
    }
}