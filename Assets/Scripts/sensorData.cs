/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

[Serializable]
public class sensorData
{

    //sensor data members

    private compass compSensor;
    private magnometer magSensor;
    private barometer barometricSensor;
    private GPS gpsSensor;

    //Structs for these complex data members-------------
    //compass

    [Serializable]private struct compass
    {
        public compass(double orientation)
        {
            this.orientation = orientation;
        }
        double orientation;
    }

    //magnetometer in each axis
    [Serializable]
    private struct magnometer
    {
        public magnometer(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        double x;
        double y;
        double z;
    }

    //barometric pressure and temperature
    [Serializable]
    private struct barometer
    {
        public barometer(double pressure, double temperature)
        {
            this.pressure = pressure;
            this.temperature = temperature;
        }
        double pressure;
        double temperature;
    }

    // GPS
    [Serializable]
    private struct GPS
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
            double degrees;
            double minutes;
            string direction;
        }
        public struct longitude
        {
            public longitude(double degrees, double minutes, string direction)
            {
                this.degrees = degrees;
                this.minutes = minutes;
                this.direction = direction;
            }
            double degrees;
            double minutes;
            string directionpublic;
        }
    }
    // --------------------------------------------------
    /*
	 * Has acessability issues
	public void setNewSensorData(compass orientation, magnometer magField, barometer pressure, GPS gps){
		compSensor = orientation;
		magSensor = magField;
		barometricSensor = pressure;
		gpsSensor = gps;
	}
	 */
    //takes a Bsondocument, parses it and updates then sensors
    /*
    ; void parseBsonToSensorData(BsonDocument result)
    {

        compSensor = new compass(result["compass"].ToDouble());
        magSensor = new magnometer(result["magnometer.x"].ToDouble(), result["magnometer.y"].ToDouble(), result["magnometer.z"].ToDouble());
        barometricSensor = new barometer(result["barometer.pressure"].ToDouble(), result["barometer.temperature"].ToDouble());

        GPS.latitude lat = new GPS.latitude(result["latitude.degrees"].ToDouble(), result["latitude.minutes"].ToDouble(), result["latitude.direction"].ToString());
        GPS.longitude lon = new GPS.longitude(result["longitude.degrees"].ToDouble(), result["longitude.minutes"].ToDouble(), result["longitude.direction"].ToString());
        gpsSensor = new GPS(lat, lon);

    }

}
*/
