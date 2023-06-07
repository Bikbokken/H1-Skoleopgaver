using FightArena;

public class Program
{
    static void Main(string[] args)
    {
        IArenaController fightArenaController = new ArenaController(new Arena(), new GuiService());
        byte pools = 3; // The amount of pools/finales to compete in. There should be at least pools*2 amount of heros before the game can start.
        if(fightArenaController.Initialize(pools))
        {
            Task.Delay(2000).Wait();
            fightArenaController.StartBattle();
        }

    }
}