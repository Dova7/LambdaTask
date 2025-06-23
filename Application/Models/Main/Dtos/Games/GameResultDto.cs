using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Main.Dtos.Games
{
    public class GameResultDto
    {
        public bool IsWin { get; set; } = false;
        public int Amount { get; set; }
    }
}
