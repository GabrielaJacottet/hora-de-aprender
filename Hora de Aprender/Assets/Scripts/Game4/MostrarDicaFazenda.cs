using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.U2D;

public class MostrarDicaFazenda : MonoBehaviour
{

    public static List<string> ListaCharacters = new List<string>(); //Lista de personagens
    public string FindCharacters;
    private string EnabledCharacter;
    public int SorteioDica;
    public int SorteioPosicao;
    public Vector3 Position;
    public Vector3 PositionY;
    public Image FindCow;
    public Image TipCow;
    public Image FindPig;
    public Image TipPig;
    public Image FindChicken;
    public Image TipChicken;
    public Image FindSheep;
    public Image TipSheep;
    public Image FindDuck;
    public Image TipDuck;
    public Image FindHorse;
    public Image TipHorse;




    private float LerpTime = 2;
    private float CurrentLerpTime = 1;
    private bool Circle1;
    private bool Circle2;
    private bool Circle3;
    private bool Circle4;
    private bool Circle5;
    private bool Up;
    bool Mudar = false;
    private int i = 0;
    public Transform StarPos, EndPos;
    private float TotalDistance;
    private Vector3 PositionCircle1;
    private Vector3 PositionCircle2;
    private Vector3 PositionCircle3;
    private Vector3 PositionCircle4;
    private Vector3 PositionCircle5;
    private bool Encontrou;
    private bool UpdateGame = false;
    public static bool FinalizouJogo;


    



    // Start is called before the first frame update
    void Start()
    {
        IniciarVariaveis();

        HabilitarCirculo1();

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
        SorteioPosicao = Random.Range(0, 7);

        PosicionarPersonagemCena(SorteioPosicao);

        HabilitandoPersonagem(FindCharacters);

        StartCoroutine(DicaParaEncontrar());

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
            SorteioPosicao = Random.Range(0, 7);

            PosicionarPersonagemCena(SorteioPosicao);

            HabilitandoPersonagem(FindCharacters);
            Encontrou = false;
            i = 0;           
        }
        else
        {
            if ((!Mudar)&&(!FinalizouJogo)&&(UpdateGame))
            {              
                StartCoroutine(DicaParaEncontrar());
            }
        }

    }

    private void IniciarVariaveis()
    {
        ListaCharacters.Clear();
        Circle1 = false;
        Circle2 = false;
        Circle3 = false;
        Circle4 = false;
        Circle5 = false;
        Encontrou = false;
        FinalizouJogo = false;
        Up = false;
    }

    IEnumerator DicaParaEncontrar()
    {
        UpdateGame = false;
        yield return new WaitForSeconds(4.0f);
        MudarPosicaoPersonagem(FindCharacters);
    }

    IEnumerator Subiu()
    {
        yield return new WaitForSeconds(2.0f);
        UpdateGame = false;
        Up = true;
        MudarPosicaoPersonagem(FindCharacters);
    }

    IEnumerator Desceu()
    {
        yield return new WaitForSeconds(2.0f);
        UpdateGame = false;
        Up = false;
        MudarPosicaoPersonagem(FindCharacters);
    }

    IEnumerator SortearNovaPosicao()
    {
        if (!FinalizouJogo)
        {
            yield return new WaitForSeconds(2.0f);

            Mudar = false;
            
            i = 0;

            SorteioPosicao = Random.Range(0, 7);
            PosicionarPersonagemCena(SorteioPosicao);
            HabilitandoPersonagem(FindCharacters);

            yield return new WaitForSeconds(2.0f);
        }

    }




    private void MudarPosicaoPersonagem(string EnabledCharacter)
    {
        if (EnabledCharacter == "TipCow")
        {
            if (FindCow != null)
            {
                if (i <= 5)
                {

                     if (!Up)
                     {
                         PositionY = Position + (Vector3.up * 15f);
                         CurrentLerpTime += Time.deltaTime;
                         if (CurrentLerpTime >= LerpTime)
                         {
                             CurrentLerpTime = LerpTime;
                         }

                         float Perc = CurrentLerpTime / LerpTime;
                         FindCow.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                         StartCoroutine(Subiu());
                         i++;
                     }
                     else
                     {
                         PositionY = Position + (Vector3.down * 15f);
                         CurrentLerpTime += Time.deltaTime;
                         if (CurrentLerpTime >= LerpTime)
                         {
                             CurrentLerpTime = LerpTime;
                         }

                         float Perc = CurrentLerpTime / LerpTime;
                         FindCow.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                         StartCoroutine(Desceu());
                         i++;
                     }
                }
                 else
                 {
                     if (!Mudar)
                     {
                         Mudar = true;
                         UpdateGame = true;
                         StartCoroutine(SortearNovaPosicao());
                     }
                 }


            }
        }
        else if (EnabledCharacter == "TipPig")
        {
            if (FindPig != null)
            {
                if (i <= 5)
                {
                    if (!Up)
                    {
                        PositionY = Position + (Vector3.up * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindPig.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Subiu());
                        i++;
                    }
                    else
                    {
                        PositionY = Position + (Vector3.down * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindPig.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Desceu());
                        i++;
                    }
                }
                else
                {
                    if (!Mudar)
                    {
                        Mudar = true;
                        UpdateGame = true;
                        StartCoroutine(SortearNovaPosicao());
                    }
                }
            }
        }
        else if (EnabledCharacter == "TipChicken")
        {
            if (FindChicken != null)
            {
                if (i <= 5)
                {
                    if (!Up)
                    {
                        PositionY = Position + (Vector3.up * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindChicken.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Subiu());
                        i++;
                    }
                    else
                    {
                        PositionY = Position + (Vector3.down * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindChicken.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Desceu());
                        i++;
                    }
                }
                else
                {
                    if (!Mudar)
                    {
                        Mudar = true;
                        UpdateGame = true;
                        StartCoroutine(SortearNovaPosicao());
                    }
                }
            }
        }
        else if (EnabledCharacter == "TipSheep")
        {
            if (FindSheep != null)
            {
                if (i <= 5)
                {
                    if (!Up)
                    {
                        PositionY = Position + (Vector3.up * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindSheep.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Subiu());
                        i++;
                    }
                    else
                    {
                        PositionY = Position + (Vector3.down * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindSheep.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Desceu());
                        i++;
                    }
                }
                else
                {
                    if (!Mudar)
                    {
                        Mudar = true;
                        UpdateGame = true;
                        StartCoroutine(SortearNovaPosicao());
                    }
                }
            }
        }
        else if (EnabledCharacter == "TipDuck")
        {
            if (FindDuck != null)
            {
                if (i <= 5)
                {
                    if (!Up)
                    {
                        PositionY = Position + (Vector3.up * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindDuck.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Subiu());
                        i++;
                    }
                    else
                    {
                        PositionY = Position + (Vector3.down * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindDuck.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Desceu());
                        i++;
                    }
                }
                else
                {
                    if (!Mudar)
                    {
                        Mudar = true;
                        UpdateGame = true;
                        StartCoroutine(SortearNovaPosicao());
                    }
                }
            }
        }
        else if (EnabledCharacter == "TipHorse")
        {
            if (FindHorse != null)
            {
                if (i <= 5)
                {
                    if (!Up)
                    {
                        PositionY = Position + (Vector3.up * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindHorse.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Subiu());
                        i++;
                    }
                    else
                    {
                        PositionY = Position + (Vector3.down * 15f);
                        CurrentLerpTime += Time.deltaTime;
                        if (CurrentLerpTime >= LerpTime)
                        {
                            CurrentLerpTime = LerpTime;
                        }

                        float Perc = CurrentLerpTime / LerpTime;
                        FindHorse.transform.localPosition = Vector3.Lerp(Position, PositionY, Perc);

                        StartCoroutine(Desceu());
                        i++;
                    }
                }
                else
                {
                    if (!Mudar)
                    {
                        Mudar = true;
                        UpdateGame = true;
                        StartCoroutine(SortearNovaPosicao());
                    }
                }
            }
        }
    }
   

   



    private void PosicoesCirculos()
    {
        PositionCircle1 = new Vector3(-130f, 150f, 0);
        PositionCircle2 = new Vector3(-70f, 150f, 0);
        PositionCircle3 = new Vector3(-10f, 150f, 0);
        PositionCircle4 = new Vector3(51f, 150f, 0);
        PositionCircle5 = new Vector3(111f, 150f, 0);
    }

    private void AdicionarPersonagensLista()
    {
        ListaCharacters.Add("TipCow");
        ListaCharacters.Add("TipPig");
        ListaCharacters.Add("TipChicken");
        ListaCharacters.Add("TipSheep");
        ListaCharacters.Add("TipDuck");
        ListaCharacters.Add("TipHorse");
    }

    private void PosicionarPersonagemCena(int SorteioPos)
    {
        if (SorteioPos == 0)
            Position = new Vector3(275f, 80f, 0);//atrás da árvore
        else if (SorteioPos == 1)
            Position = new Vector3(-9f, -117f, 0);//trator
        else if (SorteioPos == 2)
            Position = new Vector3(-110f, -68f, 0);//atrás da casa
        else if (SorteioPos == 3)
            Position = new Vector3(-334f, -94f, 0);//atrás do moinho
        else if (SorteioPos == 4)
            Position = new Vector3(-351f, -184f, 0);//atrás da carroça
        else if (SorteioPos == 5)
            Position = new Vector3(-125f, -184f, 0);//atrás da palha
        else if (SorteioPos == 6)
            Position = new Vector3(190f, -30f, 0);//atrás do espantalho
        else if (SorteioPos == 7)
            Position = new Vector3(175f, -167f, 0);//horta
    }

    private void HabilitandoPersonagem(string FindCharacters)
    {
        if (FindCharacters == "TipCow")
        {
            if (FindCow != null)
            {
                FindCow.enabled = true;
                TipCow.enabled = true;
                FindCow.transform.localPosition = Position;
                EnabledCharacter = "FindCow";
                TotalDistance = Vector3.Distance(Position, Position +(Vector3.up * 15f));
            }
        }
        else if (FindCharacters == "TipPig")
        {
            if (FindPig != null)
            {
                FindPig.enabled = true;
                TipPig.enabled = true;
                FindPig.transform.localPosition = Position;
                EnabledCharacter = "FindPig";
            }
        }
        else if (FindCharacters == "TipChicken")
        {
            if (FindChicken != null)
            {
                FindChicken.enabled = true;
                TipChicken.enabled = true;
                FindChicken.transform.localPosition = Position;
                EnabledCharacter = "FindChicken";
            }
        }
        else if (FindCharacters == "TipSheep")
        {
            if (FindSheep != null)
            {
                FindSheep.enabled = true;
                TipSheep.enabled = true;
                FindSheep.transform.localPosition = Position;
                EnabledCharacter = "FindSheep";
            }
        }
        else if (FindCharacters == "TipDuck")
        {
            if (FindDuck != null)
            {
                FindDuck.enabled = true;
                TipDuck.enabled = true;
                FindDuck.transform.localPosition = Position;
                EnabledCharacter = "FindDuck";
            }
        }
        else if (FindCharacters == "TipHorse")
        {
            if (FindHorse != null)
            {
                FindHorse.enabled = true;
                TipHorse.enabled = true;
                FindHorse.transform.localPosition = Position;
                EnabledCharacter = "FindHorse";
            }
        }

    }
    private void HabilitarCirculo1()
    {
        Circle1 = true;
        Circle2 = false;
        Circle3 = false;
        Circle4 = false;
        Circle5 = false;
    }

    private void HabilitarCirculo2()
    {
        Circle1 = false;
        Circle2 = true;
    }

    private void HabilitarCirculo3()
    {
        Circle2 = false;
        Circle3 = true;
    }

    private void HabilitarCirculo4()
    {
        Circle3 = false;
        Circle4 = true;
    }

    private void HabilitarCirculo5()
    {
        Circle4 = false;
        Circle5 = true;
    }

    private void ColocarPersonagemCirculo(string Personagem, Image FindCharacter, Image TipCharacter)
    {
        if (Circle1)
        {
            FindCharacter.transform.localPosition = PositionCircle1;
            TipCharacter.enabled = false;
            HabilitarCirculo2();
            Encontrou = true;
        }
        else if (Circle2)
        {
            FindCharacter.transform.localPosition = PositionCircle2;
            TipCharacter.enabled = false;
            HabilitarCirculo3();
            Encontrou = true;
        }
        else if (Circle3)
        {
            FindCharacter.transform.localPosition = PositionCircle3;
            TipCharacter.enabled = false;
            HabilitarCirculo4();
            Encontrou = true;
        }
        else if (Circle4)
        {
            FindCharacter.transform.localPosition = PositionCircle4;
            TipCharacter.enabled = false;
            HabilitarCirculo5();
            Encontrou = true;
        }
        else if (Circle5)
        {
            FindCharacter.transform.localPosition = PositionCircle5;
            TipCharacter.enabled = false;
            FinalizouJogo = true;
        }

    }
    
    public void Achou(string Personagem)
    {
        if(Personagem == "FindCow")
        {
            ColocarPersonagemCirculo(Personagem, FindCow, TipCow);
        }
        else if (Personagem == "FindPig")
        {
            ColocarPersonagemCirculo(Personagem, FindPig, TipPig);
        }
        else if (Personagem == "FindChicken")
        {
            ColocarPersonagemCirculo(Personagem, FindChicken, TipChicken);
        }
        else if (Personagem == "FindSheep")
        {
            ColocarPersonagemCirculo(Personagem, FindSheep, TipSheep);
        }
        else if (Personagem == "FindDuck")
        {
            ColocarPersonagemCirculo(Personagem, FindDuck, TipDuck);
        }
        else if (Personagem == "FindHorse")
        {
            ColocarPersonagemCirculo(Personagem, FindHorse, TipHorse);
        }



    }

    
}
