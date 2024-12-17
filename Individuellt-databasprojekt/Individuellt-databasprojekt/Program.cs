using Individuellt_databasprojekt;

MainMenu mainMenu = new();

async Task StartProgram()
{
    await mainMenu.Menu(null);
}

await StartProgram();