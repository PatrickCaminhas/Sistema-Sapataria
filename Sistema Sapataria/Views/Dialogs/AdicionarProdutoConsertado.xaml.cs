using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Sistema_Sapataria.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Sistema_Sapataria.Views.Dialogs
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdicionarProdutoConsertado : ContentDialog
    {
        private readonly IRepositorioDados _repositorio;

        public AdicionarProdutoConsertado(IRepositorioDados repositorio)
        {
            InitializeComponent();
            _repositorio = repositorio;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var nome = TxtNome.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                // impede o di�logo de fechar e exibe erro
                args.Cancel = true;
                ErrorText.Visibility = Visibility.Visible;
                return;
            }

            // grava no banco
            _repositorio.AddProdutoConserto(nome);
        }
    }
}
