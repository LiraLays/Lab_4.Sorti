using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrarySort;

namespace WindowsFormsSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox2.Items.AddRange(new object[]
            {
                "Сортировка «пузырьком»",
                "Сортировка «Вставкой»",
                "Сортировка «слиянием»",
                "Сортировка «быстрая сортировка Хоара»",
                "Cортировка элементов 2 типов",
                "Cортировка элементов 3 типов",
                "Cортировка элементов 4 типов",
            });
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int[] massive = textBox2.Text.Split(',', ' ', ';').Select(int.Parse).ToArray();

                switch (comboBox2.SelectedItem.ToString())
                {
                    case "Сортировка «пузырьком»":
                        ClassSort.BubbleSort(massive);
                        break;
                    case "Сортировка «Вставкой»":
                        ClassSort.InsertSort(massive);
                        break;
                    case "Сортировка «слиянием»":
                        ClassSort.MergeSort(massive);
                        break;
                    case "Сортировка «быстрая сортировка Хоара»":
                        ClassSort.QuickSort(massive);
                        break;
                }
            }
            catch 
            {
                
            }
        }

 
    }
}
