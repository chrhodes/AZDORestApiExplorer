﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using AZDORestApiExplorer.Core.Events;
using AZDORestApiExplorer.Domain;

using Prism.Commands;
using Prism.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace AZDORestApiExplorer.Presentation.ViewModels
{
    public class CollectionMainViewModel : EventViewModelBase, ICollectionMainViewModel //, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public CollectionMainViewModel(
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }
        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            LoadCollections();

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }


        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private string _title = "GoGoGo";
        private static string _URI_BD_STS_QA2 = @"https://dev.azure.com/BD-STS-QA2";
        private static string _URI_BD_STS_PROD = @"https://dev.azure.com/BD-STS-PROD";
        private static string _URI_VNC_Development = @"https://dev.azure.com/VNC-Development";

        private static string _teamProjectName = "TFS";

        private static string _PAT_BD_STS_PROD = "";

        private static string _PAT_BD_STS_QA2 = "";

        private static string _PAT_VNC_Development = "";

        public ObservableCollection<AvailableCollection> AvailableCollections { get; set; }
            = new ObservableCollection<AvailableCollection>();

        private AvailableCollection _SelectedCollection;

        public AvailableCollection SelectedCollection
        {
            get => _SelectedCollection;
            set
            {
                if (_SelectedCollection == value)
                    return;
                _SelectedCollection = value;
                OnPropertyChanged();
                PublishSelectedCollectionChanged();
            }
        }
        private void PublishSelectedCollectionChanged()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            EventAggregator.GetEvent<SelectedCollectionChangedEvent>().Publish();

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods

        private void LoadCollections()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            AvailableCollections.Add(
                new AvailableCollection
                {
                    Name = "BD_STS_PROD",
                    Details = new CollectionDetails
                    {
                        Uri = @"https://dev.azure.com/BD-STS-PROD",
                        PAT = _PAT_BD_STS_PROD
                    }
                });

            AvailableCollections.Add(
                new AvailableCollection
                {
                    Name = "BD_STS_QA2",
                    Details = new CollectionDetails
                    {
                        Uri = @"https://dev.azure.com/BD-STS-QA2",
                        PAT = _PAT_BD_STS_QA2
                    }
                });

            AvailableCollections.Add(
                new AvailableCollection
                {
                    Name = "VNC-Development",
                    Details = new CollectionDetails
                    {
                        Uri = @"https://dev.azure.com/VNC-Development",
                        PAT = _PAT_VNC_Development
                    }
                });

            //AvailableCollections.Add(
            //    new AvailableCollection
            //    {
            //        Name = "VNC-Development Limited",
            //        Details = new CollectionDetails
            //        {
            //            Uri = @"https://dev.azure.com/VNC-Development",
            //            PAT = _PAT_VNC_DevelopmentLimited
            //        }
            //    });

            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region IInstanceCount

        private static int _instanceCountVM;

        public int InstanceCountVM
        {
            get => _instanceCountVM;
            set => _instanceCountVM = value;
        }

        #endregion
    }
}
