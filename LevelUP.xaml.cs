using System.Windows;



namespace StreetFighter_Game
{
    public partial class LevelUP : Window
    {
        private MainWindow _mainWindow; // Ссылка на главное окно

        public LevelUP(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow; // Сохраняем ссылку на главное окно
        }

        //private void Button_ChangeLevel_Click(object sender, RoutedEventArgs e)
        //{
        //  _mainWindow.Level += 1; // Увеличиваем уровень
        //MessageBox.Show("Уровень повышен!");
        //this.Close();
        //}

        private void Button_LVL_Heal_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Health = 100; // Восстанавливаем здоровье
            MessageBox.Show("Здоровье восстановлено!");
            this.Close();
        }

        private void ButtButon_LVL_Damage_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AttackPower += 10; // Усиливаем атаку
            MessageBox.Show("Сила атаки увеличена!");
            this.Close();
        }

        private void Button_LVL_Block_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Level += 1; // Увеличиваем уровень
            MessageBox.Show("Уровень повышен!");
            this.Close();
        }

        //private void LvlUP_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {

        // }
    }
}


//namespace StreetFighter_Game
//{
//    /// <summary>
//    /// Логика взаимодействия для LevelUP.xaml
//    /// </summary>
//    public partial class LevelUP : Window
//    {
//        Person person;
//        Enemy enemy;


//        //public int levelPerson;
//        //public int levelEnemy;





//        public LevelUP()
//        {
//            InitializeComponent();

//        }

//        public void Button_LVL_Heal_Click(object sender, RoutedEventArgs e)
//        {

//            //LevelUP levelUP = new LevelUP();
//            //levelPerson  = 100;
//            //levelEnemy =  100;
//            //person.Health = 100;
//            //enemy.Health = 100;
//            //this.Close();

//            this.Close();












//        }

//        private void LvlUP_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            //person.printString();
//        }

//        //private void Buton_LVL_Damage_Click(object sender, RoutedEventArgs e)
//        //{
//        //    LevelUP lvlup = new LevelUP();

//        //    person.Attack_Head = +1;
//        //    person.Attack_Torso = +1;
//        //    person.Attack_Leg = +1;
//        //    person.Health = +10;
//        //    enemy.Health = 100;

//        //    this.Close();

//        //}

//    }
//}
