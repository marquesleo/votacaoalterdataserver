﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Entities.Models
{
    public class Base : IEntity
    {
        [Key]
        public Guid id { get; set; }
    }
}
