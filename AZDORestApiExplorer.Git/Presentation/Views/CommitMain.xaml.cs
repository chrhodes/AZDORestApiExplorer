using System;

using AZDORestApiExplorer.Domain.Git;
using AZDORestApiExplorer.Domain.Git.Events;
using AZDORestApiExplorer.Presentation.ViewModels;

using DevExpress.Xpf.Grid;

using VNC;
using VNC.Core.Mvvm;

namespace AZDORestApiExplorer.Git.Presentation.Views
{
    public partial class CommitMain : ViewBase, IInstanceCountV
    {
        public CommitMain(
            DomainViewModel2<Commit, GetCommitsEvent, GetCommitsEventArgs, SelectedCommitChangedEvent, ClearCommitsEvent> viewModel)
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

        private void LayoutGroup_ExpansionChanged(object sender, EventArgs e)
        {
            var lg = (DevExpress.Xpf.LayoutControl.LayoutGroup)sender;

            if (lg.IsCollapsed)
            {
                lg.Header = "Commit Selected - Expand to see Commits Grid";
            }
            else
            {
                lg.Header = "";
            }

            var ea = e;
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
