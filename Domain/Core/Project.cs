﻿using System;

namespace AZDORestApiExplorer.Domain.Core
{
    public class ProjectsRoot
    {
        public int count { get; set; }
        public Project[] value { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
        public int revision { get; set; }
        public string visibility { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public string description { get; set; }
    }
}
