using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using JetBanjo.Logic.Sensor;
using System;
using System.Collections.Generic;
using System.Text;
using JetBanjo.Utils;

namespace JetBanjo.Logic.Pages
{
    public class AvatarPageLogic : IAvatarLogic
    {
        //Classification A is best, and E is worst

        //Studies seem to show that too cold is more negative on productivity than too hot. So too cold has the worst classifications.
        public DataTypes.Classification TempClassification(double temp)
        {
            DataTypes.Classification classification;

            if (temp < Constants.MIN_TEMP) 
            {
                //Temperature is lower than the lowest allowed.
                classification = DataTypes.Classification.E;
            }
            else if (temp < Constants.MIN_COMFORTABLE_TEMP) 
            {
                //Temperature is greater than the lowest, but still less than the optimal range.
                classification = DataTypes.Classification.D;
            }
            else if (temp < Constants.MIN_OPTIMAL_ALLOWED) 
            {
                //Temperature is less than the optimal, but within an allowed range.
                classification = DataTypes.Classification.B;
            }
            else if (temp <= Constants.MAX_COMFORTABLE_TEMP) 
            {
                //Temperature is within the optimal range.
                classification = DataTypes.Classification.A;
            }
            else if (temp <= Constants.MAX_OPTIMAL_ALLOWED) 
            {
                //Temperature is greater than the optimal range, but within the allowed range.
                classification = DataTypes.Classification.B;
            }
            else if (temp <= Constants.MAX_TEMP) 
            {
                //Temperature is greater than the optimal range, but below the maximum allowed.
                classification = DataTypes.Classification.C;
            }
            else 
            {
                //Temperature is too hot for normal still sitting work.
                classification = DataTypes.Classification.E;
            }

            return classification;
        }

        public DataTypes.Classification HumidityClassification(double humidity, DataTypes.Season season)
        {
            DataTypes.Classification classification;

            if (humidity < Constants.MIN_HUMIDITY)
            {
                classification = DataTypes.Classification.E;
            }
            else if (humidity < Constants.MIN_OPTIMAL_HUMIDITY)
            {
                classification = DataTypes.Classification.D;
            }
            else if (season == DataTypes.Season.Winter && humidity < Constants.MAX_OPTIMAL_HUMIDITY_WINTER)
            {
                classification = DataTypes.Classification.A;
            }
            else if (season == DataTypes.Season.Summer && humidity < Constants.MAX_OPTIMAL_HUMIDITY_SUMMER)
            {
                classification = DataTypes.Classification.A;
            }
            else if (season == DataTypes.Season.Summer && humidity < Constants.MAX_HUMIDITY_SUMMER)
            {
                classification = DataTypes.Classification.B;
            }
            else if (season == DataTypes.Season.Winter && humidity < Constants.MAX_HUMIDITY_WINTER)
            {
                classification = DataTypes.Classification.B;
            }
            else
            {
                classification = DataTypes.Classification.E;
            }

            return classification;
        }

        public DataTypes.Classification CarbonDioxideClassification(double carbonDioxide)
        {
            DataTypes.Classification classification;

            if (carbonDioxide < Constants.MAX_OPTIMAL_CO2)
            {
                classification = DataTypes.Classification.A;
            }
            else if (carbonDioxide < Constants.MAX_SEMI_OPTIMAL_CO2)
            {
                classification = DataTypes.Classification.B;
            }
            else if (carbonDioxide < Constants.MAX_SUBOPTIMAL_CO2)
            {
                classification = DataTypes.Classification.C;
            }
            else if (carbonDioxide < Constants.MAX_CO2)
            {
                classification = DataTypes.Classification.D;
            }
            else
            {
                classification = DataTypes.Classification.E;
            }

            return classification;
        }

        public DataTypes.Classification VOCClassification(double voc)
        {
            return DataTypes.Classification.E;
        }
    }
}
