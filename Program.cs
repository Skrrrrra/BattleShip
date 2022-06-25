using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputpath = "D:\\SolutionsForSpaceApp\\2046\\input.txt";
            string outputpath = "D:\\SolutionsForSpaceApp\\2046\\output.txt";

            FileStream fs = new FileStream(inputpath, FileMode.OpenOrCreate);
            fs.Close();
            FileStream fsout = new FileStream(outputpath, FileMode.OpenOrCreate);
            fsout.Close();

            int countOfBoards;
            using (StreamReader reader1 = new StreamReader(inputpath))
            {
                countOfBoards = Convert.ToInt32(reader1.ReadLine());
            }



            //заполнение доски
            int height = 10;
            int length = 10;
            char[,] board = new char[length, height];

            string line;
            using (StreamReader reader = new StreamReader(inputpath))
            {
                for (int i = 0; i < height; i++)
                {
                    line = reader.ReadLine();
                    for (int j = 0; j < length; j++)
                    {
                        board[i, j] = line[j];
                    }
                }
            }

            //проверка на изгибы
            int counter = 0;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (
                        (board[i, j] == '*' && board[i + 1, j] == '*') &&
                        (board[i, j] == board[i + 1, j + 1] &&
                        (board[i, j] == board[i - 1, j - 1]))
                        )
                    {
                        counter++;
                    }
                    else
                    {
                        counter += 0;
                    }
                }
            }
            int sch = 0;

            int fourDeck = 0;
            int threeDeck = 0;
            int twoDeck = 0;
            int oneDeck = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (board[i, j] == '*')
                    {
                        sch++;
                    }
                    else
                    {
                        switch (sch)
                        {
                            case 1:
                                oneDeck++;
                                break;
                            case 2:
                                twoDeck++;
                                break;
                            case 3:
                                threeDeck++;
                                break;
                            case 4:
                                fourDeck++;
                                break;
                        }
                        sch = 0;
                    }
                }

            }
            using (StreamWriter writer = new StreamWriter(inputpath))
            {
                if (counter == 0 && oneDeck == 4 && twoDeck == 3 && threeDeck == 2 && fourDeck == 1)
                {
                    writer.WriteLine("YES");
                }
                else
                {
                    writer.WriteLine("NO");
                }
            }


        }
    }
}
