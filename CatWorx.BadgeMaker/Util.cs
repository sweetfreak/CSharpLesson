using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker {

    class Util {

        //method declared as "static"
        public static void PrintEmployees(List<Employee> employees)  {
            Console.WriteLine("The employees are as follows:");
            for (int i = 0; i < employees.Count; i++)
                {
                    string template ="{0,-10}\t{1,-20}\t{2}";
                      // each item in employees is now an Employee instance
                      // string format with template formatting check
                      // basically, offers a template for how to space everything out, then it places each argument in, based on the padding
                      Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
	                }
            
        }

        public static void MakeCSV(List<Employee> employees) {

            //check if "data" folder exists - if it doesn't, create it
            if (!Directory.Exists("data")) {
                Directory.CreateDirectory("data");
            }

            //use System.IO.StreamWriter to create a CSV file
            //write "using" so it disposes the StreamWriter Object after using it
            using (StreamWriter file = new StreamWriter("data/employees.csv")) {
                file.WriteLine("ID,Name,PhotoUrl");

                //loop over employees
                for (int i=0; i < employees.Count; i++) {
                    string template = "{0},{1},{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }

            }
        }

        async public static Task MakeBadges(List<Employee> employees) {
            // SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));

            // SKData data = newImage.Encode();
            // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
            
            //layout variables
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            int PHOTO_LEFT_X = 184;
        	int PHOTO_TOP_Y = 215;
        	int PHOTO_RIGHT_X = 486;
        	int PHOTO_BOTTOM_Y = 517;  

            int COMPANY_NAME_Y = 150;
            int EMPLOYEE_NAME_Y = 600;
            int EMPLOYEE_ID_Y = 730;
            
            using(HttpClient client = new HttpClient()) {
                for (int i = 0; i < employees.Count; i++) {

                    //gets the photo URL from the user(getphotoURL()) and thenencodes it into a stream: the SKImage
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));

                    //gets the background image and encodes it
                    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));   

                    //creates a new bitmap of the badge
                    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
                    //creates the canvas for the bitmap image
                    SKCanvas canvas = new SKCanvas(badge);

                    //places the background on the canvas, with a size (skRect)
                    canvas.DrawImage(background, new SKRect(0,0,BADGE_WIDTH, BADGE_HEIGHT));
                    //gives specific coordinates of where the photo should go
                    canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

                    SKPaint paint = new SKPaint();
                    paint.TextSize = 42.0f;
                    paint.IsAntialias = true;
                    paint.Color = SKColors.White;
                    paint.IsStroke = false;
                    paint.TextAlign = SKTextAlign.Center;
                    paint.Typeface = SKTypeface.FromFamilyName("Arial");          


                    canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH/2f, COMPANY_NAME_Y, paint);

                    paint.Color = SKColors.Black;
                    canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH/2f, EMPLOYEE_NAME_Y, paint);

                    paint.Typeface = SKTypeface.FromFamilyName("Courier New");
                    canvas.DrawText(employees[i].GetId().ToString(), BADGE_WIDTH/2f, EMPLOYEE_ID_Y, paint);

                    SKImage finalImage = SKImage.FromBitmap(badge);
                    SKData data = finalImage.Encode();

                    string template = "data/{0}_badge.png";
                    data.SaveTo(File.OpenWrite(string.Format(template, employees[i].GetId())));
                }
            }
        }
    }
}