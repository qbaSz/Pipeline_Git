using System;
using System.Windows.Forms;

namespace Pipelines
{
    partial class ComponentPropertiesForm : Form
    {
        Component currentCmp = new Component();
        Pipe currentPipe = new Pipe(0);
        public ComponentPropertiesForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(currentCmp != null)
            {
                if (currentCmp.GetType() == typeof(Pump))
                {
                    currentCmp.GetType().GetProperty("Capacity").SetValue(currentCmp, (double)numCapacity.Value);
                    currentCmp.GetType().GetProperty("CurrentFlow").SetValue(currentCmp, (double)numCurrentFlow.Value);
                }
                else if (currentCmp.GetType() == typeof(AdjustableSplitter))
                {
                    currentCmp.GetType().GetProperty("PercentOut1").SetValue(currentCmp, (double)numPercentage.Value/100);
                }
                else if (currentCmp.GetType() == typeof(Sink))
                {
                    currentCmp.GetType().GetProperty("Capacity").SetValue(currentCmp, (double)numCapacity.Value);
                }
                currentCmp.UpdateOutput();
            }else if(currentPipe != null)
            {
                currentPipe.Capacity = (double)numCapacity.Value;
            }
            this.Hide();

        }
        
        public void SetValues(double percentage, double currentFlow, double capacity)
        {
            numPercentage.Value = Convert.ToDecimal(percentage);
            numCapacity.Value = Convert.ToDecimal(capacity);
            numCurrentFlow.Value = Convert.ToDecimal(currentFlow);
            numCurrentFlow.Maximum = numCapacity.Value;
        }

        public void NumPercentageToggle(bool visible)
        {
            labelPercentage.Visible = visible;
            numPercentage.Visible = visible;
        }

        public void NumCurrentFlowToggle(bool visible)
        {
            labelCurrentFlow.Visible = visible;
            numCurrentFlow.Visible = visible;
        }

        public void NumCapacityFlowToggle(bool visible)
        {
            labelCapacity.Visible = visible;
            numCapacity.Visible = visible;
        }

        public void NumInputsToggle(bool percentage_visible, bool flow_visible, bool capacity_visible)
        {
            NumPercentageToggle(percentage_visible);
            NumCurrentFlowToggle(flow_visible);
            NumCapacityFlowToggle(capacity_visible);
        }

        public void SetComponent(Component cmp)
        {
            this.currentCmp = cmp;
        }

        public void SetPipe(Pipe ppe)
        {
            this.currentPipe = ppe;
        }

        private void numCapacity_ValueChanged(object sender, EventArgs e)
        {
            numCurrentFlow.Maximum = numCapacity.Value;
        }
    }
}