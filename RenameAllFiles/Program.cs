/*
 Rename All Files in a Folder with increasing numbers like 1.jpg, 2.jpg, 3.jpg...etc.
 */

using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameAllFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Program ob = new Program();
                Console.Title = "Rename All Files";

                Console.WriteLine("How Do You Want To Rename Your Files?");
                Console.WriteLine("1.Input A New Name + Increasing Number");
                Console.WriteLine("2.Input A New Name + Original Filename");
                Console.WriteLine("3.Only Number");
                Console.WriteLine("4.Only File Extension");
                Console.WriteLine("Please Enter Your Choice");

                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        {
                            ob.Rename1();
                            break;
                        }
                    case 2:
                        {
                            ob.Rename2();
                            break;
                        }
                    case 3:
                        {
                            ob.Rename3();
                            break;
                        }
                    case 4:
                        {
                            ob.Rename4();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error");
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.Read();
        }

        void Rename1()
        {
            try
            {
                Console.WriteLine("Please enter the new name");
                string newname = Console.ReadLine();

                Console.WriteLine("Now Enter First Number");
                string startnumber = Console.ReadLine();
                int num = 0;

                Console.WriteLine("Please Enter The Full Director Path");
                string path = Console.ReadLine();

                string[] filePaths = Directory.GetFiles(path);

                int totalfiles = Directory.GetFiles(path).Length;
                num = Convert.ToInt32(startnumber);
                int i = 0;

                Console.Clear();
                foreach (string filename in filePaths)
                {
                    File.Move(filename, path + "\\" + newname + num++ + Path.GetExtension(filename));
                    i++;
                }
                Console.WriteLine("{0} Files Were Renamed Successfully", i);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void Rename2()
        {
            try
            {
                Console.WriteLine("Please enter the new name");
                string newname = Console.ReadLine();

                Console.WriteLine("Please Enter The Full Director Path");
                string path = Console.ReadLine();

                string[] filePaths = Directory.GetFiles(path);

                int totalfiles = Directory.GetFiles(path).Length;

                int i = 0;

                Console.Clear();
                foreach (string filename in filePaths)
                {
                    File.Move(filename, path + "\\" + newname + Path.GetFileName(filename));
                    i++;
                }
                Console.WriteLine("{0} Files Were Renamed Successfully", i);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void Rename3()
        {
            try
            {
                Console.WriteLine("Please Enter First Number From Where To Start");
                int startnumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Please Enter The Full Director Path");
                string path = Console.ReadLine();

                string[] filePaths = Directory.GetFiles(path);

                int totalfiles = Directory.GetFiles(path).Length;

                int i = 0;

                Console.Clear();
                foreach (string filename in filePaths)
                {
                    File.Move(filename, path + "\\" + startnumber++ + Path.GetExtension(filename));
                    i++;
                }
                Console.WriteLine("{0} Files Were Renamed Successfully", i);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void Rename4()
        {
            try
            {
                Console.WriteLine("Please Enter The File Extension Name");
                string ext = Console.ReadLine();

                Console.WriteLine("Please Enter The Full Director Path");
                string path = Console.ReadLine();

                string[] filePaths = Directory.GetFiles(path);

                int totalfiles = Directory.GetFiles(path).Length;

                int i = 0;

                Console.Clear();
                foreach (string filename in filePaths)
                {
                    File.Move(filename, path + "\\" + Path.GetFileNameWithoutExtension(filename) + "." + ext);
                    i++;
                }
                Console.WriteLine("{0} Files Were Renamed Successfully", i);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void currentfilename(string[] filepath, int num)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("\rCurrent File Name :- {0}", Path.GetFileName(filepath[num]));
        }

        int visit = 1;
        string dot()
        {
            Console.CursorVisible = false;

            if (visit == 1)
            {
                visit = 2;

                //Thread.Sleep(1000);
                return ".";
            }
            else if (visit == 2)
            {
                visit = 3;
                //Thread.Sleep(1000);
                return "..";
            }
            else if (visit == 3)
            {
                visit = 4;
                //Thread.Sleep(1000);
                return "...";
            }
            else
            {
                visit = 1;
                //Thread.Sleep(1000);
                return "   ";
            }

        }

    }
}