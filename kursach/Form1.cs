using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static kursach.MyApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kursach
{
    public partial class MyApp : Form
    {
        int rus_score = 0;//создаем счетчик баллов для каждого предмета
        int math_score = 0;
        int inf_score = 0;
        int fiz_score = 0;
        int obc_score = 0;
        int ist_score = 0;
        int him_score = 0;
        int bio_score = 0;
        int yaz_score = 0;
        int geo_score = 0;
        int lit_score = 0;
        HashSet<string> yourSubjects = new HashSet<string>();//будем вносить сюда названия тех предметов, баллы которых были введены
        DataTable table; //создаем таблицу 1

        public struct vibor //создаем структуру
        {
            public string name;
            public int score;
            public vibor(string _name, int _score)
            {
                name = _name;
                score = _score;
            }
        }
        List<vibor> vibors = new List<vibor>();



        private void MyApp_Load(object sender, EventArgs e)//заполняем таблицу 1
        {
            vibors.Add(new vibor("Русский", 0));
            vibors.Add(new vibor("Математика", 0));
            vibors.Add(new vibor("Информатика", 0));
            vibors.Add(new vibor("Физика", 0));
            vibors.Add(new vibor("Обществознание", 0));
            vibors.Add(new vibor("История", 0));
            vibors.Add(new vibor("Химия", 0));
            vibors.Add(new vibor("Биология", 0));
            vibors.Add(new vibor("Иностранный язык", 0));
            vibors.Add(new vibor("География", 0));
            vibors.Add(new vibor("Литература", 0));


            table = new DataTable();
            table.Columns.Add("Предмет", typeof(string));
            table.Columns.Add("Балл", typeof(int));

            for (int i = 0; i < vibors.Count; i++)
            {
                table.Rows.Add(vibors[i].name, vibors[i].score);
            }

            input_table.DataSource = table;
            input_table.CellValueChanged += InputTable_CellValueChanged;
        }

        private void InputTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string subject = input_table.Rows[e.RowIndex].Cells[0].Value.ToString();
                int score = Convert.ToInt32(input_table.Rows[e.RowIndex].Cells[1].Value);

                if (subject == "Русский" && score<=100)
                    rus_score = score;

                else if (subject == "Математика" && score <= 100)
                    math_score = score;

                else if (subject == "Информатика" && score <= 100)
                    inf_score = score;

                else if (subject == "Физика")
                    fiz_score = score;

                else if (subject == "Обществознание" && score <= 100)
                    obc_score = score;

                else if (subject == "История" && score <= 100)
                    ist_score = score;

                else if (subject == "Химия" && score <= 100)
                    him_score = score;

                else if (subject == "Биология" && score <= 100)
                    bio_score = score;
                else if (subject == "Иностранный язык" && score <= 100)
                    yaz_score = score;
                else if (subject == "География" && score <= 100)
                    geo_score = score;

                else if (subject == "Литература" && score <= 100)
                    lit_score = score;

            }

        }//считываем баллы из таблицы



        Dictionary<string, List<Napravlenie>> vuzNapravleniya = new Dictionary<string, List<Napravlenie>>();//создаем список направлений

        public class Napravlenie//создаем его структуру
        {
            public string Name { get; set; }
            public int LastYearScore { get; set; }
            public int UserScore { get; set; }
            public string UserRank { get; set; }
            public string HowNuchPlaces { get; set; }
            public List<string> MainSubjects { get; set; }
            public List<string> OptionalSubjects { get; set; }

            public Napravlenie(string name, int lastYearScore, List<string> mainSubjects, List<string> optionalSubjects, int howmuchplaces)
            {
                Name = name;
                LastYearScore = lastYearScore;
                UserScore = 0;
                UserRank = "";
                HowNuchPlaces = howmuchplaces.ToString();
                MainSubjects = mainSubjects;
                OptionalSubjects = optionalSubjects;
            }
        }

        public MyApp()// заполнение таблицы 2
        {
            InitializeComponent();

            // Создание столбцов для таблицы DataGridView
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "Название направления";
            colName.Name = "colName";

            DataGridViewTextBoxColumn colLastYearScore = new DataGridViewTextBoxColumn();
            colLastYearScore.HeaderText = "Баллы прошлого года";
            colLastYearScore.Name = "colLastYearScore";

            DataGridViewTextBoxColumn colUserScore = new DataGridViewTextBoxColumn();
            colUserScore.HeaderText = "Баллы пользователя";
            colUserScore.Name = "colUserScore";

            DataGridViewTextBoxColumn colUserRank = new DataGridViewTextBoxColumn();
            colUserRank.HeaderText = "Номер в списке: пользователь/всего";
            colUserRank.Name = "colUserRank";

            // Добавление столбцов в DataGridView
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colName, colLastYearScore, colUserScore, colUserRank });
            int desiredWidth = 210;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = desiredWidth;
            }
            dataGridView.Height = 135;
            // Заполнение данных о направлениях
            FillNapravleniyaData();

            // Отображение направлений в таблице
            DisplayNapravleniya();
        }

        private void FillNapravleniyaData()//ввод данных о вузах, их напрвлениях и требованиях
        {
            // Вуз 1
            List<Napravlenie> vuz1Napravleniya = new List<Napravlenie>();

            List<string> mainSubjects1 = new List<string> { "Русский", "Математика" };
            List<string> optionalSubjects1 = new List<string> { "Физика", "Информатика" };
            vuz1Napravleniya.Add(new Napravlenie("Направление 1", 255, mainSubjects1, optionalSubjects1, 10));

            List<string> mainSubjects2 = new List<string> { "Русский", "Математика" };
            List<string> optionalSubjects2 = new List<string> { "Химия", "Информатика" };
            vuz1Napravleniya.Add(new Napravlenie("Направление 2", 244, mainSubjects2, optionalSubjects2, 7));

            vuzNapravleniya.Add("РТУ МИРЭА", vuz1Napravleniya);

            // Вуз 2
            List<Napravlenie> vuz2Napravleniya = new List<Napravlenie>();

            List<string> mainSubjects3 = new List<string> { "Русский", "Иностранный язык" };
            List<string> optionalSubjects3 = new List<string> { "Обществознание", "История" };
            vuz2Napravleniya.Add(new Napravlenie("Направление 3", 287, mainSubjects3, optionalSubjects3, 12));

            List<string> mainSubjects4 = new List<string> { "Русский", "Математика" };
            List<string> optionalSubjects4 = new List<string> { "Химия", "Биология" };
            vuz2Napravleniya.Add(new Napravlenie("Направление 4", 233, mainSubjects4, optionalSubjects4, 5));

            vuzNapravleniya.Add("МГТУ им. Баумана", vuz2Napravleniya);

            // Добавьте остальные вузы с их направлениями
        }
        Dictionary<string, int> goldMedalScores = new Dictionary<string, int>()
        {
            { "РТУ МИРЭА", 10 },
            { "МГТУ им. Баумана", 7 },
            // и так далее...
        };//словари для баллов за индивидуальные достижения
        Dictionary<string, int> volunteerScores = new Dictionary<string, int>()
        {
            { "РТУ МИРЭА", 6 },
            { "МГТУ им. Баумана", 5 },
            // и так далее...
        };
        Dictionary<string, int> gtoBadgeScores = new Dictionary<string, int>()
        {
            { "РТУ МИРЭА", 3 },
            { "МГТУ им. Баумана", 3 },
            // и так далее...
        };
        private void DisplayNapravleniya()//вывод 2 таблицы
        {
            dataGridView.Rows.Clear();
            Dictionary<string, int> subjectsScores = new Dictionary<string, int>()
            {
                { "Русский", rus_score },
                { "Математика", math_score },
                { "Информатика", inf_score },
                { "Физика", fiz_score },
                { "Обществознание", obc_score },
                { "История", ist_score },
                { "Химия", him_score },
                { "Биология", bio_score },
                { "Иностранный язык", yaz_score },
                { "География", geo_score },
                { "Литература", lit_score }
            };//список предметов, которые выбрал пользователь

            foreach (var kvp in subjectsScores)
            {
                if (kvp.Value > 0)
                {
                    yourSubjects.Add(kvp.Key);
                }
                else
                {
                    yourSubjects.Remove(kvp.Key);
                }
            }//если данные в таблице поменялись, то поменяет и список

            int GetSubjectScore(string subject)
            {
                if (subjectsScores.ContainsKey(subject))// Проверяем, содержит ли словарь subjectsScores ключ subject
                {
                    return subjectsScores[subject];// Если ключ subject содержится в словаре, возвращаем соответствующее ему значение (оценку)
                }
                else
                {
                    return 0; // Если ключ subject отсутствует в словаре, возвращаем 0, что может означать, что предмет не найден или оценка недоступна
                }
            } //функция принимает на вход имя предмета и возвращает оценку этого предмета из словаря 

            foreach (var kvp in vuzNapravleniya)
            {
                string vuzName = kvp.Key;
                List<Napravlenie> napravleniya = kvp.Value;

                foreach (var napravlenie in napravleniya)
                {
                    if (vuzName == cmbVuz.Text)
                    {
                        // Получаем состояние чекбоксов и выбранный вуз
                        string selectedUniversity = cmbVuz.SelectedItem.ToString();
                        // Функция для получения баллов за достижения в зависимости от вуза

                        int GetAchievementScore(string achievement, string university)
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

                        // Используем функцию GetAchievementScore() для получения баллов за каждое достижение
                        int goldMedalScore = goldbox.Checked ? GetAchievementScore("золотая медаль", selectedUniversity) : 0;
                        int volunteerScore = volontbox.Checked ? GetAchievementScore("волонтерская деятельность", selectedUniversity) : 0;
                        int gtoBadgeScore = gtobox.Checked ? GetAchievementScore("золотой значок ГТО", selectedUniversity) : 0;

                        // Общее количество баллов
                        int totalScore = goldMedalScore + volunteerScore + gtoBadgeScore;

                        // Проверяем, не превышает ли общее количество баллов 10
                        if (totalScore > 10)
                        {
                            totalScore = 10; // Если превышает, устанавливаем общее количество баллов равным 10
                        }

                        int n = 0;
                        bool flag2 = false;
                        int maxOptionalScore = 0;
                        napravlenie.UserScore = 0;
                        foreach (var i in napravlenie.MainSubjects)
                        {
                            if (yourSubjects.Contains(i))
                            {
                                n += 1;
                                napravlenie.UserScore += GetSubjectScore(i);
                            }
                        }//подсчет баллов с основных предметов

                        foreach (var i in napravlenie.OptionalSubjects)
                        {
                            if (yourSubjects.Contains(i))
                            {
                                flag2 = true;
                                int optionalScore = GetSubjectScore(i);
                                if (optionalScore > maxOptionalScore)
                                {
                                    maxOptionalScore = optionalScore;
                                }
                            }

                        }//максимум из предметов по выбору
                        if (napravlenie.MainSubjects.Count > 2 && napravlenie.OptionalSubjects.Count == 0) { flag2 = true; }
                        napravlenie.UserScore += maxOptionalScore;


                        string filePath = "C:\\Users\\Пользователь\\Desktop\\Study\\C#\\практика\\kursach\\spisok.txt";

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
                                if (line.Contains(napravlenie.Name) && line.Contains(vuzName))
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
                            scores.Add(napravlenie.UserScore + totalScore);

                            // Сортируем список баллов
                            scores.Sort();
                            scores.Reverse();
                            // Находим позицию баллов пользователя в отсортированном списке
                            int userRank = scores.IndexOf(napravlenie.UserScore + totalScore) + 1;

                            // Присваиваем значение userRank объекту napravlenie
                            napravlenie.UserRank = userRank.ToString() + "/" + napravlenie.HowNuchPlaces;

                        }//мируем место в списке(максимум мест задан в классе направления)
                        else
                        {

                            Console.WriteLine("Файл не найден.");
                        }// Обработка случая, когда файл не существует

                        if (n == napravlenie.MainSubjects.Count && flag2)
                        {
                            int rowIndex = dataGridView.Rows.Add();
                            dataGridView.Rows[rowIndex].Cells["colName"].Value = napravlenie.Name;
                            dataGridView.Rows[rowIndex].Cells["colLastYearScore"].Value = napravlenie.LastYearScore;
                            dataGridView.Rows[rowIndex].Cells["colUserScore"].Value = napravlenie.UserScore + totalScore;
                            dataGridView.Rows[rowIndex].Cells["colUserRank"].Value = napravlenie.UserRank;

                        }
                        //заполнение таблицы только в случае указания предметов, удовлетворяющих требованиям
                    }
                }//сверяем требования к предметам у направлений с предметами пользователя
            }//заполнение таблицы 2



            dataGridView.AutoResizeColumns();

            if (dataGridView.RowCount < 7)
            {
                dataGridView.Height = 135 + 20 * dataGridView.RowCount;
            }//размеры таблицы в соответствии с количеством напрвлений
            else
            {
                dataGridView.Height = 135 + 20 * 7;
            }//чтобы размеры не привысили размеры формы

        }
        private void cmbVuz_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayNapravleniya();
        }//обновление таблицы при выборе другого вуза

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = page_table;
        }//кнопка 1

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = page_score;
        }//кнопка 2

        private void button3_Click(object sender, EventArgs e)//кнопка для обновления таблицы
        {
            DisplayNapravleniya();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
