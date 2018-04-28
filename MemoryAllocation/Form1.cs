using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryAllocation
{
    
    public partial class Form1 : Form
    {
        public List<MemoryItem> holes = new List<MemoryItem>();
        public List<MemoryItem> processes = new List<MemoryItem>();
        public List<MemoryItem> ram = new List<MemoryItem>();
        public Form1()
        {
            InitializeComponent();
            int flag = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void holeB_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            DataTable ss = new DataTable();
            ss.Columns.Add("Hole Size");
            ss.Columns.Add("Starting Address");
            if (holes.Count != 0)
            {
                if ((holes[holes.Count - 1].size + holes[holes.Count - 1].starting_date) == Convert.ToInt32(holeStartT.Text))
                {
                    holes[holes.Count - 1].size = holes[holes.Count - 1].size + Convert.ToInt32(holeSizeT.Text);
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                    DataRow row = ss.NewRow();
                    row["Hole Size"] = holes[holes.Count - 1].size;
                    row["Starting Address"] = holes[holes.Count - 1].starting_date;
                    ss.Rows.Add(row);
                }
                else if ((holes[holes.Count - 1].size + holes[holes.Count - 1].starting_date) > Convert.ToInt32(holeStartT.Text))
                {
                    if ((Convert.ToInt32(holeStartT.Text) + Convert.ToInt32(holeSizeT.Text)) < (holes[holes.Count - 1].size + holes[holes.Count - 1].starting_date))
                    {
                        DataRow row = ss.NewRow();
                        row["Hole Size"] = holes[holes.Count - 1].size;
                        row["Starting Address"] = holes[holes.Count - 1].starting_date;
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                        ss.Rows.Add(row);
                    }
                    else
                    {
                        holes[holes.Count - 1].size = holes[holes.Count - 1].size + Convert.ToInt32(holeSizeT.Text) - ((holes[holes.Count - 1].size + holes[holes.Count - 1].starting_date) - Convert.ToInt32(holeStartT.Text));
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                        DataRow row = ss.NewRow();
                        row["Hole Size"] = holes[holes.Count - 1].size;
                        row["Starting Address"] = holes[holes.Count - 1].starting_date;
                        ss.Rows.Add(row);
                    }
                }
                else
                {
                    DataRow row = ss.NewRow();
                    row["Hole Size"] = holeSizeT.Text;
                    row["Starting Address"] = holeStartT.Text;
                    MemoryItem hole = new MemoryItem("h", Convert.ToInt32(holeSizeT.Text), Convert.ToInt32(holeStartT.Text));
                    holes.Add(hole);
                    ss.Rows.Add(row);
                }
            }
            else
            {
                DataRow row = ss.NewRow();
                row["Hole Size"] = holeSizeT.Text;
                row["Starting Address"] = holeStartT.Text;
                MemoryItem hole = new MemoryItem("h", Convert.ToInt32(holeSizeT.Text), Convert.ToInt32(holeStartT.Text));
                holes.Add(hole);
                ss.Rows.Add(row);
            }
            foreach (DataRow Drow in ss.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = Drow["Hole Size"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = Drow["Starting Address"].ToString();
            }
            holeSizeT.Text = "";
            holeStartT.Text = "";
            this.ActiveControl = holeSizeT;
        }

        private void processB_Click(object sender, EventArgs e)
        {
            if (noOfProT.Enabled)
            {
                int count = Convert.ToInt32(noOfProT.Text);
                noOfProT.Enabled = false;
            }
            if(holes.Count() == 0)
            {
                noOfProT.Enabled = true;
                noOfProT.Text = "";
                MessageBox.Show("Please Enter at least one hole", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable gg = new DataTable();
                gg.Columns.Add("Name");
                gg.Columns.Add("size");
                DataRow row = gg.NewRow();
                row["Name"] = proNameT.Text;
                row["size"] = proSizeT.Text;
                MemoryItem process = new MemoryItem(proNameT.Text,"p",Convert.ToInt32(proSizeT.Text));
                processes.Add(process);
                gg.Rows.Add(row);
                foreach (DataRow Drow in gg.Rows)
                {
                    int num = dataGridView2.Rows.Add();
                    dataGridView2.Rows[num].Cells[0].Value = Drow["Name"].ToString();
                    dataGridView2.Rows[num].Cells[1].Value = Drow["size"].ToString();
                }
                proNameT.Text = "";
                proSizeT.Text = "";
                this.ActiveControl = proNameT;
            }
        }

        private void restB_Click(object sender, EventArgs e)
        {
            noOfProT.Enabled = true;
            holes.Clear();
            processes.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            noOfProT.Text = "";
            proNameT.Text = "";
            proSizeT.Text = "";
            holeSizeT.Text = "";
            holeStartT.Text = "";
        }

        private void startB_Click(object sender, EventArgs e)
        {
            if (firstfit.Checked)
            {
                first_fit_allocation();
            }
            else if (bestfit.Checked)
            {
                best_fit_allocation();
            }
            else
            {
                MessageBox.Show("Please choose Allocation Method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void first_fit_allocation()
        {
            dataGridView2.Refresh();
            dataGridView3.Rows.Clear();
            List<MemoryItem> sortedHoles = new List<MemoryItem>(holes);
            List<MemoryItem> tempProcesses = new List<MemoryItem>(processes);
            sortedHoles = sortedHoles.OrderBy(a => a.starting_date).ToList();
           // int count = 0;
            
            for (int j = 0; j < sortedHoles.Count; j++)
            {
                for (int i = 0; i < tempProcesses.Count; i++)
                {
                    if (sortedHoles[j].size > tempProcesses[i].size)
                    {
                        sortedHoles[j].size = sortedHoles[j].size - tempProcesses[i].size;
                        MemoryItem temp = new MemoryItem(tempProcesses[i].name, tempProcesses[i].size, sortedHoles[j].starting_date);
                        sortedHoles[j].starting_date = tempProcesses[i].size + sortedHoles[j].starting_date;
                        ram.Add(temp);
                        tempProcesses.RemoveAt(i);
                        j = j - 1;
                        break;
                    }
                    else if (sortedHoles[j].size == tempProcesses[i].size)
                    {
                        MemoryItem temp = new MemoryItem(tempProcesses[i].name, tempProcesses[i].size, sortedHoles[j].starting_date);
                        sortedHoles.RemoveAt(j);
                        tempProcesses.RemoveAt(i);
                        ram.Add(temp);
                        break;
                    }
                }
            }
            for (int j = 0; j < sortedHoles.Count; j++)
            {
                ram.Add(sortedHoles[j]);
            }
            ram = ram.OrderBy(a => a.starting_date).ToList();
            DataTable gg = new DataTable();
            gg.Columns.Add("Name");
            gg.Columns.Add("size");
            gg.Columns.Add("Address");
            for (int i = 0; i < ram.Count; i++)
            {
                DataRow row = gg.NewRow();
                row["Name"] = ram[i].name;
                row["size"] = ram[i].size;
                row["Address"] = ram[i].starting_date;
                gg.Rows.Add(row);
            }
            foreach (DataRow Drow in gg.Rows)
            {
                int num = dataGridView3.Rows.Add();
                dataGridView3.Rows[num].Cells[0].Value = Drow["Name"].ToString();
                dataGridView3.Rows[num].Cells[1].Value = Drow["size"].ToString();
                dataGridView3.Rows[num].Cells[2].Value = Drow["Address"].ToString();
            }
            sortedHoles.Clear();
            tempProcesses.Clear();
        }
        private void best_fit_allocation()
        {
            dataGridView2.Refresh();
            dataGridView3.Rows.Clear();
            List<MemoryItem> sortedHoles = new List<MemoryItem>(holes);
            List<MemoryItem> tempProcesses = new List<MemoryItem>(processes);
            sortedHoles = sortedHoles.OrderBy(a => a.starting_date).ToList();
            for (int i = 0; i < tempProcesses.Count; i++)
            {
                int bestfitIndex = -1;
                for (int j = 0; j < sortedHoles.Count; j++)
                {
                    
                    if (sortedHoles[j].size >= tempProcesses[i].size)
                    {
                        //MessageBox.Show(sortedHoles[j].size.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (bestfitIndex == -1)
                        {
                            bestfitIndex = j;
                            //MessageBox.Show(bestfitIndex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (sortedHoles[j].size < sortedHoles[bestfitIndex].size)
                        {
                            bestfitIndex = j;
                            //MessageBox.Show(bestfitIndex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                MessageBox.Show(bestfitIndex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (bestfitIndex != -1)
                {
                    sortedHoles[bestfitIndex].size -= tempProcesses[i].size;
                    if (sortedHoles[bestfitIndex].size == 0)
                    {
                        MemoryItem temp = new MemoryItem(tempProcesses[i].name, tempProcesses[i].size, sortedHoles[bestfitIndex].starting_date);
                        sortedHoles.RemoveAt(bestfitIndex);
                        //tempProcesses.RemoveAt(i);
                        ram.Add(temp);
                    }
                    else
                    {
                        MemoryItem temp = new MemoryItem(tempProcesses[i].name, tempProcesses[i].size, sortedHoles[bestfitIndex].starting_date);
                        sortedHoles[bestfitIndex].starting_date += tempProcesses[i].size; 
                        //tempProcesses.RemoveAt(i);
                        ram.Add(temp);
                    }
                }
            }
            for (int j = 0; j < sortedHoles.Count; j++)
            {
                ram.Add(sortedHoles[j]);
            }
            ram = ram.OrderBy(a => a.starting_date).ToList();
            DataTable gg = new DataTable();
            gg.Columns.Add("Name");
            gg.Columns.Add("size");
            gg.Columns.Add("Address");
            for (int i = 0; i < ram.Count; i++)
            {
                DataRow row = gg.NewRow();
                row["Name"] = ram[i].name;
                row["size"] = ram[i].size;
                row["Address"] = ram[i].starting_date;
                gg.Rows.Add(row);
            }
            foreach (DataRow Drow in gg.Rows)
            {
                int num = dataGridView3.Rows.Add();
                dataGridView3.Rows[num].Cells[0].Value = Drow["Name"].ToString();
                dataGridView3.Rows[num].Cells[1].Value = Drow["size"].ToString();
                dataGridView3.Rows[num].Cells[2].Value = Drow["Address"].ToString();
            }
        }
    }
    public class MemoryItem
    {
        public string name, type;
        public int size, starting_date;
        public MemoryItem( string t, int s, int sa)
        {
            name = t;
            type = t;
            size = s;
            starting_date = sa;
        }
        public MemoryItem(string n, string t, int s, int sa)
        {
            name = n;
            type = t;
            size = s;
            starting_date = sa;
        }
        public MemoryItem(string n, string t, int s)
        {
            name = n;
            type = t;
            size = s;
        }
    };
}
