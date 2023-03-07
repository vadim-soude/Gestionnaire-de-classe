using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_classe
{
    class Manager
    {
        private static int studentID = 0;

        private static Student[] students;

        public static int getStudentID()
        {
            studentID++;
            return studentID - 1;
        }
        
    }
}
