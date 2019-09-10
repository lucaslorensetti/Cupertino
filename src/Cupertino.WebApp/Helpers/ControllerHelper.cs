using Cupertino.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cupertino.WebApp.Helpers
{
    public static class ControllerHelper
    {
        public static IActionResult GetActionResult(this Controller controller, OperationResult operationResult)
        {
            if (operationResult.NotFound)
            {
                return controller.NotFound();
            }

            if (!string.IsNullOrWhiteSpace(operationResult.ErrorMessage))
            {
                return controller.BadRequest(operationResult.ErrorMessage);
            }

            return controller.Ok(operationResult.EntityId);
        }
    }
}
