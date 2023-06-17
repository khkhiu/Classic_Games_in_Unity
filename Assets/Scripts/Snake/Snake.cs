using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 _direction;
    private List<Transform> _segments = new List<Transform>();
    public Transform SegmentPrefab;
    public int StartSize = 4;

    private void Start()
    {
        ResetState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow)){
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow)){
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow)){
            _direction = Vector2.right;
        }

        // Use R key to reset game
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate() 
    {
        for (int i = _segments.Count - 1; i > 0; i --)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.SegmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void ResetState()
    {
        // '0' is main snake head
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.StartSize; i++)
        {
            _segments.Add(Instantiate(this.SegmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Food")
        {
            Grow();    
        }
        else if (other.tag == "Wall")
        {
            ResetState();
        }   
    }
}
