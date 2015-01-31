using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.ValueTypes;

namespace Heroes.RPG.DAL
{
    public interface IValueTypesDao
    {
        CreatureType GetCreatureType(string name);
        ArmyType GetArmyType(string name);
        FactionType GetFactionType(string name);
        ArtefactType GetArtefactType(string name);
    }
}
