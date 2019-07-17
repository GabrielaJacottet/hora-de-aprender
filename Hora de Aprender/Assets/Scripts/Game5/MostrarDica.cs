using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDica : MonoBehaviour
{

    public static List<string> ListaCharacters = new List<string>(); //Lista de personagens
    public string FindCharacters;
    // public List<GameObject> goCharacters = new List<GameObject>(); //lista para colocar as figuras dos personagens e manipular via script
    public int Sorteio;
    public Vector2 PositionOne;
    public Vector2 PositionTwo;
    public Image FindReindeer;
    public Image FindPenguin;
    public Image FindPolarBear;


    // Start is called before the first frame update
    void Start()
    {
        PositionOne = new Vector2(220,-70);
        PositionTwo = new Vector2(220, -70);

        //adicionando os personagens na lista
        ListaCharacters.Add("TipReindeer");
        ListaCharacters.Add("TipPolarBear");
       /* ListaCharacters.Add("TipSnowman");
        ListaCharacters.Add("TipSiberianHusky");
        ListaCharacters.Add("TipSantaClaus");*/
        ListaCharacters.Add("TipPenguin");

        

        if (ListaCharacters.Count > 0)
            Sorteio = Random.Range(0, ListaCharacters.Count - 1); //Sorteando Personagem

        FindCharacters = ListaCharacters[Sorteio];

        ListaCharacters.RemoveAt(Sorteio);//Removendo o Personagem sorteado da lista, para que ele não seja desabilitado no próximo comando

        foreach (string i in ListaCharacters) //para cada Personagem que não foi sorteada
            GameObject.Find(i).SetActive(false); // desative esse Personagem

        if (FindCharacters == "TipReindeer")
            FindReindeer.enabled = true;
        else if (FindCharacters == "TipPolarBear")
            FindPolarBear.enabled = true;
        else if (FindCharacters == "TipPenguin")
            FindPenguin.enabled = true;
        

        // GameObject.Find(FindCharacters).this.GetComponent<Ima>
        /* foreach (GameObject Characters in goCharacters) 
         {
             Characters.SetActive(true);
         }*/




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
