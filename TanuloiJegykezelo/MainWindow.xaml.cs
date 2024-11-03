using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TanuloiJegykezelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnAddGradeClick(object sender, RoutedEventArgs e)
        {
            // Ellenőrizzük, hogy a jegy érvényes szám-e és van-e kiválasztott tantárgy
            if (int.TryParse(GradeTextBox.Text, out int gradeValue) && SubjectComboBox.SelectedItem != null)
            {
                string selectedSubject = (SubjectComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                Grade newGrade = new Grade(selectedSubject, gradeValue);

                // Hozzáadjuk a jegyet a ListBox-hoz
                GradesListBox.Items.Add(newGrade);

                // Töröljük a beviteli mezőket
                GradeTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Kérlek, válassz tantárgyat és adj meg egy érvényes jegyet!");
            }
        }

        private void OnGradeClick(object sender, RoutedEventArgs e)
        {
            if (GradesListBox.SelectedItem != null)
            {
                Grade selectedGrade = GradesListBox.SelectedItem as Grade;
                MessageBoxResult result = MessageBox.Show($"Biztosan törölni szeretnéd a következő jegyet: {selectedGrade.Subject} - {selectedGrade.Value}?", "Jegy törlése", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    GradesListBox.Items.Remove(selectedGrade);
                }
            }
        }

        private void OnShowAllGradesClick(object sender, RoutedEventArgs e)
        {
            if (GradesListBox.Items.Count > 0)
            {
                string allGrades = "Összes jegy:\n";
                foreach (Grade grade in GradesListBox.Items)
                {
                    allGrades += $"{grade.Subject}: {grade.Value}\n";
                }
                MessageBox.Show(allGrades, "Összes jegy");
            }
            else
            {
                MessageBox.Show("Nincs megjelenítendő jegy.");
            }
        }
    }
}