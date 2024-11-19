using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Biology_For_Begineers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MammalsPage : Page
    {
        public int _score = 0;
        public int _currentQuestionIndex = 0;
        public List<Mammals> _questions;

        public DispatcherTimer _timer;
        public int timeLeft;
        public MammalsPage()
        {
            this.InitializeComponent();
            LoadQuestions();
            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            _questions = new List<Mammals>()
            {
                new Mammals("Which is the Largest land animal?", new List<string>{"Elephant","Lion","Giraffe","Bear"}, 0),
                new Mammals("Which mammal is known for its ability to fly?", new List<string>{"Bat","Eagle","Squirrel","Kangaroo"}, 0),
                new Mammals("Which mammal is known as \"The king of the jungle\"?", new List<string>{"Lion","Tiger","Leopard","Cheetah"}, 0),
                new Mammals("Which mammal is famous for its long neck?", new List<string>{"Elephant","Camel","Giraffe","Horse"}, 2)
            };
        }

        private void DisplayQuestion()
        {
            timeLeft = 11;
            if(_currentQuestionIndex < _questions.Count)
            {
                Mammals question = _questions[_currentQuestionIndex];
                txtQuestion.Text = question.Question;
                txtChoices.ItemsSource = question.Choices;

                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += timeClick;
                _timer.Start();

                
            }
            else
            {
                txtResult.Text = $"Your Quiz is done. Your Score: {_score}/{_questions.Count}";
                txtChoices.Visibility = Visibility.Collapsed;
                txtTimer.Visibility = Visibility.Collapsed;
                txtQuestion.Visibility = Visibility.Collapsed;
            }
        }

        private void timeClick(object sender, object e)
        {
            timeLeft--;
            txtTimer.Text = timeLeft.ToString();
            if (timeLeft <= 0)
            {
                _timer.Stop();
                _currentQuestionIndex++;
                DisplayQuestion();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtChoices.SelectedIndex == -1)
            {
                txtResult.Text = "Select an option";
                return;
            }
            Mammals question = _questions[_currentQuestionIndex];
            if(txtChoices.SelectedIndex == question.CorrectAns)
            {
                _score++;
                txtResult.Text = "Correct";
            }
            else
            {
                txtResult.Text = "Wrong";
            }
            _timer.Stop();
            _currentQuestionIndex++;
            DisplayQuestion();
        }
    }
}
