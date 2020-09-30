using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace facebookApp
{
    public class AppSettings
    {
        public bool RememberUser { get; set; }

        public string LastAccessToken { get; set; }

        public AppSettings()
        {
            RememberUser = false;
            LastAccessToken = null;
        }

        public void SaveToFile()
        {
            Stream stream = null;

            using (stream = new FileStream(@"appSettings.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadFromFile()
        {
            Stream stream = null;
            if(!File.Exists(@"appSettings.xml"))
            {
                return new AppSettings();
            }

            try
            {
                stream = new FileStream(@"appSettings.xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                return serializer.Deserialize(stream) as AppSettings;
            }
            catch(Exception e)
            {
                return new AppSettings();
            }
            finally
            {
                stream.Dispose();
            }
        }
    }
}