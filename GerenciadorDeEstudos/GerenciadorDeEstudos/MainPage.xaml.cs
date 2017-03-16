using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GerenciadorDeEstudos.Views.Início.MenuItems;
using GerenciadorDeEstudos.Views.Anotacoes;
using GerenciadorDeEstudos.Views.Boletim;
using GerenciadorDeEstudos.Views.Cadastro;
using GerenciadorDeEstudos.Views.Calendario;
using GerenciadorDeEstudos.Views.Configuracoes;
using GerenciadorDeEstudos.Views.ListaDeTarefas;
using GerenciadorDeEstudos.Views.PaginaInicial;


namespace GerenciadorDeEstudos
{
    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {

            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Página Inicial",
                                               Icon = "PaginaInicial.png",
                                               TargetType = typeof(PaginaInicial)
            };
            var page2 = new MasterPageItem() { Title = "Cadastro",
                                               Icon = "Materias.png",
                                               TargetType = typeof(Cadastro)
            };
            var page3 = new MasterPageItem() { Title = "Boletim",
                                               Icon = "Boletim.png",
                                               TargetType = typeof(Boletim)
            };
            var page4 = new MasterPageItem() { Title = "Calendário",
                                               Icon = "Calendario.png",
                                               TargetType = typeof(Calendario)
            };
            var page5 = new MasterPageItem() { Title = "Anotações",
                                               Icon = "Anotacoes.png",
                                               TargetType = typeof(Anotacoes)
            };
            var page6 = new MasterPageItem() { Title = "Lista de Tarefas",
                                               Icon = "ListaTarefas.png",
                                               TargetType = typeof(ListaDeTarefas)
            };
            var page7 = new MasterPageItem() { Title = "Configurações",
                                               Icon = "Configuracoes.png",
                                               TargetType = typeof(Configuracoes)
            };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            menuList.Add(page7);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(PaginaInicial)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }        
    }
}
