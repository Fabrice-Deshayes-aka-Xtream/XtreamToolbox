using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Xtream_ToolBox {
    [Serializable]
    public class Location {
        // different location's type possible
        public const int FILESYSTEM = 1;
        public const int WEBSITE = 2;
        public const int APPLICATION = 3;
        public const int RSSFEED = 4;
        public const int CALENDAR = 5;
        public const int POP3ACCOUNT = 6;

        // for quicklaunch location
        public const int PARAMETERS_POSITION_1ST_LINE = 1;
        public const int PARAMETERS_POSITION_2ND_LINE = 2;

        // for quicklaunch location
        public const int PARAMETERS_TYPE_SHORTCUT = 1;
        public const int PARAMETERS_TYPE_SEPARATOR = 2;

        // for calendar location
        public const int PARAMETERS_TYPE_LOCAL = 1;
        public const int PARAMETERS_TYPE_REMOTE = 2;

        private String myName;
        private int myType;
        private String myLocation;
        private Dictionary<String, String> myParameters = new Dictionary<string,string>();

        // Constructeur
        public Location(String name, int type, String location) {
            myName = name;
            myType = type;
            myLocation = location;
        }

        public string name {
            get {
                return myName;
            }
            set {
                myName = value;
            }
        }

        public string completeName {
            get {
                return myName + " (" + myLocation + ")";
            }
        }

        public int type {
            get {
                return myType;
            }
            set {
                myType = value;
            }
        }

        public string location {
            get {
                return myLocation;
            }
            set {
                myLocation = value;
            }
        }

        public Dictionary<String, String> parameters {
            get {
                return myParameters;
            }
        }

        // Convertie un objet location en string type|name|location
        public String toDelimitedString() {
            String retour = myType + "|" + myName + "|" + myLocation;
            System.Collections.IEnumerator dictionnaryEnumerator = myParameters.GetEnumerator();
            while (dictionnaryEnumerator.MoveNext()) {
                KeyValuePair<String, String> current = (KeyValuePair<String, String>)dictionnaryEnumerator.Current;
                retour += "|" + current.Key + "|";
                retour += current.Value;
            }
            return retour;
        }

        // convertie une string type|name|location en un objet location
        public static Location fromString(String locationStr) {
            Location location = null;
            String[] parameters = locationStr.Split('|');
            if (parameters.Length >= 3) {
                location = new Location(parameters[1], Convert.ToInt16(parameters[0]), parameters[2]);
                int i = 3;
                while(i<parameters.Length){
                    location.myParameters.Add(parameters[i++], parameters[i++]);
                }
            }
            return location;
        }

        // insert new location Application in location list
        public static Location insertApplicationLocation(String filename, bool firstLine, int locationInsertIndex, String arguments, String description, String workingDirectory) {
            Location newLocation = null;
            String shortFilename;

            if (File.Exists(filename)) {
                // create new location and insert it into location list
                shortFilename = new FileInfo(filename).Name;
                shortFilename = shortFilename.Substring(0, shortFilename.Length - new FileInfo(filename).Extension.Length);
                newLocation = new Location(shortFilename, Xtream_ToolBox.Location.APPLICATION, filename);
                newLocation.parameters.Add("type", Convert.ToString(Xtream_ToolBox.Location.PARAMETERS_TYPE_SHORTCUT));
                newLocation.parameters.Add("imagePath", "");
                if (firstLine) {
                    newLocation.parameters.Add("position", Convert.ToString(Xtream_ToolBox.Location.PARAMETERS_POSITION_1ST_LINE));
                } else {
                    newLocation.parameters.Add("position", Convert.ToString(Xtream_ToolBox.Location.PARAMETERS_POSITION_2ND_LINE));
                }
                newLocation.parameters.Add("arguments", arguments);
                newLocation.parameters.Add("description", description);
                newLocation.parameters.Add("workingDirectory",workingDirectory);
                Properties.Settings.Default.location.Insert(locationInsertIndex, newLocation.toDelimitedString());
                Properties.Settings.Default.Save();
            }
            return newLocation;
        }

        public static Location insertSeparator(int locationInsertIndex, bool firstLine) {
            Location newLocation = new Location(DateTime.Now.ToLongTimeString(), Xtream_ToolBox.Location.APPLICATION, "SEPARATOR");
            newLocation.parameters.Add("type", Convert.ToString(Xtream_ToolBox.Location.PARAMETERS_TYPE_SEPARATOR));
            if (firstLine) {
                newLocation.parameters.Add("position", Convert.ToString(Xtream_ToolBox.Location.PARAMETERS_POSITION_1ST_LINE));
            } else {
                newLocation.parameters.Add("position", Convert.ToString(Xtream_ToolBox.Location.PARAMETERS_POSITION_2ND_LINE));
            }
            Properties.Settings.Default.location.Insert(locationInsertIndex, newLocation.toDelimitedString());
            Properties.Settings.Default.Save();
            return newLocation;
        }
    }
}
