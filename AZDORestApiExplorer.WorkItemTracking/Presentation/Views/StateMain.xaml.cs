﻿using System;

using VNC;
using VNC.Core.Mvvm;

namespace AZDORestApiExplorer.WorkItemTracking.Presentation.Views
{
    public partial class StateMain : ViewBase, IStateMain, IInstanceCountV
    {

        public StateMain(ViewModels.IStateMainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
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
