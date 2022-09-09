using System;
using System.Collections.Generic;
using System.Text;

namespace Wisps
{
    class SecondaryEffects
    {
        public SecondaryEffects(CreatureLibrary Defender, ref bool SecondaryAllowed, string MoveType)
        {
            colourcheck colourcheck = new colourcheck();

            switch(Defender.healthstatus)
            {               
                case ("Normal"):
                    {
                        switch(MoveType)
                        {
                            case ("Acid"):
                                {
                                    if(SecondaryAllowed == false || Defender.typea == "Tar" || Defender.typeb == "Tar")
                                    { }
                                    else
                                    {
                                    // reactive and corroded
                                    if(Defender.typea == "Liquid Gold"|| Defender.typeb == "Liquid Gold"|| Defender.typea == "Metal"||Defender.typeb == "Metal")
                                        {
                                            //corrosion
                                            Defender.healthstatus = "Corroded";
                                            Defender.conditionTurnsRemaining = 3;
                                            Console.WriteLine($"{colourcheck.DefColournaming(Defender).name} is covered in corrosive acid", Console.ForegroundColor = ConsoleColor.Green);
                                        }
                                        else
                                        {
                                            // reactive
                                            Defender.healthstatus = "Reactive";
                                            Defender.conditionTurnsRemaining = 2;
                                            Console.WriteLine($"{colourcheck.DefColournaming(Defender).name} is covered in reactive acid", Console.ForegroundColor = ConsoleColor.Green);
                                        }

                                    }
                                }
                                break;                                
                        }
                    }
                    break;
            }    
            switch(Defender.mods)
            {
               
            }        
        }
    }
}
