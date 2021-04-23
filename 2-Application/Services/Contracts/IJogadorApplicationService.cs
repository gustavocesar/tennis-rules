using System.Collections.Generic;
using Domain.Entities;

namespace Application.Services.Contracts
{
    public interface IJogadorApplicationService
    {
        IList<Jogador> GetJogadores();
    }
}