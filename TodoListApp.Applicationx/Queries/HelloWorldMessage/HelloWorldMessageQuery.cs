using MediatR;

namespace TodoListApp.Applicationx.Queries.HelloWorldMessage
{
    public class HelloWorldMessageQuery : IRequest<string>
    {
        public int LangCode { get; set; }
    }
}
