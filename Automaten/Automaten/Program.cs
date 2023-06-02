using Automaten;

public class Program
{
    static void Main(string[] args)
    {
        IMachineController machineController = new MachineController(new GuiService(), new Machine(), new MoneyService());
        
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