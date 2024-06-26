﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clever.Core.Models;

public class UserQuests(string tgId, int completed)
{
    [Key, ForeignKey("UserAuth")]
    [StringLength(30)]
    public string TgId { get; set; } = tgId;
    public int Completed { get; set; } = completed;
    
    public virtual UserAuth UserAuth { get; set; }
}