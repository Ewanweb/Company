﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain._shared
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

    }
}
