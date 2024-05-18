namespace GNIT.Application.Handlers.Contracts
{
    public interface IHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest requests);
    }
}
