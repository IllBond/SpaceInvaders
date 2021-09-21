using UnityEngine;


public class InputData : MonoBehaviour
{
    private HeroController _hero;

    //[SerializeField] private Pause _pause;

    public float Horizontal { get; private set; } 
    public float Vertical { get; private set; } 

    private void Awake()
    {
        _hero = GetComponent<HeroController>();
    }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal"); 
        Vertical = Input.GetAxis("Vertical");
        _hero.SetDirection(new Vector2(Horizontal, Vertical));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Пауза");
            //Pause.Pause();
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            _hero.Fire();
        }


    }
}
