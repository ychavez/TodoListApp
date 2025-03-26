using MediatR;
using System.Windows.Input;
using TodoListApp.Applicationx.Queries.HelloWorldMessage;
using TodoListApp.Mobile.Model;

namespace TodoListApp.Mobile.ViewModels
{
    public class HelloWorldViewModel : BaseViewModel
    {
        public HelloWorldViewModel(IMediator mediator)
        {
            CambiarMensajeCommand = new Command(CambiarMensaje);

            Mensaje = new();
            this.mediator = mediator;
        }

        int count;
        public async void CambiarMensaje()
        {
            count++;
            var mensaje = await mediator.Send(new HelloWorldMessageQuery() { LangCode = count});

            Mensaje = new HelloWorld { Mensaje = mensaje, Count = count };
        }

        public ICommand CambiarMensajeCommand { get; set; }


        HelloWorld _mensaje;
        private readonly IMediator mediator;

        public HelloWorld Mensaje
        {
            get => _mensaje;
            set => SetProperty(ref _mensaje, value);
        }

    }
}
