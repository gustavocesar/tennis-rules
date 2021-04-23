using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories.Contracts;

namespace Infrastructure.Data.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly TennisContext _context;

        public JogadorRepository(TennisContext context)
        {
            _context = context;
        }

        public Jogador FindByKey(int id)
        {
            return _context.Jogadores.Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<Jogador> GetAll()
        {
            return _context.Jogadores.ToList();
        }

        public Jogador Update(Jogador jogador)
        {
            _context.Update(jogador);
            _context.SaveChanges();

            return jogador;
        }
    }
}