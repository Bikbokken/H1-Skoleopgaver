using FightArena;

public class Program
{
    static void Main(string[] args)
    {
        // Creating out FightArenaController while initalizing our Arena and GuiService
        IArenaController fightArenaController = new ArenaController(new Arena(), new GuiService()); 
        byte pools = 3; // The amount of pools/finales to compete in. There should be at least pools*2 amount of heros before the game can start.
        if(fightArenaController.Initialize(pools)) // Run the Initialize function in the fightArenaController
        {
            Task.Delay(4000).Wait(); // Wait 2 seconds before starting
            fightArenaController.StartBattle(); // Start our battle!!! Running the function in the fightArenaController
        }

    }
}