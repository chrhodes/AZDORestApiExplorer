﻿using AZDORestApiExplorer.Domain;

using Prism.Events;

using VNC.Core.Events;

namespace AZDORestApiExplorer.Core.Events
{
    public class SelectedSystemControlChangedEvent : PubSubEvent<SystemControl> { }
}