﻿using System.Text;

namespace TravelExpertGUI
{
    public static class DataGridViewHelper
    {
        public static void AddModifyAndDeleteButtonsToDGV(DataGridView dataGridView)
        {
            // Add Modify button
            DataGridViewButtonColumn modifyColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dataGridView.Columns.Add(modifyColumn);
        }

        /// <summary>
        /// Hide columns that are not needed on the main data grid view
        /// </summary>
        /// <param name="dataGridView">main data grid view</param>
        /// <param name="columnsToHide">list of columns to be hidden</param>

        public static void HideUnwantedColumns(DataGridView dataGridView, List<string> columnsToHide)
        {
            foreach (var columnName in columnsToHide)
            {
                var column = dataGridView.Columns.OfType<DataGridViewColumn>()
                    .FirstOrDefault(col => col.Name == columnName);

                if (column != null)
                {
                    dataGridView.Columns.Remove(column);
                }
            }
        }
    }
}
