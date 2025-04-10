using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSort
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = "Инструкция пользователя:\n1. Выбрать метод сортировки в выпадающем меню\n2. Выбрать направление сортировки, для сортировки по возрастанию не ставить галочку, для сортировки в обратном направлении выбрать галочку\n3. Заполнить массив в соотвествии с форматом\n4. Нажать на кнопку Отсортировать и получить результат в текством поле\nФормат заполнения массива указан под надписью заполните массив.\nДля сортировок по 2/3/4 типам требуется выбрать соответствуещее количество неповторяющихся чисел(2/3/4).";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
