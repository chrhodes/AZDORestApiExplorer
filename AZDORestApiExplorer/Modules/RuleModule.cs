﻿using System;

using AZDORestApiExplorer.Core;
using AZDORestApiExplorer.DomainServices;
using AZDORestApiExplorer.Presentation.ViewModels;
using AZDORestApiExplorer.Presentation.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using VNC;

namespace AZDORestApiExplorer
{
    public class RuleModule : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public RuleModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            containerRegistry.Register<IRuleMainViewModel, RuleMainViewModel>();
            containerRegistry.RegisterSingleton<IRuleMain, RuleMain>();

            // containerRegistry.RegisterSingleton<IRuleLookupDataService, RuleLookupDataService>();
            // containerRegistry.Register<IRuleDataService, RuleDataService>();

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            // NOTE(crhodes)
            // using typeof(TYPE) calls constructor
            // using typeof(ITYPE) resolves type (see RegisterTypes)

            //this loads RuleMain into the Shell loaded in CreateShell() in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.RuleMainRegion, typeof(IRuleMain));


            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

    }
}