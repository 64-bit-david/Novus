using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpClientWinForms
{

    /// <summary>
    /// The secondary popup form HttpClientWinForms application.
    /// Displays results fetched from database.
    /// </summary>
    public partial class CalculationHistory : Form
    {

        public CalculationHistory(List<CalculationResult> calculations)
        {
            InitializeComponent();

            dataGridView1.DataSource = calculations;
        }

    }
}
