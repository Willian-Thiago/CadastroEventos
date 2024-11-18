using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEventos.Models
{
    public class Evento
    {
        
        public Lugar? LugarSelecionado { get; set; }

        public string NomeEvento { get; set; }

        public int QntConvidados { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public int Estadia
        {
            get => DataTermino.Subtract(DataInicio).Days;
        }

        public double ValorTotal
        {
            get
            {

                    double valor_convidados = QntConvidados * LugarSelecionado.CustoParticipante;

                    double total = (valor_convidados * Estadia);
                    return total;

               
                
            }
        }


    }
}
