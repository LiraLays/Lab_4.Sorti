using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySort
{
    public class ClassSort
    {
        /// <summary>
        /// Сортировка методом Пузырька
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] BubbleSort(int[] MAS, bool? vect = null)
        {
            switch (vect)
            {
                case true:    //сортировка по убыванию

                    for (int i = 0; i < MAS.Length; i++)
                        for (int j = 0; j < MAS.Length - i - 1; j++)
                            if (MAS[j] < MAS[j + 1])
                            {
                                int temp = MAS[j];
                                MAS[j] = MAS[j + 1];
                                MAS[j + 1] = temp;
                            }
                    break;

                case null:    //сортировка по возрастанию

                    for (int i = 0; i < MAS.Length; i++)
                        for (int j = 0; j < MAS.Length - i - 1; j++)
                            if (MAS[j] > MAS[j + 1])
                            {
                                int temp = MAS[j];
                                MAS[j] = MAS[j + 1];
                                MAS[j + 1] = temp;
                            }
                    break;
            }

            return MAS;
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] InsertSort(int[] MAS, bool? vect = null)
        {
            switch (vect)
            {
                case true:    //сортировка по убыванию

                    for (int i = 1; i < MAS.Length; i++)
                    {
                        int key = MAS[i], check = 0;
                        for (int j = i - 1; j >= 0 && check == 0;)
                            if (key > MAS[j])
                            {
                                MAS[j + 1] = MAS[j];
                                MAS[j] = key;
                                j--;
                            }
                            else
                                check++;
                    }
                    break;

                case null:    //сортировка по возрастанию

                    for (int i = 1; i < MAS.Length; i++)
                    {
                        int key = MAS[i], check = 0;
                        for (int j = i - 1; j >= 0 && check == 0;)
                            if (key < MAS[j])
                            {
                                MAS[j + 1] = MAS[j];
                                MAS[j] = key;
                                j--;
                            }
                            else
                                check++;

                    }
                    break;
            }

            return MAS;
        }

        /// <summary>
        /// Рекурсивная сортировка слиянием
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="low">начальный индекс</param>
        /// <param name="high">конечный индекс</param>
        /// <param name="vect">направление сортировки (true - по убыванию, false - по возрастанию)</param>
        private static void Merge_Range(int[] MAS, int low, int high, bool vect)
        {
            if (high - low > 1)
            {
                int left = low, l_mid = (low + high) / 2, r_mid = (low + high) / 2 + 1, right = high;

                Merge_Range(MAS, left, l_mid, vect);
                Merge_Range(MAS, r_mid, right, vect);

                int[] temp_MAS = new int[high - low + 1];

                for (int i = low; i <= high; i++)
                    temp_MAS[i - low] = MAS[i];

                int k = left, j = r_mid;

                for (int i = low; i <= high; i++)
                    if (k <= l_mid && j <= right)
                    {
                        bool condition = vect ? temp_MAS[k - low] > temp_MAS[j - low] : temp_MAS[k - low] < temp_MAS[j - low];
                        if (condition)
                            MAS[i] = temp_MAS[k++ - low];
                        else
                            MAS[i] = temp_MAS[j++ - low];
                    }
                    else if (k > l_mid)

                        MAS[i] = temp_MAS[j++ - low];
                    else
                        MAS[i] = temp_MAS[k++ - low];
                }

            else if (high - low == 1)
                if ((vect && MAS[low] < MAS[high]) || (!vect && MAS[low] > MAS[high]))
                {
                    int temp = MAS[low];
                    MAS[low] = MAS[high];
                    MAS[high] = temp;
                }
        }

        /// <summary>
        /// сортировка слиянием
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>остортированный массив</returns>
        public static int[] MergeSort(int[] MAS, bool? vect = null)
        {
            bool vector = vect ?? false;

            Merge_Range(MAS, 0, MAS.Length - 1, vector);

            return MAS;
        }

        /// <summary>
        /// Рекурсивная быстрая сортирока
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="low">левая граница</param>
        /// <param name="high">правая граница</param>
        /// <param name="vect">направление сортировки (false - по возрастанию, true - по убыванию)</param>
        private static void Quick_Range(int[] MAS, int low, int high, bool vect)
        {
            if (!vect)
            {
                int left = low, right = high, middle = MAS[(left + right) / 2];

                while (MAS[left] < middle)
                    left++;
                while (MAS[right] > middle)
                    right--;

                if (left <= right)
                {
                    int temp = MAS[left];
                    MAS[left] = MAS[right];
                    MAS[right] = temp;
                    left++;
                    right--;
                }

                if (low < right)
                    Quick_Range(MAS, low, right, vect);
                if (left < high)
                    Quick_Range(MAS, left, high, vect);
            }
            else
            {
                int left = low, right = high, middle = MAS[(left + right) / 2];

                while (MAS[left] > middle)
                    left++;
                while (MAS[right] < middle)
                    right--;

                if (left <= right)
                {
                    int temp = MAS[left];
                    MAS[left] = MAS[right];
                    MAS[right] = temp;
                    left++;
                    right--;
                }

                if (low < right)
                    Quick_Range(MAS, low, right, vect);
                if (left < high)
                    Quick_Range(MAS, left, high, vect);
            }
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>остортированный массив</returns>
        public static int[] QuickSort(int[] MAS, bool? vect = null)
        {
            bool vector = vect ?? false;

            Quick_Range(MAS, 0, MAS.Length - 1, vector);

            return MAS;
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] CountSort(int[] MAS, bool? vect = null)
        {
            int maxi = MAS.Max(), mini = MAS.Min();
            int[] polnmas = new int[2 * maxi + 1];
            int j;
            switch (vect)
            {
                case true:
                    for (int i = 0; i < MAS.Length; i++)
                        polnmas[MAS[i] + maxi]++;

                    j = MAS.Length - 1;

                    for (int i = mini; i <= maxi; i++)
                        for (int k = 0; k < polnmas[i + maxi]; k++)
                        {
                            MAS[j] = i;
                            j--;
                        }

                    break;

                case null:
                    for (int i = 0; i < MAS.Length; i++)
                        polnmas[MAS[i] + maxi]++;

                    j = 0;
                    for (int i = mini; i <= maxi; i++)
                        for (int k = 0; k < polnmas[i + maxi]; k++)
                        {
                            MAS[j] = i;
                            j++;
                        }

                    break;
            }

            return MAS;
        }
    }
}
