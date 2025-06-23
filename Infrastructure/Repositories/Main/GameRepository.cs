using Application.Contracts.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Main
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
