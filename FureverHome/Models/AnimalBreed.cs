﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class AnimalBreed
    {
        public AnimalBreed() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalSpeciesId { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
    }
}
