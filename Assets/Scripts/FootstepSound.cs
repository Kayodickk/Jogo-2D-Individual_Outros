
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] sonsPasso;
    public float intervalo = 0.4f;

    [Range(0f, 1f)]
    public float volume = 0.4f;

    public float velocidadeMinima = 0.5f;

    private float timer;
    private Rigidbody2D rb;
    private AudioSource audioSrc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

        bool estaNoChao = Mathf.Abs(rb.linearVelocity.y) < 0.1f;


        float velocidade = Mathf.Abs(rb.linearVelocity.x);


        if (!estaNoChao || velocidade < velocidadeMinima)
        {
            timer = 0f;
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            TocarPasso();
            timer = intervalo;
        }
    }

    void TocarPasso()
    {
        if (sonsPasso == null || sonsPasso.Length == 0 || audioSrc == null)
            return;

        AudioClip som = sonsPasso[Random.Range(0, sonsPasso.Length)];

        if (som != null)
        {
            audioSrc.PlayOneShot(som, volume);
        }
    }
}
