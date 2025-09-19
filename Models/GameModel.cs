using RPGGame.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class GameModel
    {
        public Guid Id { get; set; }

        public Guid HeroId { get; set; }
        public HeroModel Hero { get; set; } = null!;

        public int MonstersKilled { get; set; }

        public DateTime StartedAt { get; set; }
    }
}
