using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_classe
{
    class Manager
    {
        private static int studentID = 0;

        public static ArrayList students = new ArrayList();

        public static int getStudentID()
        {
            studentID++;
            return studentID - 1;
        }
        
        public static void studentsToString()
        {
            foreach(var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
