using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program snippets = new Program();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string paths = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);



            snippets.PrintFileSystemEntries(path);
            Console.ReadKey();

            string fileName = "test.txt";
            string sourcePath = path;
            string targetPath = paths;

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }



        void PrintFileSystemEntries(string path)
        {

            try
            {
                // Obtain the file system entries in the directory path.
                string[] directoryEntries =
                    System.IO.Directory.GetFileSystemEntries(path);

                foreach (string str in directoryEntries)
                {
                    System.Console.WriteLine(str);
                }
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, " +
                    "or contains invalid characters.");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.Console.WriteLine("The path encapsulated in the " +
                    "Directory object does not exist.");
            }
        }
        void PrintFileSystemEntries(string path, string pattern)
        {
            try
            {
                // Obtain the file system entries in the directory
                // path that match the pattern.
                string[] directoryEntries =
                    System.IO.Directory.GetFileSystemEntries(path, pattern);

                foreach (string str in directoryEntries)
                {
                    System.Console.WriteLine(str);
                }
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, " +
                    "or contains invalid characters.");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.Console.WriteLine("The path encapsulated in the " +
                    "Directory object does not exist.");
            }
        }

        // Print out all logical drives on the system.
        void GetLogicalDrives()
        {
            try
            {
                string[] drives = System.IO.Directory.GetLogicalDrives();

                foreach (string str in drives)
                {
                    System.Console.WriteLine(str);
                }
            }
            catch (System.IO.IOException)
            {
                System.Console.WriteLine("An I/O error occurs.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
        }
        void GetParent(string path)
        {
            try
            {
                System.IO.DirectoryInfo directoryInfo =
                    System.IO.Directory.GetParent(path);

                System.Console.WriteLine(directoryInfo.FullName);
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, or " +
                    "contains invalid characters.");
            }
        }
        void Move(string sourcePath, string destinationPath)
        {
            try
            {
                System.IO.Directory.Move(sourcePath, destinationPath);
                System.Console.WriteLine("The directory move is complete.");
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, " +
                    "or contains invalid characters.");
            }
            catch (System.IO.IOException)
            {
                System.Console.WriteLine("An attempt was made to move a " +
                    "directory to a different " +
                    "volume, or destDirName " +
                    "already exists.");
            }
        }
    }
}
