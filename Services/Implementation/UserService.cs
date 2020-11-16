using AutoMapper;
using Data.DbModels;
using Data.GenericRepository;
using Entities.Constants;
using Entities.CustomEntities.User;
using Entities.GenericResponses;
using Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _UserRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<ISingleResponse<DtoUser>> AddUser(AddUser UserToAdd)
        {
            var response = new SingleResponse<DtoUser>();
            var UserDbModel = _mapper.Map<User>(UserToAdd);
        
            await _UserRepository.AddAsync(UserDbModel);
            response.Model = _mapper.Map<DtoUser>(UserDbModel);
            response.SetResponse(false,HttpResponseMessages.DATA_ADD_SUCCESS, HttpStatusCode.OK);
            return response;
        }

        public async Task<ISingleResponse<DtoUser>> GetUser(int UserId)
        {
            var response = new SingleResponse<DtoUser>();
            var getUserByIdQuery = _UserRepository.GetAll().Where(x => x.Id == UserId);


            if (await getUserByIdQuery.AnyAsync())
            {
                response.Model = _mapper.Map<DtoUser>(await getUserByIdQuery.FirstOrDefaultAsync());
                response.SetResponse(false, HttpResponseMessages.DATA_FOUND_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(false, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<IListResponse<DtoUser>> GetUsers()
        {
            var response = new ListResponse<DtoUser>();
            var getUsers = _UserRepository.GetAll();
            if (await getUsers.AnyAsync())
            {
                response.Model = _mapper.Map<List<DtoUser>>(await getUsers.ToListAsync());
                response.SetResponse(false, HttpResponseMessages.DATA_FOUND_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(false, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoUser>> InactiveUser(int UserId)
        {
            var response = new SingleResponse<DtoUser>();
            var UserDbModel = await _UserRepository.GetAll().Where(x => x.Id == UserId).FirstOrDefaultAsync();
            if (UserDbModel != null)
            {
            
                await _UserRepository.UpdateAsync(UserDbModel);
                response.Model = _mapper.Map<DtoUser>(UserDbModel);
                response.SetResponse(false, HttpResponseMessages.DATA_UPDATE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoUser>> RemoveUser(int UserId)
        {
            var response = new SingleResponse<DtoUser>();
            var UserDbModel = await _UserRepository.GetAll().Where(x => x.Id == UserId).FirstOrDefaultAsync();
            if (UserDbModel != null)
            {
                await _UserRepository.DeleteAsync(UserDbModel);
                response.Model = _mapper.Map<DtoUser>(UserDbModel);
                response.SetResponse(false, HttpResponseMessages.DATA_DELETE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoUser>> UpdateUser(int UserId, UpdateUser UserToUpdate)
        {
            var response = new SingleResponse<DtoUser>();
            var UserDbModel = await _UserRepository.GetAll().Where(x => x.Id == UserId).FirstOrDefaultAsync();
            if (UserDbModel != null)
            {
                UserDbModel = _mapper.Map(UserToUpdate, UserDbModel);
                await _UserRepository.UpdateAsync(UserDbModel);
                response.Model = _mapper.Map<DtoUser>(UserDbModel);
                response.SetResponse(false, HttpResponseMessages.DATA_UPDATE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }
    }
}
