using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class ArenaController : IArenaController
    {
        private IArena _arena;
        private IGuiService _guiService;
        private IScoreboard _scoreBoard;

        private List<KeyValuePair<int, Hero>> _scoreboardCache;

        private int _pools;


        private bool ValidateGameStart(byte pools)
        {
            int num = 2;
            for(int i = (int)pools-1; i > 0; i--)
            {
                num = num * 2;
            }
            if(_arena.HeroCount() == num)
            {
                _pools = num;
                return true;
            }
            _guiService.ShowIncorrectPools();
            return false;
        }

        public bool Initialize(byte pools)
        {
            bool isValid = ValidateGameStart(pools);
            if(isValid)
            {
                _guiService.ShowWelcome();
                GenerateScoreboard();
                _guiService.ShowScoreboard(_scoreboardCache);
                return true;
            }
            return false;
        }

        private void RunBattle()
        {
            _guiService.ShowNextRound();
            int numberOfGroups =_scoreBoard.ScoreboardCount() / 2;
            Hero losingHero;
            for (int i = numberOfGroups; i > 0; i--)
            {
                losingHero = _arena.BattleHeros(_scoreBoard.GetGroup(i));
                _scoreBoard.DeleteFromScoreboard(losingHero, i);
            }
            _scoreBoard.RearrangeScoreboard();
            _guiService.ShowScoreboard(_scoreBoard.GetScoreboard());
            Task.Delay(2000).Wait();

        }


        public void StartBattle()
        {
            while(_scoreBoard.ScoreboardCount() > 1)
            {
                RunBattle();
            }
            _guiService.ShowWinner(_scoreBoard.GetScoreboard()[0].Value);


        }

        private void GenerateScoreboard()
        {
            _scoreBoard = new Scoreboard(_arena.GetHeros());
            _scoreBoard.GenerateGroups();
            _scoreboardCache = new List<KeyValuePair<int, Hero>>();
            _scoreboardCache = _scoreBoard.GetPools();
        }

        public ArenaController(IArena fightarena, IGuiService guiService) { 
            _arena = fightarena;
            _guiService = guiService;
        }
    }
}
