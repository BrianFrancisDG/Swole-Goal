using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwoleGoal.Models
{
    public class NutritionWiki
    {
        private string m_Artificial = "Artificial sweeteners such as sucralose and aspartame will NOT help you lose weight. " +
            "Countless studies have proven that such sugar substitutes hinder your body's ability to compute it's caloric intake. " +
            "It essentially looses track very often, which often leads to weight gain. These drugs show very strong correlations with a slew " +
            "of cancers. Stevia Leaf Extract likely follows suit, but the substance is still very new and therefore not as well tested.";
        private string m_Mercury = "Be weary of consuming fish that are high in Mercury; people often hear about the endless benefits of fish " +
            "but like most things in life, moderation is key. Mackerel, Marlin, Orange Roughy, Shark, Swordfish, Grouper, Sea Bass, and " +
            "various Tunas are all typically high in Mercury. Do note that this list varies slightly depending on where the fish was caught.";

        private string m_Bmr = "Your Basal Metabolic Rate (Abbreviated as BMR) is a rough estimate of how many calories you'd burn if you were stationary 24 hours";
        private string m_Tdee = "Your Total Daily Energy Expenditure (TDEE) is the amount of energy in calories you burn per day, taking into consideration the physical activity you subject your body to on a daily basis.";
        private string m_Metabolism = "Metabolism by definition is a rather general statement; referring to the chemical processes tha";
        private string Ectomorph= "High tollerance for carbs, 30-60% of carbs depending on goal higher carbs for mass gain lower for weight loss, at least 25% protein";
        private string Mesomorph = "moderate overall tollerance, 20-50% carbs depending on goal. For fat loss no more than 40% of calories should come from fat";
        private string Endomorph = "low tollerance for carbs high tollerance for fat, 10-40% from carbs (more for mass and less for fat loss), 25-50% from protein, 15-40% from fat";
        private string gain = "50% carb 30% protein 20% fat";
        private string maintain = "40% carb 30% protein 30% fat";
        private string lose = "20% carb 45% protein 35% fat";

        private string m_Ectomorph = "Ectomorphs have a naturally thin build to them. They have a high tollerance for carbs and a low tollerance for fat, therefore they tend to have a hard time gaining weight.";
        private string m_Mesomorph = "Mesomorph have a naturally medium build to them. They have a moderate tollerance for carbs and fat.";
        private string m_Endomorph = "Endomorphs have a naturally heavyset build to them. They have a low tollerance for carbs and a high tollerance for fat, hence they tend to put on weight easily.";



        public NutritionWiki()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
        }

    }
}