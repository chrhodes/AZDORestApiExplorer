using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

using AZDORestApiExplorer.Domain.Core;
using AZDORestApiExplorer.Domain.Git.Events;

using Newtonsoft.Json;

using Prism.Events;

using VNC;
using VNC.Core.Net;

namespace AZDORestApiExplorer.Domain.Git
{
    namespace Events
    {
        public class GetCommitChangesEvent : PubSubEvent<GetCommitChangesEventArgs> { }

        public class GetCommitChangesEventArgs
        {
            public Organization Organization;

            // public Domain.Core.Process Process;

            public Domain.Core.Project Project;

            public Domain.Git.Repository Repository;

            public Domain.Git.Commit Commit;

            // public Domain.Core.Team Team;

            // public WorkItemType WorkItemType;
        }

        public class SelectedCommitChangeChangedEvent : PubSubEvent<CommitChange> { }
    }

    //public class CommitChangesRoot
    //{
    //    public int count { get; set; }
    //    public CommitChange[] value { get; set; }
    //}

    public class CommitChange
    {

    }

    // TODO(crhodes)
    // PasteSpecial from Json result text

    // Nest any additional classes inside class CommitChange

    public class CommitChangesRoot
    {
        public string treeId { get; set; }
        public string commitId { get; set; }
        public Author author { get; set; }
        public Committer committer { get; set; }
        public string comment { get; set; }
        public string[] parents { get; set; }
        public string url { get; set; }
        public string remoteUrl { get; set; }
        public _Links _links { get; set; }
        public Push push { get; set; }

        public class Author
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
            public string imageUrl { get; set; }
        }

        public class Committer
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
            public string imageUrl { get; set; }
        }

        public class _Links
        {
            public Self self { get; set; }
            public Repository repository { get; set; }
            public Web web { get; set; }
            public Changes changes { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Repository
        {
            public string href { get; set; }
        }

        public class Web
        {
            public string href { get; set; }
        }

        public class Changes
        {
            public string href { get; set; }
        }

        public class Push
        {
            public Pushedby pushedBy { get; set; }
            public int pushId { get; set; }
            public DateTime date { get; set; }
        }

        public class Pushedby
        {
            public string displayName { get; set; }
            public string url { get; set; }
            public _Links1 _links { get; set; }
            public string id { get; set; }
            public string uniqueName { get; set; }
            public string imageUrl { get; set; }
            public string descriptor { get; set; }
        }

        public class _Links1
        {
            public Avatar avatar { get; set; }
        }

        public class Avatar
        {
            public string href { get; set; }
        }
    }

}
