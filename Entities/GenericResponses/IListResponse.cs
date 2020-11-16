using System.Collections.Generic;

namespace Entities.GenericResponses
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
