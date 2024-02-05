using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NMP_Quoting_System.Models;

namespace NMP_Quoting_System.Services
{
    public class TextFilesService
    {
        

        public TextFilesService()
        {
            
        }

        /// <summary>
        /// Reads a text file and returns an array of strings representing the contents of the text file.
        /// </summary>
        /// <param name="path">string</param>
        /// <returns>string[]</returns>
        public static string[]? ReadTextFile(string path)
        {
            if (!File.Exists(path)) 
            {
                return null;
            }

            string[] lines = File.ReadAllLines(path);
                
            return lines;
        }

        /// <summary>
        /// Reads the file that contains program data and returns an array of all the paths. 
        /// It's up to the programmer to determine which path is a which index!
        /// </summary>
        /// <returns>string[]</returns>
        public static Paths? GetProgramPaths()
        {
            string[]? paths = ReadTextFile(ProgramConstants.PROGRAM_PATHS);

            if (paths == null) return null;

            //The text file containing strings is arranged as follows.
            //There are multiple lines containing paths to certain resources needed by the program. 
            //Each line contains two strings separated by a an equal sign.
            //First string is the name of the path and the second string is the actual path.
            string[] line = paths[0].Split('=');
            Paths programPaths = new(line[1]);
            
            return programPaths;
        }
    }
}
