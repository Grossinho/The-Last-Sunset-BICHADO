using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMafia : MonoBehaviour
{

   public enum rodovia
   {
        RuaMeio,
        RuaEsquerda,
        RuaDireita

   };
    public rodovia RuaDisponivel;

    
    
    Rigidbody rgb;
    [SerializeField] private float velo;
    [SerializeField] private float limiteLateral;


    // Start is called before the first frame update
    void Start()
    {
      
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rgb.velocity = transform.forward * velo;
        
        colisaoLateral();

    }

    public void colisaoLateral()
    {
        if (Mathf.Abs(transform.position.x) > limiteLateral)
        {

            transform.position = new Vector3(limiteLateral * Mathf.Sign(transform.position.x), transform.position.y, transform.position.z);
            transform.localEulerAngles = new Vector3(0, 0, 0);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Veiculo"))
        {
            if (transform.position.x < 0)
            {
                RuaDisponivel = rodovia.RuaDireita;
            }
            else
            {
                RuaDisponivel = rodovia.RuaEsquerda;
            }

            /*if (transform.position.z < other.gameObject.transform.position.z)
            {
                if(transform.position.x < other.gameObject.transform.position.x)
                {
                    RuaDisponivel = rodovia.RuaEsquerda;
                }
                else
                {
                    RuaDisponivel = rodovia.RuaDireita;
                }


            }
            */
        }
        else RuaDisponivel = rodovia.RuaMeio;
        //
        switch (RuaDisponivel)
        {


            case rodovia.RuaDireita:
                transform.position = new Vector3((other.transform.position.x / limiteLateral )* Time.deltaTime, 0, 0);

                break;

            case rodovia.RuaEsquerda:
                

            case rodovia.RuaMeio:
                break;
        }
    }
}
