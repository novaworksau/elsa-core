using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Elsa
{
    public class AdminMenu : INavigationProvider
    {
        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            T = localizer;
        }

        public IStringLocalizer T { get; set; }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(T["Elsa"], "5", workflow => workflow
                .AddClass("elsa").Id("elsa").Action("Index", "WorkflowDefinition", new { area = "OrchardCore.Elsa" })
                    .Permission(Permissions.ManageElsaWorkflows)
                    .LocalNav());

            return Task.CompletedTask;
        }
    }
}
