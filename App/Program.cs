using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace App {
    internal class Program {
        static void Main(string[] args) {
            Output.Line("Enter Input: ");
            var inp = Console.ReadLine();
			Console.SetIn ( new StreamReader ( Console.OpenStandardInput ( 2048 ) ) );
            int WordCnt, CharCnt, NumCnt, SpecCnt;
            /********************** DO NOT EDIT ABOVE THIS LINE **********************************/
            
            
            
            //where my variables are
            WordCnt = 0;
            CharCnt = 0;
            NumCnt = 0;
            SpecCnt = 0;
            int sentenceCnt = 0;
            String[] splitArray = inp.Split();
            int numSpaces = splitArray.Length - 1;
            int index;
            int wordsPerSent = 0;
            int charPerSent = 0;
            List<int> wordsPerSentList = new List<int>();
            List<int> charPerSentList = new List<int>();


            //this for loop will do the WordCnt and CharCnt and be the main loop for everything
            foreach (String word in splitArray) //itterate through the splitarray and count the strings
            {
                //Console.WriteLine(word);
                WordCnt += 1; //adds plus one to the WordCnt
                CharCnt += word.Length; //adds the word.length to CharCnt
                wordsPerSent++;
                charPerSent += word.Length;
                index = 0;
                //this for loop will count the NumCnt variable and the special char count
                foreach (Char c in word) //interrates through each character in the word variable
                {

                    //this if statement will see if c is a digit
                    if (Char.IsDigit(c)) //this if uses the IsDigit function to check the c character
                    {
                        //Console.WriteLine(c + " is a digit");//writes the character c and says "is a digit"
                        NumCnt++; //adds plus one to the NumCnt
                    } 

                    
                    //this if statement will be my specical character counting takes place
                    if (!Char.IsLetterOrDigit(c)) //this if statement i use the Char.IsLetterOrDigit function but i use the exclamation "!" not to do the reverse to find the special character.
                    {
                        //Console.WriteLine(c + " is a special char"); //writess out the character c to the line
                        SpecCnt++; //adds plus one to the SpecCnt

                        //this if statement where i look for sentences
                        if(c == '.' || c == '?' || c == '!') //this compares to see if the character variable c is a ".", "?", "!" 
                        {
                            int lastIndex = word.Length - 1; //i make lastIndex variable = word.length
                            //this if statement checks the lastindex and compares to index
                            if (lastIndex == index) {
                                //Console.Write(" and is also a sentence ending mark"); //writes out the sentence marker to console
                                sentenceCnt++; //adds plus one to the sentence count
                                wordsPerSentList.Add(wordsPerSent); //add the wordsPerSent to the list

                                //this if else will determine the first sentence and add charPerSEnt to them.
                                if (wordsPerSentList.Count == 1) //if this is the first sentence
                                {
                                    charPerSent += (wordsPerSent - 1);//adds number of spaces to characters
                                }
                                //if it's not the first sentence
                                else //if it's not the first sentence
                                {
                                    charPerSent += wordsPerSent; //add charPerSent to the wordsPersent variable
                                }
                                charPerSentList.Add(charPerSent);
                                wordsPerSent = 0; //resets back to 0
                                charPerSent = 0; //resets Char to 0
                            }
                        }
                    }
                    index++;
                }
                
                //Console.WriteLine();
            }
            
            //this is where i write out to the console
            Console.WriteLine("word count: " + WordCnt);
            //Console.WriteLine("number of spaces: " + numSpaces);
            CharCnt += numSpaces;
            Console.WriteLine("char count: " + CharCnt);
            Console.WriteLine("num count: " + NumCnt);
            SpecCnt += numSpaces;
            Console.WriteLine("specical character count: " + SpecCnt);
            Console.WriteLine("sentence count: " + sentenceCnt);
            Console.WriteLine("average words per sentence: " + wordsPerSentList.Average());
            Console.WriteLine("average character per sentence: " + charPerSentList.Average());


            /*
            Console.WriteLine("words list: ");
            foreach (int words in wordsPerSentList)
            {
                Console.Write(words + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine("characters list: ");
            foreach (int c in charPerSentList)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            */



            // THIS SHOULD BE THE LAST STATEMENT FOR MAIN
            Console.Read();


        }



    }
}
