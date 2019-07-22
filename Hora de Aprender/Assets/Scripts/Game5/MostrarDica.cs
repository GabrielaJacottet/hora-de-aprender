﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDica : MonoBehaviour
{

    public static List<string> ListaCharacters = new List<string>(); //Lista de personagens
    public string FindCharacters;
    // public List<GameObject> goCharacters = new List<GameObject>(); //lista para colocar as figuras dos personagens e manipular via script
    public int SorteioDica;
    public int SorteioPosicao;
    public Vector3 Position;
    public Image FindReindeer;
    public Image FindPenguin;
    public Image FindPolarBear;
    public Image FindSnowman;
    public Image FindSiberianHusky;
    public Image FindSantaClaus;



    // Start is called before the first frame update
    void Start()
    {

        //adicionando os personagens na lista
        ListaCharacters.Add("TipReindeer");
        /*ListaCharacters.Add("TipPenguin");
        ListaCharacters.Add("TipPolarBear");
        ListaCharacters.Add("TipSnowman");
        ListaCharacters.Add("TipSiberianHusky");
        ListaCharacters.Add("TipSantaClaus");*/

        //Enquanto houver personagem na lista
          if (ListaCharacters.Count > 0)
            SorteioDica = Random.Range(0, ListaCharacters.Count - 1); //Sorteie um personagem
        
          //Pegando o nome do personagem sorteado
        FindCharacters = ListaCharacters[SorteioDica];

        //Removendo o Personagem sorteado da lista, para que ele não seja desabilitado no próximo comando
        ListaCharacters.RemoveAt(SorteioDica);

        //para cada personagem que não foi sorteado
        foreach (string i in ListaCharacters)  
            GameObject.Find(i).SetActive(false); // desative esse personagem
        
        //sorteando a posição que o personagem vai aparecer
         SorteioPosicao = Random.Range(0, 5);

        //colocando as posições nas variáveis
        if(SorteioPosicao == 0)
            Position = new Vector3(220f, -70f,0);//trenó
        else if (SorteioPosicao == 1)
            Position = new Vector3(255f, 70f,0);//igreja
        else if (SorteioPosicao == 2)
            Position = new Vector3(-135f, 20f,0);//iglu
        else if (SorteioPosicao == 3)
            Position = new Vector3(15f, 90f,0);//atrás casa
        else if (SorteioPosicao == 4)
            Position = new Vector3(-300f, 25f,0);//pinheiro
        else if (SorteioPosicao == 5)
            Position = new Vector3(-120f, 85f,0);//frente casa



        //Habilitando o personagem que deve ser encontrado
        if (FindCharacters == "TipReindeer")
        {
            FindReindeer.enabled = true;
            FindReindeer.transform.localPosition = Position;
        }
        else if (FindCharacters == "TipPenguin")
        {
            FindPenguin.enabled = true;
            FindPenguin.transform.localPosition = Position;
        }
        else if (FindCharacters == "TipPolarBear")
        {
            FindPolarBear.enabled = true;
            FindPolarBear.transform.localPosition = Position;
        }
        else if (FindCharacters == "TipSnowman")
        {
            FindSnowman.enabled = true;
            FindSnowman.transform.localPosition = Position;
        }
        else if (FindCharacters == "TipSiberianHusky")
        {
            FindSiberianHusky.enabled = true;
            FindSiberianHusky.transform.localPosition = Position;
        }
        else if (FindCharacters == "TipSantaClaus")
        {
            FindSantaClaus.enabled = true;
            FindSantaClaus.transform.localPosition = Position;
        }


        // GameObject.Find(FindCharacters).this.GetComponent<Ima>
        /* foreach (GameObject Characters in goCharacters) 
         {
             Characters.SetActive(true);
         }*/


       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                     
           /* if (Physics.Raycast(ray, out RaycastHit Hit))
            {
                
                if (Hit.transform.name == "TipReindeer")
                {*/
                    Debug.Log(FindCharacters);
              //  }
          //  }
        }

    }
}
