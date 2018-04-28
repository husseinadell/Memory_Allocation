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
        public List<MemoryItem> oldRam = new List<MemoryItem>();
        int flag1 = 0;
        public Form1()
        {
            InitializeComponent();
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
            ram.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            chart1.Series.Clear();
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
                /*if (flag == 0)
                {
                    best_fit_allocation();
                }
                else
                {
                    Update_best_fit();
                }*/
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
            ram.Clear();
            List<MemoryItem> sortedHoles = holes.Select(an => new MemoryItem {name = an.name,size = an.size,starting_date = an.starting_date }).ToList();
            List<MemoryItem> tempProcesses = processes.Select(i => new MemoryItem {name = i.name,size=i.size, }).ToList();
            
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
            for (int i = 0; i < ram.Count -1; i++)
            {
                if ((ram[i].size == ram[i + 1].size) && (ram[i].starting_date == ram[i].starting_date))
                    ram.RemoveAt(i + 1);
            }
            chart1.Series.Clear();
            chart1.Series.Add("h");
            chart1.Series["h"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            chart1.Series["h"].CustomProperties = "DrawSideBySide = False, PointWidth = 1";
            for (int i = 0; i < processes.Count; i++)
            {
                chart1.Series.Add(processes[i].name);
                chart1.Series[processes[i].name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                chart1.Series[processes[i].name].CustomProperties = "DrawSideBySide = False, PointWidth = 1";
            }
            for (int i = 0; i < ram.Count; i++)
            {
                chart1.Series[ram[i].name].Points.AddXY(5, ram[i].starting_date + ram[i].size, ram[i].starting_date);
            }
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
            ram.Clear();
            List<MemoryItem> sortedHoles = holes.Select(an => new MemoryItem { name = an.name, size = an.size, starting_date = an.starting_date }).ToList();
            List<MemoryItem> tempProcesses = processes.Select(i => new MemoryItem { name = i.name, size = i.size, }).ToList();
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
                //MessageBox.Show(bestfitIndex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            chart1.Series.Clear();
            chart1.Series.Add("h");
            chart1.Series["h"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            chart1.Series["h"].CustomProperties = "DrawSideBySide = False, PointWidth = 1";
            for (int i = 0; i < processes.Count; i++)
            {
                chart1.Series.Add(processes[i].name);
                chart1.Series[processes[i].name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                chart1.Series[processes[i].name].CustomProperties = "DrawSideBySide = False, PointWidth = 1";
            }
            for (int i = 0; i < ram.Count; i++)
            {
                chart1.Series[ram[i].name].Points.AddXY(5, ram[i].starting_date + ram[i].size, ram[i].starting_date);
            }
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
        
        private void processdelT_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            string name = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
            dataGridView2.Rows.RemoveAt(rowIndex);
            int target = -1;
            if (ram.Count == 0)
            {
                processes.RemoveAt(rowIndex);
            }
            else
            {
                flag1 = 1;
                for (int i = 0; i < ram.Count; i++)
                {
                    if (name == ram[i].name)
                    {
                        target = i;
                        break;
                    }
                }
                for (int i = 0; i < processes.Count; i++)
                {
                    if (name == processes[i].name)
                    {
                        processes.RemoveAt(i);
                        break;
                    }
                }
                MemoryItem removed = ram[target];
                int end_address = ram[target].size + ram[target].starting_date;
                if (target == 0)
                {
                    if (end_address == ram[target + 1].starting_date)
                    {
                        ram[target + 1].size += ram[target].size;
                        ram[target + 1].starting_date = ram[target].starting_date;
                        ram.RemoveAt(target);
                    }
                    else
                    {
                        ram[target].name = "h";
                    }
                }
                else if (target == (ram.Count - 1))
                {
                    if (ram[target].starting_date == (ram[target - 1].starting_date + ram[target - 1].size))
                    {
                        ram[target - 1].size += ram[target].size;
                        ram.RemoveAt(target);
                    }
                    else
                    {
                        ram[target].name = "h";
                    }
                }
                else
                {
                    int flag = 0;
                    if (end_address == ram[target + 1].starting_date)
                    {
                        ram[target + 1].size += ram[target].size;
                        ram[target + 1].starting_date = ram[target].starting_date;
                        //ram.RemoveAt(target);
                        flag = 1;
                    }
                    if (ram[target].starting_date == (ram[target - 1].starting_date + ram[target - 1].size))
                    {
                        ram[target - 1].size += ram[target].size;
                        //ram.RemoveAt(target);
                        flag = 1;
                    }
                    else
                    {
                        ram[target].name = "h";
                    }
                    if (flag == 1)
                        ram.RemoveAt(target);
                }
                chart1.Series.Clear();
                chart1.Series.Add("h");
                chart1.Series["h"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                chart1.Series["h"].CustomProperties = "DrawSideBySide = False, PointWidth = 1";
                for (int i = 0; i < processes.Count; i++)
                {
                    chart1.Series.Add(processes[i].name);
                    chart1.Series[processes[i].name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                    chart1.Series[processes[i].name].CustomProperties = "DrawSideBySide = False, PointWidth = 1";
                }
                for (int i = 0; i < ram.Count; i++)
                {
                    chart1.Series[ram[i].name].Points.AddXY(5, ram[i].starting_date + ram[i].size, ram[i].starting_date);
                }
                dataGridView3.Rows.Clear();
                dataGridView3.Refresh();
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
    }
    public class MemoryItem
    {

        public string name, type;
        public int size, starting_date;
        public MemoryItem()
        { }
        public MemoryItem(MemoryItem x)
        {
            this.name = x.name;
            this.size = x.size;
            this.starting_date = x.starting_date;
            this.type = x.type;
        }
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
            starting_date = -1;
        }
    };
}
