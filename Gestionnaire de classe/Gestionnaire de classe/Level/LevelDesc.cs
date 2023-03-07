using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_classe.Level
{
    class LevelDesc
    {
        public static string GetFullName(LevelEnum levelEnum)
        {
            switch (levelEnum)
            {
                case LevelEnum.PS:
                    return "Petite section";
                case LevelEnum.MS:
                    return "Moyenne section";
                case LevelEnum.GS:
                    return "Grande section";
                case LevelEnum.CP:
                    return "CP | Cours préparatoire";
                case LevelEnum.CE1:
                    return "CE1 | Cours élémentaire 1";
                case LevelEnum.CE2:
                    return "CE2 | Cours élémentaire 2";
                case LevelEnum.CM1:
                    return "CM1 | Cours moyen 1";
                case LevelEnum.CM2:
                    return "CM2 | Cours moyen 2";

                default: return "";
            }
        }
    }
}
