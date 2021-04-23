using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories.Contracts
{
    public interface IGameRepository
    {
        IList<Game> GetAll();
        Game FindByKey(int id);
        Game Insert(Game game);
        Game Update(Game game);
    }
}