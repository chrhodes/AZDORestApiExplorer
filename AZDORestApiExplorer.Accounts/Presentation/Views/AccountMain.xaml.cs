﻿using System;

using VNC;
using VNC.Core.Mvvm;

namespace AZDORestApiExplorer.Accounts.Presentation.Views
{
    public partial class AccountMain : ViewBase, IAccountMain, IInstanceCountV
    {

        public AccountMain(ViewModels.IAccountMainViewModel viewModel)
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
