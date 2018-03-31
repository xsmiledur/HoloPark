using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class GameBehavior : MonoBehaviour {

    public GameObject _TestBox;
    private GameObject[] TestBox;
    private GestureRecognizer gestureRecognizer;
    private GazeManager gazeManager;

    // Use this for initialization
    void Start () {
        // initialize TestBox
        TestBox = new GameObject[3];
        // load TestBoxPrefab
        _TestBox = (GameObject)Resources.Load("TestBox");
        // initialize GazeManager
        gazeManager = new GazeManager();
        // initialize GestureRecognizer
        gestureRecognizer = new GestureRecognizer();
        gestureRecognizer.Tapped += (TappedEventArgs args) =>
        {
            Debug.Log("TappedEvent");
           
            // if be notificated from image processing, an object is generated
            if (TestBox[2] != null)
            {
                Destroy(TestBox[2]); TestBox[2] = null;
            }
            for (int i = 0; i < 2; i++) TestBox[i + 1] = TestBox[i];
            TestBox[0] = Instantiate(_TestBox, gazeManager.GazeNormal, new Quaternion());
        };
        gestureRecognizer.StartCapturingGestures();

    }
	
	// Update is called once per frame
	void Update () {
        //InteractionManager.
	}
    
}
