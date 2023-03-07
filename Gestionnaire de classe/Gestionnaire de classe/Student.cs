using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestionnaire_de_classe.Level;

namespace Gestionnaire_de_classe
{
    class Student
    {
        public readonly int id;
        public readonly string firstName;
        public readonly string surname;
        public readonly LevelEnum level;

        public Student(string firstName, string surname, LevelEnum level)
        {
            this.id = Manager.getStudentID();
            this.firstName = firstName;
            this.surname = surname;
            this.level = level;
        }

        public override string ToString()
        {
            return firstName+"/"+surname+"/"+ LevelDesc.GetFullName(level);
        }
    }
}
