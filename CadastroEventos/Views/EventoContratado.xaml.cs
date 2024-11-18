using CadastroEventos.Models;

namespace CadastroEventos.Views;

public partial class EventoContratado : ContentPage
{
    public Evento Evento { get; set; }

    public EventoContratado(Evento evento)
    {
        InitializeComponent();
        Evento = evento;

        // Define o BindingContext com os dados do evento
        BindingContext = Evento;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CadastroEvento());
    }
}