
using MediatR;

namespace TaskManager.Application.Common
{
    public interface IQuery<out TResponse> : IRequest<TResponse> { }
    
}
