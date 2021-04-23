using System.Collections.Generic;
using Domain.Entities;

namespace Application.Services.Contracts
{
    public interface IGameApplicationService
    {
        IList<Game> GetGames();
        Game Create();
        void Pontuar(int gameId, int jogadorId);
    }
}