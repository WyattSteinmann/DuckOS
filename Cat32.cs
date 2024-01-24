using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sys = Cosmos.System;

namespace DuckOS.Core
{
    public class Cat32
    {
        public void CreateFile(string path)
        {
            try
            {
                Sys.FileSystem.VFS.VFSManager.CreateFile(path);
                Console.WriteLine($"Your File \"{path}\" Was Sucessfully Created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DeleteFile(string path)
        {
            try
            {
                Sys.FileSystem.VFS.VFSManager.DeleteFile(path);
                Console.WriteLine($"Your File \"{path}\" Was Sucessfully Removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void CreateFolder(string path)
        {
            try
            {
                Sys.FileSystem.VFS.VFSManager.CreateDirectory(path);
                Console.WriteLine($"Your Folder \"{path}\" Was Sucessfully Created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DeleteFolder(string path)
        {
            try
            {
                Sys.FileSystem.VFS.VFSManager.DeleteDirectory(path, true);
                Console.WriteLine($"Your Folder \"{path}\" Was Sucessfully Removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Write(string path, string text)
        {
            try
            {
                if (Sys.FileSystem.VFS.VFSManager.FileExists(path))
                {
                    FileStream fs = (FileStream) Sys.FileSystem.VFS.VFSManager.GetFile(path).GetFileStream();
                    if (fs.CanWrite)
                    {
                        Byte[] data = Encoding.Unicode.GetBytes(text);
                        fs.Write(data, 0, data.Length);
                        fs.Close();
                        Console.WriteLine($"Sucessfully Put \"{text}\" In To File \"{path}\"");
                    }
                    else
                    {
                        Console.WriteLine($"The File \"{path}\" Is Not Open For Writeing");
                    }
                }
                else
                {
                    Console.WriteLine($"The Path \"{path}\" Does Not Exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string Read(string path)
        {
            try
            {
                if (Sys.FileSystem.VFS.VFSManager.FileExists(path))
                {
                    FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(path).GetFileStream();
                    if (fs.CanRead)
                    {
                        Byte[] data = new Byte[256];
                        fs.Read(data, 0, data.Length);
                        Console.WriteLine(Encoding.Unicode.GetString(data));
                    }
                    else
                    {
                        Console.WriteLine($"The File \"{path}\" Is Not Open For Reading");
                    }
                }
                else
                {
                    Console.WriteLine($"The Path \"{path}\" Does Not Exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return "";
        }
        public void info()
        {
            Console.WriteLine("Disk: Formated as Cat32");
            Console.WriteLine("Cat32 Mod Info: Max File Size 4GB, Max Drive Size 2TB, Mod: FAT32");
            Console.WriteLine("Cat32 FileSystem 1.0");
        }
        public void Erase()
        {
            try
            {
                Sys.FileSystem.VFS.VFSManager.DeleteDirectory(@"0:\", true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Check(string path)
        {
            try
            {
                if (Sys.FileSystem.VFS.VFSManager.FileExists(path))
                {
                    Console.WriteLine($"{path} Exists");
                }
                else
                {
                    Console.WriteLine($"{path} Does Not Exist");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void list(string path)
        {
            try
            {
                var directoryListing = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(path);

                foreach (var item in directoryListing)
                {
                    Console.WriteLine(item.mName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void WriteScriptToFile(string script, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, script);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing script to file: {ex.Message}");
            }
        }
    }
}
