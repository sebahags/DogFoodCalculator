namespace Task2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            // Takes the given parameters from the user and creates a new Dog object using them.
            // The weight needs a checking for exeptions and i made a method for that.

            String sTempName = textBoxName.Text;
            String sTempBreed = textBoxBreed.Text;
            String sTempAge = textBoxAge.Text;
            String sTempColor = textBoxColor.Text;
            double dTempWeight = checkException();

            Dog TempDog = new Dog(sTempName, sTempBreed, sTempAge, sTempColor, dTempWeight);

            //Exception handling in case user gives the weight of zero or nothing at all.
            //If user gives a weight the messagebox will print the right amount of food
            //by using the calculateAdjustedFood method in the Dog class.

            if (dTempWeight == 0)
            {
                MessageBox.Show("You have to input at least the weight of the dog to calculate.", "Weight error");
            }
            else
            {
                MessageBox.Show("Your dog should eat " + Math.Round(TempDog.calculateAdjustedFood(), 2).ToString() + " cups per day.", "Amount of food");
            }
            
        }

        public double checkException()
        {
            //Checking if the user has inputed a "." instead of a ",", since the "." would not work in a double.
            //Also checks if the user has given a value at all.
            //after checking and editing if needed, returns the value as a double.

            String sWeightInput = "";
            String sTemp = "";
            double dTempWeight = 0;
            if (textBoxWeight.Text == "")
            {
                return dTempWeight;
            }
            else
            {
                sWeightInput = textBoxWeight.Text;
                

                if (sWeightInput.Contains("."))
                {
                    sTemp = sWeightInput.Replace(".", ",");
                }
                else
                {
                    sTemp = sWeightInput;
                }

                dTempWeight = Math.Round(Convert.ToDouble(sTemp), 1);
            }
            return dTempWeight;
        }
    }
}