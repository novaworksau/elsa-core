using Elsa.Models;

namespace OrchardCore.Elsa.ViewModels
{
    public class WorkflowDefinitionListEntryViewModel
    {
        public WorkflowDefinitionListEntryViewModel()
        {
        }

        public WorkflowDefinitionListEntryViewModel(WorkflowDefinition workflowDefinition)
        {
            WorkflowDefinition = workflowDefinition;
            Id = workflowDefinition.Id;
        }
        
        public WorkflowDefinition WorkflowDefinition { get; set; }
        public bool IsChecked { get; set; }
        public string Id { get; set; }
        public int InstanceCount { get; set; }
    }
}