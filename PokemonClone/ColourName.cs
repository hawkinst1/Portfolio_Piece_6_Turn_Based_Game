using System;
using System.Collections.Generic;
using System.Text;

namespace Wisps
{
    abstract class ColourName
    {
        public ColourName()
        { }
        private protected abstract CreatureLibrary AtkColourNaming(CreatureLibrary attacker);
        private protected abstract CreatureLibrary DefColourNaming(CreatureLibrary defender);
        private protected abstract CreatureLibrary StatusColouring(CreatureLibrary StatusHaver);
        private protected abstract CreatureLibrary FieldColouring(CreatureLibrary Fieldstatus);
        private protected abstract CreatureLibrary SkyColouring(CreatureLibrary skystatus);
        public CreatureLibrary AtkColournaming(CreatureLibrary attacker)
        {
            return AtkColourNaming(attacker);
        }
        public CreatureLibrary DefColournaming(CreatureLibrary defender)
        {
          return DefColourNaming(defender);
        }
        public CreatureLibrary Statuscolouring(CreatureLibrary StatusHaver)
        {
            return StatusColouring(StatusHaver);
        }
        public CreatureLibrary fieldColouring(CreatureLibrary Fieldstatus)
        {
            return FieldColouring(Fieldstatus);
        }
        public CreatureLibrary skyfieldcolouring(CreatureLibrary skystatus)
        {
            return SkyColouring(skystatus);
        }
    }
    class colourcheck : ColourName
    {
        private protected override CreatureLibrary AtkColourNaming(CreatureLibrary attacker)
        {
            if(attacker.teamStatus == "Player")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                return attacker;
            }
            if (attacker.teamStatus == "CPU")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return attacker;
            }
            return attacker;
        }
        private protected override CreatureLibrary DefColourNaming(CreatureLibrary defender)
        {
            if (defender.teamStatus == "Player")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                return defender;
            }
            if (defender.teamStatus == "CPU")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return defender;
            }
            return defender;
        }
        private protected override CreatureLibrary StatusColouring(CreatureLibrary StatusHaver) 
        {
            switch(StatusHaver.healthstatus)
            {
                case ("Corroded"):
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        return StatusHaver;
                    }
                    break;
                case ("Reactive"):
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        return StatusHaver;
                    }
                    break;
                case ("Stuttered"):
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        return StatusHaver;
                    }
                    break;
                case ("Shocked"):
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        return StatusHaver;
                    }
                    break;
            }
            return StatusHaver;
        }
        private protected override CreatureLibrary FieldColouring(CreatureLibrary Fieldstatus)
        {
            switch(Fieldstatus.fieldStatus)
            {
                case ("Normal"):
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        return Fieldstatus;
                    }
                    break;

                case ("Damp"):
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        return Fieldstatus;
                    }
                    break;

                case ("Blazing Fields"):
                    {
                        if (Fieldstatus.fieldStatusCount == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            return Fieldstatus;
                        }
                        if (Fieldstatus.fieldStatusCount == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            return Fieldstatus;
                        }
                        if (Fieldstatus.fieldStatusCount == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            return Fieldstatus;
                        }
                    }
                    break;
            }                      
            return Fieldstatus;
        }
        private protected override CreatureLibrary SkyColouring(CreatureLibrary skyfield)
        {
            switch (skyfield.skyFieldStatus)
            {
                case ("Normal"):
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        return skyfield;
                    }
                    break;
                case ("Soothing Rain"):
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        return skyfield;
                    }
                    break;
            }
            return skyfield;
        }
    }
}
