using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace Wisps
{
    
    class Catalogue
    {
        bool menuloop = true;
     
        public void MenuDisplay(List<CreatureLibrary> fieldguide, int counter)
        {
            InputCheckFunction inputCheckFunction = new InputCheckFunction();
            bool menuLoop = true;
           
            int switchnumberChoice;
            string creaturechoice;
            string selector;
        
            do
            {
                do
                {
                    Console.Clear();
                    Console.Write($"\nSelect an attribute or creature to compare: \n");
                    Console.WriteLine($"\nFull Value,\nHp,\nMp,\nPhys,\nPhysDef,\nAstral,\nAstDef,\nSpeed,\ntype,\nClass,\nDescription\nAbility: ");
                    Console.Write($"Enter: ");

                    selector = Console.ReadLine();
                }while ((switchnumberChoice = inputCheckFunction.checker(selector)) > 12);

                switch (switchnumberChoice)
                {
                    case (1):
                        do {
                            Console.Clear();
                            Console.WriteLine($"Current creature amount: {counter}");
                            string[] NameLister = new string[counter];
                      
                            for (int aa = 0; aa < fieldguide.Count; aa++)
                            {
                                NameLister[aa] = fieldguide[aa].name;
                                Console.WriteLine($"\u00FE {NameLister[aa]}");
                            }
                            Console.Write($"Select Creature: ");
                            creaturechoice = Console.ReadLine();

                        } while ((switchnumberChoice = inputCheckFunction.Cchecker(creaturechoice,counter,fieldguide)) > counter);
                        
                        int fieldguidenumber = 0;

                        switch(switchnumberChoice)
                        {
                            case (0): //skell
                                fieldguidenumber = 0;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (1)://ridge
                                fieldguidenumber = 1;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (2)://phase
                                fieldguidenumber = 2;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (3)://clasque
                                fieldguidenumber = 3;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (4)://bufest
                                fieldguidenumber = 4;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (5)://faethiol
                                fieldguidenumber = 5;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (6)://gazfurn
                                fieldguidenumber = 6;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (7)://wuskurg
                                fieldguidenumber = 7;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (8)://myrthra
                                fieldguidenumber = 8;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (9)://aezalor
                                fieldguidenumber = 9;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (10)://bracer
                                fieldguidenumber = 10;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;
                            case (11)://flit
                                fieldguidenumber = 11;
                                fieldguide[fieldguidenumber].PrintValueAcess();
                                break;

                        }
                        break;
                    case (2): //Health Value                     

                        int functionnumber = 1;
                        string orderchoice;
                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.health}");
                        }
                        Console.ReadLine();
                        do
                        {  
                            Console.Write("Order from highest to lowest?:");
                            orderchoice = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice, functionnumber));

                        functionnumber++;

                        if (inputCheckFunction.check(orderchoice, functionnumber) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Health Values\n=============");
                            List<CreatureLibrary> healthorder = fieldguide.OrderByDescending(fieldguide => fieldguide.health).ToList();
                            foreach (CreatureLibrary health in healthorder)
                            {
                                Console.WriteLine($"{health.name}: {health.health}");
                            }
                        }
                        
                        break;
                    case (3): // Mp value                   

                        int functionnumber2 = 1;
                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.mp}");
                        }
                        Console.ReadLine();
                        do
                        {
                      
                            Console.Write("Order from highest to lowest?:");
                            orderchoice = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice, functionnumber2));
                        functionnumber2++;
                        if (inputCheckFunction.check(orderchoice, functionnumber2) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Magic Values\n=============");
                            List<CreatureLibrary> healthorder = fieldguide.OrderByDescending(fieldguide => fieldguide.mp).ToList();
                            foreach (CreatureLibrary health in healthorder)
                            {
                                Console.WriteLine($"{health.name}: {health.mp}");
                            }
                        }
                        break;
                    case (4): // phys
                        int functionnumber3 = 1;
                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.phys}");
                        }
                        Console.ReadLine();
                        do
                        {
                            
                            Console.Write("Order from highest to lowest?:");
                            orderchoice = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice, functionnumber3));
                        functionnumber3++;
                        if (inputCheckFunction.check(orderchoice, functionnumber3) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Physical attack Values\n=============");
                            List<CreatureLibrary> healthorder = fieldguide.OrderByDescending(fieldguide => fieldguide.phys).ToList();
                            foreach (CreatureLibrary health in healthorder)
                            {
                                Console.WriteLine($"{health.name}: {health.phys}");
                            }
                        }
                        break;
                    case (5): // physdef
                        int functionnumber4 = 1;

                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.physdef}");
                        }
                        Console.ReadLine();
                        do
                        {
                            
                            Console.Write("Order from highest to lowest?:");
                            orderchoice = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice, functionnumber4));
                        functionnumber4++;
                        if (inputCheckFunction.check(orderchoice, functionnumber4) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Physical Defence Values\n=============");
                            List<CreatureLibrary> healthorder = fieldguide.OrderByDescending(fieldguide => fieldguide.physdef).ToList();
                            foreach (CreatureLibrary health in healthorder)
                            {
                                Console.WriteLine($"{health.name}: {health.physdef}");
                            }
                        }
                        break;
                    case (6): // ast
                        int functionnumber5 = 1;
                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.astral}");
                        }
                        Console.ReadLine();
                        do
                        {
                          
                            Console.Write("Order from highest to lowest?:");
                            orderchoice = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice, functionnumber5));
                        functionnumber5++;
                        if (inputCheckFunction.check(orderchoice, functionnumber5) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Astral Values\n=============");
                            List<CreatureLibrary> healthorder = fieldguide.OrderByDescending(fieldguide => fieldguide.astral).ToList();
                            foreach (CreatureLibrary health in healthorder)
                            {
                                Console.WriteLine($"{health.name}: {health.astral}");
                            }
                        }
                        break;
                    case (7): // astraldef
                        int functionnumber6 = 1;
                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.astraldef}");
                        }
                        Console.ReadLine();
                        do
                        {
                          
                            Console.Write("Order from highest to lowest?:");
                            orderchoice = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice, functionnumber6));
                        functionnumber6++;
                        if (inputCheckFunction.check(orderchoice, functionnumber6) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Astral Values\n=============");
                            List<CreatureLibrary> healthorder = fieldguide.OrderByDescending(fieldguide => fieldguide.astraldef).ToList();
                            foreach (CreatureLibrary health in healthorder)
                            {
                                Console.WriteLine($"{health.name}: {health.astraldef}");
                            }
                        }
                        break;
                    case (8): //speed
                        int functionnumber7 = 1;
                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.speed}");
                        }
                        Console.ReadLine();
                        do
                        {
                           
                            Console.Write("Order from highest to lowest?:");
                            orderchoice = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice, functionnumber7));
                        functionnumber7++;
                        if (inputCheckFunction.check(orderchoice, functionnumber7) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Speed Values\n=============");
                            List<CreatureLibrary> healthorder = fieldguide.OrderByDescending(fieldguide => fieldguide.speed).ToList();
                            foreach (CreatureLibrary health in healthorder)
                            {
                                Console.WriteLine($"{health.name}: {health.speed}");
                            }
                        }
                        break;
                    case (9): // types
                        
                        foreach (var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name}: {thing.typea} & {thing.typeb}");
                        }
                       
                        break;
                    case (10): //class
                        int functionnumber8 = 1;
                        string orderchoice8;
                        foreach(var thing in fieldguide)
                        {
                            Console.WriteLine($"{thing.name,10}: {thing.class_}");
                        }
                        Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Group?");
                            orderchoice8 = Console.ReadLine();
                        } while (!inputCheckFunction.check(orderchoice8, functionnumber8));
                        functionnumber8++;
                        if (inputCheckFunction.check(orderchoice8, functionnumber8) == false)
                        { }
                        else
                        {
                            Console.Clear();
                            fieldguide.Sort((C1, C2) => C1.class_.CompareTo(C2.class_));
                            fieldguide.ForEach(user => Console.WriteLine($"{user.name,10}: {user.class_}"));
                            fieldguide.Sort((C1, C2) => C1.id.CompareTo(C2.id));
                        }
                        break;

                    case (11): // description
                        foreach(var thing in fieldguide)
                        {
                            Console.Write($"{thing.name}: "); thing.DTacces(); Console.WriteLine("\n");
                        }                        
                        break;
                    case (12): // ability descriptions
                        { 
                        foreach(var ability in fieldguide)
                            {
                                Console.WriteLine($"{ability.name}: "); ability.creatureAbility();
                            }                        
                        }
                        break;
                    case (13):
                        { 
                        foreach( var moveslist in fieldguide)
                            {
                                Console.WriteLine($"{moveslist.name}: "); moveslist.movesavailable();
                            }
                        }
                        break;
                }
                string choice;
                int creatureselectchoice = 1;
                Console.ReadLine();
                do
                {
                    Console.Clear();
                    Console.Write($"Would you like to choose your three creatures?: ");
                    choice = Console.ReadLine();
                } while (!inputCheckFunction.check(choice, creatureselectchoice));

                creatureselectchoice++;
                if ((inputCheckFunction.check(choice, creatureselectchoice)) == true)
                {
                    foreach(var monsters in fieldguide)
                    {
                        Console.WriteLine($"{monsters.name}");
                    }
                    CreatureChoiceFunction(fieldguide, counter);
                    break;
                }
                            
            } while (menuLoop);
        }      
    
        public static void CreatureChoiceFunction(List<CreatureLibrary> fieldguide2, int counter )
        {
            InputCheckFunction inputCheckFunction = new InputCheckFunction();
            int switchnumberChoice;
            string creaturechoice;
            int b = -1;

            List<int> monsterChoiceStorage = new List<int>();
            List<int> numberchoice = new List<int>();

            int TeamNumber = 3; // amount of creatures to choose.
                                
            List<CreatureLibrary> teamChoice = new List<CreatureLibrary>();
            
            List<CreatureLibrary> cpuchoice = new List<CreatureLibrary>();

            List<CreatureLibrary> TeamChoiceBaseValues = new List<CreatureLibrary>();

            List<CreatureLibrary> CPUChoiceBaseValues = new List<CreatureLibrary>();

            for (int a = 0; a < TeamNumber; a++)
            {
               
                    do
                    {
                        do
                        {
                            Console.Write($"Creature {(a + 1)}: ");
                            creaturechoice = Console.ReadLine();
                           

                        } while ((switchnumberChoice = inputCheckFunction.Cchecker(creaturechoice, counter, fieldguide2)) > counter);
                        b++;
                    } while (!inputCheckFunction.repeatPrevention(switchnumberChoice, b, monsterChoiceStorage, numberchoice));//same number not present
           

                switch (switchnumberChoice)
                {
                        case (0):
                        Skell skell = new Skell();                        
                            teamChoice.Add(skell);
                        SkellBaseValues skellBase = new SkellBaseValues();
                        TeamChoiceBaseValues.Add(skellBase);
                            break ;
                        case (1):
                        Ridge ridge = new Ridge();
                            teamChoice.Add(ridge);
                        RidgeBaseValues ridgeBase = new RidgeBaseValues();
                        TeamChoiceBaseValues.Add(ridgeBase);
                        break;
                        case (2):
                        Phase phase = new Phase();
                            teamChoice.Add(phase);
                        PhaseBaseValues phaseBase = new PhaseBaseValues();
                        TeamChoiceBaseValues.Add(phaseBase);
                        break;
                        
                        /*
                        case (3):

                            teamChoice.Add(fieldguide2[3]);
                        ClasqueBaseValues clasqueBase = new ClasqueBaseValues();
                        TeamChoiceBaseValues.Add(clasqueBase);
                        break;
                        case (4):
                            teamChoice.Add(fieldguide2[4]);
                        BufestBaseValues bufestBase = new BufestBaseValues();
                        TeamChoiceBaseValues.Add(bufestBase);
                        break;
                        case (5):
                            teamChoice.Add(fieldguide2[5]);
                        FaethiolBaseValues faethiolBase = new FaethiolBaseValues();
                        TeamChoiceBaseValues.Add(faethiolBase);
                        break;
                        case (6):
                            teamChoice.Add(fieldguide2[6]);
                        GazfurnBaseValues gazfurnBase = new GazfurnBaseValues();
                        TeamChoiceBaseValues.Add(gazfurnBase);
                        break;
                        case (7):
                            teamChoice.Add(fieldguide2[7]);
                        WuskurgBaseValues wuskurgBase = new WuskurgBaseValues();
                        TeamChoiceBaseValues.Add(wuskurgBase);
                        break;
                        case (8):
                            teamChoice.Add(fieldguide2[8]);
                        MyrthraBaseValues myrthraBase = new MyrthraBaseValues();
                        TeamChoiceBaseValues.Add(myrthraBase);
                        break;
                        case (9):
                            teamChoice.Add(fieldguide2[9]);
                        AezalorBaseValues aezalorBase = new AezalorBaseValues();
                        TeamChoiceBaseValues.Add(aezalorBase);
                        break;
                        case (10):
                            teamChoice.Add(fieldguide2[10]);
                        BracerBaseValues bracerBase = new BracerBaseValues();
                        TeamChoiceBaseValues.Add(bracerBase);
                        break;
                        case (11):
                            teamChoice.Add(fieldguide2[11]);
                        FlitBaseValues flitBase = new FlitBaseValues();
                        TeamChoiceBaseValues.Add(flitBase);
                        break;*/
                }                                  
            }       
          
            int[] numberstorechecker = new int[TeamNumber];

            for (int a = 0; a < TeamNumber; a++)
            {
                int cputeamchoice;
                bool repeatinput = false;
                Random rnd = new Random();
                do
                {
                    cputeamchoice = rnd.Next(1, TeamNumber+1);

                    var resultchecker = Array.Find(numberstorechecker, element => element.Equals(cputeamchoice));   
                    if(resultchecker == cputeamchoice) // prevents the repitition of choice 
                    {
                       repeatinput = true;
                    }
                    else 
                    {
                        repeatinput = false;
                    }

                    numberstorechecker[a] = cputeamchoice;

                } while (repeatinput == true);
                
                switch (cputeamchoice)
                {
                    case (1): // "skell"
                        Skell1 skell1 = new Skell1();
                        SkellBaseValues skellBaseValues = new SkellBaseValues();
                        cpuchoice.Add(skell1);
                        CPUChoiceBaseValues.Add(skellBaseValues);
                        break;
                    case (2): //ridge
                        Ridge1 ridge1 = new Ridge1();
                        RidgeBaseValues ridgeBaseValues = new RidgeBaseValues();
                        cpuchoice.Add(ridge1);
                        CPUChoiceBaseValues.Add(ridgeBaseValues);
                        break;
                    case (3): //phase
                        Phase1 phase1 = new Phase1();
                        PhaseBaseValues phaseBaseValues = new PhaseBaseValues();
                        cpuchoice.Add(phase1);
                        CPUChoiceBaseValues.Add(phaseBaseValues);
                        break;
                        /*
                    case (4): //clasque
                        Clasque1 clasque1 = new Clasque1();
                        ClasqueBaseValues clasqueBaseValues = new ClasqueBaseValues();
                        cpuchoice.Add(clasque1);
                        CPUChoiceBaseValues.Add(clasqueBaseValues);
                        break;
                    case (5)://bufest
                        Bufest1 bufest1 = new Bufest1();
                        BufestBaseValues bufestBaseValues = new BufestBaseValues();
                        cpuchoice.Add(bufest1);
                        CPUChoiceBaseValues.Add(bufestBaseValues);
                        break;
                    case (6): //faethiol
                        Faethiol1 faethiol1 = new Faethiol1();
                        FaethiolBaseValues faethiolBaseValues = new FaethiolBaseValues();
                        cpuchoice.Add(faethiol1);
                        CPUChoiceBaseValues.Add(faethiolBaseValues);
                        break;
                    case (7): //gazfurn
                        Gazfurn1 gazfurn1 = new Gazfurn1();
                        GazfurnBaseValues gazfurnBaseValues = new GazfurnBaseValues();
                        cpuchoice.Add(gazfurn1);
                        CPUChoiceBaseValues.Add(gazfurnBaseValues);
                        break;
                    case (8): //wuskurg
                        WuSkurg1 wuSkurg1 = new WuSkurg1();
                        WuskurgBaseValues wuskurgBaseValues = new WuskurgBaseValues();
                        cpuchoice.Add(wuSkurg1);
                        CPUChoiceBaseValues.Add(wuskurgBaseValues);
                        break;
                    case (9): //myrthra
                        Myrthra1 myrthra1 = new Myrthra1();
                        MyrthraBaseValues myrthraBaseValues = new MyrthraBaseValues();
                        cpuchoice.Add(myrthra1);
                        CPUChoiceBaseValues.Add(myrthraBaseValues);
                        break;
                    case (10): //aezalor
                        Aezalor1 aezalor1 = new Aezalor1();
                        AezalorBaseValues aezalorBaseValues = new AezalorBaseValues();
                        cpuchoice.Add(aezalor1);
                        CPUChoiceBaseValues.Add(aezalorBaseValues);
                        break;
                    case (11): //bracer
                        Bracer1 bracer1 = new Bracer1();
                        BracerBaseValues bracerBaseValues = new BracerBaseValues();
                        cpuchoice.Add(bracer1);
                        CPUChoiceBaseValues.Add(bracerBaseValues);
                        break;
                    case (12): //flit
                        Flit1 flit1 = new Flit1();
                        FlitBaseValues flitBaseValues = new FlitBaseValues();
                        cpuchoice.Add(flit1);
                        CPUChoiceBaseValues.Add(flitBaseValues);
                        break;*/
                }                
            }
      
            PassingTeam(teamChoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues);
               
        }
        public static void PassingTeam(List<CreatureLibrary> teamChoice, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> TeamChoiceBaseValues, List<CreatureLibrary> CPUChoiceBaseValues)
        {
            gameplay gameplay = new gameplay(teamChoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues);
        }
        public Catalogue(int counter,List<CreatureLibrary> fieldguide)
           
        {           
            InputCheckFunction inputCheckFunction = new InputCheckFunction();          
                       
            string[] NameLister = new string[counter];
            
             while (menuloop == true)
             {
                int inputcounter = 1;
                string choice;
              
                do
                {
                 Console.Clear();

                    Console.WriteLine($"The fieldguide currently consists of {counter} recorded creatures:");
                    Console.WriteLine("==========");Console.WriteLine($"Menu");

                    for (int aa = 0; aa < fieldguide.Count; aa++)
                    {
                        NameLister[aa] = fieldguide[aa].name;
                        Console.WriteLine($"\u00FE {NameLister[aa]}");
                    }
                    Console.Write($"==========\nView Menu?: ");
                    choice = Console.ReadLine();

                } while (!inputCheckFunction.check(choice, inputcounter)); // while function returns false

                inputcounter++;
                if (inputCheckFunction.check(choice, inputcounter) == false)
                {
                    CreatureChoiceFunction(fieldguide, counter); // skips the menu and goes to choosing the monsters
                    menuloop = false;
                }
                else
                {
                    MenuDisplay(fieldguide, counter); // menu displayer
                    menuloop = false;
                }                 
             }
        }        
    }
}
