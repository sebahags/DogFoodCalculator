using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Dog
    {
        String sName;
        String sBreed;
        String sAge;
        String sColor;
        double dWeight;

        public Dog(string sName = "", string sBreed = "", string sAge = "0", string sColor = "", double dWeight = 0)
        {
            this.sName = sName;
            this.sBreed = sBreed;
            this.sAge = sAge;
            this.sColor = sColor;
            this.dWeight = dWeight;
        }

        public String getName()
        {
            return sName;
        }

        public String getBreed()
        {
            return sBreed;
        }

        public int getAge()
        {
            return int.Parse(sAge);
        }

        public String getColor()
        {
            return sColor;
        }

        public double getWeight()
        {
            return dWeight;
        }

        public String toString()
        {
            return "Hi my name is " + this.getName() + ". My breed, age, color and weight are " + this.getBreed() +
                ", " + this.getAge() + ", " + this.getColor() + ", " + this.getWeight();
        }

        public double calculateFood(double dFloorFood, double dCeilingFood, double dFloorWeight, double dCeilingWeight)
        {
            // Calculates the right amount of food in every segment, floor is the low boundary and ceiling the higher boundary in the segment.

            return (((dWeight - dFloorWeight) / (dCeilingWeight - dFloorWeight)) * (dCeilingFood - dFloorFood)) + dFloorFood;
        }

        public double calculateAdjustedFood()
        {
            // calculates the adjusted amount of food for every possible weight segment
            // of attribute dWeight that stands for the weight of the dog.

            double dTempWeight = dWeight;
            double dOverCeilingFood = 4.25;

            //Calculated with if statements, and using the calculateFood method.

            if (dWeight < 1.5)
            {
                return 0.3;
            }
            else if (dWeight>=1.5 && dWeight <= 5.5)
            {
                return this.calculateFood(0.3, 1.0, 1.5, 5.5);
            }
            else if (dWeight > 5.5 && dWeight <= 9.0)
            {
                return this.calculateFood(1.0, 1.3, 5.6, 9.0);
            }
            else if (dWeight > 9.0 && dWeight <= 15.9)
            {
                return this.calculateFood(1.3, 2.0, 9.1, 15.9);
            }
            else if (dWeight > 15.9 && dWeight <= 22.5)
            {
                return this.calculateFood(2.0, 2.6, 16, 22.5);
            }
            else if (dWeight > 22.5 && dWeight <= 34)
            {
                return this.calculateFood(2.6, 3.3, 22.6, 34);
            }
            else if (dWeight > 34 && dWeight <= 45)
            {
                return this.calculateFood(3.3, 4.25, 34.1, 45);
            }
            else
            {
                //If the dog weighs over 45kg this block calculates the right amount of food 
                //acording to the right parameters, +0.25 cups per every 4,5kg over the 45kg mark.
                //Calculation made using a while loop that decreases a temporary variable holding
                //the dogs weight with 4.5kg every iteration until there is under 4,5kg left to the 45kg mark,
                //and by adding an extra 0.25 cups every iteration.
                if ((dWeight - 45.0) < 4.5)
                {
                    return 4.25;
                }
                else
                {
                    while((dTempWeight - 45.0) >= 4.5)
                    {
                        dOverCeilingFood = dOverCeilingFood + 0.25;
                        dTempWeight = dTempWeight - 4.5;
                    }
                    return dOverCeilingFood;
                }
            }
        }
    }
}
