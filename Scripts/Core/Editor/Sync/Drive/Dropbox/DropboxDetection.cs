using System;
using System.IO;
using System.Text;

namespace Assets.Scripts.Core.Editor.Sync.Drive.Dropbox
{
    public class DropboxDetection : IDriveDetection
    {
        public string DriveName
        {
            get { return "Dropbox"; }
        }

#if UNITY_STANDALONE_WIN
        public string DrivePath
        {
            get
            {
                var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Dropbox\\host.db";
                var lines = File.ReadAllLines(dbPath);
                var dbBase64Text = Convert.FromBase64String(lines[1]);
                return Encoding.ASCII.GetString(dbBase64Text);
            }
        }
#endif

#if UNITY_STANDALONE_OSX
        public string DrivePath
        {
            get
            { throw new NotImplementedException(); }
        }
#endif
    }
}