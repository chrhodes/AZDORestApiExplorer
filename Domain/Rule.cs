﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using VNC.Core.DomainServices;

namespace AZDORestApiExplorer.Domain
{
    public class RulesRoot
    {
        public int count { get; set; }
        public Rule[] value { get; set; }
    }

    public class Rule
    {
        public string id { get; set; }
        public object friendlyName { get; set; }
        public Condition[] conditions { get; set; }
        public Action[] actions { get; set; }
        public bool isDisabled { get; set; }
        public bool isSystem { get; set; }

        public class Condition
        {
            public string conditionType { get; set; }
            public string field { get; set; }
            public string value { get; set; }
        }

        public class Action
        {
            public string actionType { get; set; }
            public string targetField { get; set; }
            public string value { get; set; }
        }
    }

}
