using System;
using System.Collections.Generic;
using System.Text;

namespace Wisps
{
    class TargetAbilities
    {
        public TargetAbilities(CreatureLibrary Attacker,List<CreatureLibrary> OpposingTeam, ref bool Redirect, ref List<CreatureLibrary> NewTarget, ListofMoves SelectedMove)
        {                  
            for (int a = 0; a < OpposingTeam.Count; a++)
            {
                switch (OpposingTeam[a].ability)
                {
                    case ("Ghost Hunter"):
                      {
                            if (SelectedMove.attackbase != "Phys" || SelectedMove.attackbase != "Astral")
                            { }
                            else
                            {

                                if (SelectedMove.attacktype == "Ethereal")
                                {
                                    Redirect = true;
                                    NewTarget.Add(OpposingTeam[a]);
                                }
                            }
                            
                      }
                        break;
                }
            }
        }
    }
}
