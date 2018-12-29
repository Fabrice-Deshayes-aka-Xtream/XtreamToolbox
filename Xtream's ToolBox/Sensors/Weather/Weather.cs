using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Net;
using System.IO;
using System.Globalization;

namespace Xtream_ToolBox.Sensors {

    [XmlRoot("response")]
    public class Weather {
        // http://api.wunderground.com/api/cc9fa911ce5ea9aa/conditions/q/cabourg,%20france.xml
        private const String serviceUrl = "http://api.wunderground.com/api/cc9fa911ce5ea9aa/conditions/q/";

        [XmlElement("current_observation")]
        public TWC_CO currentObservation;

        // default constructor
        public Weather() {
        }

        public static Weather GetCurrentConditionWeather(String codeLocation) {
            Weather weather = null;

            try {
                Uri uri = new Uri(serviceUrl + codeLocation+".xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Weather));

                WebResponse webResponse = HttpWebRequest.CreateDefault(uri).GetResponse();
                Stream stream = webResponse.GetResponseStream();
                weather = (Weather)xmlSerializer.Deserialize(stream);
                stream.Close();
                webResponse.Close();
            } catch (InvalidOperationException invalidOperationException) {
                Console.WriteLine(invalidOperationException.Message);
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }

            if (weather != null) {
                DateTime.TryParse(weather.currentObservation.time, out weather.currentObservation.timeDT);
                DateTime.TryParse(weather.currentObservation.lastupdateTime, out weather.currentObservation.lastupdateTimeDT);
            }
            return weather;
        }
    }

    public class TWC_CO
    {
        [XmlElement("local_time_rfc822")]
        public String time;
        public DateTime timeDT;
        [XmlElement("observation_time_rfc822")]
        public String lastupdateTime;
        public DateTime lastupdateTimeDT;

        [XmlElement("temp_c")]
        public String temp;
        [XmlElement("feelslike_c")]
        public String feelike;

        [XmlElement("relative_humidity")]
        public String relativeHumidity;
        [XmlElement("dewpoint_c")]
        public String dewpoint;

        [XmlElement("pressure_mb")]
        public String pressureMb;
        [XmlElement("pressure_trend")]
        public String pressureTrend;        

        [XmlElement("wind_kph")]
        public String windPower;
        [XmlElement("wind_dir")]
        public String windDirection;
        [XmlElement("wind_degrees")]
        public String windDegrees;

        [XmlElement("UV")]
        public String uv;
        [XmlElement("visibility_km")]
        public String visibility;

        [XmlElement("icon")]
        public String icon;
        

        [XmlElement("display_location")]
        public DisplayLocation displayLocation;
    }

    public class DisplayLocation
    {
        [XmlElement("full")]
        public String name;
        [XmlElement("latitude")]
        public String latitude;
        [XmlElement("longitude")]
        public String longitude;
    }
}