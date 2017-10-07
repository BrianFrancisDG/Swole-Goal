using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwoleGoal.Models
{
    public class ParagraphCreator
    {
        private static string m_LowActivityLoseWeight = "You could benefit from additional cardio in your lifestyle. Try fitting some in as soon as you wake up (ideally before eating anything) in order to jumpstart your metabolism. A small cup of coffee in the morning will make for a similar, but not as potent effect.";
        private static string m_HighActivityLoseWeight = "Try taking some carbs out of your diet, especially during times where your metabolism is at it's lowest (early in the morning and late at night). ";
        private static string m_HighVoluntaryActivityGain = "Cardio is the enemy; try and cut some out of your leisure time. ";
        private static string m_GainMuscle = "People very often are overdoing the protein when trying to gain muscle; keep in mind that you should be consuming 3 grams of carbohydrates for every 1 gram of protein. ";
        private static string m_GainMuscle2 = "Be sure to give a specific muscle group 48 hours of rest before targeting that group again in your workouts. ";
        private static string m_GainHypertrophy = "If you want to maximize hypertrophy keep your sets between 8 and 10 reps, and If you're trying to increase your compound personal records then keep your reps between 2 and 5. Both methods will help you gain muscle mass, but the former option is your go-to if you're looking for volume as opposed to density.";
        private static string m_LoseWeightIncreaseEndurance = "Keep your sets between 12 and 15 reps in order to stay in the \"Fat Burn\" zone. ";
        private static string m_LoseWeight = "A very simple first step for many people is simply to cut out all drinks containing sugars or artificial sweeteners. ";
        private static string m_Vitamins = "People often justify their sub-par eating habits by taking multi-vitamins; Know that a good majority of the substance is not absorbed into your system, and that the only way to really meet your reccomended intakes are through your foods. ";
        private static string m_Fiber = "It's pretty common to actually take in too much fiber when someone undergoes a complete diet change; yes, there is such a thing as too many vegetables. ";
        private static string m_Water = "You should be drinking 128 fluid ounces of water per day. Mild dehydration often results in drowsiness and prevents your body from absorbing nutrients. ";
        private static string m_Sleep = "One thing our generation has become extraordinarily prone to is sleep deprivation. A person of your age should be getting  7.5-9 hours of sleep per night. Skimping out on this will significantly deprive muscle regeneration. ";
        private static string m_Aerobic = "Be sure that you are exposing yourself to a decent amount of aerobic exercize each day. Not only will this curb your appetite, but it will also significantly boost your metabolism for the next few hours. ";
        private static string m_Preworkout = "Roughly one hour before your workout, have a serving or two of complex carbohydrates; and right before your workout have a serving of simple carbohydrates. This will essentially prime your body for the workout.";
        private static string m_Postworkout = "Within the hour of you finishing your workout, try to have some sort of liquid protein. ";


        public ResultOutputs Outputs { get; set; }
        private HomePageInputs m_Inputs;

        public ParagraphCreator(HomePageInputs inputs)
        {
            Outputs = new ResultOutputs();
            m_Inputs = inputs;
            Outputs.TotalActivity = CalculateTotalActivity(m_Inputs.VoluntaryFitness, m_Inputs.WorkFitness);
            Outputs.Bmr = CalculateBMR(m_Inputs.Height, m_Inputs.Weight, m_Inputs.Gender, m_Inputs.Age);
            Outputs.Tdee = CalculateTdee(Outputs.Bmr, Outputs.TotalActivity);
            Outputs.Paragraph = CreateParagraph(m_Inputs);
        }
        public string CreateParagraph(HomePageInputs inputs)
        {
            string answer = "";
            if (inputs.PrimaryGoal == "Gain")
            {
                answer += m_GainMuscle + m_GainMuscle2 + m_GainHypertrophy + m_HighVoluntaryActivityGain + m_Preworkout + m_Postworkout;
            }
            else if (inputs.PrimaryGoal == "Lose")
            {
                answer += m_LoseWeightIncreaseEndurance + m_HighActivityLoseWeight + m_LoseWeight;
                if (Outputs.TotalActivity == "Low")
                {
                    answer += m_LowActivityLoseWeight;
                }
                else
                {
                    answer += m_Aerobic;
                }
            }
            else if(inputs.PrimaryGoal == "Health")
            {
                answer += m_GainMuscle2 + m_Vitamins + m_Fiber + m_Water + m_Sleep;
                if (Outputs.TotalActivity == "Low")
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