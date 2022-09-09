using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Wisps
{
    class HealingMoves
    {
        public HealingMoves(CreatureLibrary Reciever, CreatureLibrary Healer, List<CreatureLibrary> TeamList, List<CreatureLibrary> OppTeam, List<CreatureLibrary> TeamValues, 
            List<CreatureLibrary> OppTeamValues,int potency, string MoveName )
        {
            colourcheck colourcheck = new colourcheck();

            bool SecondaryAllow = true;
            switch (MoveName)
            {
                case ("Scrap Armour"):
                    {
                        Console.WriteLine($"{colourcheck.AtkColournaming(Healer).name} clads {colourcheck.DefColournaming(Reciever).name} in scrap metal armour");

                        EffectAbilities effectAbilities = new EffectAbilities(ref SecondaryAllow, Reciever, MoveName, TeamList, OppTeam, TeamValues, OppTeamValues);
                    
                        if(SecondaryAllow == true)
                        {
                            for (int a = 0; a < TeamList.Count; a++)
                            {
                                if (Reciever.name == TeamList[a].name)
                                {
                                    Reciever.physdef += (TeamValues[a].physdef * .33);
                                    Reciever.speed -= (TeamValues[a].physdef * .25);
                                }
                            }
                        }
                        else
                        {
                            for (int a = 0; a < TeamList.Count; a++)
                            {
                                if (Reciever.name == TeamList[a].name)
                                {
                                    Reciever.physdef += (TeamValues[a].physdef * .33);
                                    Console.WriteLine($"{colourcheck.DefColournaming(Reciever).name}'s speed cannot be lowered");
                                }
                            }
                        }
                    }
                    break;
                case ("Nutrients of Terra"):
                    {
                        List<CreatureLibrary> healerhealth = new List<CreatureLibrary>();
                        double healing = ((potency + Healer.astral) * 0.2);
                        int recipient = 1;
                        Random rnd = new Random();
                        int a = 0;

                        for (int b = 0; b < TeamList.Count;b++)
                        {
                            if(Healer.name == TeamList[b].name)
                            {
                                healerhealth.Add(TeamList[b]);
                            }
                        }
                        if (Healer.health < healerhealth[a].health) 
                            {
                                Console.WriteLine($"{Healer.name} is running low on health!\n{Healer.name} uses {MoveName} on themselves.");

                            Healer.health += healing; 

                                break;
                            }
                        if (TeamList[recipient].health <= 0)
                        {
                            Console.WriteLine($"Cannot heal {TeamList[recipient].name} as they have fainted!");
                        }
                        else
                        {
                            do
                            {
                                recipient = rnd.Next(0, 3);

                            } while (TeamList[recipient].name == Healer.name);
                        }

                        if (TeamList[recipient].typea == "Terra" || TeamList[recipient].typeb == "Terra" || TeamList[recipient].typea == "Flora" || TeamList[recipient].typea == "Flora")
                        {
                            Console.WriteLine($"{TeamList[recipient].name} recieves extra nutrients from {Healer.name} due to their type!");
                            TeamList[recipient].health += (healing * 1.5);
                        }
                        else
                        {
                            Console.WriteLine($"{TeamList[recipient].name} recieves nutrients from {Healer.name}.");
                        }
                        TeamList[recipient].health += healing;
                    }                   
                    break;
                case ("Tar Blob"):
                    {
                        if(Healer.mods == "Tar Blob")
                        {
                            Console.WriteLine($"{Healer.name} is already convered in tar");
                        }
                        else
                        {

                            Healer.mods = "Tar Blob";
                            Healer.modcount = 3;

                            for (int a = 0; a < TeamValues.Count; a++)
                            {
                                if (Healer.name == TeamValues[a].name)
                                {
                                    Healer.physdef = (TeamValues[a].physdef * 0.1); // 10% increase.
                                }
                            }
                        }

                    }
                    break;
            }
        }
    }
}
