using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly TennisContext _context;

        public GameRepository(TennisContext context)
        {
            _context = context;
        }

        public Game FindByKey(int id)
        {
            return _context.Games
                .Include(x => x.Jogador1)
                .Include(x => x.Jogador2)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IList<Game> GetAll()
        {
            return _context.Games
                .Include(x => x.Jogador1)
                .Include(x => x.Jogador2)
                .OrderBy(x => x.Data).ThenBy(x => x.Id)
                .ToList();
        }

        public Game Insert(Game game)
        {
            _context.Add(game);
            _context.SaveChanges();
            
            return game;
        }

        public Game Update(Game game)
        {
            _context.Update(game);
            _context.SaveChanges();

            return game;
        }
    }
}