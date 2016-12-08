using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Filochstränghantering
{
   
        class Program
        {
        static void Main(string[] args)
        {

            Console.WriteLine("Välj ditt alternativ: \n 1. SKriv till fil \n 2. Läs från fil \n 3. Reversa tecken \n 4. Reversa rader på en fil \n 5. Kopiera fil innehåll \n 6. Remove file");

            int val = int.Parse(Console.ReadLine());
            switch (val)
            {
                case 1:
                    skrivTillFil.skrivTill();
                    break;
                case 2:
                    läsFrånFil.läsFil();
                    break;
                case 3:
                    reverseFil.reversaTecken();
                    break;
                case 4:
                    reverseFil.reversaFil();
                    break;
                case 5:
                    reverseFil.kopieraFil();
                    break;
                case 6:
                    reverseFil.delete();
                    break;
            }
        }
        }

        class skrivTillFil
        {

            /* Write to file */
            public static void skrivTill()
            {
                //Naming a textfile
                Console.WriteLine("Vad vill du kala filen? ");
                string filNamn = Console.ReadLine();


                Console.WriteLine("Vill du skriva över filen eller lägga till ny text: J for att lägga till text, N för för att skriva över");
                string skriva = Console.ReadLine().ToUpper();
                //a Bool to decide if the statement is true or false. It's declared as true but it changes in the if-statement following its declaration and initiasion
                bool skrivaÖver = true;
                if (skriva == "J")
                {
                    skrivaÖver = true;
                }
                else if (skriva == "N")
                {
                    skrivaÖver = false;
                }
                else                                        //If itäs not either Y or N the program gives a message
                {
                Console.WriteLine("Not a valid option! Press any key to close the program");
                Console.ReadKey();
                Environment.Exit(0);                        //This closes the console
                }

                //filNamn is declared in the beginning of the main and it gives the file its name
                //skrivaÖver is either true or false and is added at when to write to a file. If true, text is added, if false text is overwritten
                StreamWriter utFil = new StreamWriter(filNamn + ".txt", skrivaÖver);
                Console.WriteLine("Skriv en rad till text filen");


                //this writes to the file
                string rad = Console.ReadLine();
                utFil.WriteLine(rad);
                //if you don't use Close(), then the program will not write to the file
                utFil.Close();
            }


        }

    class läsFrånFil
    {

        /* Read file */
        public static void läsFil()
        {
            //choose a file to open by its name
            Console.WriteLine("Filens namn som du vill ladda?");
            string namn = Console.ReadLine();
            try
            {
                StreamReader inFil = new StreamReader(namn + ".txt", true);


                //this loops all lines in the chosen textfile, untill it hits a blank line, therefore the break;

                /*   int n = 0;
                   while (true)
                   {
                       string text = inFil.ReadLine();

                       if (text == null)
                           break;
                       Console.WriteLine(text);
                       n++;
                   } */

                //instead of reading the text file lines untill it hits a blank row, it reads the whole textfile, blank rows included
                Console.WriteLine(inFil.ReadToEnd());
                Console.WriteLine("The program will now end. Press any key");
                Console.ReadKey();
                Environment.Exit(0);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error is '{0}'", e);
                Console.WriteLine(" ");
                Console.WriteLine("There is no file with that name. Do you want to create one? Y for yes and N for no");
                string skapaFil = Console.ReadLine().ToUpper();
                if (skapaFil == "Y")
                {
                    Console.WriteLine("Vad skall filen heta?");
                    string namnPåFilen = Console.ReadLine();
                    StreamWriter skapa = new StreamWriter(namnPåFilen + ".txt", true);
                    skapa.Close();
                    Console.WriteLine("Fil har skapats");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("The application will not close. Press any key to proceeed....");
                    Console.ReadKey();
                    
                }

                
                //inFil.Close();
            }


        }
        
       

    }

    class reverseFil
    {

        /* Reverse characters in rows' reverse order */
        public static void reversaTecken()
        {

            Console.WriteLine("Vad är filnamnet som du vill omvända?");
            string filename = Console.ReadLine();
            var lines = File.ReadAllLines(filename + ".txt").Reverse();

            //This code can be changed with the commented beneath it
            foreach (string line in lines)
            {               
                char[] charArray = line.ToCharArray();
                Array.Reverse(charArray);
                Console.WriteLine(charArray);
            }

            //The code above can also instead be changed with the following one instead
            /*
                foreach(string line in lines)
            {
                Console.WriteLine(line.Reverse().ToArray());
            } 
                */

            Console.ReadKey();
        }
        
        /* Reverse rows in a textfile */
        public static void reversaFil()
        {
            Console.WriteLine("Namnet på filen vars rader du vill omvända?");
            string filename = Console.ReadLine();
            var lines = File.ReadAllLines(filename+".txt").Reverse();

            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();
        }


        //Copy file contents to another file
        public static void kopieraFil()
            {

            Console.WriteLine("Ange namnet på filen som du vill kopiera");
            string filename = Console.ReadLine();

            var lines = File.ReadAllLines(filename + ".txt");

            Console.WriteLine("File opened properly \n What do you want to call the file where the content will be copied to?");

            string filename2 = Console.ReadLine();
            StreamWriter alex = new StreamWriter(filename2 + ".txt", true);

            Console.WriteLine("Följande har skrivits till " + filename2 + ".txt");

            foreach (string line in lines)
            {
                alex.WriteLine(line);
                Console.WriteLine(line);
            }          

            alex.Close();
            

            Console.ReadKey();
            
        }


        // Delete file
        public static void delete()
        {
            Console.WriteLine("Namnet på filen som du vill ta bort?");

            string filnamn = Console.ReadLine();

            if (System.IO.File.Exists(filnamn + ".txt"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(filnamn + ".txt");
                    Console.WriteLine("File deleted");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                Console.ReadKey();
            }
        }
    }

}
