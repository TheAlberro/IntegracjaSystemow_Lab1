using System;
using System.Collections.Generic;
using System.IO;

namespace IntegracjaSystemow_Lab1
{

    
    class Program
    {
       
        string extract(string line)
        {
            string wynik="0";




            return wynik;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int exit = 0;
            string option = "0";
            int counter = 0;
            int[] max_lenght = new int[15];
            
            string[] labels = new string[]
                             {
                               "nazwa producenta"," przekątna ekranu","wymiary ekranu", "rodzaj powierzchni ekranu", "czy ekran jest dotykowy", 
                                 "nazwa procesora",  "liczba rdzeni fizycznych",  "prędkość taktowania MHz",
                                 "wielkość pamięci RAM", "pojemność dysku",
                            "rodzaj dysku", "nazwa układu graficznego", "pamięć układu graficznego",
                                 "nazwa systemu operacyjnego",  "rodzaj napędu fizycznego w komputerze"
               };
            while (exit==0)
            {
                counter = 0;
                int number_of_products = 0;
                for(int i=0;i<15;i++)
                {
                    max_lenght[i] = 0;
                }

                Console.WriteLine(" \n What you want to do? \n");
  
                Console.WriteLine(" Type 1 to run program \n");
                Console.WriteLine(" Type 2 to quit program \n");
                option = Console.ReadLine();
                if (option == "1" || option == "2")
                {
                    const string filename = "katalog.txt";
                    int actual_lenght = 0;

                    int choice = Int16.Parse(option);
                    switch (choice)
                    {
                        case 1:
                            
                          //  Console.Clear();
                            Console.WriteLine("Run program was selected \n");
                           // string[][] content = new string[14][];
                            
                            Console.Write(" Legenda: ");
                            for (int i=0; i<15;i++)
                            {
                               
                                int q = i + 1;
                                Console.Write(" numer " + q +" oznacza " +labels[i]+ "\n ");
                            }
                            for (int i = 0; i < 15; i++)
                            {
                                int q = i + 1;
                                Console.Write(" " + q + "    | ");
                            }
                            Console.Write(" \n");
                            try
                            {
                                int i = 14;
                                int j = 0;



                                 
                                // Exctract a max lenghts  
                                using (StreamReader reader = new StreamReader(filename))
                                {
                                    List<char> chars = new List<char>();
                                    while (reader.Peek() >= 0)
                                    {
                                        char c = (char)reader.Read();
                                      
                                        if (c.Equals(';'))
                                        {
                                            String slowo = new String(chars.ToArray());
                                            if (slowo == "")
                                            {
                                                slowo = "-----";
                                            }
                                            if(slowo.Length> max_lenght[counter % 15])
                                            {
                                                max_lenght[counter % 15] = slowo.Length;
                                            }
                                          //  Console.Write("<" + max_lenght[0] + ">" + slowo);

                                          
                                            
                                           
                                            counter++;
                                            chars = new List<char>();
                                            continue;
                                        }
                                        else
                                        {
                                            chars.Add(c);
                                        }
                                    }
                                }

                                for (int i1 = 0; i1 < 15; i1++)
                                {

                                    int q = i1 + 1;
                                  //  Console.Write("max dlugosc " + q + " to" + max_lenght[i1] + "\n ");
                                }
                                counter = 0;
                                // Create a StreamReader  
                                using (StreamReader reader = new StreamReader(filename))
                                    {
                                        List<char> chars = new List<char>();
                                        while (reader.Peek() >= 0)
                                        {
                                            char c = (char)reader.Read();
                                        //Console.WriteLine(c);
                                        if (c.Equals(';'))
                                        {
                                            String slowo = new String(chars.ToArray());
                                            if(slowo =="")
                                            {
                                                slowo = "-----";
                                            }

                                            if (counter % 15 == 0)  // need for print number of row
                                            {
                                                number_of_products++;
                                                
                                                Console.Write(number_of_products + ". ");
                                            }

                                            actual_lenght = max_lenght[counter % 15];   // need to calculate position of separator             
                                            // Console.WriteLine("Znalazłem separator ;");
                                            //  content[i][j] = slowo;
                                            //   Console.WriteLine(slowo );
                                            Console.Write( slowo);
                                            int roznica = actual_lenght - slowo.Length;
                                            for (int q1=0;q1<roznica;q1++)
                                            {
                                                Console.Write(" ");
                                            }
                                            Console.Write("|");
                                            //i++;
                                            //j++;
                                            //    chars.Clear();
                                            chars = new List<char>();
                                            counter++;
                                            continue;
                                        }
                                        else
                                        {
                                            chars.Add(c);
                                        }

                                        
                                    }
                                  /*  if (i > 13)
                                    {
                                        Console.Write(number_of_products + ". ");
                                        i = 0;
                                        number_of_products++;
                                    }*/

                                    /*
                                    string line;
                                    // Read line by line  
                                    while ((line = reader.ReadLine()) != null)
                                    {
                                        
                                        counter++;
                                        Console.WriteLine(counter);
                                        Console.WriteLine(line);
                                    }*/
                                }
                                j = 0;
                            }
                            catch (Exception exp)
                            {
                                Console.WriteLine(exp.Message);
                            }
                       
                            break;
                        case 2:
                            Console.Clear();
                            exit++;
                            break;
                        default:
                            Console.WriteLine(" Something was wrong. Try again \n");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("You typed wrong numbers \n");
                    Console.Clear();
                }

            }
            
            

            Console.WriteLine("Program was closed");

        }
    }
}
