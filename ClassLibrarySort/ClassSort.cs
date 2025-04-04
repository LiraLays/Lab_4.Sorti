using System;
using System.Linq;

namespace ClassLibrarySort
{
    public class ClassSort
    {
        /// <summary>
        /// Смена значений местами
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="left">первый индекс для смены значений в массиве</param>
        /// <param name="right">второй индекс для смены значений в массиве</param>
        private static void Swap(int[] MAS, int left, int right)
        {
            int temp = MAS[left];
            MAS[left] = MAS[right];
            MAS[right] = temp;
        }

        /// <summary>
        /// Сортировка методом Пузырька
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] BubbleSort(int[] MAS, bool vect = false)
        {
            for (int i = 0; i < MAS.Length; i++)
                for (int j = 0; j < MAS.Length - i - 1; j++)
                    if (MAS[j] > MAS[j + 1])
                        Swap(MAS, j, j + 1);

            if (vect)
                Array.Reverse(MAS);

            return MAS;
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] InsertSort(int[] MAS, bool vect = false)
        {
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

            if (vect)
                Array.Reverse(MAS);

            return MAS;
        }

        /// <summary>
        /// Рекурсивная сортировка слиянием
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="low">начальный индекс</param>
        /// <param name="high">конечный индекс</param>
        /// <param name="vect">направление сортировки (true - по убыванию, false - по возрастанию)</param>
        private static void Merge_Range(int[] MAS, int low, int high)
        {
            if (high - low > 1)
            {
                int left = low, l_mid = (low + high) / 2, r_mid = (low + high) / 2 + 1, right = high;

                Merge_Range(MAS, left, l_mid);
                Merge_Range(MAS, r_mid, right);

                int[] temp_MAS = new int[high - low + 1];

                for (int i = low; i <= high; i++)
                    temp_MAS[i - low] = MAS[i];

                int k = left, j = r_mid;

                for (int i = low; i <= high; i++)
                    if (k <= l_mid && j <= right)
                    {
                        if (temp_MAS[k - low] < temp_MAS[j - low])
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
                if (MAS[low] > MAS[high])
                    Swap(MAS, low, high);
        }

        /// <summary>
        /// сортировка слиянием
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>остортированный массив</returns>
        public static int[] MergeSort(int[] MAS, bool vect = false)
        {
            Merge_Range(MAS, 0, MAS.Length - 1);

            if (vect)
                Array.Reverse(MAS);
            return MAS;
        }

        /// <summary>
        /// Рекурсивная быстрая сортирока
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="low">левая граница</param>
        /// <param name="high">правая граница</param>
        /// <param name="vect">направление сортировки (false - по возрастанию, true - по убыванию)</param>
        private static void Quick_Range(int[] MAS, int low, int high)
        {
            int left = low, right = high, middle = MAS[(left + right) / 2];

            while (MAS[left] < middle)
                left++;
            while (MAS[right] > middle)
                right--;

            if (left <= right)
            {
                Swap(MAS, left, right);
                left++;
                right--;
            }

            if (low < right)
                Quick_Range(MAS, low, right);
            if (left < high)
                Quick_Range(MAS, left, high);

        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>остортированный массив</returns>
        public static int[] QuickSort(int[] MAS, bool vect = false)
        {
            Quick_Range(MAS, 0, MAS.Length - 1);

            if (vect)
                Array.Reverse(MAS);

            return MAS;
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] CountSort(int[] MAS, bool vect = false)
        {
            int maxi = MAS.Max(), mini = MAS.Min();
            int len = Math.Max(Math.Abs(mini), Math.Abs(maxi));
            int[] polnmas = new int[2 * len + 1];
            int j;

            for (int i = 0; i < MAS.Length; i++)
                polnmas[MAS[i] + len]++;

            j = 0;
            for (int i = mini; i <= maxi; i++)
                for (int k = 0; k < polnmas[i + len]; k++)
                {
                    MAS[j] = i;
                    j++;
                }

            if (vect)
                Array.Reverse(MAS);

            return MAS;
        }

        /// <summary>
        /// Сортировка элементов двух типов
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] TwoSort(int[] MAS, bool vect = false)
        {
            int left = 0, right = MAS.Length - 1;

            while (left < right)
            {
                while (left < right && MAS[left] == MAS.Min())
                    left++;
                while (left < right && MAS[right] == MAS.Max())
                    right--;

                Swap(MAS, left, right);
            }

            if (vect)
                Array.Reverse(MAS);

            return MAS;
        }

        /// <summary>
        /// Сортировка элементов трёх типов
        /// </summary>
        /// <param name="MAS">целочисленный массив</param>
        /// <param name="vect">направление сортировки (true - по убыванию, ничего - по возрастанию)</param>
        /// <returns>отсортированный массив</returns>
        public static int[] ThreeSort(int[] MAS, bool vect = false)
        {
            int[] uni = BubbleSort(MAS.ToList().Distinct().ToArray());
            int low = uni.Min(), high = uni.Max(), middle = Math.Abs(uni.Sum() - low - high);

            int left = 0;
            int mid = 0;
            int right = MAS.Length - 1;

            while (mid <= right)
            {
                if (MAS[mid] == middle)
                    mid++;
                else if (MAS[mid] == high)
                {
                    Swap(MAS, mid, right);
                    right--;
                }
                else
                {
                    Swap(MAS, left, mid);
                    left++;
                    mid++;
                }
            }

            if (vect) 
                Array.Reverse(MAS);

            return MAS;
        }

        public static int[] FourSort(int[] MAS, bool vect = false)
        {
            int[] uni = BubbleSort(MAS.ToList().Distinct().ToArray());
            int low, mid1, mid2, high;
            if (uni.Length == 4)
            {
                low = uni[0];
                mid1 = uni[1];
                mid2 = uni[2];
                high = uni[3];
            }
            else
            {
                low = uni.Min();
                high = uni.Max();
                mid1 = Math.Abs(uni.Sum() - low - high);
                mid2 = mid1;
            }

            int left = 0;
            int left_mid = 0;
            int right_mid = MAS.Length - 1;
            int right = MAS.Length - 1;
            int cur = 0;

            while (cur <= right_mid)
            {
                if (MAS[cur] == mid1)
                    cur++;
                else if (MAS[cur] == mid2)
                {
                    Swap(MAS, cur, right_mid);
                    right_mid--;
                }
                else if (MAS[cur] == low)
                {
                    Swap(MAS, cur, left);
                    left++;
                    left_mid++;
                    cur++;
                }
                else
                {
                    Swap(MAS, cur, right);

                    if (right > right_mid)
                    {
                        Swap(MAS, cur, right_mid);
                        right_mid--;
                    }

                    right--;
                }
            }

            return MAS;
        }
    }
}
