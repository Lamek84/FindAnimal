﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain
{
    public class PetPhoto
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Path { get; private set; }
        public bool IsMain { get; private set; }
    }
}
