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


        /// <summary>
        /// Validate if the number of pools is the equal number of heros needed.
        /// </summary>
        private bool ValidateGameStart(byte pools)
        {
            int num = 2;
            for(int i = (int)pools-1; i > 0; i--) // Loop the amount of pools -1 (due to we start on 2).
            {
                num *= 2; // Multiply number by 2
            }
            if(_arena.HeroCount() == num) // If the amount of heros match the number of needed heros
            {
                return true;
            }
            _guiService.ShowIncorrectPools();  // Call the guiService and execute function
            return false;
        }


        /// <summary>
        /// Initializes the game.
        /// </summary>
        public bool Initialize(byte pools)
        {
            bool isValid = ValidateGameStart(pools); // Is the number of pools valid?
            if(isValid) 
            {
                _guiService.ShowWelcome(); // Run function ShowWelcome in the guiService
                GenerateScoreboard(); // Run function Generate Scoreboard
                _guiService.ShowScoreboard(_scoreBoard.GetScoreboard()); // Show the scoreboard
                return true;
            }
            return false;
        }

        /// <summary>
        /// Runs a battle between every group that is in the scoreboard.
        /// </summary>
        private void RunBattle()
        {
            _guiService.ShowNextRound(); // Show the next round display
            int numberOfGroups =_scoreBoard.ScoreboardCount() / 2; // The number of groups is the number of entries divided by 2
            Hero losingHero;
            for (int i = numberOfGroups; i > 0; i--) // Loop the number of groups
            {
                losingHero = _arena.BattleHeros(_scoreBoard.GetGroup(i)); // Battle the two heros in the group-
                _scoreBoard.DeleteFromScoreboard(losingHero, i); // Delete the losing hero from the scoreboard
            }
            _scoreBoard.RearrangeScoreboard(); // Rearrange the scoreboard, so the groups get numerical again.
            _guiService.ShowScoreboard(_scoreBoard.GetScoreboard()); // Show the scoreboard
            Task.Delay(2000).Wait(); // Wait 2 seconds
        }


        /// <summary>
        /// Starts the battle
        /// </summary>
        public void StartBattle()
        {
            while(_scoreBoard.ScoreboardCount() > 1) // While there is more than 1 hero in the game
            {
                RunBattle(); // Run the RunBattle function
            }
            _guiService.ShowWinner(_scoreBoard.GetScoreboard()[0].Value); // Show the winner. 


        }

        /// <summary>
        /// Generates the scoreboard.
        /// </summary>
        private void GenerateScoreboard()
        {
            _scoreBoard = new Scoreboard(_arena.GetHeros()); // Initalizes the scoreboard object with our heros.
        }

        public ArenaController(IArena fightarena, IGuiService guiService) {  // Constructor
            _arena = fightarena;
            _guiService = guiService;
        }
    }
}
