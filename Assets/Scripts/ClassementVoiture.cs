using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassementVoiture : MonoBehaviour
{
    public ClassementVoiture classement;
    public int numéro;
    [HideInInspector] public int numéroClassement;
    [HideInInspector] public int numéroClassement1;
    [HideInInspector] public int numéroClassement2;
    [HideInInspector] public float chrono;
    [HideInInspector] public float chrono1;
    [HideInInspector] public float chrono2;
    [HideInInspector] public float chrono3;
    [HideInInspector] public int tour1;
    [HideInInspector] public int tour;
    [HideInInspector] public int tour2;
    [HideInInspector] public int tours;
    [HideInInspector] public int tours1;
    [HideInInspector] public int tours2;
    [HideInInspector] public int tourTotal;
    [HideInInspector] public int tourTotal1;
    [HideInInspector] public int tourTotal2;
    public GameObject chronomètre;
    public GameObject toursPlayer;
    public GameObject tours1Player;
    public GameObject classement1Player;
    public GameObject classement2Player;
    public GameObject classement3Player;
    public GameObject classement1Player1;
    public GameObject classement2Player1;
    public GameObject classement3Player1;

    // Start is called before the first frame update
    public void Start()
    { 
        toursPlayer.GetComponent<Text>().text = "Tours : " + classement.tours;
        tours1Player.GetComponent<Text>().text = "Tours : " + classement.tours1;
        classement1Player.GetComponent<Text>().text = "1) You";
        classement2Player.GetComponent<Text>().text = "2) Player";
        classement3Player.GetComponent<Text>().text = "3) Bot";
        classement1Player1.GetComponent<Text>().text = "1) Player";
        classement2Player1.GetComponent<Text>().text = "2) You";
        classement3Player1.GetComponent<Text>().text = "3) Bot";
        numéroClassement = 0;
        numéroClassement1 = 0;
        numéroClassement2 = 0;
        chrono = 0;
        chrono1 = 0;
        chrono2 = 0;
        chrono3 = 0;
        tour = 0;
        tour1 = 0;
        tour2 = 0;
        tours = 0;
        tours1 = 0;
        tours2 = 0;
        tourTotal = 0;
        tourTotal1 = 0;
        tourTotal2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        chrono2 += Time.deltaTime;
        chronomètre.GetComponent<Text>().text = "Chrono : " + chrono2;
        
        int nbTours = classement.tours - 1;
        int nbTours1 = classement.tours1 - 1;
        int nbTours2 = classement.tours2 - 1;

        if (nbTours == -1)
            nbTours = 0;
        if (nbTours1 == -1)
            nbTours1 = 0;
        if (nbTours2 == -1)
            nbTours2 = 0;

        if (classement.tourTotal1 > classement.tourTotal && classement.tourTotal > classement.tourTotal2)
        {
            classement1Player.GetComponent<Text>().text = "1) Player " + nbTours1;
            classement2Player.GetComponent<Text>().text = "2) You " ;
            classement3Player.GetComponent<Text>().text = "3) Bot " + nbTours2;

            classement1Player1.GetComponent<Text>().text = "1) You ";
            classement2Player1.GetComponent<Text>().text = "2) Player " + nbTours; 
            classement3Player1.GetComponent<Text>().text = "3) Bot " + nbTours2;
        }

        if (classement.tourTotal2 > classement.tourTotal && classement.tourTotal > classement.tourTotal1)
        {
            classement1Player.GetComponent<Text>().text = "1) Bot " + nbTours2;
            classement2Player.GetComponent<Text>().text = "2) You ";
            classement3Player.GetComponent<Text>().text = "3) Player " + nbTours1;

            classement1Player1.GetComponent<Text>().text = "1) Bot " + nbTours2;
            classement2Player1.GetComponent<Text>().text = "2) Player " + nbTours;
            classement3Player1.GetComponent<Text>().text = "3) You ";
        }

        if (classement.tourTotal1 < classement.tourTotal && classement.tourTotal1 > classement.tourTotal2)
        {
            classement1Player.GetComponent<Text>().text = "1) You ";
            classement2Player.GetComponent<Text>().text = "2) Player " + nbTours1;
            classement3Player.GetComponent<Text>().text = "3) Bot " + nbTours2;

            classement1Player1.GetComponent<Text>().text = "1) Player " + nbTours;
            classement2Player1.GetComponent<Text>().text = "2) You ";
            classement3Player1.GetComponent<Text>().text = "3) Bot " + nbTours2;
        }

        if (classement.tourTotal2 < classement.tourTotal && classement.tourTotal2 > classement.tourTotal1)
        {
            classement1Player.GetComponent<Text>().text = "1) You ";
            classement2Player.GetComponent<Text>().text = "2) Bot " + nbTours2;
            classement3Player.GetComponent<Text>().text = "3) Player " + nbTours1;

            classement1Player1.GetComponent<Text>().text = "1) Player " + nbTours;
            classement2Player1.GetComponent<Text>().text = "2) Bot " + nbTours2;
            classement3Player1.GetComponent<Text>().text = "3) You ";
        }

        if (classement.tourTotal1 < classement.tourTotal2 && classement.tourTotal1 > classement.tourTotal)
        {
            classement1Player.GetComponent<Text>().text = "1) Bot " + nbTours2;
            classement2Player.GetComponent<Text>().text = "2) Player " + nbTours1;
            classement3Player.GetComponent<Text>().text = "3) You ";

            classement1Player1.GetComponent<Text>().text = "1) Bot " + nbTours2;
            classement2Player1.GetComponent<Text>().text = "2) You ";
            classement3Player1.GetComponent<Text>().text = "3) Player " + nbTours;
        }

        if (classement.tourTotal2 < classement.tourTotal1 && classement.tourTotal2 > classement.tourTotal)
        {
            classement1Player.GetComponent<Text>().text = "1) Player " + nbTours1;
            classement2Player.GetComponent<Text>().text = "2) Bot " + nbTours2;
            classement3Player.GetComponent<Text>().text = "3) You ";

            classement1Player1.GetComponent<Text>().text = "1) You ";
            classement2Player1.GetComponent<Text>().text = "2) Bot " + nbTours2;
            classement3Player1.GetComponent<Text>().text = "3) Player " + nbTours;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Vehicles (1)"))
        {
            if (numéro == 1 && classement.tour1 == 0)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                tours1Player.GetComponent<Text>().text = "Tours : " + classement.tours1;
                classement.tours1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 2 && classement.tour1 == 1)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 3 && classement.tour1 == 2)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 4 && classement.tour1 == 3)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 5 && classement.tour1 == 4)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 6 && classement.tour1 == 5)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 7 && classement.tour1 == 6)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 8 && classement.tour1 == 7)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 += 1;
                classement.tourTotal1++;
            }

            if (numéro == 9 && classement.tour1 == 8)
            {
                classement.numéroClassement1 = numéro;
                classement.chrono1 = chrono2;
                classement.tour1 = 0;
                classement.tourTotal1++;
            }
        }
        
        if(col.gameObject.CompareTag("Vehicles"))
        {
            if (numéro == 1 && classement.tour == 0)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1;
                toursPlayer.GetComponent<Text>().text = "Tours : " + classement.tours;
                classement.tours += 1;
                classement.tourTotal++;
            }

            if (numéro == 2 && classement.tour == 1)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1;
                classement.tourTotal++;
            }

            if (numéro == 3 && classement.tour == 2)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1;
                classement.tourTotal++;
            }

            if (numéro == 4 && classement.tour == 3)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1;
                classement.tourTotal++;
            }

            if (numéro == 5 && classement.tour == 4)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1;
                classement.tourTotal++;
            }

            if (numéro == 6 && classement.tour == 5)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1; 
                classement.tourTotal++;
            }

            if (numéro == 7 && classement.tour == 6)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1;
                classement.tourTotal++;
            }

            if (numéro == 8 && classement.tour == 7)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour += 1;
                classement.tourTotal++;
            }

            if (numéro == 9 && classement.tour == 8)
            {
                classement.numéroClassement = numéro;
                classement.chrono = chrono2;
                classement.tour = 0;
                classement.tourTotal++;
            }
        }

        if (col.gameObject.CompareTag("Player"))
        {
            if (numéro == 1 && classement.tour2 == 0)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tours2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 2 && classement.tour2 == 1)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 3 && classement.tour2 == 2)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 4 && classement.tour2 == 3)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 5 && classement.tour2 == 4)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 6 && classement.tour2 == 5)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 7 && classement.tour2 == 6)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 8 && classement.tour2 == 7)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 += 1;
                classement.tourTotal2++;
            }

            if (numéro == 9 && classement.tour2 == 8)
            {
                classement.numéroClassement2 = numéro;
                classement.chrono3 = chrono2;
                classement.tour2 = 0;
                classement.tourTotal2++;
            }
        }
    }
}
