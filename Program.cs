// See https://aka.ms/new-console-template for more information
using SwitchBoardSimulation;

Console.WriteLine("Enter the number of Fans");
int numOfFans = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the number of ACs");
int numOfACs = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the number of Bulbs");
int numOfBulbs = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

int total = numOfFans + numOfACs + numOfBulbs;
Button[] buttons = new Button[total];
Appliance[] appliances = new Appliance[total];

for (int i = 0; i < numOfFans; i++)
{
    Fan fan = new Fan();
    fan.id = i;
    buttons[i] = new Button(fan.id);
    appliances[i] = fan;
    appliances[i].type = "Fan";
}
for (int i = numOfFans; i < numOfFans+numOfACs; i++)
{
    AC ac = new AC();
    ac.id = i;
    buttons[i] = new Button(ac.id);
    appliances[i] = ac;
    appliances[i].type = "AC";
}
for (int i = numOfFans+numOfACs; i < total; i++)
{
    Bulb bulb = new Bulb();
    bulb.id = i;
    buttons[i] = new Button(bulb.id);
    appliances[i] = bulb;
    appliances[i].type = "Bulb";
}

SwitchBoard switchboard = new SwitchBoard();
switchboard.buttons = buttons;
displayMenu();

int Rank(int i)
{
    int deviceCount = 0;
    if (appliances[i].type == "Fan")
    {
        deviceCount = buttons[i].applianceId + 1;
    }
    else if (appliances[i].type == "AC")
    {
        deviceCount = buttons[i].applianceId - numOfFans + 1;
    }
    else
    {
        deviceCount = buttons[i].applianceId - (numOfFans + numOfACs) + 1;
    }
    return deviceCount;
}

void displayMenu()
{
    EnumSwitch.Switch OnOrOff;
    int deviceCount;
    for (int i = 0; i < total; i++)
    {
        OnOrOff = EnumSwitch.Switch.Off;
        if (appliances[i].state is true)
        {
            OnOrOff = EnumSwitch.Switch.On;
        }
        deviceCount = Rank(i);
        Console.WriteLine($"{i+1}. {appliances[i].type}{deviceCount} is '{OnOrOff}'");
    }
    Console.WriteLine();

    Console.WriteLine("Please select a Device");
    int searchId = Convert.ToInt32(Console.ReadLine());
    if (searchId<1 || searchId > total)
    {
        Console.WriteLine();
        Console.WriteLine("Invalid Device");
        Console.WriteLine();
        displayMenu();
        return;
    }
    searchId -= 1;
    Console.WriteLine();

    OnOrOff = EnumSwitch.Switch.On;
    if (appliances[searchId].state is true)
    {
        OnOrOff = EnumSwitch.Switch.Off;
    }
    deviceCount = Rank(searchId);
    Console.WriteLine($"1. Switch {appliances[searchId].type} {deviceCount} {OnOrOff}");
    Console.WriteLine($"2. Back");

    Console.WriteLine();
    Console.WriteLine("Please select an option");
    int opt = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    switch (opt)
    {
        case 1:
            appliances[searchId].state = !appliances[searchId].state;
            displayMenu();
            break;
        case 2:
            displayMenu();
            break;
        default:
            Console.WriteLine("Invalid Option");
            Console.WriteLine();
            displayMenu();
            break;
    }
}
