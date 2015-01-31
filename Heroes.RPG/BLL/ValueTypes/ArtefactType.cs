using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;

namespace Heroes.RPG.BLL.ValueTypes
{
    public class ArtefactType
    {
        string name;
        int maxDurability;
        ParametersSet parametersSet;
        //List<Ability> abilities;

        public ArtefactType()
        {
            parametersSet = new ParametersSet();
        }

        public ArtefactType(string name, ParametersSet parametersSet)
        {
            this.name = name;
            this.parametersSet = parametersSet;
        }

        public ParametersSet Parameters
        {
            get
            {
                return parametersSet;
            }
        }
    }
}
