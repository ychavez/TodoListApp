using MediatR;
using TodoListApp.Applicationx.Services.Abstractions;

namespace TodoListApp.Applicationx.Queries.HelloWorldMessage
{
    public class HelloWorldMessageQueryHandler : IRequestHandler<HelloWorldMessageQuery, string>
    {
        private readonly INavigationService navigationService;

        public HelloWorldMessageQueryHandler(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public async Task<string> Handle(HelloWorldMessageQuery request, CancellationToken cancellationToken)
        {
            List<string> messages = new List<string>()
            {
                "Hola", "Hello", "Buenas", "Bonjour", "Hallo", "Ciao", "Olá", "Привет", "こんにちは", "안녕하세요",
                "你好", "مرحبا", "Hej", "Ahoj", "Merhaba", "Γειά σου", "שלום", "नमस्ते", "สวัสดี", "Selam",
                "Sveiki", "Tere", "Здраво", "سلام", "Здравейте", "გამარჯობა", "Xin chào", "Kamusta", "Sawubona"
            };

            if (request.LangCode < 0 || request.LangCode >= messages.Count)
            {
                return "no encontrado";
            }
            return messages[request.LangCode];
        }
    }
}
