using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwoleGoal.Models
{
    public class ParagraphCreator
    {
        private static string m_LowActivityLoseWeight = "You could benefit from additional cardio in your lifestyle. Try fitting some in as soon as you wake up (ideally before eating anything) in order to jumpstart your metabolism.";
        private static string m_HighActivityLoseWeight = "Try taking some carbs out of your diet, especially during times where your metabolism is at it's lowest.";
        private static string m_HighVoluntaryActivityGain = "Cardio is the enemy; try and cut some out of your leisure time.";
        private static string m_GainMuscle = "People very often are overdoing the protein when trying to gain muscle; keep in mind that you should be consuming 3 grams of carbohydrates for every 1 gram of protein.";
        private static string m_GainMuscle2 = "Be sure to give a specific muscle group 48 hours of rest before targeting that group again in your workout.";
        private static string m_GainHypertrophy = "Keep your sets between 8 and 10 reps in order to maximize hypertrophy.";
        private static string m_LoseWeightIncreaseEndurance = "Keep your sets between 12 and 15 reps.";
        private static string m_GainMaxout = "If you're trying to increase your compound personal records, then keep your reps between 2 and 5.";
        private static string m_LoseWeight = "A very simple first step for many people is simply to cut out all drinks containing sugars or artificial sweeteners.";

        private string m_TotalActivity;
        private double m_Bmr;
        private double m_Tdee;
        private HomePageInputs m_Inputs;
        public ParagraphCreator(HomePageInputs inputs)
        {
            m_Inputs = inputs;
            m_TotalActivity = CalculateTotalActivity(m_Inputs.VoluntaryFitness, m_Inputs.WorkFitness);
            m_Bmr = CalculateBMR(m_Inputs.Height, m_Inputs.Weight, m_Inputs.Gender, m_Inputs.Age);
            m_Tdee = CalculateTdee(m_Bmr, m_TotalActivity);
        }
        public string CreateParagraph(HomePageInputs inputs)
        {
            string answer = "";
            if (inputs.PrimaryGoal == "Gain")
            {
                answer += m_GainMuscle + m_GainMuscle2 + m_GainHypertrophy + m_GainMaxout + m_HighVoluntaryActivityGain;
            }
            else if (inputs.PrimaryGoal == "Lose")
            {
                answer += m_LoseWeightIncreaseEndurance + m_HighActivityLoseWeight + m_LoseWeight;
                if (m_TotalActivity == "Low")
                {
                    answer += m_LowActivityLoseWeight;
                }
            }
            return answer;
        }
        public double CalculateBMR(string height, string weight, string gender, string age)
        {
            double answer = 0.0;
            double heightInt = 0;
            double weightInt = 0;
            double ageInt = 0;
            double.TryParse(height, out heightInt);
            double.TryParse(weight, out weightInt);
            double.TryParse(age, out ageInt);
            if (gender == "Woman")
            {
                answer = 655 + (4.35 * weightInt) + (4.7 * heightInt) - (4.7 * ageInt);
            }
            else {
                answer = 66 + (6.23 * weightInt) + (12.7 * heightInt) - (6.8 * ageInt);
            }
            return answer;
        }
        public double CalculateTdee(double bmr, string totalActivity)
        {
            double answer = 1;
            if (totalActivity == "None")
            {
                answer *= 1.2;
            }
            else if (totalActivity == "Low")
            {
                answer *= 1.375;
            }
            else if (totalActivity == "Medium")
            {
                answer *= 1.55;
            }
            else if (totalActivity == "High")
            {
                answer *= 1.725;
            }
            return answer;
        }
        /// <summary>
        /// Used to combine Work and Voluntary activities into one discrete value
        /// </summary>
        /// <param name="voluntary"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        public string CalculateTotalActivity(string voluntary, string work)
        {
            string answer = "";
            int activityNumber = 0;
            if (voluntary == "None")
            {
            }
            else if (voluntary == "Low")
            {
                activityNumber++;
            }
            else if (voluntary == "Medium")
            {
                activityNumber += 2;
            }
            else if (voluntary == "High")
            {
                activityNumber += 3;
            }

            if (work == "Low")
            {
                activityNumber++;
            }
            else if (work == "Medium")
            {
                activityNumber += 2;
            }
            else if (work == "High")
            {
                activityNumber += 3;
            }
            if (activityNumber < 2)
            {
                answer = "None";
            }
            else if (activityNumber < 4)
            {
                answer = "Low";
            }
            else if (activityNumber < 8)
            {
                answer = "Moderate";
            }
            else
            {
                answer = "High";
            }
            return answer;
        }



    }
}