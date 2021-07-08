using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EventPlanning
{
    public partial class Form1 : Form
    {
        List<Event> ListEvents = new List<Event>();
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            DefaultData();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                textBoxName.Focus();
                return;
            }

            var nEvent = new Event
            {
                NameEvent = textBoxName.Text,
                Place = textBoxPlace.Text,
                Date = dateTimePicker1.Value,
                Priority = comboBox1.SelectedIndex
            };

            AddEvent(nEvent);
        }

        void AddEvent(Event newEvent)
        {
            ListEvents.Add(newEvent);
            listBox1.Items.Add(newEvent);
            DefaultData();
        }

        void DefaultData()
        {
            textBoxName.Text = textBoxPlace.Text = "";
            comboBox1.SelectedIndex = 1;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ListEvents.Clear();
            DefaultData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(ListEvents));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                var result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(openFileDialog1.FileName));
                   
                    buttonClean_Click(sender, null);
                    foreach(var ev in list)
                    {
                        AddEvent(ev);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
