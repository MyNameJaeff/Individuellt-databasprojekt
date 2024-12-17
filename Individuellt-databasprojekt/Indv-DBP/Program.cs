namespace Indv_DBP;

class Program
{
    private static async Task RunProgram()
    {
        await MainMenu.Menu();    
    }
    
    static void Main(string[] args)
    {
        RunProgram().Wait();
    }
}