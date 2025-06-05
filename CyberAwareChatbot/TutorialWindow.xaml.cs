using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CyberAwareChatbot
{
    public partial class TutorialWindow : Window
    {
        private readonly TaskManager _taskManager;
        private readonly ActivityLogger _logger;
        private int _totalPoints;
        private int _step;
        private string _password;

        public TutorialWindow(TaskManager taskManager, ActivityLogger logger, ref int totalPoints)
        {
            InitializeComponent();
            _taskManager = taskManager;
            _logger = logger;
            _totalPoints = totalPoints;
            LessonCombo.SelectionChanged += LessonCombo_SelectionChanged;
            LessonCombo.SelectedIndex = 0;
            _logger.LogAction("Opened tutorial window");
        }

        private void LessonCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _step = 0;
            InputText.Text = string.Empty;
            InputText.IsEnabled = true;
            if (LessonCombo.SelectedItem is ComboBoxItem item)
            {
                if (item.Content.ToString() == "Password Security")
                {
                    InstructionText.Text = "Step 1: Enter a password with at least 12 characters:";
                    _logger.LogAction("Started Password Security tutorial");
                }
                else
                {
                    InstructionText.Text = "Step 1: You receive an email with urgent language like 'Act now!'. Is this suspicious? (yes/no)";
                    _logger.LogAction("Started Phishing Awareness tutorial");
                }
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var lesson = (LessonCombo.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (lesson == "Password Security")
            {
                if (_step == 0)
                {
                    _password = InputText.Text.Trim();
                    if (_password.Length >= 12)
                    {
                        InstructionText.Text = "Step 2: Ensure it has uppercase, lowercase, numbers, and symbols:";
                        _step++;
                        InputText.Text = _password;
                        _logger.LogAction("Password tutorial: Passed length check");
                    }
                    else
                    {
                        MessageBox.Show("Password must be at least 12 characters. Try again!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        _logger.LogAction("Password tutorial: Failed length check");
                    }
                }
                else
                {
                    _password = InputText.Text.Trim();
                    bool isValid = _password.Length >= 12 &&
                                   _password.Any(char.IsUpper) &&
                                   _password.Any(char.IsLower) &&
                                   _password.Any(char.IsDigit) &&
                                   _password.Any(ch => !char.IsLetterOrDigit(ch));
                    if (isValid)
                    {
                        MessageBox.Show("Great job! Your password meets all requirements. +10 points!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        _totalPoints += 10;
                        _logger.LogAction("Completed Password Security tutorial: Success (+10 points)");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Password needs uppercase, lowercase, numbers, and symbols. Try again! +5 points for trying.", "Try Again", MessageBoxButton.OK, MessageBoxImage.Warning);
                        _totalPoints += 5;
                        _logger.LogAction("Completed Password Security tutorial: Failed complexity check (+5 points)");
                        Close();
                    }
                }
            }
            else if (lesson == "Phishing Awareness")
            {
                if (_step == 0)
                {
                    string answer = InputText.Text.Trim().ToLower();
                    if (answer == "yes")
                    {
                        MessageBox.Show("Correct! Urgent language is a common phishing tactic. +5 points!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        _totalPoints += 5;
                        _logger.LogAction("Phishing tutorial: Correct answer for step 1 (+5 points)");
                    }
                    else
                    {
                        MessageBox.Show("Not quite. Urgent language often indicates phishing. +2 points for trying!", "Try Again", MessageBoxButton.OK, MessageBoxImage.Warning);
                        _totalPoints += 2;
                        _logger.LogAction("Phishing tutorial: Incorrect answer for step 1 (+2 points)");
                    }
                    InstructionText.Text = "Step 2: Always verify the sender's email address and avoid clicking suspicious links.";
                    InputText.IsEnabled = false;
                    _step++;
                }
                else
                {
                    MessageBox.Show("Tutorial complete! Stay vigilant! +5 points.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _totalPoints += 5;
                    _logger.LogAction("Completed Phishing Awareness tutorial (+5 points)");
                    Close();
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _logger.LogAction("Closed tutorial window");
            Close();
        }
    }
}