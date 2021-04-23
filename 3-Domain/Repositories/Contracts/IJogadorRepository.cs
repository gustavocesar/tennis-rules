using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories.Contracts
{
    public interface IJogadorRepository
    {
        IList<Jogador> GetAll();
        Jogador FindByKey(int id);
        Jogador Update(Jogador jogador);
    }
}