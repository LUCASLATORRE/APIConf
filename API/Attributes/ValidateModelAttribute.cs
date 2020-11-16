﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new Models.ValidationFailedResult(context.ModelState);
            }
        }
    }
}
