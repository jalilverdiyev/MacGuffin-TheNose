using UnityEngine;
using System.Collections;
public class CameraFollower : MonoBehaviour {
 
    private Camera carcamera;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
 
    void Start()
    {
        carcamera = GetComponent<Camera>();
        GetTargetByTag("Player");
    }
 
    // Update is called once per frame
    void Update ()
    {
        if (target)
        {
            Vector3 point = carcamera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - carcamera.ViewportToWorldPoint(new Vector3(0.2f, .43f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0);
        }
 
    }
 
    /// <summary>
    /// Changes the target.
    /// </summary>
    /// <param name="_target">_target.</param>
    void ChangeTarget(Transform _target)
    {
        target = _target;
    }
 
    /// <summary>
    /// Gets the target by tag.
    /// </summary>
    /// <param name="_tag">_tag.</param>
    void GetTargetByTag(string _tag)
    {
        GameObject obj = GameObject.FindWithTag(_tag);
        if(obj)
        {
            ChangeTarget(obj.transform);
        }
        else
        {
            Debug.Log("Cant find object with tag "+ _tag);
        }
    }
       
 
}