﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;

using AZDORestApiExplorer.Core.Events;
using AZDORestApiExplorer.Core.Events.Core;
using AZDORestApiExplorer.Domain;
using AZDORestApiExplorer.Domain.Core;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;
using VNC.HttpHelper;

namespace AZDORestApiExplorer.Presentation.ViewModels
{
    public class xProjectMainViewModel : GridViewModelBase, IProjectMainViewModel, IInstanceCountVM
    {
        #region Constructors, Initialization, and Load

        public xProjectMainViewModel(
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            EventAggregator.GetEvent<xGetProjectsEvent>().Subscribe(Get_Projects);

            this.Results.PropertyChanged += PublishSelectedItemChanged;

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        public RESTResult<Project> Results { get; set; } = new RESTResult<Project>();

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods

        private async void Get_Projects(xGetProjectsEventArgs args)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Core.Helpers.InitializeHttpClient(args.Organization, client);

                    var requestUri = $"{args.Organization.Uri}/_apis/projects?api-version=6.1-preview.4";

                    RequestResponseInfo exchange = InitializeExchange(client, requestUri);

                    using (HttpResponseMessage response = await client.GetAsync(requestUri))
                    {
                        RecordExchangeResponse(response, exchange);

                        response.EnsureSuccessStatusCode();

                        string outJson = await response.Content.ReadAsStringAsync();

                        ProjectsRoot resultRoot = JsonConvert.DeserializeObject<ProjectsRoot>(outJson);

                        Results.ResultItems = new ObservableCollection<Project>(resultRoot.value);

                        IEnumerable<string> continuationHeaders = default;

                        bool hasContinuationToken = response.Headers.TryGetValues("x-ms-continuationtoken", out continuationHeaders);

                        while (hasContinuationToken)
                        {
                            RequestResponseInfo exchange2 = new RequestResponseInfo();

                            string continueToken = continuationHeaders.First();

                            string requestUri2 = $"{args.Organization.Uri}/_apis/projects?api-version=6.1-preview.4&continuationToken={continueToken}";

                            exchange2.Uri = requestUri2;
                            exchange2.RequestHeadersX.AddRange(client.DefaultRequestHeaders);

                            using (HttpResponseMessage response2 = await client.GetAsync(requestUri2))
                            {
                                exchange2.Response = response2;
                                exchange2.ResponseHeadersX.AddRange(response2.Headers);

                                RequestResponseExchange.Add(exchange2);

                                response2.EnsureSuccessStatusCode();
                                string outJson2 = await response2.Content.ReadAsStringAsync();

                                JObject oC = JObject.Parse(outJson2);

                                ProjectsRoot projects2C = JsonConvert.DeserializeObject<ProjectsRoot>(outJson2);

                                Results.ResultItems.AddRange(projects2C.value);

                                hasContinuationToken = response2.Headers.TryGetValues("x-ms-continuationtoken", out continuationHeaders);
                            }
                        }

                        Results.Count = Results.ResultItems.Count();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                ExceptionDialogService.DisplayExceptionDialog(DialogService, ex);
            }

            EventAggregator.GetEvent<HttpExchangeEvent>().Publish(RequestResponseExchange);
        }

        private void PublishSelectedItemChanged(object sender, PropertyChangedEventArgs e)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

            EventAggregator.GetEvent<xSelectedProjectChangedEvent>().Publish(Results.SelectedItem);

            Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
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
