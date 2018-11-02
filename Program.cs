using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CrimeAnalyzer
{
    class Program
    {
        public static List<Crimedata> crimeStatsList = new List<Crimedata>();
        static int first;
        static int second;
        static int totnumyears;
       
       

     

        static void Main(string[] args)
        {
            try
            {


                string[] lines = System.IO.File.ReadAllLines(@"CrimeData.csv");


                int x;
                for (x = 1; x < 21; x++)
                {

                    Crimedata data = new Crimedata();

                    string[] tokens = lines[x].Split(',');



                    data.year = int.Parse(tokens[0]);
                    data.population = int.Parse(tokens[1]);
                    data.violent = int.Parse(tokens[2]);
                    data.murder = int.Parse(tokens[3]);
                    data.rape = int.Parse(tokens[4]);
                    data.robbery = int.Parse(tokens[5]);
                    data.aggravated_assault = int.Parse(tokens[6]);
                    data.property = int.Parse(tokens[7]);
                    data.burglary = int.Parse(tokens[8]);
                    data.theft = int.Parse(tokens[9]);
                    data.vehicle = int.Parse(tokens[10]);

                    crimeStatsList.Add(data);
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File was not found please add to directory or add path to command line.");
                Console.ReadKey();
            }
            catch (Exception)
           {
                Console.WriteLine("There was a error when trying open,write, or read to the file. Or the data in the file wasn't the right amount or of the right type");
                Console.ReadKey();
            }
           

            var firstyear = from crimedata in crimeStatsList where crimedata.year <1995 select crimedata.year;                      //sets up a IEnumerable and puts in the first year that was in the crimedata.csv file
            foreach (var firstperiod in firstyear)
                {
                    first = firstperiod;                                                                                    //sets the first year equal to Program.first for future calling
                }

         var secondyear = from crimedata in crimeStatsList where crimedata.year > 2012 select crimedata.year;            //sets up a IEnumerable and puts in the second year that was in the crimedata.csv file
            foreach (var secondperiod in secondyear)
                {
                    second = secondperiod;                                                                                 //sets the second year equal to Program.second for future calling
                }
                                                                                                                    
         var manyyears = from crimedata in crimeStatsList select crimedata.year;                                                   //sets up a IEnumerable and puts in the how many years that were in the crimedata.csv file
            foreach (var allyears in manyyears)
            {
                totnumyears++;                                                                                                     //counts how many years there are in the file, totnumyears is used for future calling on total number of years
            }

         var lessmurders = from crimedata in crimeStatsList where crimedata.murder < 15000 select crimedata.year;            //sets up IEnumerable and puts all the years that had murders under 15,000
        List<string> name = new List<string>();                                                                            //makes string list called name      
            foreach (var lessmurderyears in lessmurders)
            {
                name.Add(Convert.ToString(lessmurderyears));                                                                   //converts integers to string and adds them to name
            }

         var robberieyears = from crimedata in crimeStatsList where crimedata.robbery > 500000  select crimedata.year;      //sets up a IEnumerable and puts all the years that had robberies greater than 50,000
        List<string> secondname = new List<string>();                                                                       //makes string list called second name
            foreach (var greatermurderyears in robberieyears)
            {
               
                secondname.Add(Convert.ToString(greatermurderyears));                                                                  //converts integers to string and adds them to secondname
            }

         var robberieamount = from crimedata in crimeStatsList where crimedata.robbery > 500000 select crimedata.robbery;           //sets up IEnumerable for robbery amounts over 50,000
         List<string> robberiename = new List<string>();                                                                            //makes string called robbriename      
            foreach (var murderamount in robberieamount)
            {
                
                robberiename.Add(Convert.ToString(murderamount));                                                                   //converts integers to string and adds them to robberiename
            }

            string population = null;

            var crimeper = from crimedata in crimeStatsList where crimedata.year == 2010 select crimedata.population;               //creates IEnumerable for population in the year 2010
            foreach(var pop in crimeper)
            {
                population = Convert.ToString(pop);                                                                                 //converts population in year 2010 from IEnumerable to string and puts it in population
            }

            string violent = null;
            var crimeinyear = from crimedata in crimeStatsList where crimedata.year == 2010 select crimedata.violent;              // gets violents crimes in the year 2010
            foreach(var violentcrimes in crimeinyear)
            {
                violent = Convert.ToString(violentcrimes);                                                                         //converts IENumerable to string and puts in violentcrime numbers into the violent string
            }
            double crimepercapita = double.Parse(violent) / double.Parse(population);                                              //does crime per capita equation by coverting violent and population strings to doubles and dividing them

            int count = 0;
            double murdertotal = 0;
            var averagemurders = from crimedata in crimeStatsList select crimedata.murder;                                      //sets a IEnumerable for all the murders
            foreach(var murder in averagemurders)
            {
                murdertotal += murder;                                                                                          //gets a total of all the murders
                count++;
            }
            double murderaverage = murdertotal / count;                                                                        //gets average of all murders by diving by count

            int secondcount = 0;
            double secondmurdertotal = 0;
            var secondaveragemurders = from crimedata in crimeStatsList where crimedata.year>1993 && crimedata.year<1998 select crimedata.murder;                //sets up IEnumerable for all murders inbetween year 1994-1997
            foreach(var secondmurder in secondaveragemurders)
            {
                secondmurdertotal += secondmurder;                                                                                                               //gets total of all murders between years
                secondcount++;
            }
            double secondmurderaverage = secondmurdertotal / secondcount;                                                                                        // gets average between those years by diving by second count

            int thirdcount = 0;
            double thirdmurdertotal = 0;
            var thirdaveragemurders = from crimedata in crimeStatsList where crimedata.year > 2009 && crimedata.year < 2015 select crimedata.murder;            //sets IEnumerable for murders between 2010 and 2014
            foreach(var thirdmurder in thirdaveragemurders)
            {
                thirdmurdertotal += thirdmurder;                                                                                                               //gets total amount of murders between those years
                thirdcount++;
            }
            double thirdmurderaverage = thirdmurdertotal / thirdcount;                                                                                        //gets average of murders inbetween those years

            
            double mintheftamount = 0;
            var minthefts = from crimedata in crimeStatsList where crimedata.year > 1998 && crimedata.year < 2005 select crimedata.theft;                       //IEnumerable for thefts inbetween 1999-2004
            foreach(var mintheft in minthefts)
            {

                if (mintheftamount == 0)                
                {
                    mintheftamount = mintheft;                                                                                                                  //if first time sets amount equal to the first theft amount
                }   
                else if (mintheft < mintheftamount)
                {
                    mintheftamount = mintheft;                                                                                                                 //if not first time checks to see if mintheft is less than mintheftamount, if so is sets mintheftamount = to mintheft.
                }
            }

            double maxtheftamount = 0;
            var maxthefts = from crimedata in crimeStatsList where crimedata.year > 1998 && crimedata.year < 2005 select crimedata.theft;               //sets IEnumerable for all thefts betwen 1999-2004
            foreach (var maxtheft in maxthefts)
            {
                if (maxtheftamount == 0)
                {
                    maxtheftamount = maxtheft;                                                                                                            //if first time sets amount equal to the first theft amount
                }
                else if (maxtheft > maxtheftamount)                                                                                                      //if not first time checks to see if maxtheft is greater than maxtheftamount, if so is sets maxtheftamount = to maxtheft.
                {
                    maxtheftamount = maxtheft;
                }
            }

            int mostamount = 0;
            var highestmvt = from crimedata in crimeStatsList select crimedata.vehicle;                                                                 //IEnumerable for motor vehicle thefts
            foreach(var theft in highestmvt)
            {
                if (mostamount == 0)                                                                                                                    //if first time sets mostamount equal to theft
                {
                    mostamount = theft;
                }
                else if (theft > mostamount)                                                                                                           //if not first time it'll check to see if theft is greater that most amount if it is it will set mostamount= to theft.
                {
                    mostamount = theft;
                }
            }

            int mvtyear = 0;
            var highestmvtyear = from crimedata in crimeStatsList where crimedata.vehicle==mostamount select crimedata.year;                       //IEnumerable for the year that has the highest motor vehicle theft amount 
            foreach(var year in highestmvtyear)
            {
                mvtyear = year;
            }


            Console.WriteLine("Period: " + first + "-" + second + " (" + totnumyears + " years)");
            Console.WriteLine();
            Console.WriteLine("Years murders per year < 15000: " + name[0]+","+name[1]+","+name[2]+","+name[3]);
            Console.WriteLine("Robberies per year > 500000: " + secondname[0] + " = " + robberiename[0]+ ","  + secondname[1] + " = " + robberiename[1] + ", " + secondname[2] + " = " + robberiename[2]);
            Console.WriteLine("Violent crime per capita rate (2010): "+ crimepercapita);
            Console.WriteLine("Average murder per year(all years): " + murderaverage);
            Console.WriteLine("Average murder per year (1994–1997): " + secondmurderaverage);
            Console.WriteLine("Average murder per year(2010–2014): " + thirdmurderaverage);
            Console.WriteLine("Minimum thefts per year (1999–2004): " + mintheftamount);
            Console.WriteLine("Maximum thefts per year (1999–2004): " + maxtheftamount);
            Console.WriteLine("Year of highest number of motor vehicle thefts: " + mvtyear);
           Console.ReadKey();
        }
    }
}
        
 
