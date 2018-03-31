using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class GameBehavior : MonoBehaviour {

    public GameObject _TestBox;
    private GameObject TestBox;
    private GameObject cursor;
    private GestureRecognizer gestureRecognizer;

    // Use this for initialization
    void Start () {
        // load TestBoxPrefab
        _TestBox = (GameObject)Resources.Load("TestBox");
        // initialize Cursor
        cursor = GameObject.Find("DefaultCursor").gameObject;
        // initialize GestureRecognizer
        gestureRecognizer = new GestureRecognizer();
        gestureRecognizer.Tapped += (TappedEventArgs args) =>
        {
            Debug.Log("TappedEvent");
            // if be notificated from image processing, an object is generated
            if (TestBox != null) Destroy(TestBox);
            TestBox = Instantiate(_TestBox, cursor.transform.position, new Quaternion());
        };
        gestureRecognizer.StartCapturingGestures();

    }
	
	// Update is called once per frame
	void Update () {
        //InteractionManager.
	}
    
}
