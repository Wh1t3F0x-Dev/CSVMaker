namespace BlueCare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateCSV();
        }

        private void GenerateCSV()
        {
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            if (CheckInputs() == false)
            {

                MessageBox.Show("Completa todas las inputs por favor.");

            }
            else
            {
                try
                {

                    CreateTheFile(path);

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.ToString());

                }

            }
        }

        private void CreateTheFile(string path)
        {
            string newPath = path + $"\\{textBox2.Text}.csv";
            string csvLine = "";
            //Tests(newPath);

            foreach (string line in textBox3.Lines)
            {
                csvLine += $"{comboBox1.Text}_{line};";
            }

            using (StreamWriter writer = new StreamWriter(newPath, false))
            {
                writer.Write("\"" + csvLine + "\"");
            }

        }

        private bool CheckInputs()
        {


            bool checked_Inputs = true;
            if (comboBox1.SelectedIndex < 0) checked_Inputs = false;
            if ((textBox2.Text == "") || (textBox3.Text == "")) checked_Inputs = false;

            return checked_Inputs;
        }

        //private void Tests(string textToShow)
        //{
        //    //$"The combobox1 = {comboBox1.SelectedIndex}, The textBox1 ({textBox2.Text}) and the textBox2 ({textBox3.Text})"
        //    MessageBox.Show(textToShow);
        //}

    }
}