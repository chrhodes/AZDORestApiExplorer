﻿using AZDORestApiExplorer.Domain.WorkItemTrackingProcess;

using Prism.Events;

namespace AZDORestApiExplorer.Core.Events
{
    public class SelectedProcessChangedEvent : PubSubEvent<Process> { }
}
