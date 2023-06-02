using Automaten;

public class Program
{
    static void Main(string[] args)
    {

        Machine machine = new Machine();
        MoneyService moneyService = new MoneyService();

        IAdminController adminController = new AdminController(moneyService, machine);
        IMachineController machineController = new MachineController(new GuiService(), machine, moneyService);
        
        while(true)
        {
            Console.Clear();
            machineController.ShowMachineStatus();
            machineController.ShowAllItems();
            bool orderValid = machineController.PromptOrder();
            if(orderValid)
            {
                Console.Clear();
                machineController.ShowSelectedItem();
                machineController.ConfirmOrder();

            }
            Task.Delay(3000).Wait();
        }

    } 
} 