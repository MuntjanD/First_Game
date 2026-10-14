
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace StreetFighter_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int Level { get; set; } = 1;
        public int Health { get; set; } = 100;
        public int AttackPower { get; set; } = 10;

        private void OpenLevelUP_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно LevelUP
            LevelUP levelUpWindow = new LevelUP(this); // Передаем экземпляр MainWindow
            levelUpWindow.ShowDialog(); // Открываем как модальное окно
            UpdateStats();
        }

        private void UpdateStats()
        {
            // Здесь можно обновить UI или отобразить новые данные
            MessageBox.Show($"Уровень: {Level}\nЗдоровье: {Health}\nСила атаки: {AttackPower}");
        }

        Person person;
        Enemy enemy;
        Random random = new Random();
        ArrayList persons = new ArrayList();
        ArrayList enemys = new ArrayList();


        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Show a warning on startup if player name is not provided
            if (string.IsNullOrWhiteSpace(text_Name?.Text))
            {
                MessageBox.Show("First create a player name before starting the game.", "Player name required", MessageBoxButton.OK, MessageBoxImage.Warning);
                text_Name?.Focus();
            }
        }

        public void UpdateStats(int levelPerson, int levelEnemy)
        {
            levelEnemy = enemy.Health;
            levelPerson = person.Health;
            // Assume your MainWindow has these TextBlocks 
            //LevelPersonTextBlock.Text = levelPerson.ToString();
            //LevelEnemyTextBlock.Text = levelEnemy.ToString();
        }

        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            // Require player name before creating/starting the game
            if (string.IsNullOrWhiteSpace(text_Name?.Text))
            {
                MessageBox.Show("Please type a player name before starting the game.", "Player name required", MessageBoxButton.OK, MessageBoxImage.Warning);
                text_Name?.Focus();
                return;
            }

            enemy = new Enemy(50, 1, 100, "Enemy", 1, 11);
            person = new Person(50, 1, 100, "", 1, 11);
            Person.Count++;
            Enemy.Count++;
            person.Name = text_Name.Text;
            //person.Damage = person.rnd_dmg.Next(0, person.Damage);
            //enemy.Damage = enemy.rnd_dmg.Next(0, enemy.Damage);
            //person.Health = Convert.ToInt32(text_Health.Text);
            //person.Armor = Convert.ToInt32(text_Armor.Text);
            //MessageBox.Show(" Player Created !");
            //text_Name = "";
            //text_Damage = "";
            //text_Health = "";
            //text_Armor = "";
            List.Items.Add(person.printString());
            //List.Items.Add(enemy.E_printString());
            EnemyList.Items.Add(enemy.E_printString());
            person.Attack_Head = 10;
            person.Attack_Torso = 6;
            person.Attack_Leg = 3;
            enemy.Attack_Head = 10;
            enemy.Attack_Torso = 6;
            enemy.Attack_Leg = 3;

            persons.Add(person);
            enemys.Add(enemy);
        }

        public void UpdateList()
        {
            List.Items.Clear();
            foreach (Person a in persons)
                List.Items.Add(a.printString());

            //foreach (Enemy b in enemys)
            //List.Items.Add(b.E_printString());

        }
        public void E_UpdateList()
        {
            EnemyList.Items.Clear();
            foreach (Enemy b in enemys)

                EnemyList.Items.Add(b.E_printString());
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //int index = List.SelectedIndex;
            //if (index >= 0)
            //{
            //    person a = persons[index] as person;
            //    text_Name.Text = a.Name;
            //    text_Damage.Text = a.Damage.ToString();
            //    text_Health.Text = a.Health.ToString();
            //    text_Armor.Text = a.Armor.ToString();
            //    Enemy b = enemys[index] as Enemy;
            //    text_Name.Text = b.Name;
            //    text_Damage.Text = b.Damage.ToString();
            //    text_Health.Text = b.Health.ToString();
            //    text_Armor.Text = b.Armor.ToString();

            //}

        }

        private void Button_block_Click(object sender, RoutedEventArgs e)
        {
            {


                if (person.Health > 0 && enemy.Health > 0)

                {

                    //person.Health -= Convert.ToInt32(Enemy.rnd.Next(0, 3));//Convert.ToInt32(enemy.Damage - 6); //Convert.ToInt32(enemy.Damage);
                    //enemy.Health -= Convert.ToInt32(Person.rnd.Next(0, 3));//ToInt32(person.Damage);

                    label_PlayerDamage.Content = "DMG - " + person.Damage;
                    label_EnemyDamage.Content = " DMG - " + enemy.Damage;
                    pbhealth_enemy.Value = enemy.Health;
                    //pbhealth_enemy.Value = pbhealth_enemy.Value -= person.Damage;
                    pbhealth_person.Value = person.Health;
                    //pbhealth_person.Value = pbhealth_person.Value -= enemy.Damage;
                    person.Health -= enemy.Damage;
                    enemy.Health -= person.Damage;
                }

                UpdateList();
                E_UpdateList();
            }
        }


        public void Button_Attack_Click(object sender, RoutedEventArgs e)
        {
            // UpdateList();
            //E_UpdateList();



            //enemy.Damage = enemy.rnd_dmg.Next(0, enemy.Damage);
            //person.Damage = person.rnd_dmg.Next(0, person.Damage);
            if (person.Health > 0 && enemy.Health > 0)
            {
                int RND_Attack = enemy.rnd_dmg.Next(1, 4);
                if (RND_Attack == 1)
                {

                    enemy.Damage = enemy.Attack_Head;
                }
                if (RND_Attack == 2)
                {
                    enemy.Damage = enemy.Attack_Torso;
                }
                if (RND_Attack == 3)
                {
                    enemy.Damage = enemy.Attack_Leg;
                }


                int RND_Block = enemy.rnd_block.Next(1, 4);
                if (RND_Block == 1)
                {

                }
                if (RND_Block == 2)
                {

                }
                if (RND_Block == 3)
                {

                }

                if (person.Damage == RND_Block)
                {
                    person.Damage = 0;
                }
                if (RND_Attack == person.pBlock)
                {
                    enemy.Damage = 0;
                }



                person.Health -= enemy.Damage;

                enemy.Health -= person.Damage;


                label_PlayerDamage.Content = " DMG - " + person.Damage;
                {
                    if (person.Damage == 10)
                    {
                        label_PlayerDamage.Content = "HEAD  :" + person.Damage;
                    }
                    if (person.Damage == 6)
                    {
                        label_PlayerDamage.Content = "TORSO  :" + person.Damage;
                    }
                    if (person.Damage == 3)
                    {
                        label_PlayerDamage.Content = "LEG  :" + person.Damage;
                    }

                    if (person.Damage == 0)
                    {
                        label_PlayerDamage.Content = " MISS ";
                    }
                }
                label_EnemyDamage.Content = " DMG - " + enemy.Damage;
                {
                    if (enemy.Damage == 0)
                    {
                        label_EnemyDamage.Content = " MISS ";
                    }
                    if (enemy.Damage == 10)
                    {
                        label_EnemyDamage.Content = "HEAD  :" + enemy.Damage;
                    }
                    if (enemy.Damage == 6)
                    {
                        label_EnemyDamage.Content = "TORSO  :" + enemy.Damage;
                    }
                    if (enemy.Damage == 3)
                    {
                        label_EnemyDamage.Content = "LEG  :" + enemy.Damage;
                    }
                }

                //enemy.Damage = Enemy.rnd.Next(1, 11);
                //person.Damage = Person.rnd.Next(1, 11);

                //person.Health -=Convert.ToInt32(Enemy.rnd.Next(0, enemy.Damage)); //enemy.rnd_dmg.Next(0, enemy.Damage);   
                //enemy.Health -= Convert.ToInt32(Person.rnd.Next(0, person.Damage)); //person.rnd_dmg.Next(0, person.Damage);  
                //person.Health -= Convert.ToInt32(new Random().Next(enemy.MinDamage, enemy.MaxDamage));
                //enemy.Health -= Convert.ToInt32(new Random().Next(person.MinDamage, person.MaxDamage));
                //     label_PlayerDamage.Content = "DMG -" + person.Damage;// person.Damage;                    
                //     label_EnemyDamage.Content = "DMG -" + enemy.Damage;// enemy.Damage;



                //int enemyMiss = Convert.ToInt32(random.Next(0, 100));
                //int personMiss = Convert.ToInt32(random.Next(0, 100));

                //enemy.Damage = 0; // enemy.Damage = 0
                //person.Damage = 0;
                // For making a MISS Damage.....

                //if (enemyMiss > 30) // если больше 30 то попал
                //{
                //enemy.Damage = random.Next(enemy.MinDamage, enemy.MaxDamage);
                //person.Health -= Convert.ToInt32(enemy.Damage);
                //}

                //if (personMiss > 30)
                // {
                //person.Damage = random.Next(person.MinDamage, person.MaxDamage);
                //enemy.Health -= Convert.ToInt32(person.Damage);
                //}



            }

            pbhealth_enemy.Value = Convert.ToInt32(enemy.Health);
            //pbhealth_enemy.Value = pbhealth_enemy.Value -= person.Damage;
            //if (pbhealth_enemy.Value < 101)
            //{
            TxtEnemyHealthBar.Text = Convert.ToString(pbhealth_enemy.Value);   //+ Convert.ToString(enemy.Health);      //Convert.ToString(enemy.Health);

            //}
            pbhealth_person.Value = Convert.ToInt32(person.Health);
            //pbhealth_person.Value = pbhealth_person.Value -= enemy.Damage;
            //if (pbhealth_person.Value < 101)
            //{
            TxtPersonHealthBar.Text = Convert.ToString(pbhealth_person.Value);   //+ Convert.ToString(person.Health / 100000);      //Convert.ToString(enemy.Health);

            //}




            if (person.Health <= 0 && enemy.Health <= 0)
            {
                MessageBox.Show("Draw");
            }
            else if (person.Health <= 0)
            {
                MessageBox.Show("You LOST");
            }
            else if (enemy.Health <= 0)
            {
                //LevelUP levelUP = new LevelUP();


                //levelUP.Show();








                //levelUP.Close();

                //MessageBoxResult Result = MessageBox.Show("WIN Take Reward. <Yes + Head>  <NO + TORSO>  <Cancel + HP>","LVL UP - LVL ATTACK. ",MessageBoxButton.YesNoCancel);
                //if (Result == MessageBoxResult.Yes)
                // {
                //     person.Health = person.Health + 10;
                //     enemy.Health = 100;
                //     person.Attack_Head++;
                // }                 
                // if (Result == MessageBoxResult.No)
                // {
                //     person.Health = +10;
                //     enemy.Health = 100;
                //     person.Attack_Torso++;
                // }
                // if (Result == MessageBoxResult.Cancel)
                // {
                //     person.Health = 100;
                //     enemy.Health = 100;
                //     person.Health = person.Health + 10;
                // }
            }

            UpdateList();
            E_UpdateList();

        }



        private void PBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


            //Duration duration = new Duration(TimeSpan.FromSeconds(20)));
            //DoubleAnimation doubleanimation = new DoubleAnimation(200.0, duration);
            //PBar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);

        }
        //private void CreateDynamicProgressBarControl()
        //{
        //    ProgressBar PBar2 = new ProgressBar();
        //    PBar2.Value = person.Health;
        //    PBar2.Orientation = Orientation.Horizontal;
        //    PBar2.Width = person.Health - PBar2.Width;
        //    PBar2.Width = 200;
        //    PBar2.Height = 20;
        //    //Duration duration = new Duration(TimeSpan.FromSeconds(20)));
        //    //DoubleAnimation doubleanimation = new DoubleAnimation(200.0, duration);
        //    //PBar2.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        //    SBar.Items.Add(PBar2);
        //}

        public void pbhealth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //pbhealth.Value = person.Health;


        }

        private void EnemyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void Button_Attack_Head_Click(object sender, RoutedEventArgs e)
        //{
        //    if (person.Health > 0 && enemy.Health > 0)
        //    {
        //        //person.Damage = 10;
        //    }

        //}

        //private void Button_Attack_Torso_Click(object sender, RoutedEventArgs e)                        // FOR FUTURE BUTTONS ATTACK AND BLOCK/////
        // {
        //     if (person.Health > 0 && enemy.Health > 0)
        //     {
        //         //person.Damage = 6;
        //     }
        // }

        //private void Button_Attack_Leg_Click(object sender, RoutedEventArgs e)
        // {
        //     if (person.Health > 0 && enemy.Health > 0)
        //     {
        //         //person.Damage = 3;
        //     }
        // }

        //private void Button_Block_head_Click(object sender, RoutedEventArgs e)
        // {
        //     if (person.Health > 0 && enemy.Health > 0)
        //     {

        //     }
        // }

        private void CheckBox_Attack_Head_Checked(object sender, RoutedEventArgs e)
        {
            person.Damage = person.Attack_Head;
            person.pAttack = 1;
            //if (person.Health > 0 && enemy.Health > 0)
            //{


            //person.Damage = 10;
            //CheckBox_Attack_Torso.Visibility = Visibility.Hidden;
            //CheckBox_Attack_Leg.Visibility = Visibility.Hidden;
            CheckBox_Attack_Torso.IsChecked = false;
            CheckBox_Attack_Leg.IsChecked = false;

            // }
        }
        private void CheckBox_Attack_Head_CheckedChanged(object sender, RoutedEventArgs e)
        {

            //CheckBox_Attack_Head_CheckedChanged
            //CheckBox_Attack_Torso.Visibility = Visibility.Visible;
            //CheckBox_Attack_Leg.Visibility = Visibility.Visible;

        }

        private void CheckBox_Attack_Torso_Checked(object sender, RoutedEventArgs e)
        {
            person.Damage = person.Attack_Torso;
            person.pAttack = 2;
            //CheckBox_Attack_Head.Visibility = Visibility.Hidden;
            //CheckBox_Attack_Leg.Visibility = Visibility.Hidden;
            CheckBox_Attack_Head.IsChecked = false;
            CheckBox_Attack_Leg.IsChecked = false;
        }

        private void CheckBox_Attack_Leg_Checked(object sender, RoutedEventArgs e)
        {
            person.pAttack = 3;
            person.Damage = person.Attack_Leg;
            //CheckBox_Attack_Head.Visibility = Visibility.Hidden;
            //CheckBox_Attack_Torso.Visibility = Visibility.Hidden;
            CheckBox_Attack_Head.IsChecked = false;
            CheckBox_Attack_Torso.IsChecked = false;
        }

        private void CheckBox_Block_Head_Checked(object sender, RoutedEventArgs e)
        {
            person.pBlock = 1;
            CheckBox_Block_Torso.IsChecked = false;
            CheckBox_Block_Leg.IsChecked = false;
        }

        private void CheckBox_Block_Torso_Checked(object sender, RoutedEventArgs e)
        {
            person.pBlock = 2;
            CheckBox_Block_Head.IsChecked = false;
            CheckBox_Block_Leg.IsChecked = false;
        }

        private void CheckBox_Block_Leg_Checked(object sender, RoutedEventArgs e)
        {
            person.pBlock = 3;
            CheckBox_Block_Torso.IsChecked = false;
            CheckBox_Block_Head.IsChecked = false;
        }

        private void Button_Attack_Head_Click(object sender, RoutedEventArgs e)
        {

        }
    }



}