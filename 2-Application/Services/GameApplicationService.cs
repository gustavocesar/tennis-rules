using System;
using System.Collections.Generic;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Repositories.Contracts;
using Domain.Services.Contracts;

namespace Application.Services
{
    public class GameApplicationService : IGameApplicationService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IJogadorRepository _jogadorRepository;

        public GameApplicationService(IGameRepository gameRepository, IJogadorRepository jogadorRepository)
        {
            _gameRepository = gameRepository;
            _jogadorRepository = jogadorRepository;
        }

        public IList<Game> GetGames()
        {
            return _gameRepository.GetAll();
        }

        public Game Create()
        {
            var jogadores = _jogadorRepository.GetAll();
            var jogador1 = jogadores[0];
            var jogador2 = jogadores[1];

            var game = new Game(jogador1, jogador2);

            return _gameRepository.Insert(game);
        }

        public void Pontuar(int gameId, int jogadorId)
        {
            var game = _gameRepository.FindByKey(gameId);
            var jogador = _jogadorRepository.FindByKey(jogadorId);
            
            if (game == null || jogador == null)
                return;

            if (game.Jogador1 == jogador)
                game.PontuarJogador1();
            else
                game.PontuarJogador2();

            _gameRepository.Update(game);
        }
    }
}
