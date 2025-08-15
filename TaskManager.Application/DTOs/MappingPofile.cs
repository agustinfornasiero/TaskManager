
using AutoMapper;
using TaskManager.Application.DTOs.Tasks;
using TaskManager.Application.DTOs.Users;
using TaskManager.Core.Entities;

namespace TaskManager.Application.DTOs
{
    public class MappingPofile : Profile
    {
        public MappingPofile()
        {
            // Users
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Tasks
            CreateMap<TaskItem, TaskDto>().ReverseMap();
            CreateMap<CreateTaskDto, TaskItem>();
            CreateMap<UpdateTaskDto, TaskItem>();
        }
    }
}
