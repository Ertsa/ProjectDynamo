using UnityEngine;
using UnityEngine;
using System.Collections;

public class MovingPoint : MonoBehaviour {
	
	public WheelCollider ve; //Listataan k?ytett?v?t WheelColliderit, jotta niiden "torque"-arvoja voidaan muuttaa ve = vasen etu jne jne...
	public WheelCollider oe;
	public WheelCollider vt;
	public WheelCollider ot;
	
	float vauhti;	// luodaan muuttujat joilla s??dell??n nopeutta ja k??ntyvyytt?	
	float kulma;
	
	float haistavittu; //koodille suutusp?iss?ni nimesin enk? jaksa muuttaa
	
	public float maksohjaus; //luodaan muuttujat joilla voi suoraan Inspectorista muuttaa nopeutta ja k??ntyvyytt?
	public float maksvauhti;
	public float automaattinenLiike;
	public float gravitaatio;

	// Start py?ritet??n l?pi vain kerran heti skriptin alettua
	void Start () {
		rigidbody.centerOfMass = new Vector3(0, -1, 1); //muutetaan auton massakeskipistett? ett? siit? tulee tukevampi
	}
	
	// Update py?ritet??n l?pi joka framessa
	void Update () {
		
		vauhti = Input.GetAxis("Vertical") * maksvauhti * Time.deltaTime * 250 + automaattinenLiike; //Input.Getaxis ja Input.GetButton kannattaa katsoa t??lt?: http://unity3d.com/learn/tutorials/modules/
		bool jarru = Input.GetButton("Jump");
		kulma = Input.GetAxis("Horizontal") * maksohjaus;

		if (vauhti >= maksvauhti) {
			vauhti = maksvauhti;
				}

		ve.steerAngle = kulma; //steerAngle s??t?? WheelCollideeraattoreiden suuntaa
		oe.steerAngle = kulma; //huom! Auto on etuvetoinen. K?sittelee eritavalla takavetoisena eli mahdollisuutta tweekkailla

		
		palautin ();
		
		if (jarru == true) {
			vt.brakeTorque = 200; //BrakeTorque on yksitt?isen WheelColliderin jarrutusvoima
			ot.brakeTorque = 200;
			ve.brakeTorque = 200;
			oe.brakeTorque = 200;
			ve.motorTorque = 0;	//MotorTorque on -II- liikkumisvoima
			oe.motorTorque = 0;
		
		} else {
			vt.brakeTorque = 0;
			ot.brakeTorque = 0;
			ve.brakeTorque = 0;
			oe.brakeTorque = 0;
			ve.motorTorque = vauhti;
			oe.motorTorque = vauhti;
		
		}
		
	}
	
	void palautin(){
		if (kulma == 0 && transform.localEulerAngles.y > 2 && transform.localEulerAngles.y < 358) {  // palautin eli jos autoa ei ohjata vasemmalle tai oikealle (kulma = 0) niin auto palautuu
			// x:n suuntaiselle linjalle haistavitun m??rittelem?ll? nopeudella
			if (transform.localEulerAngles.y < 180){												// tweakattava kuntoon kunhan saadaan mappi alle, kuten nopeus k??ntyvyys ja kitkakin
				haistavittu = -100;
			}else if(transform.localEulerAngles.y > 180){
				haistavittu = 100;										//iffin sis?iset iffit on aika sexyj? sellasessa laittomalla tavalla mutta jos nyt t?n kerran
			}
			transform.Rotate (Vector3.up, haistavittu * Time.deltaTime); //k?ytin rotatea koska helpompaa vaikkei n?in periaatteessa saisi tehd?, kokeile jos keksit parempaa ideaa joka
		}																// k?ytt?isi steerAnglea
	} //also tein siit? funktion koska ne on seksikk?it? ja kauniita ja helpottaa update constructorin ymm?rt?smist?


}

	
