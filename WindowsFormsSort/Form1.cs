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

            checkBox1.Text = "По убыванию";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int[] massive = textBox2.Text.Split(',', ' ', ';').Select(int.Parse).ToArray();
                bool vect = checkBox1.Checked;

                switch (comboBox2.SelectedItem.ToString())
                {
                    case "Сортировка «пузырьком»":
                        textBox3.Clear();
                        ClassSort.BubbleSort(massive, vect);
                        int i = 0;
                        foreach (var number in massive)
                        {
                            i++;
                            if (i != massive.Length)
                                textBox3.Text += String.Format("{0}, ", number);
                            else
                                textBox3.Text += String.Format("{0}", number);
                        }
                        break;
                    case "Сортировка «Вставкой»":
                        textBox3.Clear();
                        ClassSort.InsertSort(massive, vect);
                        int j = 0;
                        foreach (var number in massive)
                        {
                            j++;
                            if (j != massive.Length)
                                textBox3.Text += String.Format("{0}, ", number);
                            else
                                textBox3.Text += String.Format("{0}", number);
                        }
                        break;                        
                    case "Сортировка «слиянием»":
                        textBox3.Clear();
                        ClassSort.MergeSort(massive, vect);
                        int k = 0;
                        foreach (var number in massive)
                        {
                            k++;
                            if (k != massive.Length)
                                textBox3.Text += String.Format("{0}, ", number);
                            else
                                textBox3.Text += String.Format("{0}", number);
                        }
                        break;                       
                    case "Сортировка «быстрая сортировка Хоара»":
                        textBox3.Clear();
                        ClassSort.QuickSort(massive, vect);
                        int l = 0;
                        foreach (var number in massive)
                        {
                            l++;
                            if (l != massive.Length)
                                textBox3.Text += String.Format("{0}, ", number);
                            else
                                textBox3.Text += String.Format("{0}", number);
                        }
                        break;
                    case "Cортировка элементов 2 типов":
                        textBox3.Clear();
                        ClassSort.TwoSort(massive, vect);
                        int p = 0;
                        int cnt_uniq2 = new HashSet<int>(massive).Count;
                        if (cnt_uniq2 == 2)
                        {
                            foreach (var number in massive)
                            {
                                p++;
                                if (p != massive.Length)
                                    textBox3.Text += String.Format("{0}, ", number);
                                else
                                    textBox3.Text += String.Format("{0}", number);
                            }
                        }
                        else
                            MessageBox.Show("Количество уникальных чисел должно быть равно не больше 2", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "Cортировка элементов 3 типов":
                        textBox3.Clear();
                        ClassSort.ThreeSort(massive, vect);

                        int u = 0;
                        int cnt_uniq3 = new HashSet<int>(massive).Count;                                              
                        if (cnt_uniq3 == 3)
                        {
                            foreach (var number in massive)
                            {
                                u++;
                                if (u != massive.Length)
                                    textBox3.Text += String.Format("{0}, ", number);
                                else
                                    textBox3.Text += String.Format("{0}", number);
                            }
                        }
                        else
                            MessageBox.Show("Количество уникальных чисел должно быть равно не больше 3. На флаге России всего 3 цвета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "Cортировка элементов 4 типов":
                        textBox3.Clear();
                        ClassSort.FourSort(massive, vect);
                        int r = 0;
                        int cnt_uniq4 = new HashSet<int>(massive).Count;
                        if (cnt_uniq4 == 4)
                        {
                            foreach (var number in massive)
                            {
                                r++;
                                if (r != massive.Length)
                                    textBox3.Text += String.Format("{0}, ", number);
                                else
                                    textBox3.Text += String.Format("{0}", number);
                            }
                        }
                        else
                            MessageBox.Show("Количество уникальных чисел должно быть равно не больше 4. В Хогвартсе всего 4 факультета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод! Используйте только целые числа, разделенные пробелами, запятыми или точки с запятыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
