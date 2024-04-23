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
        int rus_score = 0;//������� ������� ������ ��� ������� ��������
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
        HashSet<string> yourSubjects = new HashSet<string>();//����� ������� ���� �������� ��� ���������, ����� ������� ���� �������
        DataTable table; //������� ������� 1

        public struct vibor //������� ���������
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



        private void MyApp_Load(object sender, EventArgs e)//��������� ������� 1
        {
            vibors.Add(new vibor("�������", 0));
            vibors.Add(new vibor("����������", 0));
            vibors.Add(new vibor("�����������", 0));
            vibors.Add(new vibor("������", 0));
            vibors.Add(new vibor("��������������", 0));
            vibors.Add(new vibor("�������", 0));
            vibors.Add(new vibor("�����", 0));
            vibors.Add(new vibor("��������", 0));
            vibors.Add(new vibor("����������� ����", 0));
            vibors.Add(new vibor("���������", 0));
            vibors.Add(new vibor("����������", 0));


            table = new DataTable();
            table.Columns.Add("�������", typeof(string));
            table.Columns.Add("����", typeof(int));

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

                if (subject == "�������")
                    rus_score = score;

                else if (subject == "����������")
                    math_score = score;

                else if (subject == "�����������")
                    inf_score = score;

                else if (subject == "������")
                    fiz_score = score;

                else if (subject == "��������������")
                    obc_score = score;

                else if (subject == "�������")
                    ist_score = score;

                else if (subject == "�����")
                    him_score = score;

                else if (subject == "��������")
                    bio_score = score;
                else if (subject == "����������� ����")
                    yaz_score = score;
                else if (subject == "���������")
                    geo_score = score;

                else if (subject == "����������")
                    lit_score = score;

            }

        }//��������� ����� �� �������



        Dictionary<string, List<Napravlenie>> vuzNapravleniya = new Dictionary<string, List<Napravlenie>>();//������� ������ �����������

        public class Napravlenie//������� ��� ���������
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

        public MyApp()// ���������� ������� 2
        {
            InitializeComponent();


            // �������� �������� ��� ������� DataGridView
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "�������� �����������";
            colName.Name = "colName";

            DataGridViewTextBoxColumn colLastYearScore = new DataGridViewTextBoxColumn();
            colLastYearScore.HeaderText = "����� �������� ����";
            colLastYearScore.Name = "colLastYearScore";

            DataGridViewTextBoxColumn colUserScore = new DataGridViewTextBoxColumn();
            colUserScore.HeaderText = "����� ������������";
            colUserScore.Name = "colUserScore";

            DataGridViewTextBoxColumn colUserRank = new DataGridViewTextBoxColumn();
            colUserRank.HeaderText = "����� � ������: ������������/�����";
            colUserRank.Name = "colUserRank";

            // ���������� �������� � DataGridView
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colName, colLastYearScore, colUserScore, colUserRank });
            int desiredWidth = 210;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = desiredWidth;
            }
            dataGridView.Height = 135;
            // ���������� ������ � ������������
            FillNapravleniyaData();

            // ����������� ����������� � �������
            DisplayNapravleniya();
        }

        private void FillNapravleniyaData()//���� ������ � �����, �� ����������� � �����������
        {
            // ��� 1
            List<Napravlenie> vuz1Napravleniya = new List<Napravlenie>();

            List<string> mainSubjects1 = new List<string> { "�������", "����������" };
            List<string> optionalSubjects1 = new List<string> { "������", "�����������" };
            vuz1Napravleniya.Add(new Napravlenie("����������� 1", 255, mainSubjects1, optionalSubjects1, 10));

            List<string> mainSubjects2 = new List<string> { "�������", "����������" };
            List<string> optionalSubjects2 = new List<string> { "�����", "�����������" };
            vuz1Napravleniya.Add(new Napravlenie("����������� 2", 244, mainSubjects2, optionalSubjects2, 7));

            vuzNapravleniya.Add("��� �����", vuz1Napravleniya);

            // ��� 2
            List<Napravlenie> vuz2Napravleniya = new List<Napravlenie>();

            List<string> mainSubjects3 = new List<string> { "�������", "����������� ����" };
            List<string> optionalSubjects3 = new List<string> { "��������������", "�������" };
            vuz2Napravleniya.Add(new Napravlenie("����������� 3", 287, mainSubjects3, optionalSubjects3, 12));

            List<string> mainSubjects4 = new List<string> { "�������", "����������" };
            List<string> optionalSubjects4 = new List<string> { "�����", "��������" };
            vuz2Napravleniya.Add(new Napravlenie("����������� 4", 233, mainSubjects4, optionalSubjects4, 5));

            vuzNapravleniya.Add("���� ��. �������", vuz2Napravleniya);

            // �������� ��������� ���� � �� �������������
        }
        Dictionary<string, int> goldMedalScores = new Dictionary<string, int>()
        {
            { "��� �����", 10 },
            { "���� ��. �������", 7 },
            // � ��� �����...
        };//������� ��� ������ �� �������������� ����������
        Dictionary<string, int> volunteerScores = new Dictionary<string, int>()
        {
            { "��� �����", 6 },
            { "���� ��. �������", 5 },
            // � ��� �����...
        };
        Dictionary<string, int> gtoBadgeScores = new Dictionary<string, int>()
        {
            { "��� �����", 3 },
            { "���� ��. �������", 3 },
            // � ��� �����...
        };
        private void DisplayNapravleniya()//����� 2 �������
        {
            dataGridView.Rows.Clear();
            Dictionary<string, int> subjectsScores = new Dictionary<string, int>()
            {
                { "�������", rus_score },
                { "����������", math_score },
                { "�����������", inf_score },
                { "������", fiz_score },
                { "��������������", obc_score },
                { "�������", ist_score },
                { "�����", him_score },
                { "��������", bio_score },
                { "����������� ����", yaz_score },
                { "���������", geo_score },
                { "����������", lit_score }
            };//������ ���������, ������� ������ ������������

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
            }//���� ������ � ������� ����������, �� �������� � ������

            int GetSubjectScore(string subject)
            {
                if (subjectsScores.ContainsKey(subject))// ���������, �������� �� ������� subjectsScores ���� subject
                {
                    return subjectsScores[subject];// ���� ���� subject ���������� � �������, ���������� ��������������� ��� �������� (������)
                }
                else
                {
                    return 0; // ���� ���� subject ����������� � �������, ���������� 0, ��� ����� ��������, ��� ������� �� ������ ��� ������ ����������
                }
            } //������� ��������� �� ���� ��� �������� � ���������� ������ ����� �������� �� ������� 

            foreach (var kvp in vuzNapravleniya)
            {
                string vuzName = kvp.Key;
                List<Napravlenie> napravleniya = kvp.Value;

                foreach (var napravlenie in napravleniya)
                {
                    if (vuzName == cmbVuz.Text)
                    {
                        // �������� ��������� ��������� � ��������� ���
                        string selectedUniversity = cmbVuz.SelectedItem.ToString();
                        // ������� ��� ��������� ������ �� ���������� � ����������� �� ����

                        int GetAchievementScore(string achievement, string university)
                        {
                            Dictionary<string, int> scores;

                            // �������� ��������������� ������� � ����������� �� ����������
                            if (achievement == "������� ������")
                            {
                                scores = goldMedalScores;
                            }
                            else if (achievement == "������������ ������������")
                            {
                                scores = volunteerScores;
                            }
                            else if (achievement == "������� ������ ���")
                            {
                                scores = gtoBadgeScores;
                            }
                            else
                            {
                                return 0; // ���� ���������� �� ����������, ���������� 0 ������
                            }

                            // ���������, �������� �� ������� ����� ��� ���������� ����
                            if (scores.ContainsKey(university))
                            {
                                return scores[university]; // ���������� ����� ��� ���������� ���� � ����������
                            }
                            else
                            {
                                return 0; // ���� ����� �� ������� ��� ���������� ����, ���������� 0 ������
                            }
                        }//������� ������ �� ����������

                        // ���������� ������� GetAchievementScore() ��� ��������� ������ �� ������ ����������
                        int goldMedalScore = goldbox.Checked ? GetAchievementScore("������� ������", selectedUniversity) : 0;
                        int volunteerScore = volontbox.Checked ? GetAchievementScore("������������ ������������", selectedUniversity) : 0;
                        int gtoBadgeScore = gtobox.Checked ? GetAchievementScore("������� ������ ���", selectedUniversity) : 0;

                        // ����� ���������� ������
                        int totalScore = goldMedalScore + volunteerScore + gtoBadgeScore;

                        // ���������, �� ��������� �� ����� ���������� ������ 10
                        if (totalScore > 10)
                        {
                            totalScore = 10; // ���� ���������, ������������� ����� ���������� ������ ������ 10
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
                        }//������� ������ � �������� ���������

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

                        }//�������� �� ��������� �� ������
                        if (napravlenie.MainSubjects.Count > 2 && napravlenie.OptionalSubjects.Count == 0) { flag2 = true; }
                        napravlenie.UserScore += maxOptionalScore;


                        string filePath = "C:\\Users\\������������\\Desktop\\Study\\C#\\��������\\kursach\\spisok.txt";

                        if (File.Exists(filePath))
                        {
                            // ������ ������ �� �����
                            string[] lines = File.ReadAllLines(filePath);

                            // ������� ������ ��� �������� ������
                            List<int> scores = new List<int>();

                            // ���������� �� ������ ������ �����
                            foreach (string line in lines)
                            {
                                // ���������, �������� �� ������� ������ �������� �����������
                                if (line.Contains(napravlenie.Name) && line.Contains(vuzName))
                                {
                                    // ��������� ������ �� �����, ��������� ������ ��� �����������
                                    string[] parts = line.Split(' ');

                                    // ��������� ������� ������ �������� �����
                                    if (parts.Length > 0)
                                    {
                                        // �������� ������������� ��������� ������� ������ � �����
                                        if (int.TryParse(parts[parts.Length - 1], out int score))
                                        {
                                            // ��������� ���� � ������
                                            scores.Add(score);
                                        }
                                    }
                                }
                            }

                            // ��������� ����� ������������ � ������
                            scores.Add(napravlenie.UserScore + totalScore);

                            // ��������� ������ ������
                            scores.Sort();
                            scores.Reverse();
                            // ������� ������� ������ ������������ � ��������������� ������
                            int userRank = scores.IndexOf(napravlenie.UserScore + totalScore) + 1;

                            // ����������� �������� userRank ������� napravlenie
                            napravlenie.UserRank = userRank.ToString() + "/" + napravlenie.HowNuchPlaces;

                        }//������ ����� � ������(�������� ���� ����� � ������ �����������)
                        else
                        {

                            Console.WriteLine("���� �� ������.");
                        }// ��������� ������, ����� ���� �� ����������

                        if (n == napravlenie.MainSubjects.Count && flag2)
                        {
                            int rowIndex = dataGridView.Rows.Add();
                            dataGridView.Rows[rowIndex].Cells["colName"].Value = napravlenie.Name;
                            dataGridView.Rows[rowIndex].Cells["colLastYearScore"].Value = napravlenie.LastYearScore;
                            dataGridView.Rows[rowIndex].Cells["colUserScore"].Value = napravlenie.UserScore + totalScore;
                            dataGridView.Rows[rowIndex].Cells["colUserRank"].Value = napravlenie.UserRank;

                        }
                        //���������� ������� ������ � ������ �������� ���������, ��������������� �����������
                    }
                }//������� ���������� � ��������� � ����������� � ���������� ������������
            }//���������� ������� 2



            dataGridView.AutoResizeColumns();

            if (dataGridView.RowCount < 7)
            {
                dataGridView.Height = 135 + 20 * dataGridView.RowCount;
            }//������� ������� � ������������ � ����������� ����������
            else
            {
                dataGridView.Height = 135 + 20 * 7;
            }//����� ������� �� ��������� ������� �����

        }
        private void cmbVuz_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayNapravleniya();
        }//���������� ������� ��� ������ ������� ����

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = page_table;
        }//������ 1

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = page_score;
        }//������ 2

        private void button3_Click(object sender, EventArgs e)//������ ��� ���������� �������
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