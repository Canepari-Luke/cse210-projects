using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SolarSystemSimulator
{
    public class SaveLoadManager
    {
        private const string SaveDirectory = "saves";

        public SaveLoadManager()
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
        }

        public void SaveSystem(SolarSystem system, string name)
        {
            string filePath = Path.Combine(SaveDirectory, $"{name}.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(SolarSystem));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, system);
            }
        }

        public SolarSystem LoadSystem(string name)
        {
            string filePath = Path.Combine(SaveDirectory, $"{name}.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(SolarSystem));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (SolarSystem)serializer.Deserialize(reader);
            }
        }

        public string[] GetSavedSystems()
        {
            string[] files = Directory.GetFiles(SaveDirectory, "*.xml");
            List<string> systemNames = new List<string>();
            foreach (string file in files)
            {
                systemNames.Add(Path.GetFileNameWithoutExtension(file));
            }
            return systemNames.ToArray();
        }
    }
}
