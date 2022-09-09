using System;
using System.Collections.Generic;
using System.Text;

namespace Wisps
{
    class EffectAbilities
    {
        public EffectAbilities(ref bool secondaryAllow, CreatureLibrary Defender, string MoveType, List<CreatureLibrary> Team, List<CreatureLibrary> EnemyTeam, List<CreatureLibrary> TeamValues, List<CreatureLibrary> enemyValues )
        {
            colourcheck colourcheck = new colourcheck();
                  
            switch (Defender.ability)
            {
                case ("Golem Arms"):
                    {
                        if(MoveType == "Terra")
                        {
                            Console.WriteLine($"{colourcheck.DefColournaming(Defender).name}' imbues their arms in earth");
                            Defender.mods = "Golem Arms";
                            Defender.modcount = 3;

                            for (int a = 0; a < Team.Count; a++)
                            {
                                if (Defender.name == Team[a].name)
                                {
                                    Defender.phys += TeamValues[a].phys * .2;
                                }
                            }                     
                        }
                    }
                    break;
                case ("Thick Skin"):
                    {
                        if(MoveType == "Acid")
                        {
                            secondaryAllow = false;
                            Console.WriteLine($"{colourcheck.DefColournaming(Defender).name}'s thick skin is immune to acid effects");
                        }
                    }
                    break;
                case ("Ethereal Speed"): // prevents speed lowering
                    {
                        if(Defender.teamStatus == "Player")
                        {
                            for(int a = 0; a < Team.Count; a++)
                            {
                                if(Defender.name == Team[a].name)
                                {
                                    if(Defender.speed < TeamValues[a].speed)
                                    {
                                        secondaryAllow = false;
                                    }
                                }
                            }
                        }

                        if(Defender.teamStatus == "CPU")
                        {
                            for (int a = 0; a < EnemyTeam.Count; a++)
                            {
                                if (Defender.name == EnemyTeam[a].name)
                                {
                                    if (Defender.speed < enemyValues[a].speed)
                                    {
                                        secondaryAllow = false;
                                    }
                                }
                            }
                        }
                    }
                    break;


            }
} 
    }
        }
