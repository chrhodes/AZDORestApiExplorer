using System;

using AZDORestApiExplorer.Domain.Test;
using AZDORestApiExplorer.Presentation.ViewModels;
using AZDORestApiExplorer.Domain.Test.Events;

using DevExpress.Xpf.Grid;

using VNC;
using VNC.Core.Mvvm;

namespace AZDORestApiExplorer.Test.Presentation.Views
{
    public partial class TestPointMain : ViewBase, IInstanceCountV
    {
        //public TestPointMain(DomainViewModel<TestPoint, GetTestPointsEvent, GetTestPointsEventArgs, SelectedTestPointChangedEvent> viewModel)
        //{
        //    Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

        //    InstanceCountV++;
        //    InitializeComponent();

        //    ViewModel = viewModel;
        //    TargetGrid = grdResults;

        //    Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        public TestPointMain(DomainViewModel<Value, GetTestPointsEvent, GetTestPointsEventArgs, SelectedTestPointChangedEvent> viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;
            TargetGrid = grdResults;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private GridControl _targetGrid;

        public GridControl TargetGrid
        {
            get => _targetGrid;
            set => _targetGrid = value;

        }

        #region IInstanceCount

        private static int _instanceCountV;

        public int InstanceCountV
        {
            get => _instanceCountV;
            set => _instanceCountV = value;
        }

        #endregion
    }
}