using System;
using System.Collections.Generic;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Repositories.Contracts;

namespace Application.Services
{
    public class JogadorApplicationService : IJogadorApplicationService
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorApplicationService(IJogadorRepository jogadorRepository, IGameRepository gameRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        public IList<Jogador> GetJogadores()
        {
            return _jogadorRepository.GetAll();
        }
    }
}