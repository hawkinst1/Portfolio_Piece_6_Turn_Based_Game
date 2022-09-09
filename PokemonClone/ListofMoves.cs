using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Wisps
{    
    abstract class ListofMoves
    {
        public string name;
        public int basepower;
        public int MpCost;
        public string attacktype;
        public string attackbase;
        public string target;

        public int ctr = 9;
        public ListofMoves(string Name, int powerName, int mpcost, string typeName, string attackBase, string Target)
        {
            name = Name;
            basepower = powerName;
            MpCost = mpcost;
            attacktype = typeName;
            attackbase = attackBase;
          
            target = Target; // single, multi(2), Triple(3), self(caster), field(0)
        }
        private protected abstract void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam);
        private protected abstract void MoveUse(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam ,List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues);
        public void Moveuse(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            CombatText(defender, attacker, wholeteam);
            MoveUse(defender, attacker, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
        }
    }  
      

    class Rest : ListofMoves
    {
        public Rest() : base("Respite" , 0, 0,"Rest","Rest","Self")
        {
        }         
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" rests up replenishing their Mp.");        
        }
        private protected override void MoveUse(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        { 
            
            for(int a = 0; a < wholeteam.Count; a++)
            {
                if(attacker.name == wholeteam[a].name)
                {
                    if (attacker.mp == TeamBaseValues[a].mp)
                    {
                        Console.WriteLine($"{attacker.name} is already at max mp");
                    }
                    else
                    {
                        attacker.mp += (TeamBaseValues[a].mp / 2);
                        if(attacker.mp > TeamBaseValues[a].mp)
                        {
                            attacker.mp = TeamBaseValues[a].mp;
                        }
                    }
                }
            }
        }

    }
    class CorrosiveGeyser : ListofMoves
    {
        public CorrosiveGeyser() : base("Corrosive Geyser" , 60, 5, "Acid", "Astral","Single")
        {           
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            colourcheck colouring = new colourcheck();
                      
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" summons a stream of acid from under ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;

        }
        private protected override void MoveUse(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {          
            MoveAndEffects typegrid = new MoveAndEffects(basepower,attacktype,defender,attacker,attackbase,target,wholeteam,OpposingWholeTeam,TeamBaseValues, EnemyBaseValues);           
           
            attacker.mp -= MpCost;
       
        }
    }
    class SlickHands : ListofMoves
    {
        public SlickHands() : base("Slick Hands", 45, 5, "Acid", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {        
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"Acid oozes from ");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");           
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"'s hands and they strike ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            
            attacker.mp -= MpCost;
        }
    }
    
    class HighWind : ListofMoves
    {
        public HighWind() : base("High Winds", 0, 5, "Air", "status","Field")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
           
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.WriteLine($"High velocity winds blow around the whole field, removing field effects");
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary user, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            FieldAlterations fieldAlterations = new FieldAlterations(name, "Both", wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            user.mp -= MpCost;
        }
    }
    class AirBlades : ListofMoves
    {
        public AirBlades() : base("Air Blades", 40, 5, "Air", "Phys","Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}\nHigh velocity air streams about ");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" as they attack ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class Cyclone : ListofMoves
    {
        public Cyclone() : base("Cyclone", 50, 5, "Air", "Astral","Triple")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
          
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" summons a vicous cyclone around ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            for (int a = 0; a < OpposingWholeTeam.Count; a++)
            {
                MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
                attacker.mp -= MpCost;
            }
        }
    }
    class ExplosivePalms : ListofMoves
    {
        public ExplosivePalms() : base("Explosive Palms", 60, 5, "Phosphoro", "Phys","Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" strikes ");
            Console.Write(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" with phosphoro covered limbs ");
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class ClusterShots : ListofMoves
    {
        public ClusterShots() : base("ClusterShots", 35, 5, "Phosphoro", "Astral", "Triple")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
           
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" launches searing projectiles at ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            Random cluster = new Random();
            Random Targets = new Random();
            colourcheck colouring = new colourcheck();

            int clusterNums = cluster.Next(4, 10);
            int Target;

            for (int a = 0; a < clusterNums; a++)
            {

                Target = Targets.Next(0, OpposingWholeTeam.Count);
                Console.WriteLine($"Phosphoro crashes into {colouring.DefColournaming(OpposingWholeTeam[Target]).name}");
                MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
               
            } attacker.mp -= MpCost;
        }
    }    
    class SearingKiss : ListofMoves
    {
        public SearingKiss() : base("SearingKiss", 45, 5, "Fire", "Phys", "Single") // recoil move
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
         
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" smashes their and ");
            Console.Write(colouring.AtkColournaming(defender).name);
            Console.Write($"'s heads together whilst covered in flames");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            double PreviousHealth = defender.health;
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);

            double recoil = (PreviousHealth - defender.health);

            attacker.health = attacker.health-recoil;
            Console.WriteLine($"{attacker.name} takes {recoil} recoil damage!");
            attacker.mp -= MpCost;
        }
    }
    class BlazingFields : ListofMoves
    {
        public BlazingFields() : base("Blazing Fields", 25, 5, "Fire", "Astral", "Triple") // Changes the terrain type to fire
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
    
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" summons a stream of purple tinted flames around the battlefield.\n");
      
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            for (int a = 0; a < OpposingWholeTeam.Count; a++)
            {
                MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, OpposingWholeTeam[a], attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            }
                
            FieldAlterations field = new FieldAlterations(name, "Both", wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            
            attacker.mp -= MpCost;
        }
    }
    class PetalScythe : ListofMoves
    {
        public PetalScythe() : base("Petal Scythe", 35, 5, "Floral", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
         
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
           
            Console.Write($"Razor petals slice around ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class NutrientsofTerra : ListofMoves
    {
        public NutrientsofTerra() : base("Nutrients of Terra", 30, 5, "Floral", "Astral", "Single") // heal allies but hurt enemies
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
           
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"'s roots are poised.\n");
     
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attackerHealer, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            if(defender.teamStatus != attackerHealer.teamStatus)
            {
                colourcheck colouring = new colourcheck();
                // hurt
                Console.Write($"{colouring.AtkColournaming(attackerHealer).name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" attacks ");
                Console.WriteLine(colouring.AtkColournaming(defender).name);
                Console.ForegroundColor = ConsoleColor.White;

                MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attackerHealer, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
                attackerHealer.mp -= MpCost;
            }
            if (defender.teamStatus == attackerHealer.teamStatus)
            {
                // heal
                HealingMoves healingmoves = new HealingMoves(defender,attackerHealer, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues, basepower, name);
                attackerHealer.mp -= MpCost;
            }                      
        }
    } 
    class SnapFreeze : ListofMoves
    {   
        public SnapFreeze() : base("Snap Freeze", 35, 5, "Ice", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
      
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" summons icicles implaing ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class RayofFrost : ListofMoves
    {
        public RayofFrost() : base("Ray of Frost", 35, 10, "Ice", "Astral", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
          
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" emits a freezing blast at ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class AngelicCommand : ListofMoves
    {
        public AngelicCommand() : base("Angelic Command", 0, 5, "Light", "status", "Triple")
        { 
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"'s angelic aura attempts to subdue the opposing team");
         
            Console.ForegroundColor = ConsoleColor.White;
            
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary user, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            Random rnd = new Random();
            int shocked;
            for(int a = 0; a < OpposingWholeTeam.Count; a++ )
            {
                shocked = rnd.Next(0, 5);
                if (shocked < 1)
                {
                    OpposingWholeTeam[a].faintstatus = "CommandShocked";
                    Console.WriteLine($"{OpposingWholeTeam[a].name} is halted by the command", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($"{OpposingWholeTeam[a].name} is unaffected.");
                }
            }
            
            user.mp -= MpCost;
        }
    }
    class FieldofLight : ListofMoves
    {
        public FieldofLight() : base("Field of Light", 40, 5, "Light", "Astral", "Double")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
    
            colourcheck colouring = new colourcheck();
            
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" expels concentrated light into ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class LightBludgeon : ListofMoves
    {
        public LightBludgeon() : base("Light Bludgeon", 60, 5, "Light", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
          
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" conjures a solid light club, rushing at ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class HummingTackle : ListofMoves
    {
        public HummingTackle() : base("Humming Tackle", 60, 5, "Lightning", "Phys", "Single") // recoil or two turn?
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
        
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.WriteLine($"Lightning pulses throughout ");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" as they tackle ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);

            Console.WriteLine($"{attacker.name} is damaged through recoil!");
            attacker.health -= ((attacker.health/100)*12);
            attacker.mp -= MpCost;
        }
    }
    class Release : ListofMoves
    {
        public Release() : base("Release", 60, 5, "Lightning", "Astral", "Single") 
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {

            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" gathers up and releases electrical charge towards ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);

          
            attacker.mp -= MpCost;
        }
    }
    class EyesOfTheJust : ListofMoves
    {
        public EyesOfTheJust() : base("Eyes of the Just", 50, 5, "Liquid Gold", "Astral", "Single") 
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
                    
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"'s eyes bring ethereal gold into reality above ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)  
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class ArmsFromAbove : ListofMoves
    {
        public ArmsFromAbove() : base("Arms from Above", 50, 5, "Liquid Gold", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
          
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"'s arms manifested as gold materialise over ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class ScrapMetal : ListofMoves
    {
        public ScrapMetal() : base("Scrap Metal", 55, 5, "Metal", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
       
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" gathers jagged scrap as they slash at ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class MetallicDebris : ListofMoves
    {
        public MetallicDebris() : base("Metallic Debris", 55, 5, "Metal", "Astral", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" blows out scraps around ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class ScrapArmour : ListofMoves
    {
        public ScrapArmour() : base("Scrap Armour",2, 5, "Metal", "status", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            colourcheck colouring = new colourcheck();
            if (attacker.mods == "Scrap Armour")
            {                
            }
            else
            {
                Console.Write($"{colouring.AtkColournaming(attacker).name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" uses {name}");
            }
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            HealingMoves healingMoves = new HealingMoves(defender,attacker,wholeteam,OpposingWholeTeam,TeamBaseValues,EnemyBaseValues, basepower, name);
            attacker.mp -= MpCost;
        }
    }
    class MeteorCast : ListofMoves 
    {
        public MeteorCast() : base("Meteor Cast", 75, 50, "Mineral", "Astral", "Triple")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
         
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" drags down celestial rocks on to the opposing team ");
          
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            for (int a = 0; a < OpposingWholeTeam.Count; a++)
            {
                MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
               
            }
             attacker.mp -= MpCost;
        }
    }
    class GolemArms : ListofMoves
    {
        public GolemArms() : base("Golem Arms", 75, 5, "Mineral", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
        
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" gathers stone about their limbs, lunging at ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class CrystalSpear : ListofMoves
    {
        public CrystalSpear() : base("Crystal Spear", 55, 5, "Amber", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
           
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" solidifies amber and launches it at  ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class SyrupTrap : ListofMoves
    {
        public SyrupTrap() : base("Syrup Trap", 40, 5, "Amber", "Astral", "Single") // slowing move and opponents field move
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            //      Console.WriteLine($"{attacker.name} uses {name}"); Console.WriteLine($"liquid amber crashes into a surrounds {defender.name}'s team");

            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");            
            Console.Write($" liquid amber crashes into, and surrounds the opposing team");
      
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            FieldAlterations fieldAlterations = new FieldAlterations(name, "Opposing Field", wholeteam,OpposingWholeTeam,TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class Manifestation : ListofMoves
    {
        public Manifestation() : base("Manifestation", 45, 5, "Ethereal", "Phys", "Single") // slowing move and field move
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
         

            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"Spectral limbs sprout from ");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" striking ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class FearfulAura : ListofMoves
    {
        public FearfulAura() : base("Fearful Aura", 0, 5, "Ethereal", "Astral", "Triple") // chance to remove changes?
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" summons their fear into an illusion behind them \n");
            
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            for (int a = 0; a < OpposingWholeTeam.Count; a++)
            {
                MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, OpposingWholeTeam[a], attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            }
            attacker.mp -= MpCost;
        }
    }
    class TarBlob : ListofMoves
    {
        public TarBlob() : base("Tar Blob", 0, 5, "Tar", "status", "Self")
        { }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
         
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" convers themselves in tar, reducing damage taken ");
            }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary healer, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            HealingMoves healingMoves = new HealingMoves(defender, healer, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues, basepower, name);
            healer.mp -= MpCost;
        }

    }
    class Fumes : ListofMoves
    {
        public Fumes() : base("Fumes", 40, 5, "Tar", "Astral", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
  
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            
            Console.Write($" fumes surround and invade the sense of ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class Sludge : ListofMoves
    {
        public Sludge() : base("Sludge", 40, 5, "Tar", "Phys", "Single") 
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
         //   Console.WriteLine($"{attacker.name} uses {name}"); Console.WriteLine($"{attacker.name} lobs tar blobs at {defender.name}");
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" summons a stream of acid from under ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class Fissure : ListofMoves
    {
        public Fissure() : base("Fissure", 55, 5, "Terra", "Phys", "Single") // removes certain field effects
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
          
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" opens up cracks in the earth around ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            FieldAlterations fieldAlterations = new FieldAlterations(name, "Own Field", wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class Vibration : ListofMoves
    {
        public Vibration() : base("Vibration", 40, 5, "Terra", "Astral", "Single") 
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
       
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" vibrates the ground harshly under ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class PyramidPillars : ListofMoves
    {
        public PyramidPillars() : base("Pyramid Pillars" ,40, 5, "Timber", "Astral", "Single") // slowing effect?
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
          
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" summons a timber beams to constrict ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
                       
            if (defender.speed == 0)
            { 
            }
            if(defender.ability == "Ethereal Speed")
            {
                Console.WriteLine($"{defender.name}'s {defender.ability} means their speed is unaffected");
            }
            else
            {
                colourcheck colouring = new colourcheck();
                defender.speed -= 10;
                Console.Write(colouring.AtkColournaming(defender).name);
                Console.ForegroundColor = ConsoleColor.White; 
                Console.WriteLine("'s speed is reduced by the refuse");
            }
            attacker.mp -= MpCost;
        }
    }
    class BarkSkin : ListofMoves
    {
        public BarkSkin() : base("Barkskin", 50, 5, "Timber", "Phys", "Single") 
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
            
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"Bark grows over  ");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"'s limbs as they strike ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class Drowned : ListofMoves
    {
        public Drowned() : base("Drowned", 45, 5, "Water", "Phys", "Single")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {
    
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" spews jets of high pressure at ");
            Console.WriteLine(colouring.AtkColournaming(defender).name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
            attacker.mp -= MpCost;
        }
    }
    class TorrentialEagles : ListofMoves
    {
        public TorrentialEagles() : base("Crashing Eagles", 10, 2, "Water", "Astral", "Triple") // multi hit 2-5.
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam)
        {            
            colourcheck colouring = new colourcheck();

            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" uses {name}");
            Console.Write($"{colouring.AtkColournaming(attacker).name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" brings down compact water as eagles onto the opposing team ");          
            Console.ForegroundColor = ConsoleColor.White;
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary attacker, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
           Random eaglenumbers = new Random();
           Random Targets = new Random();
           colourcheck colouring = new colourcheck();

           int eagles = eaglenumbers.Next(2, 6);
           int Target;
            
           for(int a = 0; a < eagles; a++)
           {
                
                Target = Targets.Next(0, OpposingWholeTeam.Count);
                Console.WriteLine($"An eagle crashes into {colouring.DefColournaming(OpposingWholeTeam[Target]).name}");
                MoveAndEffects typegrid = new MoveAndEffects(basepower, attacktype, defender, attacker, attackbase, target, wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
                 attacker.mp -= MpCost;
           }
       
        }
    }
    class SoothingRain : ListofMoves
    {
        public SoothingRain() : base("Soothing Rain", 45, 50, "Water", "status", "Sky")
        {
        }
        private protected override void CombatText(CreatureLibrary defender, CreatureLibrary healer, List<CreatureLibrary> wholeteam)
        {
            colourcheck colouring = new colourcheck();

            Console.WriteLine($"{colouring.AtkColournaming(healer).name} uses {name}.\n Bringing a soothing rain down over their team");
           
        }
        private protected override void MoveUse( CreatureLibrary defender, CreatureLibrary healer, List<CreatureLibrary> wholeteam, List<CreatureLibrary> OpposingWholeTeam, List<CreatureLibrary> TeamBaseValues, List<CreatureLibrary> EnemyBaseValues)
        {
            if (healer.skyFieldStatus != "Soothing Rain")
            {
                FieldAlterations field = new FieldAlterations(name, "Own Field", wholeteam, OpposingWholeTeam, TeamBaseValues, EnemyBaseValues);
                healer.mp -= MpCost;
            }
            else
            {
                Console.WriteLine("The rain is already falling...");
            }

           
        }
      
    }
}
