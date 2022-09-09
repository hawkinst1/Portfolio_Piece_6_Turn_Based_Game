using System;
using System.Collections.Generic;
using System.Text;

namespace Wisps
{
    class OffensiveAbilities
    {
        public OffensiveAbilities(CreatureLibrary Attacker, CreatureLibrary Defender, List<CreatureLibrary> Team, List<CreatureLibrary> EnemyTeam, List<CreatureLibrary> TeamBaseValues,List<CreatureLibrary> EnemyBaseValues ,string MoveType, string AstorPhys, string TargetType, ref double dmgMod, ref double dmgMod2, double basepower)
        {
            colourcheck colourcheck = new colourcheck();

            switch (Defender.ability) // defender
            {
                case ("Ghost Hunter"):
                    {
                        if (AstorPhys != "Astral" || AstorPhys != "Phys")
                        { }
                        else
                        {
                            if (MoveType == "Ethereal")
                            {
                                dmgMod = 0;
                                Console.WriteLine($"{colourcheck.DefColournaming(Defender).name} draws in ethereal moves!");
                            }
                        }
                    }
                    break;
                case ("Arctic Grace"):
                    {
                        if (MoveType == "Ice")
                        {
                            for (int a = 0; a < Team.Count; a++)
                            {
                                if (Defender.name == TeamBaseValues[a].name)
                                {
                                    Defender.health += (TeamBaseValues[a].health * 0.25);
                                    if (Defender.health > TeamBaseValues[a].health)
                                    {
                                        Defender.health = TeamBaseValues[a].health; // to stop it going over 100% health
                                    }
                                    Console.WriteLine($"{Defender.name}'s health is restored by the ice!");
                                    dmgMod = 0;
                                    dmgMod2 = 0;
                                }
                            }
                        }
                    }
                    break;              
            }
            switch (Attacker.ability)
            {
                case ("Power Supplier"):
                    {
                        if(MoveType == "Lightning")
                        {
                            dmgMod = 0.6;
                            Console.WriteLine($"{colourcheck.AtkColournaming(Attacker).name}'s power supplier charges their electric moves");
                        }
                    }
                    break;
                case ("Crystalline Expansion"):
                    {
                        if(Defender.typea == "Water" || Defender.typeb == "Water")
                        {
                            dmgMod = 0.6;
                            Console.WriteLine($"The ice forms damaging crystals");
                        }

                    }
                    break;
            }
        }        
    }
}
