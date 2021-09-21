using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fleet : MonoBehaviour
{
    [Header("Враг")] 
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private List<GameObject> _enemyReady= new List<GameObject>();
    
    [Header("К-во рядов врагов")] 
    [SerializeField] [Range(1, 5)] 
    private int _row = 1;

    [Header("К-во коллон врагов")] 
    [SerializeField] [Range(1, 5)]  
    private int _col = 1;

    [Space]
    [Header("Скорость перемещения врагов")]  
    [SerializeField] 
    private float _speed = 5 ;

    [Header("Скорость спуска врагов")]  
    [SerializeField] 
    private float _fallSpeed = 2.5f;
    private float _atackpeedCoeficient = 25f;

    [Header("Базовое направление движения")] 
    [SerializeField] [Range(-1, 1)] 
    private float _directionX = 1; //-1 0 1;

    [Range(-1, 0)] 
    private float _directionY = 0; //-1 0;

    //////////////
    private bool _isMove = true;
    //private Vector2 _baseCoor;
    private Vector2 _tileSize;
    private float _currentSpawnX = 0;
    private float _currentSpawnY = 0;


    [SerializeField] private UnityEvent _destroFleet;
    [SerializeField] private HealthComponent _player;
    [SerializeField] private GameOverComponent _gameOverComponent;
    private GameSession _session;
    private void Awake()
    {
        _session = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        transform.position += new Vector3(_directionX * Time.deltaTime * _speed, _directionY * Time.deltaTime * _fallSpeed, 0);
    }

    private void Start()
    {
        _speed = _session.Data.speedFleet;
        _fallSpeed = _session.Data._fallSpeedFleet;

        _tileSize = _enemy.GetComponent<BoxCollider2D>().size;
        //_baseCoor = transform.position;
        _enemys = new GameObject[_col * _row];

        SpawnEnemy();
        FleetAtack(_atackpeedCoeficient / _speed);
    }

    public void SwitchDirection() {
        if (!_isMove) return;
        StartCoroutine(SwitchDirectionCoru());
    }


    public void ResetSpeed() {
        _session.Data.speedFleet = 5;
        _session.Data._fallSpeedFleet = 2.5f;
    }

    IEnumerator SwitchDirectionCoru() {
        float prevDirectionX = _directionX;
        _directionX = 0;
        _isMove = false;
        yield return new WaitForSeconds(0.5f);
        _directionY = -1;
        yield return new WaitForSeconds(0.2f);
        _directionY = 0;
        yield return new WaitForSeconds(0.5f);
        _directionX = prevDirectionX * -1;
        _isMove = true;
    }

    public int CountEnemy() {
        return gameObject.transform.childCount;
    }

    public void AddSpeed() {
        _session.Data.speedFleet++;
        _session.Data._fallSpeedFleet += 0.5f;
    }

    public void SpawnEnemy() {
        int k = 0;

        //transform.position = _baseCoor;
        _currentSpawnX = 0;
        _currentSpawnY = 0;
        

        if (_row > 1 || _col > 1)
        {
            float spawnX = -1 * (_tileSize.x * _col - _tileSize.x);
            _currentSpawnX = spawnX;

            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    GameObject item = Instantiate(_enemy, new Vector2(_currentSpawnX, _currentSpawnY) + (Vector2)transform.position, Quaternion.identity, transform);
                    _enemys[k] = item;
                    k++;
                    _currentSpawnX += _tileSize.x * 2;

              
                }
                _currentSpawnY -= _tileSize.y * 2;
                _currentSpawnX = spawnX;
            }
        }
        else {
            GameObject item = Instantiate(_enemy, new Vector2(0, 0) + (Vector2)transform.position, Quaternion.identity, transform);
            _enemys[k] = item;
        }
    }


    public void CheckWin() {
        if (CountEnemy() == 1)
        {
            AddSpeed();
            _destroFleet.Invoke();
        }
    }

    private void FleetAtack(float time) {
        StartCoroutine(FleetAtackLoop(time));
    }

    IEnumerator FleetAtackLoop(float time) {
        yield return new WaitForSeconds(time);
        FindBottomEnemy();
        FleetAtack(_atackpeedCoeficient / _speed);
    }



    private void FindBottomEnemy() {
        _enemyReady = new List<GameObject>();
        foreach (var it in _enemys)
        {
            if (it != null) {
                RaycastHit2D hit = Physics2D.Raycast(it.transform.position, new Vector2(0, -1));
                if (hit.collider.tag == "GameController" || hit.collider.tag == "Player")
                {
                    _enemyReady.Add(it);
                }
            }
        }

        int rnd = Random.Range(0, _enemyReady.Count-1);
        FireComponent fireComponent = _enemyReady[rnd].GetComponent<FireComponent>();
        fireComponent?.Fire();
    }
}
