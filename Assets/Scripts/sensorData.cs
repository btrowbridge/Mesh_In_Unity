
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using SocketIO;

[Serializable]
public class sensorData :  SocketIOEvent
{

    //sensor data members

    public compass compSensor;
    public magnometer magSensor;
    public barometer barometricSensor;
    public GPS gpsSensor;

    //Structs for these complex data members-------------
    //compass

    [Serializable]public struct compass
    {
        public compass(double orientation)
        {
            this.orientation = orientation;
        }
        public double orientation;
    }

    //magnetometer in each axis
    [Serializable]
    public struct magnometer
    {
        public magnometer(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double x;
        public double y;
        public double z;
    }

    //barometric pressure and temperature
    [Serializable]
    public struct barometer
    {
        public barometer(double pressure, double temperature)
        {
            this.pressure = pressure;
            this.temperature = temperature;
        }
        public double pressure;
        public double temperature;
    }

    // GPS
    [Serializable]
    public struct GPS
    {
        latitude lat;
        longitude lon;
        public GPS(latitude lat, longitude lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
        public struct latitude
        {
            public latitude(double degrees, double minutes, string direction)
            {
                this.degrees = degrees;
                this.minutes = minutes;
                this.direction = direction;
            }
            public double degrees;
            public double minutes;
            public string direction;
        }
        public struct longitude
        {
            public longitude(double degrees, double minutes, string direction)
            {
                this.degrees = degrees;
                this.minutes = minutes;
                this.direction = direction;
            }
            public double degrees;
            public double minutes;
            public string direction;
        }
    }
    // --------------------------------------------------

    
    public void parseBsonToSensorData(BsonDocument result)
    {

        compSensor = new compass(result["compass"].ToDouble());
        magSensor = new magnometer(result["magnometer.x"].ToDouble(), result["magnometer.y"].ToDouble(), result["magnometer.z"].ToDouble());
        barometricSensor = new barometer(result["barometer.pressure"].ToDouble(), result["barometer.temperature"].ToDouble());

        GPS.latitude lat = new GPS.latitude(result["latitude.degrees"].ToDouble(), result["latitude.minutes"].ToDouble(), result["latitude.direction"].ToString());
        GPS.longitude lon = new GPS.longitude(result["longitude.degrees"].ToDouble(), result["longitude.minutes"].ToDouble(), result["longitude.direction"].ToString());
        gpsSensor = new GPS(lat, lon);

    }

}

