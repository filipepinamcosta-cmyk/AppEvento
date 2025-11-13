using AppEvento.Models;

namespace AppEvento.Views;

public partial class CadastroEventoPage : ContentPage
{
    private Evento _evento;

    public CadastroEventoPage()
    {
        InitializeComponent();
        _evento = new Evento { DataInicio = DateTime.Today, DataTermino = DateTime.Today, NumeroParticipantes = 1, CustoPorParticipante = 0 };
        BindingContext = _evento;
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_evento.Nome))
        {
            await DisplayAlert("Atenção", "Informe o nome do evento.", "OK");
            return;
        }
        if (_evento.DataTermino < _evento.DataInicio)
        {
            await DisplayAlert("Atenção", "A data de término não pode ser anterior à data de início.", "OK");
            return;
        }
        if (_evento.NumeroParticipantes <= 0)
        {
            await DisplayAlert("Atenção", "Informe um número válido de participantes.", "OK");
            return;
        }
        await Navigation.PushAsync(new ResumoEventoPage(_evento));
    }
}