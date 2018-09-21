using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour {

    public GameObject Bird;
    private Sprite[] spritesList;
    private int contador;
    private bool isVoando;


	void Start ()
    {
        //Vetor com os sprites em. OBS: Ele apenas carregas os sprites da pasta Resources
        spritesList = Resources.LoadAll<Sprite>("");
        contador = 0;
        isVoando = false;
	}
	
	void Update ()
    {

        //Lógica da Animação
        if (isVoando && contador < 20)
        {
            MudaSkin(0);
            contador++;
        } else if(isVoando && contador >= 20 && contador < 40 ){
            MudaSkin(2);
            contador++;
        } else if(isVoando && contador >= 40){
            MudaSkin(1);
            contador = 0;
            isVoando = false;
        }


		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space))
        {
			Bird.GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 500));   

            //Inicia a animação         
            MudaSkin(2);
            isVoando = true;
            
        }

	}

    //Muda  o Sprite do Bird
    void MudaSkin(int i)
    {
        Bird.GetComponent<SpriteRenderer>().sprite = spritesList[i];
    }
}