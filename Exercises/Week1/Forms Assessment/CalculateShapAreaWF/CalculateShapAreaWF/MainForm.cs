namespace CalculateShapAreaWF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CircleForm circleForm = new CircleForm();
            circleForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TriangleForm triangleForm = new TriangleForm();
            triangleForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RectangleForm rectangleForm = new RectangleForm();
            rectangleForm.Show();
        }
    }
}