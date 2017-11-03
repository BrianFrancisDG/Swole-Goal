using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwoleGoal.Models
{
    public class ResultOutputs
    {
        public string TotalActivity { get; set; }
        public int Bmr { get; set; }
        public int Tdee { get; set; }
        public string Paragraph { get; set; }
        public int Caloric { get; set; }
        public string PrimaryGoal { get; set; }
        public string CaloricPercent { get; set; }
        public int GramsFat { get; set; }
        public int GramsProtein { get; set; }
        public int GramsCarbs { get; set; } 
    }
}