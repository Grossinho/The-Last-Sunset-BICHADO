using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Veiculo : MonoBehaviour
{
    public Transform[] MeshRodas;
    public WheelCollider[] ColisorRodas;
    public CarroMafia mafia;
    private Rigidbody corpoRigido;
    private float angulo, direcao;
    [SerializeField] float Velocidade, pesoVeiculo = 1500;
    [SerializeField] float limiteLateral;
    [SerializeField] float rotationZ, sensitivityZ, curva;

    bool perdaVelo = false;

   
    

    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
        corpoRigido.mass = pesoVeiculo;

    }
    void Update()
    {
        corpoRigido.velocity = transform.forward * Velocidade;
        Velocidade += 2f* Time.deltaTime;
        

        direcao = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0.7f || Input.GetAxis("Horizontal") < -0.7f)
        {
            angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 4);
        }
        else
        {
            angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 2);
        }


        colisaoLateral();

    }
    void FixedUpdate()
    {
        lockedRotation();
        ColisorRodas[0].steerAngle = angulo * 40;
        ColisorRodas[1].steerAngle = angulo * 40;
        //
        
        

        for (int x = 0; x < ColisorRodas.Length; x++)
        {
            Quaternion quat;
            Vector3 pos;
            ColisorRodas[x].GetWorldPose(out pos, out quat);
            MeshRodas[x].position = pos;
            MeshRodas[x].rotation = quat;
        }

        
    }


    public void colisaoLateral()
    {
        
        
          if (Mathf.Abs(transform.position.x) > limiteLateral)
          {

            transform.position = new Vector3(limiteLateral * Mathf.Sign(transform.position.x), transform.position.y, transform.position.z);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            
             
                
             perdeVelAcostamento();   
               
          }
        

    }

    void perdeVelAcostamento()
    {
        if (perdaVelo == true && Velocidade > 30f)
        {
            Velocidade -= 2f;
            if (Velocidade == 30f)
            {


                perdaVelo = false;


            }

            if (perdaVelo == false)
            {

                Velocidade = 30f;

            }
        }
    }

    void ColisaoCarro()
    {
        perdaVelo = true;
        if (perdaVelo == true && Velocidade > 20f)
        {
            Velocidade -= 3f;
            if (Velocidade == 20f)
            {


                perdaVelo = false;


            }

          
        }
    }


    void lockedRotation()
    {
        rotationZ += Input.GetAxis("Horizontal") * sensitivityZ;
        rotationZ = Mathf.Clamp(rotationZ, -45, 45);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationZ, transform.localEulerAngles.z) * Time.deltaTime * curva;
    }


    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Veiculo"))
        {
            
            ColisaoCarro();

        }

        if (collision.gameObject.CompareTag("Mafia"))
            mafia.CapotaMafia();
    }

}