
using Entities.CustomEntities.User;
using Entities.GenericResponses;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<IListResponse<DtoUser>> GetUsers();
        Task<ISingleResponse<DtoUser>> GetUser(int contactId);
        Task<ISingleResponse<DtoUser>> AddUser(AddUser contactToAdd);

        Task<ISingleResponse<DtoUser>> UpdateUser(int contactId,UpdateUser contactToUpdate);

        Task<ISingleResponse<DtoUser>> RemoveUser(int contactId);
        Task<ISingleResponse<DtoUser>> InactiveUser(int contactId);
    }
}
