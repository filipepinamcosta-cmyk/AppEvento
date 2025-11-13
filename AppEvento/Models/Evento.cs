using System;
using System.ComponentModel;

namespace AppEvento.Models
{
    public class Evento : INotifyPropertyChanged
    {
        private string _nome;
        private DateTime _dataInicio;
        private DateTime _dataTermino;
        private int _numeroParticipantes;
        private string _local;
        private double _custoPorParticipante;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Nome { get => _nome; set { _nome = value; OnPropertyChanged(nameof(Nome)); } }
        public DateTime DataInicio { get => _dataInicio; set { _dataInicio = value; OnPropertyChanged(nameof(DataInicio)); OnPropertyChanged(nameof(DuracaoDias)); } }
        public DateTime DataTermino { get => _dataTermino; set { _dataTermino = value; OnPropertyChanged(nameof(DataTermino)); OnPropertyChanged(nameof(DuracaoDias)); } }
        public int NumeroParticipantes { get => _numeroParticipantes; set { _numeroParticipantes = value; OnPropertyChanged(nameof(NumeroParticipantes)); OnPropertyChanged(nameof(CustoTotal)); } }
        public string Local { get => _local; set { _local = value; OnPropertyChanged(nameof(Local)); } }
        public double CustoPorParticipante { get => _custoPorParticipante; set { _custoPorParticipante = value; OnPropertyChanged(nameof(CustoPorParticipante)); OnPropertyChanged(nameof(CustoTotal)); } }

        public int DuracaoDias => (int)(DataTermino - DataInicio).TotalDays + 1;
        public double CustoTotal => NumeroParticipantes * CustoPorParticipante;
    }
}