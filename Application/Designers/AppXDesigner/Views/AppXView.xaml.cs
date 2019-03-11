using FireworksFramework.Interfaces;
using FireworksFramework.Managers;
using FireworksFramework.Types;
using IsWiXAutomationInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FireworksFramework.Types.Enums;

namespace AppXDesigner.Views
{
    /// <summary>
    /// Interaction logic for AppXView.xaml
    /// </summary>
    public partial class AppXView : UserControl, IFireworksDesigner
    {
        DocumentManager _documentManager = DocumentManager.DocumentManagerInstance;
        public AppXView()
        {
            InitializeComponent();
        }
        public System.Drawing.Image PluginImage
        {
            get
            {
                return System.Drawing.Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("AppXDesigner.AppX.ico"));
            }
        }

        public string PluginInformation
        {
            get
            {
                return new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("AppXDesigner.License.txt")).ReadToEnd();
            }
        }

        public PluginType PluginType { get { return PluginType.Designer; } }

        public string PluginName
        {
            get { return "AppX"; }
        }

        public string PluginOrder
        {
            get { return "iswix_group2_appx"; }
        }
        public bool IsValidContext()
        {
            bool valid = false;
            IsWiXDocumentType documentType = _documentManager.Document.GetDocumentType();

            if (documentType == IsWiXDocumentType.Product || documentType == IsWiXDocumentType.Fragment)
            {
                valid = true;
            }
            return true;
        }

        public void LoadData()
        {
            viewModel.Load();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateNew();
        }

        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            viewModel.Delete();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            new FireGiantWiXMessage().ShowDialog();
        }
    }
}
