using com.calitha.goldparser;
namespace task1
{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p = new MyParser("Task1.cgt", listBox1, listBox2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            p.Parse(textBox1.Text);
        }

    }
}