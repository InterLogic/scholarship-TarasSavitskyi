using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;
using Heroes.RPG.BLL.ValueTypes;

namespace Heroes.RPG.BLL.Main
{
    public class Artefact
    {
        ArtefactType artefactType;
        bool isEquipped;
        int currentDurability;

        public Artefact(ArtefactType artefactType, int currentDurability)
        {
            this.artefactType = artefactType;
            this.isEquipped = false;
            this.currentDurability = currentDurability;
        }

        public Artefact(ArtefactType artefactType, bool isEquipped, int currentDurability)
        {
            this.artefactType = artefactType;
            this.isEquipped = isEquipped;
            this.currentDurability = currentDurability;
        }

        public bool EquipArtefact()
        {
            if (currentDurability != 0 && isEquipped==false/*herolevel+place*/)
            {
                return true;
            }
            return false;
        }

        public void ReduceCurrentDurability()
        {
            currentDurability=Math.Max(currentDurability-1,0);
            if (currentDurability == 0)
                isEquipped = false;
        }

        public bool IsEquipped
        {
            get
            {
                return isEquipped;
            }
        }

        public ParametersSet Parameters
        {
            get
            {
                return artefactType.Parameters;
            }
        }
    }
}
