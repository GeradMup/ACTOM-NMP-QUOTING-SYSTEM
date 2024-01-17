using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NMP_Quoting_System.Models
{
    public static class ProgramConstants
    {
        public static string? ASSEMBLY_PATH = AppDomain.CurrentDomain.BaseDirectory;
        public static string PROGRAM_PATHS = $"{ASSEMBLY_PATH}\\Resources\\Paths.txt";
    }
}
