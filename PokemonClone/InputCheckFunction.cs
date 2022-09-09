using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Wisps
{
    class InputCheckFunction
    {
        public bool check(string input, int marker)
        {
            bool CanProgress = false;
            switch (marker)
            {
                case (1): // View menu options
                    if (input == "Yes" || input == "yes" || input == "See Menu" || input == "see menu" || input == "y" || input == "Y"
                        || input == "No" || input == "no" || input == "N" || input == "n" || input == "NO" || input == "nO")
                    {
                        CanProgress = true;
                    }
                    return CanProgress;

                case (2): // ignore menu options
                    if (input == "No" || input == "no" || input == "N" || input == "n" || input == "NO" || input == "nO")
                    {
                        return CanProgress;
                    }
                    if (input == "Yes" || input == "yes" || input == "See Menu" || input == "see menu" || input == "y" || input == "Y")
                    {
                        CanProgress = true;
                        return CanProgress;
                    }
                    break;
            }

            return CanProgress;
        }
        public int checker(string input2)
        {
            int thechoice = 13;

            string input = input2.ToUpper();

            if (input == "FULLVALUE" || input == "FULL VALUE" || input == "FULLVALUES" || input == "FULL VALUES")
            {
                thechoice = 1;
                return thechoice;
            }
            if (input == "HP" || input == "HEALTH")
            {
                thechoice = 2;
                return thechoice;
            }
            if (input == "MP" || input == "MAGICPOWER")
            {
                thechoice = 3;
                return thechoice;
            }
            if (input == "PHYS" || input == "PHYSICAL")
            {
                thechoice = 4;
                return thechoice;
            }
            if (input == "PHYSDEF" || input == "PHYSICALDEF" || input == "PHYSICAL DEF" || input == "PHYSICALDEFENCE" || input == "PHYSICAL DEFENCE")
            {
                thechoice = 5;
                return thechoice;
            }
            if (input == "ASTRAL" || input == "AST")
            {
                thechoice = 6;
                return thechoice;
            }
            if (input == "ASTDEF" || input == "AST DEF" || input == "ASTRALDEF" || input == "ASTRAL DEF" || input == "ASTRALDEFENCE" || input == "ASTRAL DEFENCE")
            {
                thechoice = 7;
                return thechoice;
            }
            if (input == "SPEED" || input == "SPD")
            {
                thechoice = 8;
                return thechoice;
            }
            if (input == "TYPE")
            {
                thechoice = 9;
                return thechoice;
            }
            if (input == "CLASS")
            {
                thechoice = 10;
                return thechoice;
            }
            if (input == "DESCRIPTION")
            {
                thechoice = 11;
                return thechoice;
            }
            if (input == "ABILITY")
            {
                thechoice = 12;
                return thechoice;
            }

            return thechoice;
        }
        public int Cchecker(string input3,int counter, List<CreatureLibrary> monsterlist)
        {
            int creatureNumber = (counter+1);
            string input = input3.ToUpper(); 
            
            for (int a = 0; a < counter; a++)
            {
                if (input == monsterlist[a].name.ToUpper())
                {
                    creatureNumber = a;
                    return creatureNumber;
                }              
            }           
            return creatureNumber;
        }
        public bool TargetChecker(string Target, List<CreatureLibrary> team, List<CreatureLibrary> opposingTeam)
        {
            List<CreatureLibrary> CombinedTeam = new List<CreatureLibrary>();
         
            for (int b = 0; b < team.Count; b++ )
            {
                CombinedTeam.Add(team[b]);
            }
            for (int c = 0; c < opposingTeam.Count; c++)
            {
                CombinedTeam.Add(opposingTeam[c]);
            }


            bool TargetAccept = true;
            {
                string target2 = Target.ToUpper();

                for (int a = 0; a < CombinedTeam.Count; a++)
                {
                    if (target2 == CombinedTeam[a].name.ToUpper() && CombinedTeam[a].faintstatus != "Fainted")
                    {
                        TargetAccept = false;
                    }
                }

            }
            return TargetAccept;
        }
        public bool repeatPrevention(int numberchosen, int loopnumber, List<int> monsterChoiceStorage, List<int> numberchoice)  // prevents the player from inputing repeats of a monster.
        {
            bool canProgress = true;
        
            numberchoice.Add(numberchosen);

            if(loopnumber == 0)
            { 
                monsterChoiceStorage.Add(numberchosen);
            }           
            else
            {              
                    if(monsterChoiceStorage.Contains(numberchoice[loopnumber]))
                    {
                    Console.WriteLine("Monster already on team, please choose another.");
                    Console.ReadLine();                  
                    canProgress = false;               
                    return canProgress;
                    }
                monsterChoiceStorage.Add(numberchosen);               
                return canProgress;
            }
            return canProgress;
        }   
        public bool HealorHurt(string answer)
        {
            bool progress = false;
            string bigAnswer = answer.ToUpper();

            if(bigAnswer == "HURT" || bigAnswer == "HEAL")
            {
                progress = true;
            }

            return progress;
        }
    }
}
