using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
   public GameObject explosion;
    public FollowType type = FollowType.MoveToward;
    public PointsToFollow path;
    public float speed = 1;
    public float maxDistanceToGoal = .1f;
    private IEnumerator<Transform> _currentPoint;
    private SoundController soundSFX;

    public enum FollowType
    {

        MoveToward,
        Lerp
    }


    private void Awake()
    {

        soundSFX = GameObject.Find("AudioSource").GetComponent<SoundController>();
    }
    private void Start()
    {
        if (path == null)
        {
            Debug.LogError("Path is cannot be null", gameObject);
            return;
        }

        _currentPoint = path.GetPathEnumerator();
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null)
        {
            return;
        }

        transform.position = _currentPoint.Current.position;
    }

    public void Update()
    {

        if (_currentPoint == null || _currentPoint.Current == null)
        {
            return;
        }

        if (type == FollowType.MoveToward)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }
        else if (type == FollowType.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }

        var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared < maxDistanceToGoal * maxDistanceToGoal)
        {
            _currentPoint.MoveNext();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soundSFX.sounds[2].Play();
            Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        
    }


    
}
