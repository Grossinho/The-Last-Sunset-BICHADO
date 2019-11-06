using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;

public class GameController : MonoBehaviour
{
    public static GameController instancia;
    [SerializeField] Text textoDistancia, textoMusica;
    [SerializeField] RectTransform posTextoMusica;
    [SerializeField] Transform carroPos;
    [SerializeField] float aumentoDistancia, velocidadeTexto;
    [SerializeField] AudioSource aud;
    public float distancia;
    Vector3 posInicial, textoPosInicial;
    [SerializeField] float tempo = 3;


    [SerializeField] MeshRenderer carroMafia1, carroMafia2, carroMafia3, carroMafia4, carroMafia5;
    [SerializeField] Collider coliderCarroMafia;

    Bloom bloom;
    LensAberrations lensAberrations;

    Camera cam;
    public float zoom = 90;
    public float normal = 60;
    float smooth = 5;
    bool isZoomed = false;


    void Awake()
    {
        if (instancia == null) instancia = this;
        else if (instancia != this) Destroy(this);
    }

    private void Start()
    {
        cam = Camera.main;
        bloom = cam.GetComponent<Bloom>();
        textoMusica.text = "Colete fitas para ouvir alguma coisa!";
        posInicial = carroPos.position;

        textoPosInicial = textoMusica.transform.localPosition;

        carroMafia1.enabled = false;
        carroMafia2.enabled = false;
        carroMafia3.enabled = false;
        carroMafia4.enabled = false;
        carroMafia5.enabled = false;
        coliderCarroMafia.enabled = false;
    }
    private void Update()
    {
        distancia = Mathf.Round(Vector3.Distance(posInicial, carroPos.position) * aumentoDistancia);
        textoDistancia.text = distancia.ToString();

        textoMusica.text = aud.clip.name.ToString();
        textoMusica.transform.localPosition += new Vector3(-velocidadeTexto * Time.deltaTime, 0, 0);

        if (textoMusica.transform.localPosition.x < textoPosInicial.x - textoMusica.text.Length * 15)
        {
            textoMusica.transform.localPosition = textoPosInicial;
        }


        if (!carroMafia1.enabled && distancia >= tempo)
        {

            carroMafia1.enabled = true;
            carroMafia2.enabled = true;
            carroMafia3.enabled = true;
            carroMafia4.enabled = true;
            carroMafia5.enabled = true;
            coliderCarroMafia.enabled = true;
        }
    }

    public void SaveRecord()
    {
        PlayerPrefs.SetFloat("Record", distancia);
        PlayerPrefs.Save();
    }

    public void nitro(float pot)
    {
        bloom.setIntensity(pot);
    }


    public void zom( bool valor)
    {
        isZoomed = valor;

        if (isZoomed == true)
        {
           cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime * smooth);
            //lensAberrations.setDistortion(-50);

        }
        else if(!isZoomed)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normal, Time.deltaTime * smooth);
            //lensAberrations.setDistortion(0);
        }        
    }
}



