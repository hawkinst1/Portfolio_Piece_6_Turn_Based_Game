using System;

using System.Collections.Generic;
using System.Text;

namespace Wisps
{
    class FieldAlterations
    {
        public FieldAlterations(string name, string EffectRange, List<CreatureLibrary> yourTeam, List<CreatureLibrary> OpposingTeam, List<CreatureLibrary> BaseValues, List<CreatureLibrary> EnemyBase)
        {
            colourcheck colourcheck = new colourcheck();
            bool canEffect = true;
            switch (EffectRange)
            {
                case ("Opposing Field"):
                { 
                    switch (name)
                    {
                            case ("Syrup Trap"):
                                {
                                    for( int a = 0; a < OpposingTeam.Count; a++)
                                    {
                                        OpposingTeam[a].fieldStatus = "Syrup Trap";
                                        OpposingTeam[a].fieldStatusCount = 3; 
                                        OpposingTeam[a].speed = (OpposingTeam[a].speed / 2);
                                        
                                        EffectAbilities effectAbilities = new EffectAbilities(ref canEffect, OpposingTeam[a], name, yourTeam , OpposingTeam ,BaseValues, EnemyBase);
                                        if (canEffect == false)
                                        {
                                            Console.WriteLine($"{colourcheck.DefColournaming(OpposingTeam[a]).name}'s speed cannot be lowered");
                                        }
                                    }
                                }
                                break; 
                            
                           case ("Fissure"):
                                {
                                    if (OpposingTeam[0].fieldStatus != "Normal")
                                    {
                                        Console.WriteLine($"The {OpposingTeam[0].fieldStatus} falls away into the opened fissure.");
                                        for (int a = 0; a < OpposingTeam.Count; a++)
                                        {
                                            OpposingTeam[a].fieldStatus = "Normal";
                                            OpposingTeam[a].fieldStatusCount = 0;       
                                        }
                                    }                                   
                                }
                          break;                          
                    }
                }
                    break;
                case ("Own Field"):
                    {
                        switch (name)
                        {
                            case ("Soothing Rain"):
                                {                                
                                for(int a = 0; a < yourTeam.Count; a++)
                                    {
                                        yourTeam[a].skyFieldStatus = "Soothing Rain";
                                        yourTeam[a].skyFieldCount = 3;
                                        yourTeam[a].fieldStatus = "Damp";
                                        yourTeam[a].fieldStatusCount = 3;
                                    }
                                } 
                                break;
                        }
                    }
                    break;
                case ("Both"):
                    {
                        switch (name)
                        {
                            case ("High Winds"):
                                {
                                    for (int a = 0; a < OpposingTeam.Count; a++)
                                    {
                                       OpposingTeam[a].fieldStatusCount = 0;
                                       OpposingTeam[a].skyFieldCount = 0;
                                    }
                                    for (int b = 0; b < yourTeam.Count; b++)
                                    {
                                       yourTeam[b].fieldStatusCount = 0;
                                       yourTeam[b].skyFieldCount = 0;
                                    }
                                }
                                break;
                            case ("Blazing Fields"):
                                {                                    
                                    for (int a = 0; a < OpposingTeam.Count; a++)
                                    {
                                        if (OpposingTeam[a].fieldStatus == "Blazing Fields")
                                        { }
                                        else
                                        {
                                            OpposingTeam[a].fieldStatus = "Blazing Fields";
                                           
                                            OpposingTeam[a].fieldStatusCount = 3;
                                            
                                        }
                                    }
                                    for (int b = 0; b < yourTeam.Count; b++)
                                    {
                                        if (yourTeam[b].fieldStatus == "Blazing Fields")
                                        { }
                                        else
                                        {
                                            yourTeam[b].fieldStatus = "Blazing Fields";
                                            
                                            yourTeam[b].fieldStatusCount = 3;
                                         
                                        }
                                        }
                                }
                                break;
                        }

                    }
                    break;                    
            }
         }
    }
}
