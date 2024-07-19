using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertGUI
{
    public static class ErrorExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            if (ex is SqlException)
            {
                MessageBox.Show("Database is currently not available. Try again later.", "Database connection problem.");
            }
            else if (ex is ArgumentException argEx)
            {
                // show message box when there is error in updating for unique value
                MessageBox.Show(argEx.Message, "Message Here", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ex is DbUpdateException dbUpdateEx)
            {
                string msg = "";
                var sqlException = (SqlException)dbUpdateEx.InnerException!;
                foreach (SqlError error in sqlException.Errors)
                {
                    msg += $"ERROR CODE {error.Number}: {error.Message}\n";
                }
                MessageBox.Show(msg, "Database Error");
            }
            else
            {
                MessageBox.Show("An error occurred while processing the request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
