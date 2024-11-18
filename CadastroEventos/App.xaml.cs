
using CadastroEventos.Models;

namespace CadastroEventos
{
    public partial class App : Application
    {
        public List<Lugar> lista_lugar = new List<Lugar>
        {
            new Lugar()
            {
                Descricao = "Salao de Festa",
                CustoParticipante = 100.0
            },
            new Lugar()
            {
                Descricao = "Sítio",
                CustoParticipante = 200.0
            },
            new Lugar()
            {
                Descricao = "Clube Aquático",
                CustoParticipante = 300.0
            }

        };
        



        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.CadastroEvento());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
           var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;
        }


    }
}
