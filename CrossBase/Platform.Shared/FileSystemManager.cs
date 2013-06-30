using System.IO;
using CrossBase.FileSystem;

namespace CrossBase.Platform.Shared
{
    public class FileSystemManager : IFileSystemManager
    {
        public string FileFind(string currentDir, string searchFile)
        {
            var files = Directory.GetFiles(currentDir);
            foreach (var file in files)
            {
                if (searchFile == Path.GetFileName(file))
                {
                    return file;
                }
            }

            var dirs = Directory.GetDirectories(currentDir);
            foreach (var dir in dirs)
            {
                var file = FileFind(dir, searchFile);
                if (file != string.Empty)
                    return file;
            }
            return string.Empty;
        }

        public void FileMove(string source, string destination)
        {
            File.Move(source, destination);
        }

        public void FileDelete(string file)
        {
            File.Delete(file);
        }

        public bool FileExists(string file)
        {
            return File.Exists(file);
        }

        public bool DirectoryExists(string dir)
        {
            return Directory.Exists(dir);
        }

        public void DirectoryCreate(string dir)
        {
            Directory.CreateDirectory(dir);
        }

        public byte[] FileReadAllBytes(string file)
        {
            return File.ReadAllBytes(file);
        }

        public void FileWriteAllBytes(string file, byte[] bytes)
        {
            File.WriteAllBytes(file, bytes);
        }

        public Stream FileOpen(string filename)
        {
            return File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public string[] DirectoryGetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        }

        public string FileReadAllText(string file)
        {
            return File.ReadAllText(file);
        }

        public void FileWriteAllText(string file, string contents)
        {
            File.WriteAllText(file, contents);
        }

        public void DirectoryDelete(string dir)
        {
            Directory.Delete(dir, true);
        }

        public void Dispose()
        {
            
        }
    }
}