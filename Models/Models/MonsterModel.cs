using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Models.Models
{
    public class MonsterModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

    }
}
