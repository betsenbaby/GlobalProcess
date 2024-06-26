﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalProcess.Core.Models
{
    public class ActionItem : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AssignedUserId { get; set; }
        public ApplicationUser AssignedUser { get; set; }
        public ActionStatus Status { get; set; }
        public int StepId { get; set; }
        public Step Step { get; set; }
        public int? ParentActionItemId { get; set; }
        public ActionItem ParentActionItem { get; set; }
        public int Priority { get; set; }
        public DateTime Deadline { get; set; }
        public ICollection<ActionItem>? SubActionItems { get; set; }

        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
    }

    public enum ActionStatus
    {
        Pending,
        InProgress,
        Completed
    }
}
