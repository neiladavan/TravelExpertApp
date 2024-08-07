using System.Globalization;

namespace TravelExpertGUI
{
    /// <summary>
    ///  a collection of static methods to validate user input
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// checks if text box has non-empty string in it
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsPresent(TextBox textBox)
        {
            bool isValid = true; //"innocent until proven guilty"
            if (textBox.Text == "") // bad
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " is required");
                textBox.Focus();
            }
            return isValid;
        }
        /// <summary>
        /// checks if value is selected from combox box
        /// </summary>
        /// <param name="cbo">combo box to be validated</param>
        /// <returns>true if selected and false if not</returns>
        public static bool IsSelected(ComboBox cbo)
        {
            bool isValid = true; //"innocent until proven guilty"

            if (cbo.SelectedIndex == -1) // bad
            {
                isValid = false;
                MessageBox.Show(cbo.Tag + " needs to be selected");
                cbo.Focus();
            }

            return isValid;
        }

        /// <summary>
        /// checks if text box contains non-negative integer
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeInt(TextBox textBox)
        {
            bool isValid = true;
            int value; // parsed value
            if (!Int32.TryParse(textBox.Text, out value)) // bad int
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a whole number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < 0) // negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " must be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains non-negative double
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox textBox)
        {
            bool isValid = true;
            double value; // parsed value
            if (!Double.TryParse(textBox.Text, out value)) // bad double
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < 0) // negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " must be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains non-negative decimal
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox textBox)
        {
            bool isValid = true;
            decimal value; // parsed value
            if (!Decimal.TryParse(textBox.Text, out value)) // bad double
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < 0) // negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " must be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        public static bool IsDecimalInRange(TextBox textBox, decimal minValue, decimal maxValue)
        {
            bool isValid = true;
            decimal value; // parsed value
            if (!Decimal.TryParse(textBox.Text, out value)) // bad decimal
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < minValue || value > maxValue) // out of range
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + $" must be between {minValue} and {maxValue}");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value != Math.Round(value, 1))
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " can only have one digit after the decimal point.");
                textBox.SelectAll();
                textBox.Focus();
            }

            return isValid;
        }

        public static bool IsValidDateTime(TextBox textBox)
        {
            bool isValid = true;
            DateTime value; // parsed value
            if (!DateTime.TryParseExact(textBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be in a valid date format. (mm/dd/yyyy)");
                textBox.SelectAll();
                textBox.Focus();
            }

            return isValid;
        }

        public static bool IsValidEndDate(TextBox startDateTextBox, TextBox endDateTextBox)
        {
            bool isValid = true;
            DateTime startDate, endDate;

            if (!DateTime.TryParseExact(startDateTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate)
                || !DateTime.TryParseExact(endDateTextBox.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                // If dates are not in valid format, return false
                return false;
            }

            DateTime today = DateTime.Today;
            if (startDate < today && endDate < today)
            {
                isValid = false;
                MessageBox.Show($"{startDateTextBox.Tag} and {endDateTextBox.Tag} should not be in the past.");
                startDateTextBox.SelectAll();
                startDateTextBox.Focus();
            }
            else if (endDate < today)
            {
                isValid = false;
                MessageBox.Show(endDateTextBox.Tag + " should not be in the past.");
                endDateTextBox.SelectAll();
                endDateTextBox.Focus();
            }
            else if (endDate < startDate)
            {
                isValid = false;
                MessageBox.Show(startDateTextBox.Tag + " should not greater than " + endDateTextBox.Tag);
                endDateTextBox.SelectAll();
                endDateTextBox.Focus();
            }

            return isValid;
        }
    }// class
}// namespace
