using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Models;
using Elsa.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrchardCore.Admin;
using OrchardCore.Elsa.ViewModels;

namespace OrchardCore.Elsa.Controllers
{
    [Route("Admin/Elsa/WorkflowDefinitions")]
    [Admin]
    public class WorkflowDefinitionController : Controller
    {
        private readonly IWorkflowDefinitionStore definitionStore;
        private readonly IAuthorizationService authorizationService;

        public WorkflowDefinitionController
        (
            IWorkflowDefinitionStore definitionStore,
            IAuthorizationService authorizationService
        )
        {
            this.definitionStore = definitionStore;
            this.authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var workflowDefinitions = await definitionStore.ListAsync(VersionOptions.Latest, cancellationToken);
            var entries = workflowDefinitions.Select(x => new WorkflowDefinitionListEntryViewModel(x)).ToList();
            
            var model = new WorkflowDefinitionListViewModel
            {
                WorkflowDefinitions = entries
            };

            return View(model);
        }
        
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var model = new WorkflowDefinitionViewModel();

            return View("Create", model);
        }
        
        [HttpPost("Create")]
        public IActionResult Create(WorkflowDefinitionViewModel model)
        {
            return RedirectToAction("Index");
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!await authorizationService.AuthorizeAsync(User, Permissions.ManageElsaWorkflows))
            {
                context.Result = Unauthorized();
            }
            
            await base.OnActionExecutionAsync(context, next);
        }
    }
}
