using System;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibrary
{
    public class ClassForTxt
    {
        public string ProcessData(string vuzName, int totalScore, string napravlenieName)
        {
            string filePath =  "C:\\Users\\Пользователь\\Desktop\\kursach\\kursach\\spisok.txt";

            if (File.Exists(filePath))
            {
                // Читаем строки из файла
                string[] lines = File.ReadAllLines(filePath);

                // Создаем список для хранения баллов
                List<int> scores = new List<int>();

                // Проходимся по каждой строке файла
                foreach (string line in lines)
                {
                    // Проверяем, содержит ли текущая строка название направления
                    if (line.Contains(napravlenieName) && line.Contains(vuzName))
                    {
                        // Разбиваем строку на части, используя пробел как разделитель
                        string[] parts = line.Split(' ');

                        // Последний элемент строки содержит баллы
                        if (parts.Length > 0)
                        {
                            // Пытаемся преобразовать последний элемент строки в число
                            if (int.TryParse(parts[parts.Length - 1], out int score))
                            {
                                // Добавляем балл в список
                                scores.Add(score);
                            }
                        }
                    }
                }

                // Добавляем баллы пользователя к списку
                scores.Add(totalScore);

                // Сортируем список баллов
                scores.Sort();
                scores.Reverse();
                // Находим позицию баллов пользователя в отсортированном списке
                int userRank = scores.IndexOf(totalScore) + 1;
                return userRank.ToString();

            }
            else
            {
                return "Файл пустой";
            }
        }
    }
    public class ClassForAchivments
    {
        public int GetAchievementScore(string achievement, string university, Dictionary<string, int> goldMedalScores, Dictionary<string, int> volunteerScores, Dictionary<string, int> gtoBadgeScores)
        {
            Dictionary<string, int> scores;

            // Выбираем соответствующий словарь в зависимости от достижения
            if (achievement == "золотая медаль")
            {
                scores = goldMedalScores;
            }
            else if (achievement == "волонтерская деятельность")
            {
                scores = volunteerScores;
            }
            else if (achievement == "золотой значок ГТО")
            {
                scores = gtoBadgeScores;
            }
            else
            {
                return 0; // Если достижение не распознано, возвращаем 0 баллов
            }

            // Проверяем, содержит ли словарь баллы для выбранного вуза
            if (scores.ContainsKey(university))
            {
                return scores[university]; // Возвращаем баллы для выбранного вуза и достижения
            }
            else
            {
                return 0; // Если баллы не указаны для выбранного вуза, возвращаем 0 баллов
            }
        }//подсчет баллов за достижения
    }
}
