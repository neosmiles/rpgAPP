using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dto
{
    public class CharacterForGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int hitPOINTS { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public rpgCLASS Class { get; set; } = rpgCLASS.Knight;
    }
}