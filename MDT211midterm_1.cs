using System;
using System.Collections.Generic;
enum RandomWord
{
    tennis = 1,
    football = 2,
    badminton = 3,
}
enum MenuGame
{
    PlayGame = 1,
    Exit
}
namespace MDT211midterm_1
{
    class HangMan {
        public int IncorrectScore = 0;
        protected RandomWord randomWord;

        public HangMan(int indexOfRandomWord) {
            this.randomWord = (RandomWord)indexOfRandomWord;
        }
        public void RndWord() {
            string randomword = randomWord.ToString();
        }
        public RandomWord getRndWord() {    
            return this.randomWord;
        }
        public int GetIncorrectScore()              
        {
            return this.IncorrectScore;
        }

        public string IsLetter(string randomWord, List<string> letterGuessed)           // method ของ hangman ที่ไว้แสดงตัวอักษรที่ถูกกับช่องที่เหลือ เปิด google มาครับ
        {
            string correctletters = "";

            for (int i = 0; i < randomWord.Length; i++) {

                string LetterInWord = Convert.ToString(randomWord[i]);
                if (letterGuessed.Contains(LetterInWord))
                {
                    correctletters += LetterInWord;
                }
                else
                {
                    correctletters += "_ ";
                }
            }
            return correctletters;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            PrintMenuHeader();      //แสดงหัวเมนู
            SelectMenu();           //เลือกเมนู


        }
        static void PrintMenuHeader()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("-----------------------");
            PrintMenu();
        }
        static void PrintMenu()         //แสดงตัวเลือกเมนู
        {
            Console.WriteLine("1. Play Game ");
            Console.WriteLine("2. Exit ");
            
        }
        static void SelectMenu()
        {
            Console.Write("Please Select Menu : ");

            MenuGame menu = (MenuGame)(int.Parse(Console.ReadLine()));
            MenuActivate(menu);
        }
        static void MenuActivate(MenuGame menu)     //ทำงานเมนูที่เลือก
        {
            if (menu == MenuGame.PlayGame)       // ถ้าเมนู = 1 คือเริ่มเกม
            {
                PlayHangman();     
            }
            else if (menu == MenuGame.Exit)     // ถ้าเมนู =2 ออกโปรแกรม
            {
                                   
            }
            else                                 //ใส่ผิด ให้ใส่เมนูใหม่
            {       
                Console.Clear();
                Console.WriteLine("Incorrect Menu. Please try again.");
                PrintMenu();
            }

        }
        static void PlayHangman()       //เริ่ม hangman
        {
            
            List<string> letterGuessed = new List<string>();        // list ตัวอักษรที่เราเดาที่จะใส่เข้าไปคำ

            Random random = new Random();
            int resultRandom = random.Next(1, 4);                   //  random เลข เพื่อไป random คำ
            HangMan hangman = new HangMan(resultRandom);            //  เอาเลขที่ random ได้ไปเปลี่ยนเป็นคำจาก enum ข้างบน
            string randomword = Convert.ToString(hangman.getRndWord());     //  เอาคำที่ได้เปลี่ยนไปใส่ในตัวแปร string
            
            int IncorrectScore = hangman.GetIncorrectScore();           //จำนวนครั้งที่ผิด
            hangman.IsLetter(randomword, letterGuessed);                // method ของ hangman ที่ไว้แสดงตัวอักษรที่ถูกกับช่องที่เหลือ
            

            while (IncorrectScore < 6) {            // ลูปจนกว่าผิดครบ 6 ครั้ง

                PrintHeaderPlayGame(ref IncorrectScore, hangman);       //แสดงหัวข้อเล่น hangman

                string lettersHint = hangman.IsLetter(randomword, letterGuessed);       //แสดง _ ตามจำนวนตัวอักษรคำที่สุม
                Console.WriteLine(lettersHint);

                if (lettersHint == randomword)      //  check ว่า ตัวอักษรกับคำตรงกันหมดหรือไม่ ถ้าตรงก็จบเกม
                {
                    Console.WriteLine("Your Win!!");
                    break;
                }

                Console.WriteLine("Input letter alphabet:");  //input ตัวอักษร
                string inputLetter = Console.ReadLine();

                letterGuessed.Add(inputLetter);
                if (randomword.Contains(inputLetter))  // ทำถูก วนลูปต่อ
                {

                }
                else //ทำผิด แต้มผิดจะเพิ่มแล้ววนลูปต่อ
                {
                    Console.Clear();
                    IncorrectScore++;

                }
                Console.WriteLine();    //ผิดครับ 6 ครั้ง จบโปรแกรม
                if (IncorrectScore == 6) {
                    Console.WriteLine("Game Over");
                }
            }
        }
        static void PrintHeaderPlayGame(ref int IncorrectScore, HangMan hangman) {
            
            Console.WriteLine("PLay Game HangMan");
            Console.WriteLine("-----------------");

            Console.WriteLine("Incorrect Score : {0}", IncorrectScore);
        }

    }
}
