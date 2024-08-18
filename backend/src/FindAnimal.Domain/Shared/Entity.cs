﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Shared
{
    public abstract class Entity<TId> where TId : notnull
    {
        public TId Id { get; private set; }

        protected Entity(TId id)
        {
            Id = id;
        }
    }
}
