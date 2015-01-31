using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;

namespace Heroes.RPG.BLL.Main
{
    public class Inventory
    {
        public const int MAX_SIZE = 30;
        List<Artefact> artefacts;

        public Inventory(List<Artefact> artefacts)
        {
            this.artefacts = artefacts;
        }

        public bool AddArtefactToInventory(Artefact artefact)
        {
            if (artefacts.Count >= MAX_SIZE) return false;
            artefacts.Add(artefact);
            return true;
        }

        public ParametersSet Parameters
        {
            get
            {
                ParametersSet parameters = new ParametersSet();
                for (int i = 0; i < artefacts.Count; i++)
                    if (artefacts[i].IsEquipped == true)
                        parameters = parameters + artefacts[i].Parameters;
                return parameters;
            }
        }
    }
}
