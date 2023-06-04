using Automaten;

public class Program
{
    static void Main(string[] args)
    {

        Machine machine = new Machine(); // Create a Machine Object
        MoneyService moneyService = new MoneyService(); // Create a Money Service Object

        IAdminController adminController = new AdminController(moneyService, machine); // Create a AdminController Object using the created machine and money service
        IMachineController machineController = new MachineController(new GuiService(), machine, moneyService); // Create a controller, using the created machine and money service, and create a new gui service
        
        while(true) // While the program is running
        {
            Console.Clear();
            machineController.ShowMachineStatus(); // Show what the machine contains
            machineController.ShowAllItems(); // Show all the items in the machine
            bool orderValid = machineController.PromptOrder(); // Ask the user which product he/she wants to order
            if(orderValid) // Is the order valid?
            {
                Console.Clear(); 
                machineController.ShowSelectedItem();
                machineController.ConfirmOrder(); // Confirm with the user if he/she wants the order

            }
            Task.Delay(3000).Wait();
        }

    } 
} 