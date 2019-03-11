using AppXDesigner.Models;
using FireworksFramework.Managers;
using FireworksFramework.Types;
using IsWiXAutomationInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXDesigner.ViewModels
{
    public class AppXViewModel : ObservableObject
    {
        DocumentManager _documentManager = DocumentManager.DocumentManagerInstance;
        IsWiXFGAppXs _appxs;
        
        ObservableCollection<AppXModel> _appxModels = new ObservableCollection<AppXModel>();
        AppXModel _selectedAppxModel;

        bool _selected = false;

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChangedEvent("Selected");
            }
        }

        public ObservableCollection<AppXModel> AppXModels
        {
            get
            {
                return _appxModels;
            }
            set
            {
                _appxModels = value;
                RaisePropertyChangedEvent("AppXModels");
            }
        }


        public AppXModel SelectedAppXModel
        {
            get
            {
                return _selectedAppxModel;
            }
            set
            {
                _selectedAppxModel = value;
                if(_selectedAppxModel == null)
                {
                    Selected = false;
                }
                else
                {
                    Selected = true;
                }
                RaisePropertyChangedEvent("SelectedAppXModel");
            }
        }

        public void Load()
        {
            _appxs = new IsWiXFGAppXs(DocumentManager.DocumentManagerInstance.Document);
            AppXModels.Clear();
            SelectedAppXModel = new AppXModel(); ;
            foreach (var appx in _appxs)
            {
                AppXModel appxModel = new AppXModel();
                appxModel.Id = appx.Id;
                appxModel.Description = appx.Description;
                appxModel.DisplayName = appx.DisplayName;
                appxModel.LogoFile = appx.LogoFile;
                appxModel.MainPackage = appx.MainPackage;
                appxModel.MainPackage = appx.Manufacturer;
                appxModel.Publisher = appx.Publisher;
                appxModel.Target = appx.Target;
                appxModel.Version = appx.Version;
                appxModel.PropertyChanged += AppxModel_PropertyChanged;
                SelectedAppXModel = appxModel;
                AppXModels.Add(appxModel);
            }
        }

        public void CreateNew()
        {
            
            string appxName = IsWiXFGAppXs.SuggestNextAppXName(_documentManager.Document);
            IsWiXFGAppX appx = _appxs.Create(appxName, "CN=YourCompanyName", TargetType.desktop);

            AppXModel appxModel = new AppXModel();
            appxModel.Id = appx.Id;
            appxModel.Description = appx.Description;
            appxModel.DisplayName = appx.DisplayName;
            appxModel.LogoFile = appx.LogoFile;
            appxModel.MainPackage = appx.MainPackage;
            appxModel.MainPackage = appx.Manufacturer;
            appxModel.Publisher = appx.Publisher;
            appxModel.Target = appx.Target;
            appxModel.Version = appx.Version;
            appxModel.PropertyChanged += AppxModel_PropertyChanged;
            AppXModels.Add(appxModel);
            SelectedAppXModel = appxModel;

        }

        private void AppxModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }

        public void Delete()
        {

            var iswixAppXItem = _appxs.Where(a => a.Id == SelectedAppXModel.Id).First();
            iswixAppXItem.Delete();
            _appxs.Remove(iswixAppXItem);

            AppXModels.Remove(SelectedAppXModel);

            if (AppXModels.Any())
            {
                SelectedAppXModel = AppXModels.First();
            }

        }
    }
}
