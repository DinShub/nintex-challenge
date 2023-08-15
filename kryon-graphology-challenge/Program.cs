using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using kryon_graphology_challenge.Classes;
using kryongraphologychallenge.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kryon_graphology_challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //   /$$   /$$                                        
            //  | $$  /$$/                                        
            //  | $$ /$$/   /$$$$$$  /$$   /$$  /$$$$$$  /$$$$$$$ 
            //  | $$$$$/   /$$__  $$| $$  | $$ /$$__  $$| $$__  $$
            //  | $$  $$  | $$  \__/| $$  | $$| $$  \ $$| $$  \ $$
            //  | $$\  $$ | $$      | $$  | $$| $$  | $$| $$  | $$
            //  | $$ \  $$| $$      |  $$$$$$$|  $$$$$$/| $$  | $$
            //  |__/  \__/|__/       \____  $$ \______/ |__/  |__/
            //                       /$$  | $$                    
            //                      |  $$$$$$/                    
            //                       \______/                     

            // TODO: STAGE 1 - read and understand what this code is suppose to do //
            //string[] paths = { "demo-image-1.jpeg" };

            // Create a base path for the images
            const string BASE_IMAGE_PATH = "demo-image-";
            const int NUM_OF_IMAGES = 5;


            for (int i = 1; i <= NUM_OF_IMAGES; i++) // Changed it to be more dynamic as I can
            {
                // Creating the path
                string currPath = $"{BASE_IMAGE_PATH}{i}.jpeg";

                Console.WriteLine("\nReading challenge file " + currPath + "...\n");
                var process = HandwritingAnalyzer.ReadHandwrittenText("./Image-files/" + currPath);
                process.Wait();
                JToken result = process.Result;

                // TODO: STAGE 2 - fix the code so it prints the wanted results //
                // WANT TO ANALYZE HUGE AMOUNTS OF TEXT 
                // AND UTILIZE IT TO PARTICIPATE THE NEXT
                // INDUSTRIAL REVOLUTION? 

                // Created classes to deserialize the json into an object
                OCRResult ocrResult = JsonConvert.DeserializeObject<OCRResult>(result.ToString());

                // verify the OCR succeeded
                if (ocrResult.Status.Equals("Succeeded"))
                {
                    // Print the lines of the results
                    foreach(RecognitionResult recognitionResult in ocrResult.RecognitionResults)
                    {
                        // We might have more than one recognition results
                        foreach(Line line in recognitionResult.Lines)
                        {
                            Console.WriteLine($"Result: {line.Text}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed to read the text in the image file!");
                }
            }

            // TODO: STAGE 3 - find the connections between the outputs above //
            Console.WriteLine("\nCan you find the connection between the outputs above?");

            Console.WriteLine("They are all leaders of nations. Peter the Great was the first Tsar of Russia.");
            Console.WriteLine("Catherine the Great was the eighth Tsar of Russia");
            Console.WriteLine("George Washington was the first President of the USA");
            Console.WriteLine("Thomas Jefferson was the third President of the USA");

            // TODO: STAGE 4 - submit your answers, repo and CV, and join us for a cup of coffee //
            Console.WriteLine("\nSend us your solution with the github repo and your CV to challenge@kryonsystems.com and wait for our call!\n");
            Console.ReadLine();
        }
    }
}
