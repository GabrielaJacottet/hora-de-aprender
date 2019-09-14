using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    private bool Circle1 = true;
    private bool Circle2 = false;
    private bool Circle3 = false;
    private Vector3 PositionCircle1;
    private Vector3 PositionCircle2;
    private Vector3 PositionCircle3;
    private bool Encontrou = false;

    

    // Start is called before the first frame update
    void Start()
    {
        PosicoesCirculos();

        AdicionarPersonagensLista();

        //Enquanto houver personagem na lista
        if (ListaCharacters.Count > 0)
            SorteioDica = Random.Range(0, ListaCharacters.Count - 1); //Sorteie um personagem

        //Pegando o nome do personagem sorteado
        FindCharacters = ListaCharacters[SorteioDica];

        //Removendo o Personagem sorteado da lista, para que ele não seja desabilitado no próximo comando
        ListaCharacters.RemoveAt(SorteioDica);


        //sorteando a posição que o personagem vai aparecer
        SorteioPosicao = Random.Range(0, 5);

        PosicionarPersonagemCena(SorteioPosicao);

        HabilitandoPersonagem(FindCharacters);


        // GameObject.Find(FindCharacters).this.GetComponent<Ima>
        /* foreach (GameObject Characters in goCharacters) 
         {
             Characters.SetActive(true);
       */
    }

        // Update is called once per frame
    void Update()
    {
        if(Encontrou)
        {
            if (ListaCharacters.Count > 0)
                SorteioDica = Random.Range(0, ListaCharacters.Count - 1); //Sorteie um personagem
            //Pegando o nome do personagem sorteado
            FindCharacters = ListaCharacters[SorteioDica];

            //Removendo o Personagem sorteado da lista, para que ele não seja desabilitado no próximo comando
            ListaCharacters.RemoveAt(SorteioDica);
            SorteioPosicao = Random.Range(0, ListaCharacters.Count - 1);

            PosicionarPersonagemCena(SorteioPosicao);

            HabilitandoPersonagem(FindCharacters);
            Encontrou = false;
        }

    }

    private void PosicoesCirculos()
    {
        PositionCircle1 = new Vector3(-100f, -127f, 0);
        PositionCircle2 = new Vector3(-30, -127f, 0);
        PositionCircle3 = new Vector3(40f, -127f, 0);
    }

    private void AdicionarPersonagensLista()
    {
        ListaCharacters.Add("TipReindeer");
        ListaCharacters.Add("TipPenguin");
        ListaCharacters.Add("TipPolarBear");
        ListaCharacters.Add("TipSnowman");
        ListaCharacters.Add("TipSiberianHusky");
        ListaCharacters.Add("TipSantaClaus");
    }

    private void PosicionarPersonagemCena(int SorteioPos)
    {
        if (SorteioPos == 0)
            Position = new Vector3(220f, -70f, 0);//trenó
        else if (SorteioPos == 1)
            Position = new Vector3(255f, 70f, 0);//igreja
        else if (SorteioPos == 2)
            Position = new Vector3(-135f, 20f, 0);//iglu
        else if (SorteioPos == 3)
            Position = new Vector3(15f, 90f, 0);//atrás casa
        else if (SorteioPos == 4)
            Position = new Vector3(-300f, 25f, 0);//pinheiro
        else if (SorteioPos == 5)
            Position = new Vector3(-120f, 85f, 0);//frente casa
    }

    private void HabilitandoPersonagem(string FindCharacters)
    {
        if (FindCharacters == "TipReindeer")
        {
            if (FindReindeer != null)
            {
                FindReindeer.enabled = true;
                FindReindeer.transform.localPosition = Position;
            }
        }
        else if (FindCharacters == "TipPenguin")
        {
            if (FindPenguin != null)
            {
                FindPenguin.enabled = true;
                FindPenguin.transform.localPosition = Position;
            }
        }
        else if (FindCharacters == "TipPolarBear")
        {
            if (FindPolarBear != null)
            {
                FindPolarBear.enabled = true;
                FindPolarBear.transform.localPosition = Position;
            }
        }
        else if (FindCharacters == "TipSnowman")
        {
            if (FindSnowman != null)
            {
                FindSnowman.enabled = true;
                FindSnowman.transform.localPosition = Position;
            }
        }
        else if (FindCharacters == "TipSiberianHusky")
        {
            if (FindSiberianHusky != null)
            {
                FindSiberianHusky.enabled = true;
                FindSiberianHusky.transform.localPosition = Position;
            }
        }
        else if (FindCharacters == "TipSantaClaus")
        {
            if (FindSantaClaus != null)
            {
                FindSantaClaus.enabled = true;
                FindSantaClaus.transform.localPosition = Position;
            }
        }

    }

    private void HabilitarCirculo2()
    {
        Circle1 = false;
        Circle2 = true;
    }

    private void HabilitarCirculo3()
    {
        Circle1 = false;
        Circle2 = false;
        Circle3 = true;
    }

    private void ColocarPersonagemCirculo(string Personagem, Image FindCharacter)
    {
        if (Circle1)
        {
            FindCharacter.transform.localPosition = PositionCircle1;
            HabilitarCirculo2();
            Encontrou = true;
        }
        else if (Circle2)
        {
            FindCharacter.transform.localPosition = PositionCircle2;
            HabilitarCirculo3();
            Encontrou = true;
        }
        else if (Circle3)
        {
            FindCharacter.transform.localPosition = PositionCircle3;
        }

    }
    
    public void Achou(string Personagem)
    {
        if(Personagem == "FindReindeer")
        {
            ColocarPersonagemCirculo(Personagem, FindReindeer);
        }
        else if (Personagem == "FindPenguin")
        {
            ColocarPersonagemCirculo(Personagem, FindPenguin);
        }
        else if (Personagem == "FindPolarBear")
        {
            ColocarPersonagemCirculo(Personagem, FindPolarBear);
        }
        else if (Personagem == "FindSnowman")
        {
            ColocarPersonagemCirculo(Personagem, FindSnowman);
        }
        else if (Personagem == "FindSiberianHusky")
        {
            ColocarPersonagemCirculo(Personagem, FindSiberianHusky);
        }
        else if (Personagem == "FindSantaClaus")
        {
            ColocarPersonagemCirculo(Personagem, FindSantaClaus);
        }



    }

    
}
