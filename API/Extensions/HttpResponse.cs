using Entities.GenericResponses;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions
{
    public static class HttpResponse
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.HttpCode
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.HttpCode
            };
        }
    }
}
