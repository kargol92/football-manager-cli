﻿using System;

namespace FootballManager
{
    public abstract class Window
    {
        public static void displayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void setTitle(string title)
        {
            Console.Title = title;
        }

        public static void setDimensions(int width, int height)
        {
			try
			{
            	if (width <= Console.LargestWindowWidth && height <= Console.LargestWindowHeight)
            	{
                	Console.WindowWidth = width;
                	Console.WindowHeight = height;
                	Console.BufferWidth = width;
            	}
			}
			catch(Exception e) {
				displayMessage (e.Message);
				Console.ReadKey();
			}
        }

        public Window()
        {
            isRunning = true;
        }

        public void run()
        {
            while (isRunning && Program.isRunning)
            {
                update();
                draw();
                selectOption();
            }
        }



        protected static readonly string logo =
              "____ ____ ____ ___ ___  ____ _    _       _  _ ____ _  _ ____ ____ ____ ____ \n" +
              "|___ |  | |  |  |  |__] |__| |    |       |\\/| |__| |\\ | |__| | __ |___ |__/ \n" +
              "|    |__| |__|  |  |__] |  | |___ |___    |  | |  | | \\| |  | |__] |___ |  \\ \n";
        protected static readonly string version = "\t\t\t\t\t\t\t\t    v. 19.07";

        protected bool isRunning;
        protected string menu;
        protected int selectedNumber;
        protected string selectedOption;
        protected string[] options;

        protected abstract void update();
        protected abstract void draw();
        protected abstract void selectOption();

        protected void displayHeader()
        {
            Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine(menu + "\n");
        }

        protected void displayOptionsWithoutNumbers()
        {
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine(options[i]);
            Console.WriteLine();
        }

        protected void displayOptions()
        {
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine(i + 1 + ". " + options[i]);
            Console.WriteLine();
        }
    }
}