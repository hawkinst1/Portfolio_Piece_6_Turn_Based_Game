using System;
using System.Collections.Generic;
using System.Text;

namespace Wisps
{
    class MoveAndEffects
    {
        bool SecondaryAllowed = true;
        double dmgMod =0.5;
        double dmgMod2 =0.5;
        double super = 0.6;
        double minimal = 0.4;
        public MoveAndEffects(double basepower, string attackType, CreatureLibrary defender, CreatureLibrary attacker,string attackbase, string target, List<CreatureLibrary> WholeTeam, List<CreatureLibrary>OpposingWholeTeam,List<CreatureLibrary> TeamBaseValues,List<CreatureLibrary> EnemyBaseValues)
        {
            if (attackType == "Acid")
            {
                if (defender.typea == "Acid")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = super; ;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Tar")
                {
                    dmgMod = 0;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Acid")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Tar")
                {
                    dmgMod2 = 0;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = minimal; 
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Air")
            {
                if(defender.typea == "Air")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Air")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = super;
                }

            }
            if (attackType == "Phosphoro")
            {
                if( defender.healthstatus == "Reactive")
                {
                    dmgMod = super;
                    defender.healthstatus = "Normal";
                    defender.conditionTurnsRemaining = 0;
                }
                if(defender.typea == "Acid")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Tar")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Acid")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Tar")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Fire")
            {
                if(defender.healthstatus == "Reactive")
                {
                    dmgMod = super;
                    defender.healthstatus = "Normal";
                    defender.conditionTurnsRemaining = 0;
                    Console.WriteLine($"The reactive acid burns explosively!");
                }
                if(defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = 0;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = 0;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = super; 
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = minimal;
                }
            }
            if (attackType == "Flora")
            {
                if(defender.typea == "Acid")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Acid")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = minimal; 
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Ice")
            {
                if(defender.typea == "Air")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = minimal; 
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Air")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = super; 
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Light")
            {
                if(defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = 0;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = 0;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Tar")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = 0;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = 0;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Tar")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = minimal;
                }
            }
            if (attackType == "Lightning")
            {
                if(defender.typea == "Air")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = 0;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Air")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = 0;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Liquid Gold")
            {
                if(defender.typea == "Fire")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Minera")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Tar")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Minera")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Tar")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Metal")
            {
                if(defender.typea == "Acid")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = minimal;
                }
                if (defender.typeb == "Acid")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = minimal;
                }
            }
            if (attackType == "Mineral")
            {
                if(defender.typea == "Acid")
                {
                    dmgMod = super; 
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Acid")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Amber")
            {
                if(defender.typea == "Flora")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = 0;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = 0;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Ethereal")
            {
                if(defender.typea == "Air")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Tar")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Air")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Tar")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = super;
                }

            }
            if (attackType == "Tar")
            {
                if(defender.typea == "Air")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Tar")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Air")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Tar")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = super;
                }
            }
            if (attackType == "Terra")
            {
                if(defender.typea == "Acid")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = minimal;
                }
                if (defender.typeb == "Acid")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = super; 
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = minimal;
                }

            }
            if (attackType == "Timber")
            {
                if(defender.typea == "Air")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Phosphor")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Light")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Air")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ethereal")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = super;
                }
                if (defender.typeb == "Air")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Phosphor")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Light")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Air")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ethereal")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = super;
                }

            }
            if (attackType == "Water")
            {
                if(defender.typea == "Acid")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Phosphoro")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Fire")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Flora")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Ice")
                {
                    dmgMod = 0;
                }
                if (defender.typea == "Lightning")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Liquid Gold")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Metal")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Mineral")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Amber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Tar")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Terra")
                {
                    dmgMod = super;
                }
                if (defender.typea == "Timber")
                {
                    dmgMod = minimal;
                }
                if (defender.typea == "Water")
                {
                    dmgMod = minimal;
                }
                if (defender.typeb == "Acid")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Phosphoro")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Fire")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Flora")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Ice")
                {
                    dmgMod2 = 0;
                }
                if (defender.typeb == "Lightning")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Liquid Gold")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Metal")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Mineral")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Amber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Tar")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Terra")
                {
                    dmgMod2 = super;
                }
                if (defender.typeb == "Timber")
                {
                    dmgMod2 = minimal;
                }
                if (defender.typeb == "Water")
                {
                    dmgMod2 = minimal;
                }
            }

        AbilityMod(attacker, defender, WholeTeam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues, attackType,attackbase,target,ref dmgMod,ref dmgMod2,basepower); // see how the calcs need to change

        DamageCalc(dmgMod,dmgMod2,basepower,defender,attacker,attackbase); // where the actual health calculation takes place

        AbilityMod2(ref SecondaryAllowed,defender, attackType, WholeTeam , OpposingWholeTeam ,TeamBaseValues, EnemyBaseValues);

        SecondaryEffects(ref SecondaryAllowed, defender, attackType);
        }
        public static void AbilityMod(CreatureLibrary Attacker, CreatureLibrary Defender, List<CreatureLibrary> Team, List<CreatureLibrary> EnemyTeam, List<CreatureLibrary>TeamBaseValues, List<CreatureLibrary>EnemyBaseValues ,string MoveType, string AstorPhys, string TargetType,ref double dmgMod,ref double dmgMod2,double basepower)
        {
            OffensiveAbilities abiltiyChecker = new OffensiveAbilities(Attacker,Defender,Team,EnemyTeam,TeamBaseValues,EnemyBaseValues,MoveType,AstorPhys,TargetType,ref dmgMod, ref dmgMod2, basepower);        
        }
        public static void DamageCalc(double damagecalc, double damagecalc2, double basepower, CreatureLibrary defender, CreatureLibrary attacker,string attackbase)
        {   
            if(attackbase == "Phys")
            {
                if (defender.faintstatus == "Fainted")
                {
                    Console.WriteLine($"{defender.name} has already fainted!");
                }
                else
                {
                    if ((basepower + attacker.phys) > defender.physdef)
                    {
                        double MoveDamage = (((basepower + attacker.phys) - defender.physdef) * (damagecalc * damagecalc2));
                        defender.health -= MoveDamage;
                        int displaydamage = Convert.ToInt32(MoveDamage);
                        Console.WriteLine($"Does {displaydamage} damage!");
                    }
                    if ((basepower + attacker.phys) < defender.physdef)
                    {
                        double MoveDamage = ((defender.physdef - (basepower + attacker.phys)) * (damagecalc * damagecalc2));
                        int displaydamage = Convert.ToInt32(MoveDamage);
                        defender.health -= MoveDamage;
                        if (displaydamage != 0)
                        {
                            Console.WriteLine($"Does {displaydamage} damage!");
                        }
                    }
                    if ((basepower + attacker.phys) == defender.phys)
                    {
                        defender.health -= 1;
                        Console.WriteLine($"Evenly matched");
                    }
                }
            }
            if (attackbase == "Astral")
            {
                if (defender.faintstatus == "Fainted")
                {
                    Console.WriteLine($"{defender.name} has already fainted!");
                }
                else
                if ((basepower + attacker.astral) > defender.astraldef)
                {
                    double MoveDamage = (((basepower + attacker.astral) - defender.astraldef) * (damagecalc * damagecalc2));
                    int displaydamage = Convert.ToInt32(MoveDamage);
                    defender.health -= MoveDamage;
                    if (displaydamage != 0)
                    {
                        Console.WriteLine($"Does {displaydamage} damage!");
                    }
                }
                if ((basepower + attacker.astral) < defender.astraldef)
                {
                    double MoveDamage = ((defender.astraldef - (basepower + attacker.astral)) * (damagecalc * damagecalc2));
                    int displaydamage = Convert.ToInt32(MoveDamage); 
                    defender.health -= MoveDamage;
                    Console.WriteLine($"Does {displaydamage} damage!");
                }
                if ((basepower + attacker.astral) == defender.astraldef)
                {
                    defender.health -= 1;
                    Console.WriteLine($"Evenly matched");
                }
            }
            if (defender.faintstatus == "Fainted")
            {
            }
            else
            {
                if ((damagecalc * damagecalc2) == 0)
                {
                    Console.WriteLine($"Doesnt effect {defender.name}");
                }
                if (defender.health <= 0)
                {
                    defender.faintstatus = "Fainted";
                    Console.WriteLine($"{defender.name} fainted!");
                }
            }
        }
        public static void AbilityMod2(ref bool secondaryAllow,CreatureLibrary defender, string MoveType, List<CreatureLibrary> Team , List<CreatureLibrary> EnemyTeam , List<CreatureLibrary> TeamValues, List<CreatureLibrary> EnemyValues)
        {
            EffectAbilities abilityIndexEffects = new EffectAbilities(ref secondaryAllow, defender, MoveType, Team , EnemyTeam , TeamValues, EnemyValues);
        }
        public static void SecondaryEffects(ref bool SecondaryAllowed, CreatureLibrary Defender, string MoveType)
        {           
            SecondaryEffects secondary = new SecondaryEffects(Defender,ref SecondaryAllowed, MoveType);
        }
       
    }
}
