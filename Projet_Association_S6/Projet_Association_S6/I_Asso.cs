using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
     public interface I_Asso
    {
        // Interface qui oblige à avoir accès à l'identifiant dans les classes
        int Identifiant { get; }
    }
}
