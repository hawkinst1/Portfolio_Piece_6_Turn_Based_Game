using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
// (name, id, health, mp, phys, physdef, astral, astraldef, speed, typea, typeb, class_, faintstatus, teamStatus, healthstatus, conditionTurnsRemaining, fieldStatus, wholeFieldStatus, fieldStatusCount, wholeFieldCount);
namespace Wisps
{
    public static class InstanceCounter<T>
    {
        public static int _counter;
        public static int Count { get { return _counter; } }

        public static void Increase()
        {
            _counter++;
        }
        public static void Decrease()
        {
            _counter--;
        }
    }
    abstract class CreatureLibrary
    {

        private string Name;
        private int ID;
        private double Health;
        private double Mp;
        private double Phys;
        private double PhysDef;
        private double Astral;
        private double AstralDef;
        private double Speed;
        private string TypeA;
        private string TypeB;
        private string Class_; // role description
        private string FaintStatus; // has fainted or not
        private string TeamStatus; // Player Team or CPU team
        private string HealthStatus; // Any conditions such as burning or poison on a single target
        private int ConditionTurnsRemaining; // How many turns remain unless indefinite on a single target
        private string FieldStatus; // Team only field.
        private string SkyFieldStatus; // sky battlefield
        private int FieldStatusCount; // Turns of effect the field.
        private int SkyFieldCount; // Turns of the sky field effects.
        private string Modifications; // Mods to stats brought on by temporary condition changes.
        private int ModificationCount; // turns left on the temp changes.
        private string Ability;
        protected int x;

        public CreatureLibrary
            (
            string name,
              int id,
              double health,
              double mp,
              double phys,
              double physdef,
              double astral,
              double astraldef,
              double speed,
              string typeA,
              string typeB,
              string class_,
              string faintstatus,
              string teamStatus,
              string healthstatus,
              int conditionTurnsRemaining,
              string fieldStatus,
              string skyFieldStatus,
              int fieldStatusCount,
              int skyFieldCount,
              string mods,
              int modcount,
              string ability
            )
        {
            Name = name;
            ID = id;
            Health = health;
            Mp = mp;
            Phys = phys;
            PhysDef = physdef;
            Astral = astral;
            AstralDef = astraldef;
            Speed = speed;
            TypeA = typeA;
            TypeB = typeB;
            Class_ = class_;
            FaintStatus = faintstatus;
            TeamStatus = teamStatus;
            HealthStatus = healthstatus;
            ConditionTurnsRemaining = conditionTurnsRemaining;
            FieldStatus = fieldStatus;
            SkyFieldStatus = skyFieldStatus;
            FieldStatusCount = fieldStatusCount;
            SkyFieldCount = skyFieldCount;
            Modifications = mods;
            ModificationCount = modcount;
            Ability = ability;
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public double health
        {
            get { return Health; }
            set { Health = value; }
        }
        public double mp
        {
            get { return Mp; }
            set { Mp = value; }
        }
        public double phys
        {
            get { return Phys; }
            set { Phys = value; }
        }
        public double physdef
        {
            get { return PhysDef; }
            set { PhysDef = value; }
        }
        public double astral
        {
            get { return Astral; }
            set { Astral = value; }
        }
        public double astraldef
        {
            get { return AstralDef; }
            set { AstralDef = value; }
        }
        public double speed
        {
            get { return Speed; }
            set { Speed = value; }
        }
        public string typea
        {
            get { return TypeA; }
            set { TypeA = value; }
        }
        public string typeb
        {
            get { return TypeB; }
            set { TypeB = value; }
        }
        public string class_
        {
            get { return Class_; }
            set { class_ = value; }
        }
        public string faintstatus
        {
            get { return FaintStatus; }
            set { FaintStatus = value; }
        }
        public string teamStatus
        {
            get { return TeamStatus; }
            set { TeamStatus = value; }
        }
        public string healthstatus
        {
            get { return HealthStatus; }
            set { HealthStatus = value; }
        }
        public int conditionTurnsRemaining
        {
            get { return ConditionTurnsRemaining; }
            set { ConditionTurnsRemaining = value; }
        }
        public string fieldStatus
        {
            get { return FieldStatus; }
            set { FieldStatus = value; }
        }
        public string skyFieldStatus
        {
            get { return SkyFieldStatus; }
            set { SkyFieldStatus = value; }
        }
        public int fieldStatusCount
        {
            get { return FieldStatusCount; }
            set { FieldStatusCount = value; }
        }
        public int skyFieldCount
        {
            get { return SkyFieldCount; }
            set { SkyFieldCount = value; }
        }
        public string mods
        {
            get { return Modifications; }
            set { Modifications = value; }
        }
        public int modcount
        {
            get { return ModificationCount; }
            set { ModificationCount = value; }
        }
        public string ability
        {
            get { return Ability; }
            set { Ability = value; }
        }

        private protected abstract void DescriptionText();
        private protected abstract void printvalues();
        private protected abstract void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam);
        private protected abstract ListofMoves MoveSetChoice(int movechosen);
        private protected abstract void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType);
        private protected abstract void CreatureAbility();
        private protected abstract void MovesAvailable();

        public void DTacces()
        {
            DescriptionText();
        }
        public void PrintValueAcess()
        {
            printvalues();
        }
        public void displayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {
            DisplayMoves(ref movechoice, CPURefValues, CPUTeam);
        }
        public ListofMoves movesetchoice(int movechosen)
        {
            return MoveSetChoice(movechosen);
        }
        public void target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {
            Target(User, ref targetChoice, team, opposingteam, moveSelected, MoveType);
        }
        public void creatureAbility()
        {
            CreatureAbility();
        }
        public void movesavailable()
        {
            MovesAvailable();
        }
    }
    class Skell : CreatureLibrary
    {
        public Skell() : base("Skell", 1, 250, 150, 100, 90, 280, 198, 222, "Ice", "Acid", "Astral Damage", "Active", "Player", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Crystalline Expansion")
        {
            InstanceCounter<CreatureLibrary>.Increase();           
        }
        private protected override void DescriptionText()
        {
            Console.WriteLine($"The temperature drops steadily as a silver-furred fox drops down, the ground beneath its maw eroding where saliva touches");
        }
        private protected override void printvalues()
        {
            Console.WriteLine($"{name}\nID: {id}\nHp: {health}\nPhys: {phys}\n" +
                $"Astral: {astral}\nPhysical Defence: {physdef}\nAstral Defence {astraldef}" +
                $"\nSpeed: {speed}\nTypeA: {typea}\nTypeB: {typeb}");
        }
        private protected override void MovesAvailable()
        {
            SoothingRain soothing = new SoothingRain();
            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Fumes fumes = new Fumes();
            Drowned drowned = new Drowned();

            List<ListofMoves> DisplayMoveList = new List<ListofMoves>();
            DisplayMoveList.Add(soothing); DisplayMoveList.Add(rayofFrost); DisplayMoveList.Add(corrosiveGeyser); DisplayMoveList.Add(fumes); DisplayMoveList.Add(drowned);

            foreach(var name in DisplayMoveList)
            {
                Console.WriteLine($"{name.name}");
            }

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {
            SoothingRain soothing = new SoothingRain();
            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest);monstermoves.Add(rayofFrost); monstermoves.Add(corrosiveGeyser); monstermoves.Add(soothing);

            List<ListofMoves> MPcostListing = monstermoves.OrderByDescending(monstermoves => monstermoves.MpCost).ToList();
            List<ListofMoves> MpCostLowest = new List<ListofMoves>();
            int noMp = (monstermoves.Count - 1);

            for(; noMp >= 0 ; noMp--)
            {
                MpCostLowest.Add(MPcostListing[noMp]);
            }

            if (mp < MpCostLowest[1].MpCost)
            {
                Console.WriteLine($"{name} has no more MP left and must rest.");
                movechoice = 1;
            }
            else
            {
                int listnumber;
                var moveAsString = "";
                int movechosen;
                do
                {
                    do
                    {
                        listnumber = 0;
                        Console.WriteLine($"Move List | {name}\n====================");
                        Console.WriteLine($"What should {name} do?\n====================");
                        foreach (var movename in monstermoves)
                        {
                            listnumber++;
                            Console.WriteLine($"{listnumber}| {movename.name}");

                        }
                        Console.WriteLine($"====================");
                        do
                        {
                            moveAsString = Console.ReadLine();
                            movechosen = Convert.ToInt32(moveAsString);

                            if (mp < monstermoves[movechosen-1].MpCost)
                            {
                                Console.WriteLine($"Not enough MP!");
                            }
                        } while (mp < monstermoves[movechosen-1].MpCost);

                    } while (!int.TryParse(moveAsString, out movechoice));
                } while (movechoice > listnumber);
            }
        }
        private protected override ListofMoves MoveSetChoice(int movechosen)
        {
            SoothingRain soothing = new SoothingRain();
            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser(); Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
           monstermoves.Add(rest); monstermoves.Add(rayofFrost); monstermoves.Add(corrosiveGeyser);monstermoves.Add(soothing);

            Console.WriteLine($"\n====================");
            return monstermoves[(movechosen - 1)];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {
           List<CreatureLibrary> TargetList = new List<CreatureLibrary>();

            SoothingRain soothing = new SoothingRain();
            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest);monstermoves.Add(rayofFrost); monstermoves.Add(corrosiveGeyser); monstermoves.Add(soothing);

            int listcounter = 1;
            var WhoTarget = "";
            int targetedMon;
            bool IsRedirected = false;
            List<CreatureLibrary> TargetAlter = new List<CreatureLibrary>();

            MoveType = monstermoves[moveSelected-1].attacktype;

            TargetAbilities targetAbilities = new TargetAbilities(User, opposingteam, ref IsRedirected, ref TargetAlter, monstermoves[moveSelected-1]);


            if (IsRedirected == true)
            {
                targetChoice.Add(TargetAlter[0]);
            }

            else
            {
                if (monstermoves[(moveSelected - 1)].target == "Self" || monstermoves[(moveSelected - 1)].target == "Field" || monstermoves[(moveSelected - 1)].target == "Sky")
                {
                    for (int a = 0; a < team.Count; a++)
                    {
                        if (team[a].name == User.name)
                        {
                            targetChoice.Add(User);
                        }
                    }
                }
                else
                {
                    if (monstermoves[(moveSelected - 1)].target == "Triple")
                    {
                        targetChoice.Add(opposingteam[0]);
                    }
                    else
                    {
                        if (monstermoves[(moveSelected - 1)].target == "Single")
                        {
                            for (int a = 0; a < team.Count; a++)
                            {
                                if (team[a].faintstatus != "Fainted")
                                    TargetList.Add(team[a]);
                            }
                            for (int a = 0; a < team.Count; a++)
                            {
                                if (opposingteam[a].faintstatus != "Fainted")
                                    TargetList.Add(opposingteam[a]);
                            }

                            foreach (var monster in TargetList)
                            {
                                if (monster.teamStatus == "Player")
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"{listcounter}: {monster.name}:");
                                }
                                if (monster.teamStatus == "CPU")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{listcounter}: {monster.name}:");
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                listcounter++;
                            }
                        }
                        do
                        {
                            do
                            {
                                Console.Write($"\nTarget (number):");
                                WhoTarget = Console.ReadLine();

                            } while (!int.TryParse(WhoTarget, out targetedMon));
                        } while (targetedMon > TargetList.Count);

                        targetChoice.Add(TargetList[targetedMon - 1]);
                    }
                }
            }
        }
        private protected override void CreatureAbility()
        {
            Console.WriteLine($"Arctice Grace:\n\tIce attacks heal for 25% of total health.\n" +
                $"Crystalline Expansion:\n\tIce attacks deal extra damage to water types.\n" +
                $"Ghost Hunter (s):\n\tDraws in an nullifies ethereal offensive attacks.");            
        }
    }
    class SkellBaseValues : CreatureLibrary
    {
        public SkellBaseValues() : base("Skell", 1, 250, 150, 100, 90, 280, 198, 222, "Ice", "Acid", "Astral Damage", "Active", "Player", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Arctic Grace")
        {
        }
        private protected override void DescriptionText()
        { }
        private protected override void printvalues()
        { }
        private protected override void MovesAvailable()
        {          

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {

        }
        private protected override ListofMoves MoveSetChoice(int a)
        {

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            return monstermoves[0];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {

        }
        private protected override void CreatureAbility()
        {
            Console.WriteLine($"{ability}:\n\tCannot be afflicated with status conditions applied physically.");
        }
    }
    class Skell1 : CreatureLibrary //cpu values
    {
        public Skell1() : base("Skell", 1, 250, 150, 100, 90, 280, 198, 222, "Ice", "Acid", "Astral Damage", "Active", "CPU", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Ghost Hunter")
        {
            InstanceCounter<CreatureLibrary>.Increase();
        }
        private protected override void DescriptionText()
        {
            Console.WriteLine($"The temperature drops steadily as a silver-furred fox drops down, the ground beneath its maw eroding where saliva touches");
        }
        private protected override void printvalues()
        {
            Console.WriteLine($"{name}\nID: {id}\nHp: {health}\nPhys: {phys}\n" +
                $"Astral: {astral}\nPhysical Defence: {physdef}\nAstral Defence {astraldef}" +
                $"\nSpeed: {speed}\nTypeA: {typea}\nTypeB: {typeb}");
        }
        private protected override void MovesAvailable()
        {
            SoothingRain soothing = new SoothingRain();
            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Fumes fumes = new Fumes();
            Drowned drowned = new Drowned();

            List<ListofMoves> DisplayMoveList = new List<ListofMoves>();
            DisplayMoveList.Add(soothing); DisplayMoveList.Add(rayofFrost); DisplayMoveList.Add(corrosiveGeyser); DisplayMoveList.Add(fumes); DisplayMoveList.Add(drowned);

            foreach (var name in DisplayMoveList)
            {
                Console.WriteLine($"{name.name}");
            }

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPUBaseValues, List<CreatureLibrary> CPUTeam)
        {   
            Random rnd = new Random();

            SoothingRain soothing = new SoothingRain();
            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(rayofFrost); monstermoves.Add(corrosiveGeyser); monstermoves.Add(soothing);
            int canRest = 1;
            int restPotential;

            for (int a = 0; a < CPUTeam.Count; a++)
            {
               if(name == CPUTeam[a].name)
               {
                    if(mp == CPUBaseValues[a].mp)
                    {
                        canRest = 2;
                    }

                    if(mp < (CPUBaseValues[a].mp*.66))
                        {
                        restPotential = rnd.Next(1, 4);
                        if(restPotential == 1)
                        {
                            canRest = 1;
                        }
                    }
                    if(mp < (CPUBaseValues[a].mp*.33))
                    {
                        restPotential = rnd.Next(1, 4);
                        if (restPotential == 1|| restPotential == 2) 
                        {
                            canRest = 1;
                        }
                    }
               }
            }
      
            movechoice = rnd.Next(canRest, (monstermoves.Count+1));

        }

        private protected override ListofMoves MoveSetChoice(int movechosen)
        {
            SoothingRain soothing = new SoothingRain();
            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest);monstermoves.Add(rayofFrost); monstermoves.Add(corrosiveGeyser); monstermoves.Add(soothing);

            Console.WriteLine($"\n=====================");
            return monstermoves[(movechosen - 1)];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {
            bool CanTarget = false;
            int targeted;
            Random Target = new Random();
            List<CreatureLibrary> PlayerTeamMonsters = new List<CreatureLibrary>();
            bool IsRedirected = false;

            List<CreatureLibrary> TargetAlter = new List<CreatureLibrary>();

            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(manifestation); monstermoves.Add(fearful); monstermoves.Add(hummingTackle);

            TargetAbilities targetAbilities = new TargetAbilities(User, opposingteam, ref IsRedirected, ref TargetAlter, monstermoves[moveSelected]);


            if (IsRedirected == true)
            {
                targetChoice.Add(TargetAlter[0]);
            }
            else
            {
                for (int a = 0; a < opposingteam.Count; a++)
                {
                    PlayerTeamMonsters.Add(opposingteam[a]);
                }

                do
                {
                    targeted = Target.Next(0, PlayerTeamMonsters.Count); // number for index of the opposing team list

                    targetChoice.Add(PlayerTeamMonsters[targeted]);

                    CanTarget = true;

                } while (PlayerTeamMonsters[targeted].faintstatus == "Fainted");
            }
        }
        private protected override void CreatureAbility()
        {

        }
    }
    class Ridge : CreatureLibrary
    {
        public Ridge() : base("Ridge", 1, 300, 160, 360, 170, 30, 240, 155, "Timber", "Terra", "Defensive", "Active", "Player", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Thick Skin")
        {
            InstanceCounter<CreatureLibrary>.Increase();
        }
        private protected override void DescriptionText()
        {
            Console.WriteLine($"The temperature drops steadily as a silver-furred fox drops down, the ground beneath its maw eroding where saliva touches");
        }
        private protected override void printvalues()
        {
            Console.WriteLine($"{name}\nID: {id}\nHp: {health}\nPhys: {phys}\n" +
                $"Astral: {astral}\nPhysical Defence: {physdef}\nAstral Defence {astraldef}" +
                $"\nSpeed: {speed}\nTypeA: {typea}\nTypeB: {typeb}");
        }
        private protected override void MovesAvailable()
        {
            NutrientsofTerra nutrientsof = new NutrientsofTerra();
            Fissure fissure = new Fissure();
            PyramidPillars pyramidPillars = new PyramidPillars();            
            BlazingFields blazingFields = new BlazingFields();
            Vibration vibration = new Vibration();


            List<ListofMoves> DisplayMoveList = new List<ListofMoves>();
            DisplayMoveList.Add(nutrientsof); DisplayMoveList.Add(fissure); DisplayMoveList.Add(pyramidPillars); DisplayMoveList.Add(blazingFields); DisplayMoveList.Add(vibration);

            foreach (var name in DisplayMoveList)
            {
                Console.WriteLine($"{name.name}");
            }

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {
            NutrientsofTerra nutrientsof = new NutrientsofTerra();
            Fissure fissure = new Fissure();
            PyramidPillars pyramidPillars = new PyramidPillars();
            Rest rest = new Rest();
            BlazingFields blazingFields = new BlazingFields();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(nutrientsof); monstermoves.Add(fissure); monstermoves.Add(pyramidPillars); monstermoves.Add(blazingFields);


            List<ListofMoves> MPcostListing = monstermoves.OrderByDescending(monstermoves => monstermoves.MpCost).ToList();
            List<ListofMoves> MpCostLowest = new List<ListofMoves>();
            int noMp = (monstermoves.Count - 1);

            for (; noMp >= 0; noMp--)
            {
                MpCostLowest.Add(MPcostListing[noMp]);
            }

            if (mp < MpCostLowest[1].MpCost)
            {
                Console.WriteLine($"{name} has no more MP left and must rest.");
                movechoice = 1;
            }
            else
            {
                int movechosen;
                int listnumber;
                var moveAsString = "";
                do
                {
                    do
                    {
                        listnumber = 0;
                        Console.WriteLine($"Move List | {name}\n====================");
                        Console.WriteLine($"What should {name} do?\n====================");
                        foreach (var movename in monstermoves)
                        {
                            listnumber++;
                            Console.WriteLine($"{listnumber}| {movename.name}");

                        }
                        Console.WriteLine($"====================");
                        do
                        {
                            moveAsString = Console.ReadLine();
                            movechosen = Convert.ToInt32(moveAsString);
                            if (mp < monstermoves[movechosen-1].MpCost)
                            {
                                Console.WriteLine($"Not enough MP!");
                            }
                        } while (mp < monstermoves[movechosen-1].MpCost);

                    } while (!int.TryParse(moveAsString, out movechoice));
                } while (movechoice > listnumber);
            }
        }
        private protected override ListofMoves MoveSetChoice(int movechosen)
        {
            NutrientsofTerra nutrientsof = new NutrientsofTerra();
            Fissure fissure = new Fissure();
            PyramidPillars pyramidPillars = new PyramidPillars();
            Rest rest = new Rest();
            BlazingFields blazingFields = new BlazingFields();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
           monstermoves.Add(rest); monstermoves.Add(nutrientsof); monstermoves.Add(fissure); monstermoves.Add(pyramidPillars); monstermoves.Add(blazingFields);

            Console.WriteLine($"\n====================");
            return monstermoves[(movechosen - 1)];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {
            List<CreatureLibrary> TargetList = new List<CreatureLibrary>();

            NutrientsofTerra nutrientsof = new NutrientsofTerra();
            Fissure fissure = new Fissure();
            PyramidPillars pyramidPillars = new PyramidPillars();
            Rest rest = new Rest();
            BlazingFields blazingFields = new BlazingFields();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
           monstermoves.Add(rest); monstermoves.Add(nutrientsof); monstermoves.Add(fissure); monstermoves.Add(pyramidPillars); monstermoves.Add(blazingFields);

            int listcounter = 1;
            var WhoTarget = "";
            int targetedMon;
            bool IsRedirected = false;
            List<CreatureLibrary> TargetAlter = new List<CreatureLibrary>();
            MoveType = monstermoves[moveSelected-1].attacktype;
            TargetAbilities targetAbilities = new TargetAbilities(User, opposingteam,ref IsRedirected, ref TargetAlter, monstermoves[moveSelected-1] );


            if (IsRedirected == true)
            {
                targetChoice.Add(TargetAlter[0]);
            }
            else
            {
                if (monstermoves[(moveSelected - 1)].target == "Self" || monstermoves[(moveSelected - 1)].target == "Field" || monstermoves[(moveSelected - 1)].target == "Sky")
                {
                    for (int a = 0; a < team.Count; a++)
                    {
                        if (team[a].name == User.name)
                        {
                            targetChoice.Add(User);
                        }
                    }
                }
                else
                {
                    if (monstermoves[(moveSelected - 1)].target == "Triple")
                    {
                        targetChoice.Add(opposingteam[0]);
                    }
                    else
                    {
                        if (monstermoves[(moveSelected - 1)].target == "Single")
                        {
                            for (int a = 0; a < team.Count; a++)
                            {
                                if (team[a].faintstatus != "Fainted")
                                    TargetList.Add(team[a]);
                            }
                            for (int a = 0; a < team.Count; a++)
                            {
                                if (opposingteam[a].faintstatus != "Fainted")
                                    TargetList.Add(opposingteam[a]);
                            }

                            foreach (var monster in TargetList)
                            {
                                if (monster.teamStatus == "Player")
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"{listcounter}: {monster.name}:");
                                }
                                if (monster.teamStatus == "CPU")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{listcounter}: {monster.name}:");
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                listcounter++;
                            }
                        }

                        do
                        {
                            do
                            {
                                Console.Write($"\nTarget (number):");
                                WhoTarget = Console.ReadLine();

                            } while (!int.TryParse(WhoTarget, out targetedMon));
                        } while (targetedMon > TargetList.Count);

                        targetChoice.Add(TargetList[targetedMon - 1]);
                    }
                }
            }
        }
        private protected override void CreatureAbility()
        {
            Console.WriteLine($"Thick Skin:\n\tPrevents acid secondary effects.\n" +
                $"Golem Arms:\n\tTerra attacks give this creature extra physical.\n");
        }
    }
    class RidgeBaseValues : CreatureLibrary
    {
        public RidgeBaseValues() : base("Ridge", 1, 300, 160, 360, 170, 30, 240, 155, "Timber", "Terra", "Defensive", "Active", "Player", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Thick Skin")
        {
        }
        private protected override void DescriptionText()
        { }
        private protected override void printvalues()
        { }
        private protected override void MovesAvailable()
        {
           

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {

        }
        private protected override ListofMoves MoveSetChoice(int a)
        {

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            return monstermoves[0];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {

        }
        private protected override void CreatureAbility()
        {

        }
    }
    class Ridge1 : CreatureLibrary //cpu values
    {
        public Ridge1() : base("Ridge", 1, 300, 160, 360, 170, 30, 240, 155, "Timber", "Terra", "Defensive", "Active", "CPU", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Golem Arms") // hit by terra gets +1 phys
        {
            InstanceCounter<CreatureLibrary>.Increase();
        }
        private protected override void DescriptionText()
        {
            Console.WriteLine($"The temperature drops steadily as a silver-furred fox drops down, the ground beneath its maw eroding where saliva touches");
        }
        private protected override void printvalues()
        {
            Console.WriteLine($"{name}\nID: {id}\nHp: {health}\nPhys: {phys}\n" +
                $"Astral: {astral}\nPhysical Defence: {physdef}\nAstral Defence {astraldef}" +
                $"\nSpeed: {speed}\nTypeA: {typea}\nTypeB: {typeb}");
        }
        private protected override void MovesAvailable()
        {
            NutrientsofTerra nutrientsof = new NutrientsofTerra();
            Fissure fissure = new Fissure();
            PyramidPillars pyramidPillars = new PyramidPillars();
            BlazingFields blazingFields = new BlazingFields();
            Vibration vibration = new Vibration();


            List<ListofMoves> DisplayMoveList = new List<ListofMoves>();
            DisplayMoveList.Add(nutrientsof); DisplayMoveList.Add(fissure); DisplayMoveList.Add(pyramidPillars); DisplayMoveList.Add(blazingFields); DisplayMoveList.Add(vibration);

            foreach (var name in DisplayMoveList)
            {
                Console.WriteLine($"{name.name}");
            }

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {

            Random rnd = new Random();

            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Rest rest = new Rest();
            BlazingFields blazingFields = new BlazingFields();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(rayofFrost); monstermoves.Add(corrosiveGeyser); monstermoves.Add(blazingFields);
            int canRest = 1;
            int restPotential;

            for (int a = 0; a < CPUTeam.Count; a++)
            {
                if (name == CPUTeam[a].name)
                {
                    if (mp == CPURefValues[a].mp)
                    {
                        canRest = 2;
                    }

                    if (mp < (CPURefValues[a].mp * .66))
                    {
                        restPotential = rnd.Next(1, 4);
                        if (restPotential == 1)
                        {
                            canRest = 1;
                        }
                    }
                    if (mp < (CPURefValues[a].mp * .33))
                    {
                        restPotential = rnd.Next(1, 4);
                        if (restPotential == 1 || restPotential == 2)
                        {
                            canRest = 1;
                        }
                    }
                }
            }

            movechoice = rnd.Next(canRest, (monstermoves.Count + 1));

        }

        private protected override ListofMoves MoveSetChoice(int movechosen)
        {
            NutrientsofTerra nutrientsof = new NutrientsofTerra();
            Fissure fissure = new Fissure();
            PyramidPillars pyramidPillars = new PyramidPillars();
            Rest rest = new Rest();
            BlazingFields blazingFields = new BlazingFields();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest);monstermoves.Add(nutrientsof); monstermoves.Add(fissure); monstermoves.Add(pyramidPillars); monstermoves.Add(blazingFields);

            Console.WriteLine($"\n=====================");
            return monstermoves[(movechosen - 1)];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {
            bool CanTarget = false;
            int targeted;
            Random Target = new Random();
            List<CreatureLibrary> PlayerTeamMonsters = new List<CreatureLibrary>();
            bool IsRedirected = false;
            List<CreatureLibrary> TargetAlter = new List<CreatureLibrary>();

            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(manifestation); monstermoves.Add(fearful); monstermoves.Add(hummingTackle);

            TargetAbilities targetAbilities = new TargetAbilities(User, opposingteam, ref IsRedirected, ref TargetAlter, monstermoves[moveSelected]);


            if (IsRedirected == true)
            {
                targetChoice.Add(TargetAlter[0]);
            }
            else
            {
                for (int a = 0; a < opposingteam.Count; a++)
                {
                    PlayerTeamMonsters.Add(opposingteam[a]);
                }

                do
                {
                    targeted = Target.Next(0, PlayerTeamMonsters.Count); // number for index of the opposing team list

                    targetChoice.Add(PlayerTeamMonsters[targeted]);

                    CanTarget = true;

                } while (PlayerTeamMonsters[targeted].faintstatus == "Fainted");
            }
        }
        private protected override void CreatureAbility()
        {

        }
    }
    class Phase : CreatureLibrary
    {
        public Phase() : base("Phase", 1, 200, 195,300, 110, 200, 200, 220, "Lightning", "Ethereal", "Physical Damage", "Active", "Player", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Power Supplier")
        {
            InstanceCounter<CreatureLibrary>.Increase();
        }
        private protected override void DescriptionText()
        {
            Console.WriteLine($"The temperature drops steadily as a silver-furred fox drops down, the ground beneath its maw eroding where saliva touches");
        }
        private protected override void printvalues()
        {
            Console.WriteLine($"{name}\nID: {id}\nHp: {health}\nPhys: {phys}\n" +
                $"Astral: {astral}\nPhysical Defence: {physdef}\nAstral Defence {astraldef}" +
                $"\nSpeed: {speed}\nTypeA: {typea}\nTypeB: {typeb}");
        }
        private protected override void MovesAvailable()
        {
            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            SyrupTrap syrupTrap = new SyrupTrap();
            TarBlob tarBlob = new TarBlob();

            List<ListofMoves> DisplayMoveList = new List<ListofMoves>();
            DisplayMoveList.Add(manifestation); DisplayMoveList.Add(fearful); DisplayMoveList.Add(hummingTackle); DisplayMoveList.Add(syrupTrap); DisplayMoveList.Add(tarBlob);

            foreach (var name in DisplayMoveList)
            {
                Console.WriteLine($"{name.name}");
            }

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {
            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(manifestation); monstermoves.Add(fearful); monstermoves.Add(hummingTackle);

            List<ListofMoves> MPcostListing = monstermoves.OrderByDescending(monstermoves => monstermoves.MpCost).ToList();
            List<ListofMoves> MpCostLowest = new List<ListofMoves>();
            int noMp = (monstermoves.Count - 1);

            for (; noMp >= 0; noMp--)
            {
                MpCostLowest.Add(MPcostListing[noMp]);
            }

            if (mp < MpCostLowest[1].MpCost)
            {
                Console.WriteLine($"{name} has no more MP left and must rest.");
                movechoice = 1;
            }
            else
            {
                int movechosen;
                int listnumber;
                var moveAsString = "";
                do
                {
                    do
                    {
                        listnumber = 0;
                        Console.WriteLine($"Move List | {name}\n====================");
                        Console.WriteLine($"What should {name} do?\n====================");
                        foreach (var movename in monstermoves)
                        {
                            listnumber++;
                            Console.WriteLine($"{listnumber}| {movename.name}");

                        }
                        Console.WriteLine($"====================");
                        do
                        {
                            moveAsString = Console.ReadLine();
                             movechosen = Convert.ToInt32(moveAsString);
                            if (mp < monstermoves[movechosen-1].MpCost)
                            {
                                Console.WriteLine($"Not enough MP!");
                            }
                        } while (mp < monstermoves[movechosen-1].MpCost);

                    } while (!int.TryParse(moveAsString, out movechoice));
                } while (movechoice > listnumber);
            }
        }
        private protected override ListofMoves MoveSetChoice(int movechosen)
        {
            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
          monstermoves.Add(rest);  monstermoves.Add(manifestation); monstermoves.Add(fearful); monstermoves.Add(hummingTackle); 

            Console.WriteLine($"\n====================");
            return monstermoves[(movechosen - 1)];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {
            List<CreatureLibrary> TargetList = new List<CreatureLibrary>();

            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
          monstermoves.Add(rest);  monstermoves.Add(manifestation); monstermoves.Add(fearful); monstermoves.Add(hummingTackle); 

            int listcounter = 1;
            var WhoTarget = "";
            int targetedMon;
            bool IsRedirected = false;

            MoveType = monstermoves[moveSelected-1].attacktype;
            List<CreatureLibrary> TargetAlter = new List<CreatureLibrary>();

            TargetAbilities targetAbilities = new TargetAbilities(User, opposingteam, ref IsRedirected, ref TargetAlter, monstermoves[moveSelected-1]);


            if (IsRedirected == true)
            {
                targetChoice.Add(TargetAlter[0]);
            }
            else
            {


                if (monstermoves[(moveSelected - 1)].target == "Self" || monstermoves[(moveSelected - 1)].target == "Field" || monstermoves[(moveSelected - 1)].target == "Sky")
                {
                    for (int a = 0; a < team.Count; a++)
                    {
                        if (team[a].name == User.name)
                        {
                            targetChoice.Add(User);
                        }
                    }
                }
                else
                {
                    if (monstermoves[(moveSelected - 1)].target == "Triple")
                    {
                        targetChoice.Add(opposingteam[0]);
                    }
                    else
                    {
                        if (monstermoves[(moveSelected - 1)].target == "Single")
                        {
                            for (int a = 0; a < team.Count; a++)
                            {
                                if (team[a].faintstatus != "Fainted")
                                    TargetList.Add(team[a]);
                            }
                            for (int a = 0; a < team.Count; a++)
                            {
                                if (opposingteam[a].faintstatus != "Fainted")
                                    TargetList.Add(opposingteam[a]);
                            }

                            foreach (var monster in TargetList)
                            {
                                if (monster.teamStatus == "Player")
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"{listcounter}: {monster.name}:");
                                }
                                if (monster.teamStatus == "CPU")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{listcounter}: {monster.name}:");
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                listcounter++;
                            }
                        }

                        do
                        {
                            do
                            {
                                Console.Write($"\nTarget (number):");
                                WhoTarget = Console.ReadLine();

                            } while (!int.TryParse(WhoTarget, out targetedMon));
                        } while (targetedMon > TargetList.Count);

                        targetChoice.Add(TargetList[targetedMon - 1]);
                    }
                }
            }
        }
        private protected override void CreatureAbility()
        {
            Console.WriteLine($"Power Supplier:\n\tIncreases electrical attacks.\n" +
               $"Ethereal Speed:\n\tCannot have its speed altered.\n");
        }
    }
    class PhaseBaseValues : CreatureLibrary
    {
        public PhaseBaseValues() : base("Phase", 1, 200, 195, 300, 110, 200, 200, 220, "Lightning", "Ethereal", "Physical Damage", "Active", "Player", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Ethereal Speed")
        {
        }
        private protected override void DescriptionText()
        { }
        private protected override void printvalues()
        { }
        private protected override void MovesAvailable()
        {
           

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {

        }
        private protected override ListofMoves MoveSetChoice(int a)
        {

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            return monstermoves[0];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {

        }
        private protected override void CreatureAbility()
        {

        }
    }
    class Phase1 : CreatureLibrary //cpu values
    {
        public Phase1() : base("Phase", 1, 200, 195, 300, 110, 200, 200, 220, "Lightning", "Ethereal", "Physical Damage", "Active", "CPU", "Normal", 0, "Normal", "Normal", 0, 0, "Normal", 0, "Ethereal Speed")
        {
            InstanceCounter<CreatureLibrary>.Increase();
        }
        private protected override void DescriptionText()
        {
            Console.WriteLine($"The temperature drops steadily as a silver-furred fox drops down, the ground beneath its maw eroding where saliva touches");
        }
        private protected override void printvalues()
        {
            Console.WriteLine($"{name}\nID: {id}\nHp: {health}\nPhys: {phys}\n" +
                $"Astral: {astral}\nPhysical Defence: {physdef}\nAstral Defence {astraldef}" +
                $"\nSpeed: {speed}\nTypeA: {typea}\nTypeB: {typeb}");
        }
        private protected override void MovesAvailable()
        {
            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            SyrupTrap syrupTrap = new SyrupTrap();
            TarBlob tarBlob = new TarBlob();

            List<ListofMoves> DisplayMoveList = new List<ListofMoves>();
            DisplayMoveList.Add(manifestation); DisplayMoveList.Add(fearful); DisplayMoveList.Add(hummingTackle); DisplayMoveList.Add(syrupTrap); DisplayMoveList.Add(tarBlob);

            foreach (var name in DisplayMoveList)
            {
                Console.WriteLine($"{name.name}");
            }

        }
        private protected override void DisplayMoves(ref int movechoice, List<CreatureLibrary> CPURefValues, List<CreatureLibrary> CPUTeam)
        {

            Random rnd = new Random();

            RayofFrost rayofFrost = new RayofFrost();
            CorrosiveGeyser corrosiveGeyser = new CorrosiveGeyser();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(rayofFrost); monstermoves.Add(corrosiveGeyser);
            int canRest = 1;
            int restPotential;

            for (int a = 0; a < CPUTeam.Count; a++)
            {
                if (name == CPUTeam[a].name)
                {
                    if (mp == CPURefValues[a].mp)
                    {
                        canRest = 2;
                    }

                    if (mp < (CPURefValues[a].mp * .66))
                    {
                        restPotential = rnd.Next(1, 4);
                        if (restPotential == 1)
                        {
                            canRest = 1;
                        }
                    }
                    if (mp < (CPURefValues[a].mp * .33))
                    {
                        restPotential = rnd.Next(1, 4);
                        if (restPotential == 1 || restPotential == 2)
                        {
                            canRest = 1;
                        }
                    }
                }
            }

            movechoice = rnd.Next(canRest, (monstermoves.Count + 1));

        }

        private protected override ListofMoves MoveSetChoice(int movechosen)
        {
            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
           monstermoves.Add(rest); monstermoves.Add(manifestation); monstermoves.Add(fearful); monstermoves.Add(hummingTackle); 

            Console.WriteLine($"\n=====================");
            return monstermoves[(movechosen - 1)];
        }
        private protected override void Target(CreatureLibrary User, ref List<CreatureLibrary> targetChoice, List<CreatureLibrary> team, List<CreatureLibrary> opposingteam, int moveSelected, string MoveType)
        {
            bool CanTarget = false;
            int targeted;
            Random Target = new Random();
            List<CreatureLibrary> PlayerTeamMonsters = new List<CreatureLibrary>();
            bool IsRedirected = false;
            List<CreatureLibrary> TargetAlter = new List<CreatureLibrary>();
            
            Manifestation manifestation = new Manifestation();
            FearfulAura fearful = new FearfulAura();
            HummingTackle hummingTackle = new HummingTackle();
            Rest rest = new Rest();

            List<ListofMoves> monstermoves = new List<ListofMoves>();
            monstermoves.Add(rest); monstermoves.Add(manifestation); monstermoves.Add(fearful); monstermoves.Add(hummingTackle);

            TargetAbilities targetAbilities = new TargetAbilities(User, opposingteam, ref IsRedirected, ref TargetAlter, monstermoves[moveSelected]);


            if (IsRedirected == true)
            {
                targetChoice.Add(TargetAlter[0]);
            }
            else
            {
                for (int a = 0; a < opposingteam.Count; a++)
                {
                    PlayerTeamMonsters.Add(opposingteam[a]);
                }

                do
                {
                    targeted = Target.Next(0, PlayerTeamMonsters.Count); // number for index of the opposing team list

                    targetChoice.Add(PlayerTeamMonsters[targeted]);

                    CanTarget = true;

                } while (PlayerTeamMonsters[targeted].faintstatus == "Fainted");
            }
        }
        private protected override void CreatureAbility()
        {

        }
    }

}