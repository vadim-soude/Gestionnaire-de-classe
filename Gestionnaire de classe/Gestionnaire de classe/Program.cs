﻿using Gestionnaire_de_classe;

namespace premier_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("test", "test2", LevelEnum.CP);

            Console.WriteLine(student.ToString());
        }
    }
}