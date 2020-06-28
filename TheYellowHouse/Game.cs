using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace TheYellowHouse
{
    class Game
    {

        Location currentLocation;

        public bool isRunning = true;
        private bool _gameOver = false;
        Player player = new Player(50, 10, 20, true);
        Random rnd = new Random();
        bool justMoved = false;


        public Game()
        {
            Console.SetWindowSize(150, 57);


            Console.WriteLine("Welcome adventurer, prepare yourself for a fantastical journey into the unknown in...");

            // Ascii art picture of the front of the house

            string title_art = @"
dc;,:oooddoxkkkddkkxkkkxk0OxOKKKXNKOdcdOx00k00kdkxdooxkOdoxxx0WNKddK0xolxkookkkdxO0OkO00000KKXNWMMMMMWWWWWWWWWMWWNNWWWWWWWWWM
;',lx0K0OOkkxdkOOOOOkkxddxkxx0NXKXK0d:oOxkOOK0kxkkxllodOkodod0XN0ok0xolodoldkkdxkkOOkkkOOOO0KKXWWMMMWWWWWWWWWWWWWNNWMWWWWWWWM
;:lloxxkkkkkkxddxddxdxO0OkxdllkKXXXK0ocdddOKK0O00OkdclxxdllcckKKklO0dloxoloddxOxdxkxxO00KK0KXXXNWMMWMWWWWWWWMWWWWWNWWWWWWWWWW
oooodkxdolldxxocldkOkxkO00XX0kod00KXN0lccd0XNXKKOOkdoooxocl:;xXXxoxkdldxoldxdxxxxkkOO000KXNNNNWWMMMMMMMMMWMMMWWWWWWWWWWWWWWWW
c:ldxkkxxxO000OOO0000XXXXXXXXK0koxOO0Xk::xKNWNOO0kllOXkdx:co,oK0xddxockKdlddolxO0KXXXNNNNXKXNWMMMMMMMMMMMMMMWWWWWWMMMMMWWWWWW
lllodxxdxkkkOkk000KXXXXXNWWNNNNN0dokO00c;d0NWN00K0dkNNNkl::l;codxdoxooOxcloodOXNNWWNNXXXXXXXNWWMMMMMMMMMMMMMMMWWWMMMMMWWWWWWW
:;;::lldkkxkOOxxO00000KXNNNNNNNNXKOdxOOccxxXMXKXKOkKWXXXxc;:lc:okldOdOd,:lclx0XNWWXKKKK0KXXKXNNWWWWMMMMMMMMWWWWWMMMWWWWWWWWWW
,,,;;:ccoxOKNNXOkOKXXXXKKK0O0KKXNNWKxdx:cKOkNXXKKOd0K00KKd;:o:'d0llood::oxOOkkOKXK00KXX0OOkkO0KKXNWWWWWWWWWWWWWWWWWWWWWWWWWWW
;;,colloddkOO000XXXXXKKXXK00KKKKKXXNXxxo:OOdkKK0XxoKXXK0Okc;ll;xkll:lc,oKXK00kxddkOOO0OO0OkkO000KXXNNWWWWWWWWWWWWWWWWWWWWWWWW
lcldkO000OOkO0KKKKK00KXNNNXXXXXNXK0O0dcl;x0oxK0X0d0XK00Ok00c';ckx;,:c:cOKXXXXOoldxkkO0000OOO0KKKKKKXNNWWWWWWWWWWWWWWWWWWWWWWW
ldkxxOOOkxkO0KKOOKXKXXXXXXKK0KKKKXXK0koc;dKodOOOdkXXK000000d',:kk,',,:xOO0XNKxxkkkOkkO00K0KK0OOkO0KXNWWWWWWWWWWWWWWWWWWWWWWWW
kxdooxxxxkO0OOOO0XNNNNNNXKXXKXXKKKK0O0Oc.cKxlOkokKKKKXNNOlox:',xk,,:;oXXXXXNOx0KXXXXNXXKOkkkOO0KKO0NWWWWWWWWWWWWWWWWWWWWWWWNN
;;:cododxOOOOOKKKKK00Okxxxxxxxxddxkxxxdl;:docdolxddxkkkkdcldc;;lo;cl;okkkkkdlxOOOxdkOOOxoodxkkOOkdxO00KXNNWWWWWWWWWWWWWWWWXKX
',clooodddooddolc:::;;;:::::::::::::::::cc::cccc:::::::::cc::cc:::::::::::::::::::;:::::::::::::::::::cclloddxkkO0KKXNNWWWNNN
::lol:,,;;;::;,,;;;;;;;;;;;;;;;;;;::::::::::c::ccccccccccccccccccccccc::ccccccccccccccccccccc::::::::::::::::::::ccloodxKWWWN
codolccclddxd;....''''''......''''''''''''''''',,,;,,,,,,;,;;;;;;;;;;,,,,,,,,,,,,,,,,;;,,,,,,,,,,,,,,,,,,,,,,,,,:dxk000KNNNX0
oollcoxxdxkxdc;;,,,,;;;;'.  ...............'. .,::::;:::;;;,;:ccccccc;. ........'...':::;.............. .;:::::;:xKNNXXK0kxdd
lllllloodxxxdollllllllll:. .'..............,. .:dddddddl;;;,:oxdddddxl. .,'''...,. .:dddl. .'........'. 'odddddooO0Okkxdlcocc
c::cccccllccloddddddddddl. .;'.............,. .lxxxdddxdc:c:cdkkkkkkkd' .;,',,'';,..ckxkd,.','.''''.';..,dkkkkkxxxddxxxollolc
,;;:cccc:::;:oxxxxxxxxxxo' .:,............';. .okko,.:xxoooooxOkkOOkOx:';llclcccl:',okkkx;.';'''''''';,.;xOkkkkxxdlcccc;,;,,;
;;::ccc::;;;cdxxxxxxxxxxo,.,c;,;;;;;;;;;;;;;,.,cxOxc:lxkxxxxxkOkkkxkOOkkkkkkkkkkkkkkkOOOx;.,:,',,,,'':;.:xOOOOOkxo::::c:;;,,,
,..',;:;,'':dxxxxxxxxxxxxdodxxxxxxxxxxxxxkxl;,;okkkOkkkkkkkxxkkkkxlx0OkOOOOOOOOOOOOOOOOOkc';cc:c:::::c:,cxOOOOOkxxoolcoollooc
,''.'';;''':dkxxxxxxxxxxxkkkkkkkkkkkkkkkkkxl;;ckkoxOkkkOOOOOOkkkkxld0OkkOOOOOOOOOOOOOOOOOkxxkkkkkkkkkkxxkOOOOOOkxxdoooooooool
,,,,;::::cc:oxxxxkkkkkkxxkkkkkkkkkkkkkkkkkxc;;ckdcxkkkkOOOOOOOkkxxloOOkkkOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOkxxdoooooooooo
.',;;:;,;;;;cxxxxxxxxxxxxxkxxkkkkkkkkkkxxkxc;:dklcdxxdodddddddooddclO0kkkkkOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOkxdc:cccccllll
,;;::::;::::ldxxxxxxxxxxxxdolllllodxxxddddo:;:llc::clccccccccccccc:loolllllldxkkkkkkkkkkkkkkkdooooldkOOOOkkkkkOkxl;,,,,,,,,;;
::cc:::::::::oxxxxxxxxxdddd;..''.'lxddddddc,''':c;;:::::::::::cc::;cc,..''..ckkkkxxxkkkxxxkkxc,,;,':kOOOkkkkkkOkxl;;;;;;;;;;;
;;::;;;;;;;,;oxxxxxxxxxxdxdc,;;;,:oxddddddc'..,c:,;;;;::::::::::::::c;..''..cxkkkxxxxkkkkxxxkoclllcokkkkkkkkOOOkxo:;;;;,,;;;;
;;,,,,,,,,,',coccclllllllllccccccccc:::::;'...':;;:::::::::::c:ccc:::,......':cccccllllcccclllllclloooooooooooooc:;;;;;;;;;:;
,,;;,,,,,,,'',,'',,,,'',,,,',,,,,,'''''''.....,;;::::::::::::::::cc::;'.''',,,,,;;;;:;;;;;;;:;;;;;:::;;;;:;;;::;;;;;;;;;;;;:;
,;;,,'',,,,,,,,,,,,,,,,,,,,,,,,;;;;;;;;;;;,''',;,,,,,,',,,,,,,,,,,,,;,',,;;:::;;;;;::::::::::::::::::::cc::::::::::::::::::::
,,,,,,,,,,,,;,,,;;,,,,,;;;;;;;,,;;;;;;;,;:;,;,;;,,,,;;,,,,,;;,,,,,,,;;;:::;;;;;;;;;;::;::::c:c::::::c::cc::::::::c:::::::::::
'',,,,,,,,,;;;,,;;;;;;;;::;;;;;:;;;,;;;;;:;;;;;,,;:cllllllloolcc;;;;;::;;:;;;;;;::;;:::;::;::;;::::cc::cc::::c::c::c:::::cc::
',,,,,,,,;;::;,;:;::;;;;;;;;;;;::;;;;;;;;;;;;;;,,;cloooooooooool:;;;;::::;::;:;::::c::::::;:::;;::;;;;;::;::::::;::::::::::::
,,,;;;;;;::;;;;::;,;;;;;;;;;;,;::;;;;;;,,;;;;;;;;:ccllolllloolllc;,;:::::;;::::;;::::::::::c:::;:::;;;,;:;;;;;::;:c:;:::::c:;
;;;;;;;;:::;;;:;;;;;;,,;;;;;;;;;;;;;;:;::;:;;;;;;;;:;::::cccccc::;;;;::::;;::::;;;;:::::;;:::::::cc::;;;::::;;::;;:;;;:::;;:;
:;;;;,,;;;;:;;;:;;;;;;;::::;,;;;;;;;,;;::;::;;;;;::::clllllllccc:;,;:::::;;::::;;;;::;;:;;;;;;;:cc:;:;:::::c:::::::;,,;;::::;
;,,;;,;;;;;,,,;;;;;:;,;;;;:;;;;;;;;;;:::;;;;;;::;:::cllllllllllc:;;;;;;;:;;;,,;;;,;::::;;,,,,,,;:c::c::cc:cc:::;;;:;;;;;;;;;;
;;;::;;;;;;;;;;;;;::;;;;;;:;;;:::;;:ccc:;:;;;;:c::cllllllllllllcc:;,;:cc::;;;:::;;;::::::c:;;;;;:::::;;;:::::;::;;;;;:;;;;;::
;;;::;,;;;;;,;;;;;;,,,;::;:::::ccc::cc::;:;;;;:::cclllllllllllcccc:;;;;:::::;:c:;;::::;;:::::;;;::;;;;;;:::;::::;;;;;::;;::;;
;;:;;,,,;;;,;:;;;;,,,;;::;;;;:::ccc:cc;:cc:;;;;::clllllllllllccccc:,,,;::::::c:;;:clcc:;;;;;:;,;:c::::::::;:;:c;,;::;;;;;:;;:
;;;;,,,,,;;;;:c:,,;:::::;;;,;:::c:::::;;c:;;;,;:llllllllllllllccc::;;;::c::::::c;::::::::cccccc::::::coc::::;::;;,;c:;::,,,,;";
            Console.WriteLine(title_art);

            // Ascii Title

            //want to break this into three parts to make "Yellow" yellow like the house

            string title = @"                                                                                                                                                                                                                                       
▄▄▄█████▓██░ ██▓█████    ▓██   ██▓█████ ██▓    ██▓    ▒█████  █     █░    ██░ ██ ▒█████  █    ██  ██████▓█████ 
▓  ██▒ ▓▓██░ ██▓█   ▀     ▒██  ██▓█   ▀▓██▒   ▓██▒   ▒██▒  ██▓█░ █ ░█░   ▓██░ ██▒██▒  ██▒██  ▓██▒██    ▒▓█   ▀ 
▒ ▓██░ ▒▒██▀▀██▒███        ▒██ ██▒███  ▒██░   ▒██░   ▒██░  ██▒█░ █ ░█    ▒██▀▀██▒██░  ██▓██  ▒██░ ▓██▄  ▒███   
░ ▓██▓ ░░▓█ ░██▒▓█  ▄      ░ ▐██▓▒▓█  ▄▒██░   ▒██░   ▒██   ██░█░ █ ░█    ░▓█ ░██▒██   ██▓▓█  ░██░ ▒   ██▒▓█  ▄ 
  ▒██▒ ░░▓█▒░██░▒████▒     ░ ██▒▓░▒████░██████░██████░ ████▓▒░░██▒██▓    ░▓█▒░██░ ████▓▒▒▒█████▓▒██████▒░▒████▒
  ▒ ░░   ▒ ░░▒░░░ ▒░ ░      ██▒▒▒░░ ▒░ ░ ▒░▓  ░ ▒░▓  ░ ▒░▒░▒░░ ▓░▒ ▒      ▒ ░░▒░░ ▒░▒░▒░░▒▓▒ ▒ ▒▒ ▒▓▒ ▒ ░░ ▒░ ░
    ░    ▒ ░▒░ ░░ ░  ░    ▓██ ░▒░ ░ ░  ░ ░ ▒  ░ ░ ▒  ░ ░ ▒ ▒░  ▒ ░ ░      ▒ ░▒░ ░ ░ ▒ ▒░░░▒░ ░ ░░ ░▒  ░ ░░ ░  ░
  ░      ░  ░░ ░  ░       ▒ ▒ ░░    ░    ░ ░    ░ ░  ░ ░ ░ ▒   ░   ░      ░  ░░ ░ ░ ░ ▒  ░░░ ░ ░░  ░  ░    ░   
         ░  ░  ░  ░  ░    ░ ░       ░  ░   ░  ░   ░  ░   ░ ░     ░        ░  ░  ░   ░ ░    ░          ░    ░  ░
                          ░ ░                                                                                  ";

            Console.WriteLine(title);

            //wait for user to hit a key to move past title screen, clears then, continues
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1;
            Console.Write("Enter a key to begin...");
            Console.ReadKey();
            Console.Clear();
            Console.SetWindowSize(80, 40);
            Console.WriteLine("Press 'h' or type 'help' for help.");

            // build the "map"
            Location l1 = new Location("Entrance to hall", "You stand at the entrance of a long hallway. The hallways gets darker\nand darker, and you cannot see what lies beyond. To the east\nis an old oaken door, unlocked and beckoning.");
            Item rock = new Item("rock", true, "A rather jagged rock, slightly smaller than a fist.");
            l1.addItem(rock);

            Location l2 = new Location("End of hall", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            l2.addItem(window);

            Location l3 = new Location("Small study", "This is a small and cluttered study, containing a desk covered with\npapers. Though they no doubt are of some importance,\nyou cannot read their writing");
            Enemy darkOne = new Enemy("Dark One", 30, 12, 7, "An evil wizard dressed in black.", true);
            l3.addEnemy(darkOne);

            l1.addExit(new Exit(Exit.Directions.North, l2));
            l1.addExit(new Exit(Exit.Directions.East, l3));

            l2.addExit(new Exit(Exit.Directions.South, l1));

            l3.addExit(new Exit(Exit.Directions.West, l1));

            currentLocation = l1;
            showLocation();
            Console.Write(">");
        }

        public void showLocation()
        {
            Console.WriteLine("\n" + currentLocation.getTitle() + "\n");
            Console.WriteLine(currentLocation.getDescription());

            if (currentLocation.getInventory().Count > 0)
            {
                Console.WriteLine("\nThe room contains the following:\n");

                for (int i = 0; i < currentLocation.getInventory().Count; i++)
                {
                    Console.WriteLine(currentLocation.getInventory()[i].Name);
                }
            }

            Console.WriteLine("\nAvailable Exits: \n");

            foreach (Exit exit in currentLocation.getExits())
            {
                Console.WriteLine(exit.getDirection());
            }

            if (currentLocation.getEnemies().Count > 0)
            {
                Console.WriteLine("\nA creature shares the room with you:\n");

                for (int i = 0; i < currentLocation.getEnemies().Count; i++)
                {
                    Console.WriteLine(currentLocation.getEnemies()[i].Name);
                }
            }

            Console.WriteLine();
        }

        //Input handling algorithm
        public void doAction(string command)
        {
            //help command
            //expand to be more like Zork's help menu
            //it includes finer details about the parser among other user things for new users to know about the game
            if (command.ToLower() == "help" || command.ToLower() == "h")
            {
                Console.WriteLine("Welcome to this Text Adventure!");
                Console.WriteLine("'l' / 'look':        Shows you the room, its exits, and any items it contains.");
                Console.WriteLine("'Look at X':         Gives you information about a specific item in your \n                     inventory, where X is the items name.");
                Console.WriteLine("'take x':            Attempts to take an item, where X is the item's name");
                Console.WriteLine("'use X':             Attempts to use an item, where X is the items name.");
                Console.WriteLine("'i' / 'inventory':   Allows you to see the items in your inventory.");
                Console.WriteLine("'q' / 'quit':        Quits the game.");
                Console.WriteLine();
                Console.WriteLine("Directions can be input as either the full word, or the abbriviation, \ne.g. 'North or N'");
                return;
            }

            if (command.ToLower() == "attack")
            {
                Console.WriteLine("\nPlease specify what you want to attack.\n");
                return;
            }
            if (command.Length >= 6 && command.ToLower().Substring(0,6) == "attack")
            {
                if (currentLocation.getEnemies().Exists(x => x.Name.ToLower() == command.ToLower().Substring(7)) && currentLocation.getEnemies().Exists(x => x.IsAlive == true))
                {
                    int roll = diceRoll(20);

                    foreach (Enemy enemy in currentLocation.getEnemies()) if (currentLocation.getEnemies().Exists(x => x.Name.ToLower() == command.ToLower().Substring(7)))
                    {
                            if (roll > enemy.ArmorClass)
                            {
                                enemy.setHealth(enemy.Health - player.Damage);
                                Console.WriteLine("You attack the " + enemy.Name + " for " + player.Damage + ".");
                                if (enemy.Health <= 0)
                                {
                                    enemy.setAlive(false);
                                    Console.WriteLine("The " + enemy.Name + " is dead.");
                                }

                            }
                            else
                            {
                                Console.WriteLine("You try to attack the " + enemy.Name + ", but miss.");
                            }
                            break;
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("\nCan't attack that.\n");
                    return;
                }
            }

            //show player inventory
            if (command.ToLower() == "inventory" || command.ToLower() == "i")
            {
                player.showInventory();
                Console.WriteLine();
                return;
            }

            //take command
            if (command.Length >= 4 && command.ToLower().Substring(0,4) == "take")
            {
                if (command.ToLower() == "take")
                {
                    Console.WriteLine("\nPlease specify what you would like to pick up.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(5)) && currentLocation.getInventory().Exists(x => x.Useable == true))
                {
                    player.addItem(currentLocation.takeItem(command.Substring(5)));
                    Console.WriteLine("\nYou take the " + command.Substring(5) + ".\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(5)) && currentLocation.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nYou cannot take the " + command.Substring(5) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(5) + " does not exist.\n");
                    return;
                }
            }

            //look command
            if (command.ToLower() == "look" || command.ToLower() == "l")
            {
                showLocation();
                if (currentLocation.getInventory().Count == 0)
                {
                    Console.WriteLine("There are no items of interest in the room.\n");
                }
                return;
            }
            // make this a question that just accepts an item next like the plain "use" command
            if (command.ToLower() == "look at")
            {
                Console.WriteLine("\nPlease specify what you wish to look at when using this command.\n");
                return;
            }
            // would like to remove the need to have "at" in the look at command, but removing right now messes with specified substring ranges
            // may change to contain method
            if (command.ToLower().Contains("look at"))
            {
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) || player.inventory.Exists(x => x.Name == command.ToLower().Substring(8)))
                {
                    if (command.Substring(8).ToLower() == "rock")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("rock")).Description + "\n");
                        return;
                    }

                    if (command.Substring(8).ToLower() == "window")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("window")).Description + "\n");
                        return;
                    }

                    if (command.Substring(8).ToLower() == "smashed window")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("smashed window")).Description + "\n");
                        return;
                    }
                }
                if (currentLocation.getEnemies().Exists(x => x.Name.ToLower() == command.ToLower().Substring(8)))
                {
                    Console.WriteLine("\n" + currentLocation.getEnemies().Find(x => x.Name.ToLower().Contains("dark one")).Description + "\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nThat does not exist in this location or your inventory.\n");
                    return;
                }
            }

            // use command
            //WIP:  i like the more dynamic way of parsing with the contain method within expected ranges
            if (command.Length >= 3 && command.ToLower().Substring(0, 3) == "use")
            {
                if (command.ToLower() == "use")
                {
                    Console.WriteLine("\nPlease specify what you wish to use when using this command\n");
                    return;
                }
                //check for both items in user input first
                if (command.ToLower().Substring(3,11).Contains("rock") == true && command.ToLower().Substring(7).Contains("window") == true)
                {
                    if (player.inventory.Exists(x => x.Name == "rock") == true && currentLocation.getInventory().Exists(x => x.Name == "window"))
                    {
                        Item smashedWindow = new Item("smashed window", false, "A window frame with broken pieces of glass inside.");
                        currentLocation.addItem(smashedWindow);
                        foreach (Item item in currentLocation.getInventory())
                        {
                            if (item.Name.ToLower() == "window")
                            {
                                currentLocation.removeItem(item);
                                break;
                            }

                            if (item.Name.ToLower() == "rock")
                            {
                                currentLocation.removeItem(item);
                                break;
                            }
                        }
                        Console.WriteLine("\nYou smash in the window.\n");
                        return;
                    }
                }
                //check for an existing single item player inventory from user input
                if (player.inventory.Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    Console.WriteLine("\nUse " + command.Substring(4) + " with?\n");
                    string secondItem = Console.ReadLine();
                    if (currentLocation.getInventory().Exists(x => x.Name == secondItem))
                    {
                        if (secondItem == "window" && command.Substring(4) == "rock")
                        {
                            Item smashedWindow = new Item("smashed window", false, "A window frame with broken pieces of glass inside.");
                            currentLocation.addItem(smashedWindow);
                            foreach (Item item in currentLocation.getInventory())
                            {
                                if (item.Name.ToLower() == "window")
                                {
                                    currentLocation.removeItem(item);
                                    break;
                                }

                                if (item.Name.ToLower() == "rock")
                                {
                                    currentLocation.removeItem(item);
                                    break;
                                }

                            }
                            Console.WriteLine("\nYou smash in the window.\n");
                            return;
                        }
                    }
                }
                //check for an existing single item in current location from user input
                if (currentLocation.getInventory().Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    if (command.ToLower().Substring(4) == "window")
                    {
                        Console.WriteLine("\nThe window's locked tight, with no way of opening it.\n");
                        return;
                    }
                    if (command.ToLower().Substring(4) == "smashed window")
                    {
                        Console.WriteLine("\nYou clamber out the window. Victory is yours!");
                        _gameOver = true;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Cannot do that.");
                    return;
                }
            }
            //move command
            if (moveRoom(command))
                return;

            //no matching commands
            Console.WriteLine("\nInvalid command, are you confused?\n");
        }

        private bool moveRoom(string command)
        {
            foreach (Exit exit in currentLocation.getExits())
            {
                if (command == exit.ToString().ToLower() || command == exit.getShortDirection().ToLower())
                {
                    currentLocation = exit.getLeadsTo();
                    Console.WriteLine("\nYou move " + exit.ToString() + " to the:\n");
                    showLocation();
                    justMoved = true;
                    return true;
                }
            }
            return false;
        }
        private int diceRoll(int sides)
        {
            int dieResult;
            dieResult = rnd.Next(1, sides);
            return dieResult;
        }

        public void Update()
        {
            string currentCommand = Console.ReadLine().ToLower();

            // instantly check for a quit
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }

            if (!_gameOver)
            {
                // otherwise, process commands.
                Console.WriteLine("\n-------------------------------------------------------------------------------\n");
                justMoved = false;
                doAction(currentCommand);

                //check for enemy combat
                if (currentLocation.getEnemies().Count > 0 && justMoved == false)
                {

                    foreach (Enemy enemy in currentLocation.getEnemies()) if (currentLocation.getEnemies().Exists(x => x.IsAlive == true))
                        {
                            int roll = diceRoll(20);


                            if (roll > player.ArmorClass)
                            {
                                Console.WriteLine("The " + enemy.Name + " hit you for " + enemy.Damage);
                                player.setHealth(player.Health - enemy.Damage);
                                Console.WriteLine("Your health is now:  " + player.Health);
                            }
                            else
                            {
                                Console.WriteLine("The " + enemy.Name + " attempts to attack you, but misses.");
                            }

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("\n\nOh dear!  You're dead.");
                                _gameOver = true;
                                break;
                            }
                        }
                }
                Console.Write("\n>");
            }
            else
            {
                Console.WriteLine("Game Over.  Press a key to close the game...\n");
                Console.ReadKey();
                isRunning = false;
                return;
            }



        }
    }
}
