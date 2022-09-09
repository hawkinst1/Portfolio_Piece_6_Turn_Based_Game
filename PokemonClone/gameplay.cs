using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Wisps
{
    class gameplay
    {
        public gameplay(List<CreatureLibrary> teamchoice, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> TeamChoiceBaseValues, List<CreatureLibrary> CPUChoiceBaseValues)
        {
            Console.Clear();
            GameLoop(teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues);
        }
        public void GameLoop(List<CreatureLibrary> teamchoice, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> TeamChoiceBaseValues, List<CreatureLibrary> CPUChoiceBaseValues)
        {
            List<CreatureLibrary> speedfunction = new List<CreatureLibrary>();
            bool ContinueChecker = true;
            int turncounter = 0;
            do
            {
                speedfunction.Clear();

                if (teamchoice[0].faintstatus != "Fainted")
                {
                    speedfunction.Add(teamchoice[0]);
                }
                if (teamchoice[1].faintstatus != "Fainted")
                {
                    speedfunction.Add(teamchoice[1]);
                }
                if (teamchoice[2].faintstatus != "Fainted")
                {
                    speedfunction.Add(teamchoice[2]);
                }
                if (cpuchoice[0].faintstatus != "Fainted")
                {
                    speedfunction.Add(cpuchoice[0]);
                }
                if (cpuchoice[1].faintstatus != "Fainted")
                {
                    speedfunction.Add(cpuchoice[1]);
                }
                if (cpuchoice[2].faintstatus != "Fainted")
                {
                    speedfunction.Add(cpuchoice[2]);
                }

                List<CreatureLibrary> speedDetermine = speedfunction.OrderByDescending(speedfunction => speedfunction.speed).ToList(); // fastest to slowest creatures

                //////////////////////////////////////////////////////////////////////////////////////               
                MoveUsed(turncounter, speedDetermine, teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues);
                /////////////////////////////////////////////////////////////////////////////////////

                turncounter++;

            } while (ContinueCheck(teamchoice, cpuchoice, ContinueChecker)); // team health checker

            Console.WriteLine($"Game Finished");
        }
        public void MiniHealthDisplay(int counter, List<CreatureLibrary> teamchoice, List<CreatureLibrary> cpuchoice)
        {
            int[] healthValues = new int[teamchoice.Count];
            int[] cpuhealthValues = new int[cpuchoice.Count];

            Console.WriteLine($"============\n\nPlayer Team\n============");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int a = 0; a < teamchoice.Count; a++)
            {
                healthValues[a] = Convert.ToInt32(teamchoice[a].health);
                if (teamchoice[a].health <= 0)
                {
                    teamchoice[a].health = 0;
                    healthValues[a] = Convert.ToInt32(teamchoice[a].health);
                }
                Console.WriteLine($"{teamchoice[a].name,-10}{Convert.ToInt32(healthValues[a])}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"\nCPU Team\n=============");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int a = 0; a < cpuchoice.Count; a++)
            {
                cpuhealthValues[a] = Convert.ToInt32(cpuchoice[a].health);
                if (cpuchoice[a].health <= 0)
                {
                    cpuchoice[a].health = 0;
                    cpuhealthValues[a] = Convert.ToInt32(cpuchoice[a].health);
                }
                Console.WriteLine($"{cpuchoice[a].name,-10}{Convert.ToInt32(cpuhealthValues[a])}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string HealthbarDisplay(List<CreatureLibrary> teamchoice,  List<CreatureLibrary> teamchoicebase,List<CreatureLibrary> cpuchoice, List<CreatureLibrary> cpuchoicebase)
        {
            int width = Console.WindowWidth;
            double nameoffset = 0;
            StringBuilder healthbar1 = new StringBuilder();

            List<CreatureLibrary> CurrentTeam = new List<CreatureLibrary>();
            
            double P1damg = teamchoicebase[0].health - teamchoice[0].health;
            double P2damg = teamchoicebase[1].health - teamchoice[1].health;
            double P3damg = teamchoicebase[2].health - teamchoice[2].health;

            List<double> DamageTeam = new List<double>(); 

            DamageTeam.Add(P1damg); DamageTeam.Add(P2damg); DamageTeam.Add(P3damg);
                      
            for (int LifeCheck = 0; LifeCheck < teamchoice.Count; LifeCheck++)
            {
                if (teamchoice[LifeCheck].faintstatus != "Fainted")
                {
                    CurrentTeam.Add(teamchoice[LifeCheck]);
                }
            }
          
            for (int PlayerHealth = 0; PlayerHealth < CurrentTeam.Count; PlayerHealth++)
            {
                healthbar1.Append(CurrentTeam[PlayerHealth].name + ": ");

                for (int a = 0; a < (CurrentTeam[PlayerHealth].health / 10); a++)
                {
                    healthbar1.Append("█");
                }
                for (int a = 0; a < DamageTeam[PlayerHealth] / 10; a++)
                {
                    healthbar1.Append("▒");
                }

                nameoffset = 1;

                for (int a = 0; a < nameoffset; a++) // distance between p1 health and cpu name
                {
                    healthbar1.Append("| ");
                }
            }
            healthbar1.Append("\n");
            CurrentTeam.Clear();
            DamageTeam.Clear();
            return healthbar1.ToString();
        }
        public static string MPDisplay(List<CreatureLibrary> teamchoice, List<CreatureLibrary> teamchoicebase, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> cpuchoicebase)
        {
            int width = Console.WindowWidth;
            double nameoffset = 0;
            StringBuilder mpbar1 = new StringBuilder();

            List<CreatureLibrary> CurrentTeam = new List<CreatureLibrary>();

            double P1damg = teamchoicebase[0].mp - teamchoice[0].mp;
            double P2damg = teamchoicebase[1].mp - teamchoice[1].mp;
            double P3damg = teamchoicebase[2].mp - teamchoice[2].mp;

            List<double> DamageTeam = new List<double>();

            DamageTeam.Add(P1damg); DamageTeam.Add(P2damg); DamageTeam.Add(P3damg);

            for (int LifeCheck = 0; LifeCheck < teamchoice.Count; LifeCheck++)
            {
                if (teamchoice[LifeCheck].faintstatus != "Fainted")
                {
                    CurrentTeam.Add(teamchoice[LifeCheck]);
                }
            }

            for (int PlayerHealth = 0; PlayerHealth < CurrentTeam.Count; PlayerHealth++)
            {
                mpbar1.Append(CurrentTeam[PlayerHealth].name + ": ");

                for (int a = 0; a < (CurrentTeam[PlayerHealth].mp / 10); a++)
                {
                    mpbar1.Append("█");
                }
                for (int a = 0; a < DamageTeam[PlayerHealth] / 10; a++)
                {
                    mpbar1.Append("▒");
                }

                nameoffset = 1;

                for (int a = 0; a < nameoffset; a++) // distance between p1 health and cpu name
                {
                    mpbar1.Append("| ");
                }
            }
            mpbar1.Append("\n");
            CurrentTeam.Clear();
            DamageTeam.Clear();
            return mpbar1.ToString();
        }
        public static string CPUmpDisplay(List<CreatureLibrary> teamchoice, List<CreatureLibrary> teamchoicebase, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> cpuchoicebase)
        {
            int width = Console.WindowWidth;
            double nameoffset = 0;
            StringBuilder cpuBarMP = new StringBuilder();

            List<CreatureLibrary> CPUteam = new List<CreatureLibrary>();

            double C1MpGone = cpuchoicebase[0].mp - cpuchoice[0].mp;
            double C2MpGone = cpuchoicebase[1].mp - cpuchoice[1].mp;
            double C3MgGone = cpuchoicebase[2].mp - cpuchoice[2].mp;

            List<double> DamageTeam = new List<double>();

            DamageTeam.Add(C1MpGone); DamageTeam.Add(C2MpGone); DamageTeam.Add(C3MgGone);

            for (int LifeCheck = 0; LifeCheck < cpuchoice.Count; LifeCheck++)
            {
                if (cpuchoice[LifeCheck].faintstatus != "Fainted")
                {
                    CPUteam.Add(cpuchoice[LifeCheck]);
                }
            }

            for (int PlayerHealth = 0; PlayerHealth < CPUteam.Count; PlayerHealth++)
            {
                cpuBarMP.Append(CPUteam[PlayerHealth].name + ": ");

                for (int a = 0; a < (CPUteam[PlayerHealth].mp / 10); a++)
                {
                    cpuBarMP.Append("█");
                }
                for (int a = 0; a < DamageTeam[PlayerHealth] / 10; a++)
                {
                    cpuBarMP.Append("▒");
                }

                nameoffset = 1;

                for (int a = 0; a < nameoffset; a++) // distance between p1 health and cpu name
                {
                    cpuBarMP.Append("| ");
                }
            }
            cpuBarMP.Append("\n");
            CPUteam.Clear();
            DamageTeam.Clear();
            return cpuBarMP.ToString();
        }
        public static string CPUHealthbarDisplay(List<CreatureLibrary> teamchoice, List<CreatureLibrary> teamchoicebase, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> cpuchoicebase)
        {
            int width = Console.WindowWidth;
            double nameoffset = 0;
            StringBuilder healthbar1 = new StringBuilder();

            List<CreatureLibrary> CPUteam = new List<CreatureLibrary>();

            double C1damg = cpuchoicebase[0].health - cpuchoice[0].health;
            double C2damg = cpuchoicebase[1].health - cpuchoice[1].health;
            double C3damg = cpuchoicebase[2].health - cpuchoice[2].health;
            
            List<double> DamageTeam = new List<double>();

            DamageTeam.Add(C1damg); DamageTeam.Add(C2damg); DamageTeam.Add(C3damg);

            for (int LifeCheck = 0; LifeCheck < cpuchoice.Count; LifeCheck++)
            {
                if (cpuchoice[LifeCheck].faintstatus != "Fainted")
                {
                    CPUteam.Add(cpuchoice[LifeCheck]);
                }
            }
            for (int PlayerHealth = 0; PlayerHealth < CPUteam.Count; PlayerHealth++)
            {
                healthbar1.Append(CPUteam[PlayerHealth].name + ": ");

                for (int a = 0; a < (CPUteam[PlayerHealth].health / 10); a++)
                {
                    healthbar1.Append("█");
                }
                for (int a = 0; a < DamageTeam[PlayerHealth] / 10; a++)
                {
                    healthbar1.Append("▒");
                }

                nameoffset = 1;

                for (int a = 0; a < nameoffset; a++) // distance between p1 health and cpu name
                {
                    healthbar1.Append("| ");
                }
            }
            healthbar1.Append("\n");
            CPUteam.Clear();
            DamageTeam.Clear();
            return healthbar1.ToString();
        }
        public bool ContinueCheck(List<CreatureLibrary> teamchoice, List<CreatureLibrary> cpuchoice, bool cont)
        {
            bool playerteam = true;
            bool cputeam = true;

            if (teamchoice[0].health <= 0 && teamchoice[1].health <= 0 && teamchoice[2].health <= 0)
            {
                playerteam = false;
            }
            if (cpuchoice[0].health <= 0 && cpuchoice[1].health <= 0 && cpuchoice[2].health <= 0)
            {
                cputeam = false;
            }
            if (playerteam == false || cputeam == false)
            {
                cont = false;
            }
            return cont;
        }
        /////////////////////////////////////////////////////////////
        ///MOVEUSED FUNCTION
        /////////////////////////////////////////////////////////////     
        public void MoveUsed(int turncounter, List<CreatureLibrary> TurnOrder, List<CreatureLibrary> teamchoice, List<CreatureLibrary> cpuchoice, List<CreatureLibrary> TeamChoiceBaseValues, List<CreatureLibrary> CPUChoiceBaseValues)
        {
            List<int> MoveStorage = new List<int>();
            int moveSelection = 0;
            List<string> TargetStorage = new List<string>();
            string targetSelection = "";
          
            List<CreatureLibrary> TheTargetList = new List<CreatureLibrary>();
            
            string UI = HealthbarDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);
            string cpuUI = CPUHealthbarDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);
            string Mp = MPDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);
            string CPUMp = CPUmpDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);

            for (int turn = 0; turn < TurnOrder.Count; turn++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Player Team\n{UI}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{Mp}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CPU Team\n{cpuUI}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{CPUMp}");
                Console.ForegroundColor = ConsoleColor.White;
                // MiniHealthDisplay(turn, teamchoice, cpuchoice); // display the health at all times.

                switch (TurnOrder[turn].teamStatus) // move selection
                {
                    case ("Player"):
                        {
                            MonsterPlayerMoveSelection(turn, turncounter , TurnOrder, teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues, moveSelection, MoveStorage);
                            PlayerTarget(turn,MoveStorage[turn],TurnOrder, teamchoice, cpuchoice, targetSelection, TargetStorage, TheTargetList);
                        }
                        break;
                    case ("CPU"):
                        {
                            MonsterCPUMoveSelection(turn,turncounter, TurnOrder, teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues, moveSelection, MoveStorage);
                            CPUTarget(turn, moveSelection ,TurnOrder, teamchoice,cpuchoice,TargetStorage, TheTargetList);
                        }
                        break;
                }
                Console.ReadLine();                
                Console.Clear();
            }
            for(int turn = 0; turn < TurnOrder.Count; turn++)
            {
                UI = HealthbarDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);
                cpuUI = CPUHealthbarDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);
                Mp = MPDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);
                CPUMp = CPUmpDisplay(teamchoice, TeamChoiceBaseValues, cpuchoice, CPUChoiceBaseValues);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Player Team\n{UI}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{Mp}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CPU Team\n{cpuUI}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{CPUMp}");
                Console.ForegroundColor = ConsoleColor.White;
                switch (TurnOrder[turn].teamStatus) // Move Action
                {
                    case ("Player"):
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Turn {turn+1}/{TurnOrder.Count}");
                            Console.ForegroundColor = ConsoleColor.White;
                            if (TurnOrder[turn].faintstatus != "Fainted")
                            {
                                MonsterPlayerMoves(turn, turncounter, TurnOrder, teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues, MoveStorage, TargetStorage, TheTargetList);
                            }
                            else
                            {
                                Console.WriteLine($"{TurnOrder[turn].name} has fainted");
                            }
                        }
                        break;
                    case ("CPU"):
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Turn {turn+1}/{TurnOrder.Count}");
                            Console.ForegroundColor = ConsoleColor.White;
                            if (TurnOrder[turn].faintstatus != "Fainted")
                            {
                                MonsterCPUMoves(turn, turncounter, TurnOrder, teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues, MoveStorage, TargetStorage, TheTargetList);
                            }
                            else
                            {
                                Console.WriteLine($"{TurnOrder[turn].name} has fainted");
                            }
                        }
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
            EndofTurnView(TurnOrder, teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues);
            fieldstatus(TurnOrder, teamchoice, cpuchoice, TeamChoiceBaseValues, CPUChoiceBaseValues);
        }
        public void MonsterPlayerMoveSelection(int turncount, int turncounter , List<CreatureLibrary> MonsterTurn, List<CreatureLibrary> PlayerTeam, List<CreatureLibrary> CPUTeam, List<CreatureLibrary> PlayerRefValues, List<CreatureLibrary> CPURefValues, int moveSelection, List<int> Movestorage)
        {
            Console.WriteLine($"=====================\n  Turn {turncounter + 1}| Move {turncount + 1}/{MonsterTurn.Count}");
            MonsterTurn[turncount].displayMoves(ref moveSelection,CPURefValues,CPUTeam);
            Movestorage.Add(moveSelection);
        }
        public void MonsterCPUMoveSelection(int turncount, int turncounter, List<CreatureLibrary> MonsterTurn, List<CreatureLibrary> PlayerTeam, List<CreatureLibrary> CPUTeam, List<CreatureLibrary> PlayerRefValues, List<CreatureLibrary> CPURefValues, int moveSelection, List<int> Movestorage)
        {
            Console.WriteLine($"=====================\n  Turn {turncounter + 1}| Move {turncount + 1}/{MonsterTurn.Count}");
            MonsterTurn[turncount].displayMoves(ref moveSelection, CPURefValues, CPUTeam);
            Movestorage.Add(moveSelection);
        }
        public void PlayerTarget(int turn,int moveSelected, List<CreatureLibrary> MonsterTurn, List<CreatureLibrary> PlayerTeam, List<CreatureLibrary> CPUteam, string targetname, List<string> targetList, List<CreatureLibrary> TheTargetList)
        {
            string move = "";
            MonsterTurn[turn].target(MonsterTurn[turn], ref TheTargetList, PlayerTeam, CPUteam, moveSelected,move);                      
        }
        public void CPUTarget(int turn, int moveSelected, List<CreatureLibrary> MonsterTurn, List<CreatureLibrary> PlayerTeam, List<CreatureLibrary> CPUteam, List<string> targetList, List<CreatureLibrary> TheTargetList)
        {
            string move = "";
            MonsterTurn[turn].target(MonsterTurn[turn], ref TheTargetList, CPUteam, PlayerTeam, moveSelected,move);                                   
        }
        public void MonsterPlayerMoves(int turncount, int turncounter, List<CreatureLibrary> MonsterTurn, List<CreatureLibrary> PlayerTeam, List<CreatureLibrary> CPUTeam, List<CreatureLibrary> PlayerRefValues, List<CreatureLibrary> CPURefValues, List<int> Movestorage, List<string> TargetStorage, List<CreatureLibrary> TheTargetList)
        {
            MonsterTurn[turncount].movesetchoice(Movestorage[turncount]).Moveuse( TheTargetList[turncount], MonsterTurn[turncount], PlayerTeam, CPUTeam, PlayerRefValues, CPURefValues);
        }
        public void MonsterCPUMoves(int turncount, int turncounter, List<CreatureLibrary> MonsterTurn, List<CreatureLibrary> PlayerTeam, List<CreatureLibrary> CPUTeam, List<CreatureLibrary> PlayerRefValues, List<CreatureLibrary> CPURefValues, List<int> Movestorage, List<string> TargetStorage, List<CreatureLibrary> TheTargetList)
        {
            MonsterTurn[turncount].movesetchoice(Movestorage[turncount]).Moveuse(TheTargetList[turncount], MonsterTurn[turncount], PlayerTeam, CPUTeam, PlayerRefValues, CPURefValues);
        } 
        public void EndofTurnView(List<CreatureLibrary> TurnOrder, List<CreatureLibrary> Teamchoice, List<CreatureLibrary> CPUchoice, List<CreatureLibrary> TeamchoiceBV, List<CreatureLibrary> CPUchoiceBV)
        {
            Console.WriteLine($"================= End of Turn Effects ============================");
            EndofTurnEffects endofTurnEffects = new EndofTurnEffects(TurnOrder, Teamchoice, CPUchoice, TeamchoiceBV, CPUchoiceBV);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n================= End of Turn Effects ============================\n");
        }
        public void fieldstatus(List<CreatureLibrary> TurnOrder, List<CreatureLibrary> Teamchoice, List<CreatureLibrary> CPUchoice, List<CreatureLibrary> TeamchoiceBV, List<CreatureLibrary> CPUchoiceBV)
        {
            colourcheck colouring = new colourcheck();
            Console.WriteLine($"=========================================================== Field and Sky ====================================================");
            Console.Write($"Player Field: {colouring.fieldColouring(Teamchoice[0]).fieldStatus}    ||    "); Console.Write($"CPU Field: {colouring.fieldColouring(CPUchoice[0]).fieldStatus}        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\t\t\t\tPlayer Sky: {colouring.skyfieldcolouring(Teamchoice[0]).skyFieldStatus}    ||    "); Console.Write($"CPU Sky: {colouring.skyfieldcolouring(CPUchoice[0]).skyFieldStatus}        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n=========================================================== Field and Sky ====================================================\n");
        }
    }
}