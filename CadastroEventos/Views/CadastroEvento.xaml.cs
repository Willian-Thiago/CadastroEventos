using CadastroEventos.Models;

namespace CadastroEventos.Views;

public partial class CadastroEvento : ContentPage
{
    App PropriedadesApp;


    public CadastroEvento()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        lugar_evento.ItemsSource = PropriedadesApp.lista_lugar;

        data_inicio.MinimumDate = DateTime.Now;
        data_inicio.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        // Define o valor inicial da data de término como um dia após a data de início
        data_inicio.Date = DateTime.Now;
        data_termino.Date = DateTime.Now.AddDays(1);
        data_termino.MinimumDate = DateTime.Now.AddDays(1);
        data_termino.MaximumDate = DateTime.Now.AddMonths(3);


    }

    private void data_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;
        DateTime data_selecionada_data_inicio = elemento.Date;

        data_termino.MinimumDate = data_selecionada_data_inicio.AddDays(1);
        data_termino.MaximumDate = data_selecionada_data_inicio.AddMonths(3);

        // Atualiza os limites e o valor da data de término
        data_termino.MinimumDate = data_selecionada_data_inicio.AddDays(1);
        data_termino.MaximumDate = data_selecionada_data_inicio.AddMonths(3);
        data_termino.Date = data_selecionada_data_inicio.AddDays(1);


    }

    private void data_termino_DateSelected(object sender, DateChangedEventArgs e)
    {
        data_termino.MinimumDate = data_inicio.Date.AddDays(1);
        data_termino.MaximumDate = data_inicio.Date.AddMonths(3);

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nomeEvento.Text))
        {
            await DisplayAlert("Erro", "O nome do evento é obrigatório.", "OK");
            return;
        }

        if (lugar_evento.SelectedItem == null)
        {
            await DisplayAlert("Erro", "Selecione um local para o evento.", "OK");
            return;
        }

        // Cria a instância do evento
        Evento evento = new Evento
        {
            NomeEvento = nomeEvento.Text,
            DataInicio = data_inicio.Date,
            DataTermino = data_termino.Date,
            QntConvidados = Convert.ToInt32(stp_convidados.Value),
            LugarSelecionado = lugar_evento.SelectedItem as Lugar
        };

        // Navega para a próxima tela passando os dados do evento
        await Navigation.PushAsync(new EventoContratado(evento));
    }

}




