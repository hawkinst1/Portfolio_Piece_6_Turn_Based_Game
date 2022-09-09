using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Wisps
{
    class EndofTurnEffects
    {
        public EndofTurnEffects(List<CreatureLibrary> AllMonsters, List<CreatureLibrary> teamchoice, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> TeamChoiceBaseValues, List<CreatureLibrary> CPUChoiceBaseValues)
        {
            colourcheck colouring = new colourcheck();

            for (int a = 0; a < teamchoice.Count; a++)
            {
                Console.Write($"{colouring.AtkColournaming(teamchoice[a]).name}: {colouring.Statuscolouring(teamchoice[a]).healthstatus}|");
                Console.Write("    ");

            }
            
            Console.WriteLine();

            for (int a = 0; a < cpuchoice.Count; a++)
            {
                Console.Write($"{colouring.AtkColournaming(cpuchoice[a]).name}: {colouring.Statuscolouring(cpuchoice[a]).healthstatus}|");
                Console.Write("    ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            for (int a = 0; a < teamchoice.Count; a++)
            {
                if (teamchoice[a].teamStatus == "Player")
                {
                    if (teamchoice[a].faintstatus != "Active" || teamchoice[a].healthstatus != "Normal" || teamchoice[a].fieldStatus != "Normal" || teamchoice[a].skyFieldStatus != "Normal" || teamchoice[a].mods != "Normal")
                    {
                        switch (teamchoice[a].faintstatus)
                        {
                            case ("CommandShocked"):
                                {
                                    teamchoice[a].faintstatus = "Active";
                                    Console.WriteLine($"{teamchoice[a].name} is freed of their command");
                                }
                                break;
                        }
                        switch (teamchoice[a].healthstatus)
                        {
                            case ("Corroded"):
                                {
                                    if (AllMonsters[a].conditionTurnsRemaining == 0)
                                    {
                                        Console.WriteLine($"The corrosive acid has reacted away!");
                                        teamchoice[a].healthstatus = "Normal";
                                        teamchoice[a].physdef = TeamChoiceBaseValues[a].physdef;
                                    }
                                    if (teamchoice[a].conditionTurnsRemaining > 0)
                                    {
                                        if (teamchoice[a].typea == "Metal" || teamchoice[a].typeb == "Metal")
                                        {
                                            teamchoice[a].physdef -= Convert.ToDouble(TeamChoiceBaseValues[a].physdef * 0.05); // 5% reduction for 3 turns
                                            Console.WriteLine($"{teamchoice[a].name}'s defences are being corroded away!", Console.ForegroundColor = ConsoleColor.Green);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            teamchoice[a].conditionTurnsRemaining--;
                                        }
                                        else if (teamchoice[a].typea == "Liquid Gold" || teamchoice[a].typeb == "Liquid Gold")
                                        {
                                            teamchoice[a].astraldef -= Convert.ToDouble(TeamChoiceBaseValues[a].astraldef * 0.05); // 5% reduction for 3 turns
                                            Console.WriteLine($"{teamchoice[a].name}'s astral defences are being corroded away!", Console.ForegroundColor = ConsoleColor.Green);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            teamchoice[a].conditionTurnsRemaining--;
                                        }
                                    }
                                }
                                break;
                            case ("Reactive"):
                                {
                                    teamchoice[a].conditionTurnsRemaining--;
                                    if (teamchoice[a].conditionTurnsRemaining == 0)
                                    {
                                        teamchoice[a].healthstatus = "Normal";
                                        Console.Write($"{colouring.AtkColournaming(teamchoice[a]).name} is no longer reactive.");
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        switch (teamchoice[a].mods)
                        {
                            case ("Golem Arms"):
                                {
                                    teamchoice[a].modcount--;
                                    if(teamchoice[a].modcount == 0)
                                    {
                                        teamchoice[a].mods = "Normal";

                                        for (int b = 0; b < TeamChoiceBaseValues.Count; b++)
                                        {
                                            if (teamchoice[b].name == TeamChoiceBaseValues[b].name)
                                            {
                                                teamchoice[a].phys = TeamChoiceBaseValues[b].phys;
                                            }
                                        }
                                    }
                                }
                                break;
                            case ("Scrap Armour"):
                                {
                                    if (teamchoice[a].modcount == 3 || teamchoice[a].modcount == 2 || teamchoice[a].modcount == 1)
                                    {
                                        teamchoice[a].modcount--;
                                    }
                                    if (teamchoice[a].modcount == 0)
                                    {
                                        teamchoice[a].healthstatus = "Normal";
                                        Console.Write($"{colouring.AtkColournaming(teamchoice[a]).name} is no longer reactive.");

                                        teamchoice[a].physdef = TeamChoiceBaseValues[a].physdef;
                                        teamchoice[a].speed = TeamChoiceBaseValues[a].speed;
                                    }
                                }                                
                                break;
                            case ("Tar Blob"):
                                {
                                    teamchoice[a].modcount--;

                                    if (teamchoice[a].modcount == 0)
                                    {
                                        Console.WriteLine($"The tar falls away from {teamchoice[a].name}.");
                                        teamchoice[a].modcount = 0;
                                        teamchoice[a].mods = "Normal";

                                        for (int b = 0; b < TeamChoiceBaseValues.Count; b++)
                                        {
                                            if (teamchoice[b].name == TeamChoiceBaseValues[b].name)
                                            {
                                                teamchoice[a].physdef = TeamChoiceBaseValues[b].physdef;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                        switch (teamchoice[a].fieldStatus)
                        {
                         
                            case ("Syrup Trap"):
                                {
                                    AllMonsters[a].fieldStatusCount--;
                                    Console.WriteLine($"The amber is drying around {AllMonsters[a].name}'s feet", Console.ForegroundColor = ConsoleColor.DarkBlue);
                                    Console.ForegroundColor = ConsoleColor.White;

                                    if (AllMonsters[a].fieldStatusCount == 0)
                                    {
                                        Console.WriteLine($"{AllMonsters[a].name} is freed from the amber!");
                                        AllMonsters[a].speed = TeamChoiceBaseValues[a].speed;
                                        AllMonsters[a].fieldStatus = "Normal";
                                    }
                                }
                                break;
                            case ("Blazing Fields"):
                                {
                                    if (teamchoice[a].fieldStatusCount > 1)
                                    {
                                        if (teamchoice[a].typea == "Air" || teamchoice[a].typeb == "Air")
                                        {

                                        }
                                        if (teamchoice[a].typea == "Fire" || teamchoice[a].typeb == "Fire" || teamchoice[a].typea == "Water" || teamchoice[a].typeb == "Water")
                                        {
                                            if (teamchoice[a].typea == "Fire" || teamchoice[a].typeb == "Fire")
                                            {
                                                Console.Write($"{colouring.AtkColournaming(teamchoice[a]).name} is healed through the blazing fields.\t");
                                                AllMonsters[a].health += (TeamChoiceBaseValues[a].health * .12);
                                            }

                                            if (teamchoice[a].typea == "Water" || teamchoice[a].typeb == "Water")
                                            {
                                                teamchoice[a].health -= (TeamChoiceBaseValues[a].health * .05);
                                                Console.Write($"{colouring.AtkColournaming(teamchoice[a]).name} is hurt by the flames.\t");
                                            }
                                        }
                                        else
                                        {
                                            AllMonsters[a].health -= (TeamChoiceBaseValues[a].health * .12);
                                            Console.Write($"{colouring.AtkColournaming(teamchoice[a]).name} is hurt by the flames.\t");
                                        }

                                        teamchoice[a].fieldStatusCount--;
                                      
                                    }
                                    else
                                    {
                                        if (teamchoice[a].fieldStatusCount == 1)
                                        {
                                            teamchoice[a].fieldStatusCount = 0;
                                          
                                            teamchoice[a].fieldStatus = "Normal";

                                            Console.Write($"{colouring.AtkColournaming(teamchoice[a]).name} is no longer in the fire.\t");
                                        }
                                    }
                                }
                                break;                           
                        }
                        switch (teamchoice[a].skyFieldStatus)
                        {
                            case ("Soothing Rain"):
                                {
                                    if (teamchoice[a].skyFieldCount > 1)
                                    {
                                        if (teamchoice[a].health == TeamChoiceBaseValues[a].health)
                                        {
                                            Console.WriteLine($"{colouring.AtkColournaming(teamchoice[a]).name} is at max health.");
                                            teamchoice[a].skyFieldCount--;
                                            teamchoice[a].fieldStatusCount--;
                                        }
                                        else
                                        {
                                            teamchoice[a].health += (TeamChoiceBaseValues[a].health*0.2);
                                            Console.WriteLine($"Soothing rain falls on {colouring.AtkColournaming(teamchoice[a]).name}.");
                                            teamchoice[a].skyFieldCount--;
                                            teamchoice[a].fieldStatusCount--;
                                        }
                                    }
                                    if(teamchoice[a].skyFieldCount == 1)
                                    {
                                        Console.WriteLine("The rain stops");
                                        teamchoice[a].skyFieldCount = 0;
                                        teamchoice[a].skyFieldStatus = "Normal";
                                        teamchoice[a].fieldStatusCount = 0;
                                        teamchoice[a].fieldStatus = "Normal";
                                    }
                                }
                                break;
                        }
                    }
                }    
                switch(teamchoice[a].ability)
                {
                    case ("In Touch"):
                        {
                            Console.WriteLine($"{colouring.AtkColournaming(teamchoice[a]).name} is in touch with the universe, restoring their MP.");
                            if (teamchoice[a].mp == TeamChoiceBaseValues[a].mp)
                            {}
                            else
                            { 
                                teamchoice[a].mp += TeamChoiceBaseValues[a].mp * .1;
                            }

                        }
                        break;
                }
            }
            Console.WriteLine();
            /////////////////////////////////////////////////////////////////////
            /// CPU STUFF
            /////////////////////////////////////////////////////////////////////
            for (int a = 0; a < cpuchoice.Count; a++)
            {
                colourcheck colourcheck = new colourcheck();

                if (cpuchoice[a].teamStatus == "CPU")
                {
                    if (cpuchoice[a].faintstatus != "Active" || cpuchoice[a].healthstatus != "Normal" || cpuchoice[a].fieldStatus != "Normal" || cpuchoice[a].skyFieldStatus != "Normal" || cpuchoice[a].mods != "Normal") ;
                }
                switch (cpuchoice[a].ability)
                {
                    case ("In Touch"):
                        {
                            Console.WriteLine($"{colouring.AtkColournaming(cpuchoice[a]).name} is in touch with the universe, restoring their MP.");
                         
                            if (cpuchoice[a].mp == CPUChoiceBaseValues[a].mp)
                            { }
                            else
                            {
                                cpuchoice[a].mp += CPUChoiceBaseValues[a].mp * .1;
                            }
                        }
                        break;
                }
            }
        }
    }
}
