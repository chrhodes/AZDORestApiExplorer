﻿using System;
using System.Collections.Generic;

using AZDORestApiExplorer.Domain;

using VNC.Core.Mvvm;

namespace AZDORestApiExplorer.Presentation.ModelWrappers
{
    public class ContextWrapper : ModelWrapper<Domain.Context>
    {
        public ContextWrapper(Domain.Context model) : base(model)
        {
        }

        public Project SelectedProject
        {
            get { return GetValue<Project>(); }
            set { SetValue(value); }
        }

        public Team SelectedTeam
        {
            get { return GetValue<Team>(); }
            set { SetValue(value); }
        }

        public Process SelectedProcess
        {
            get { return GetValue<Process>(); }
            set { SetValue(value); }
        }

        public WorkItemType SelectedWorkItemType
        {
            get { return GetValue<WorkItemType>(); }
            set { SetValue(value); }
        }

        public Dashboard SelecteDashboard
        {
            get { return GetValue<Dashboard>(); }
            set { SetValue(value); }
        }
    }
}
