/*
------------------------------------------------------------------------------



------------------------------------------------------------------------------
*/
using UnityEngine;
using System.Collections;
using MongoDB.Bson;
public class Node : MonoBehaviour
{
	private string nodeName{ get; set; }		//for identifying the server
	private sensorData nodeSensor;	//allowing nodes to have sensor data
	private int timeStamp{ get; set; }
	//public MongoDBServer myServer;

	//accessor methods -------------
	public string getName(){
		return nodeName;
	}
	public int getTimeStamp(){
		return timeStamp;
	}
	public void setTimeStamp(int time){
		timeStamp = time;
	}
	public sensorData pointToSensor(){
		return nodeSensor;
	}
	//---------------------------------

	//constructor
	public Node (string name)
	{
		nodeName = name;
	}

	//setup
	void Awake(){
		//grab server object
		//myServer = MongoDBServer.FindObjectOfType <MongoDBServer>();
		//myServer.addToNodeList (this);

		//update the node
		//myServer.updateNode (this);

	}
	void FixedUpdate(){
		//myServer.updateNode(this);
	}



}

public class sensorData {

	//sensor data members
	private compass magDegree;
	private magnometer magAxis;
	private barometer barometricSensor;
	private GPS gpsSensor;

	//Structs for these complex data members-------------
	//compass
	private struct  compass {
		public compass(double orientation){
			this.orientation = orientation;
		}
		double orientation;
	}
	//magnetometer in each axis
	private struct magnometer {
		public magnometer(double x, double y, double z){
			this.x = x;
			this.y = y;
			this.z = z;
		}
		double x;
		double y;
		double z;
	}
	//barometric pressure and temperature
	private struct barometer {
		public barometer( double pressure, double temperature){
			this.pressure = pressure;
			this.temperature = temperature;
		}
		double pressure;
		double temperature;
	}
	// GPS
	private struct GPS{
		latitude lat;
		longitude lon;
		public GPS(latitude lat, longitude lon){
			this.lat = lat;
			this.lon = lon;
		}
		public struct latitude{
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
		public struct longitude{
			public longitude(double degrees, double minutes, string direction)
			{
				this.degrees = degrees;
				this.minutes = minutes;
				this.direction = direction;
			}
			double degrees;
			double minutes;
			string direction;
		}
	}
	// --------------------------------------------------
	/*
	 * Has acessability issues
	public void setNewSensorData(compass orientation, magnometer magField, barometer pressure, GPS gps){
		magDegree = orientation;
		magAxis = magField;
		barometricSensor = pressure;
		gpsSensor = gps;
	}
	 */
	//takes a Bsondocument, parses it and updates then sensors
	public void parseBsonToSensorData(BsonDocument result){

		magDegree = new compass (result ["compass"].ToDouble ());
		magAxis = new magnometer (result ["magnometer.x"].ToDouble(), result ["magnometer.y"].ToDouble(), result ["magnometer.z"].ToDouble());
		barometricSensor = new barometer(result["barometer.pressure"].ToDouble(), result["barometer.temperature"].ToDouble());

		GPS.latitude lat = new GPS.latitude (result ["latitude.degrees"].ToDouble(), result ["latitude.minutes"].ToDouble(), result ["latitude.direction"].ToString());
		GPS.longitude lon = new GPS.longitude (result ["longitude.degrees"].ToDouble(), result ["longitude.minutes"].ToDouble(), result ["longitude.direction"].ToString());
		gpsSensor = new GPS (lat, lon);

	}

}