using System.Collections.Generic;

namespace OrchardCore.Elsa.ViewModels
{
    public class WorkflowDefinitionListViewModel
    {
        public IList<WorkflowDefinitionListEntryViewModel> WorkflowDefinitions { get; set; }
    }
}