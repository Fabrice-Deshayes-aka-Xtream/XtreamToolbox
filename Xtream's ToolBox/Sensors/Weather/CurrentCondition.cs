using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace XtreamToolbox.Sensors
{

    public class CurrentCondition
    {
        /*
        id City ID
        name City name
        cod Internal parameter
        base Internal parameter
        visibility 
        coord
            coord.lon City geo location, longitude
            coord.lat City geo location, latitude
        weather (more info Weather condition codes)
            weather.id Weather condition id
            weather.main Group of weather parameters (Rain, Snow, Extreme etc.)
            weather.description Weather condition within the group
            weather.icon Weather icon id
        main
            main.temp Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
            main.pressure Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
            main.humidity Humidity, %
            main.temp_min Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
            main.temp_max Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
            main.sea_level Atmospheric pressure on the sea level, hPa
            main.grnd_level Atmospheric pressure on the ground level, hPa
        wind
            wind.speed Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
            wind.deg Wind direction, degrees (meteorological)
        clouds
            clouds.all Cloudiness, %
        rain
            rain.1h Rain volume for the last 1 hour, mm
            rain.3h Rain volume for the last 3 hours, mm
        snow
            snow.1h Snow volume for the last 1 hour, mm
            snow.3h Snow volume for the last 3 hours, mm
        dt Time of data calculation, unix, UTC
        sys
            sys.type Internal parameter
            sys.id Internal parameter
            sys.message Internal parameter
            sys.country Country code (GB, JP etc.)
            sys.sunrise Sunrise time, unix, UTC
            sys.sunset Sunset time, unix, UTC
        */
        private const String serviceUrl = "http://api.openweathermap.org/data/2.5/weather?APPID=21b1038d06dfc516332435c8477ec327&id=";

        public string Id { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; }
        public double Dt { get; set; }
        public Weather_weather[] Weather { get; set; }
        public Weather_main Main { get; set; }
        public Weather_coord Coord { get; set; }
        public Weather_wind Wind { get; set; }
        public Weather_Sys Sys { get; set; }
        public string TempUnits { get; set; }
        public string WindSpeedUnit { get; set; }
        public string PressureUnit { get; set; }
        public static List<string> AvailableIcons { get; } = new List<string>()
            { "01d","01n","02d","02n","03d","03n","04d","04n","09d","09n","10d","10n","11d","11n","13d","13n","50d","50n" };

        // default constructor
        public CurrentCondition()
        {
        }

        public static CurrentCondition GetCurrentCondition(String cityId, String tempUnit)
        {
            CurrentCondition currentCondition;
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    Uri uri = new Uri(serviceUrl + cityId + "&units=" + tempUnit);
                    var json = webClient.DownloadString(uri);
                    currentCondition = JsonConvert.DeserializeObject<CurrentCondition>(json);
                }

                switch (tempUnit)
                {
                    case "metric":
                        currentCondition.TempUnits = "°C";
                        currentCondition.WindSpeedUnit = "km/h";
                        currentCondition.PressureUnit = "hPa";
                        // convert wind speed from meter/second to km/second
                        currentCondition.Wind.Speed = (float)Math.Round(currentCondition.Wind.Speed * 3.6f);
                        break;
                    case "imperial":
                        currentCondition.TempUnits = "°F";
                        currentCondition.WindSpeedUnit = "mph";
                        currentCondition.PressureUnit = "hPa";
                        break;
                    default:
                        // Standard
                        currentCondition.TempUnits = "K";
                        currentCondition.WindSpeedUnit = "km/s";
                        currentCondition.PressureUnit = "hPa";
                        // convert wind speed from meter/second to km/second
                        currentCondition.Wind.Speed = (float)Math.Round(currentCondition.Wind.Speed * 3.6f);
                        break;
                }
            }
            catch (WebException)
            {
                // log we.Message
                return null;
            }

            return currentCondition;
        }

        public static DateTime ConvertUnixUTCToLocalDateTime(double unixUtc)
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(unixUtc);
            return dateTime.ToLocalTime();
        }
    }

    public class Weather_weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Main { get; set; }
        public string Id { get; set; }
    }

    public class Weather_main
    {
        public float Temp_max { get; set; }
        public float Temp_min { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public float Temp { get; set; }
    }

    public class Weather_coord
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class Weather_wind
    {
        public int Deg { get; set; }
        public float Speed { get; set; }
    }

    public class Weather_Sys
    {
        public double Sunset { get; set; }
        public double Sunrise { get; set; }
        public string Country { get; set; }
    }
}