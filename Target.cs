using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager;
    private float minHýz = 10;
    private float maxHýz = 16;
    private float maxTorque = 6;
    private float xRange = 4;
    private float ySpawnPos = -2;
    
    public int SkorDegeri;

    public ParticleSystem explosionParticle;
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse); //Yukarý dogru rastgele kuvvet uyguluyor
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //kendi ekseninde rastgele dönmesini saðlýyorum

        transform.position = RandomSpawnPos(); //Spawn olacagý kýsmýn asagýda rastgele olmasýný saglýyor
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bad"))
            {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                gameManager.OyunBitti();
                return;
            }
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateSkor(SkorDegeri);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.OyunBitti();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minHýz, maxHýz);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

}
