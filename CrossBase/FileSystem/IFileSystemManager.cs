
using System;
using System.IO;

namespace CrossBase.FileSystem
{
    public interface IFileSystemManager : IDisposable
    {
        string FileFind(string dir, string file);
        void FileMove(string source, string destination);
        void FileDelete(string file);
        bool FileExists(string file);
        bool DirectoryExists(string dir);
        void DirectoryCreate(string dir);
        byte[] FileReadAllBytes(string file);
        string[] DirectoryGetFiles(string path, string searchPattern);
        string[] DirectoryRecursivelyGetSubdirectories(string path);
        string FileReadAllText(string file);
        void DirectoryDelete(string dir);
        void FileWriteAllBytes(string file, byte[] bytes);
        void FileWriteAllText(string file, string contents);
        Stream FileOpen(string filename);
    }
}