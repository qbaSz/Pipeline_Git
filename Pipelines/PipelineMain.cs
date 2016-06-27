using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pipelines
{
    public partial class PipelineMain : Form
    {
        PipelineGround pg = new PipelineGround();
        

        FileHelper fh;
        bool changes = false;

        string path = "";
        /// <summary>
        /// for changeng the value to various components
        /// </summary>
        private ComponentPropertiesForm propertiesForm;

        public PipelineMain()
        {
            InitializeComponent();
            NumInputsToggle(false, true, true);
            pbPipeline.Invalidate();
            propertiesForm = new ComponentPropertiesForm();
            fh = new FileHelper();
        }

        private void pbPipeline_Paint(object sender, PaintEventArgs e)
        {
            pg.Paint(e.Graphics);
        }

        private void pbPipeline_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X - Component.Size / 2, e.Y - Component.Size / 2);
            if (buttonPump.Checked)
            {
             changes=pg.AddPump(Convert.ToDouble(numCurrentFlow.Value), Convert.ToDouble(numCapacity.Value), pt);
            }
            else if (buttonSink.Checked)
            {
               changes= pg.AddSink(pt, Convert.ToDouble(numCapacity.Value));
            }
            else if (buttonMerger.Checked)
            {
                changes = pg.AddMerger(pt);
            }
            else if (buttonDelete.Checked)
            {
               changes= pg.Delete(new Point(e.X, e.Y));
            }
            else if (buttonSplitter.Checked)
            {
                changes = pg.AddSplitter(pt);
            }
            else if (buttonAdjSplitter.Checked)
            {
                changes = pg.AddAdjustableSplitter(pt, Convert.ToDouble(numPercentage.Value / 100));
            }else if (buttonEdit.Checked)
            {
                EditComponent(new Point(e.X, e.Y));
            }
            else if (buttonPipe.Checked)
            {
                pg.AddPipe(new Point(e.X, e.Y), (double)numCapacity.Value);
            }
           

            pbPipeline.Invalidate();
          
        }
        /*
        private void pbPipeline_MouseDown(object sender, MouseEventArgs e)
        {
            if (buttonPipe.Checked)
            {
                pg.AddStartPipePt(new Point(e.X, e.Y), Convert.ToDouble(numCapacity.Value));
            }
        }

        private void pbPipeline_MouseUp(object sender, MouseEventArgs e)
        {
            if (buttonPipe.Checked)
            {
                pg.AddEndPipePt(new Point(e.X, e.Y));
            }
            pbPipeline.Refresh();
        }
        */
        private void NumPercentageToggle(bool visible)
        {
            labelPercentage.Visible = visible;
            numPercentage.Visible = visible;
        }

        private void NumCurrentFlowToggle(bool visible)
        {
            labelCurrentFlow.Visible = visible;
            numCurrentFlow.Visible = visible;
        }

        private void NumCapacityFlowToggle(bool visible)
        {
            labelCapacity.Visible = visible;
            numCapacity.Visible = visible;
        }

        private void NumInputsToggle(bool percentage_visible, bool flow_visible, bool capacity_visible)
        {
            NumPercentageToggle(percentage_visible);
            NumCurrentFlowToggle(flow_visible);
            NumCapacityFlowToggle(capacity_visible);
        }

        private void buttonPump_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, true, true);
        }

        private void buttonSink_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, true);
        }

        private void buttonPipe_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, true);
            pg.ClearTempPipe();
            pbPipeline.Invalidate();
        }

        private void buttonMerger_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, false);
        }

        private void buttonSplitter_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, false);
        }

        private void buttonAdjSplitter_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(true, false, false);
        }

        private void buttonDelete_MouseClick(object sender, MouseEventArgs e)
        {
           NumInputsToggle(false, false, false);
        }

        private void buttonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, false);
        }

        private void buttonPipe_CheckedChanged(object sender, EventArgs e)
        {
            pg.ClearTempPipe();
            pbPipeline.Invalidate();
        }

        // called this method in main form itself rather than calling in pipeground 
        public void EditComponent(Point pt)
        {
            Component cmp = pg.FindComponent(pt);
            Pipe ppe =pg.CheckCollisionPipe(pt);
            this.propertiesForm.SetComponent(cmp);
            if (cmp != null)
            {
                if (cmp.GetType() == typeof(Pump))
                {
                    this.propertiesForm.NumInputsToggle(false, true, true);
                    this.propertiesForm.SetValues(0, (double)cmp.GetType().GetProperty("CurrentFlow").GetValue(cmp), (double)cmp.GetType().GetProperty("Capacity").GetValue(cmp));
                    this.propertiesForm.ShowDialog();
                }
                else if (cmp.GetType() == typeof(AdjustableSplitter))
                {
                    this.propertiesForm.NumInputsToggle(true, false, false);
                    this.propertiesForm.SetValues(100 * (double)typeof(AdjustableSplitter).GetProperty("PercentOut1").GetValue(cmp), 0, 0);
                    this.propertiesForm.ShowDialog();
                }
                else if (cmp.GetType() == typeof(Sink))
                {
                    this.propertiesForm.NumInputsToggle(false, false, true);
                    this.propertiesForm.SetValues(0, 0, (double)cmp.GetType().GetProperty("Capacity").GetValue(cmp));
                    this.propertiesForm.ShowDialog();
                }
                this.propertiesForm.SetPipe(null);
            }
            else if (ppe != null)
            {
                this.propertiesForm.SetPipe(ppe);
                this.propertiesForm.NumInputsToggle(false, false, true);
                this.propertiesForm.SetValues(0, 0, (double)ppe.Capacity);
                this.propertiesForm.ShowDialog();
            }
        }

        //file handling starts from here 

        private void NewFile()
        {

            ClearNumericBox();
            Reset();
            pbPipeline.Invalidate();
        }
        public void Reset()
        {
            pg.ComponentList.Clear();
            pg.pipelist.Clear();
            //  fh = new FileHelper();


        }
        public void ClearNumericBox()
        {
            foreach (Control c in Controls)
            {
                if (c is NumericUpDown)
                {
                    ((NumericUpDown)c).Value = 0;
                }
            }
        }

        private void SaveToFile()
        {
            try
            {
                string filename = "";
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    path = filename = saveFileDialog1.FileName;
                    fh.SaveToFile(filename, pg);
                    changes = true;
                  //  MessageBox.Show("Saving is done.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void OpenFile()
        {


            if (changes)
            {
                DialogResult result = MessageBox.Show("Do you want to save the previous work?", "save?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (path == "")
                        SaveToFile();
                    else
                    {
                        fh.SaveToFile(path, pg);
                    }
                }
            }
            string filename = "";
            OpenFileDialog newfile = new OpenFileDialog();
            DialogResult dr = newfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                path = filename = newfile.FileName;
                ClearNumericBox();
                Reset();
                pg = fh.LoadFromFile(filename);
                if (pg == null)
                {
                    pg = new PipelineGround();
                }

                pbPipeline.Invalidate();
                changes = true;
                this.Text = filename;

            }
        }

      
        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (changes)
            {
              //  DialogResult result1 = MessageBox.Show("Do you really want to create a new project?", "new project?", MessageBoxButtons.YesNo);
              //  if (result1 == DialogResult.Yes)
              
                    DialogResult result = MessageBox.Show("Do you want to save the previous work?", "save?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (path == "")
                            SaveToFile();
                        else
                        {
                            fh.SaveToFile(path, pg);
                        }
                    
                }

            }
            else
                changes = false;
            NewFile();
            path = "";

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (path != "")
                try
                {
                    fh.SaveToFile(path, pg);
                    changes = true;
                   // MessageBox.Show("saving is done.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewManual();
        }
        private void ViewManual()
        {
            Manual newManual = new Manual();
            newManual.Visible = true;
            this.openManualToolStripMenuItem.Enabled = false;
            newManual.FormClosing += newManual_FormClosing;
        }
        private void newManual_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.openManualToolStripMenuItem.Enabled = true;
        }

        private void PipelineMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!changes)
            {
                DialogResult result = MessageBox.Show("Do you really want to quit?", "Quit?", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                DialogResult Want2Save = MessageBox.Show("Do you want to Save your work before quiting?", "Saving?", MessageBoxButtons.YesNoCancel);
                if (Want2Save == DialogResult.Yes)
                {
                    if (path == "")
                        SaveToFile();
                    else
                    {
                        fh.SaveToFile(path, pg);
                    }
                }
                if (Want2Save == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

      
    }
}
