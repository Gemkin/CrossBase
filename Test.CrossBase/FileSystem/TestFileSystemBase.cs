using System.IO;
using CrossBase;
using NUnit.Framework;
using Test.CrossBase.Base;

namespace Test.CrossBase.FileSystem
{
    [TestFixture]
    public class TestFileSystemBase : TestBase
    {
        private const string LocalDir = "SomeDir";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            if (SystemServices.FileSystemManager.DirectoryExists(LocalDir))
                SystemServices.FileSystemManager.DirectoryDelete(LocalDir);
        }

        [Test]
        public void DirectoryCreateExists()
        {
            SystemServices.FileSystemManager.DirectoryCreate(LocalDir);
            Assert.That(SystemServices.FileSystemManager.DirectoryExists(LocalDir), Is.True);
        }

        [Test]
        public void DirectoryDelete()
        {
            SystemServices.FileSystemManager.DirectoryCreate(LocalDir);
            SystemServices.FileSystemManager.DirectoryDelete(LocalDir);
            Assert.That(SystemServices.FileSystemManager.DirectoryExists(LocalDir), Is.False);
        }

        [Test]
        public void DirectoryDeleteRecursive()
        {
            SystemServices.FileSystemManager.DirectoryCreate(LocalDir);
            SystemServices.FileSystemManager.DirectoryCreate(Path.Combine(LocalDir, LocalDir));
            SystemServices.FileSystemManager.DirectoryDelete(LocalDir);
            Assert.That(SystemServices.FileSystemManager.DirectoryExists(LocalDir), Is.False);
        }
    }
}