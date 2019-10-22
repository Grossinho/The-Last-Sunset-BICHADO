using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class Explosao : MonoBehaviour
{

   
    public GameObject explosao;
    public float tempoParaEstourar = 0.5f;
    public float raioDaExplosao = 5;
    public float forcaExp = 5;
    float cronometro = 0;
    bool explodiu = false;

    private void Update()
    {

       
        explosao.transform.position += transform.position;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Veiculo"))
        {
            
            Explodir(transform.position, raioDaExplosao);
        }
    }


    void Explodir(Vector3 centro,float raio)
    {
        Collider[] HitColliders = Physics.OverlapSphere(centro, raio);
        for(int x = 0; x < HitColliders.Length; x++)
        {

            Rigidbody TempRB = HitColliders[x].GetComponent<Rigidbody>();
            if(TempRB)
            {
                TempRB.AddExplosionForce(forcaExp, transform.position, 10, 1, ForceMode.Impulse);

            }
        }

        if(explosao)
        {
            GameObject particula = Instantiate(explosao, transform.position, transform.rotation) as GameObject ;
            Destroy(particula, 3);

        }

        
        Destroy(this.gameObject,3);


    }
   

}
