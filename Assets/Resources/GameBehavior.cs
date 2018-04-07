using UnityEngine;
//using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class GameBehavior : MonoBehaviour {

    public GameObject _TestBox;
    private GameObject TestBox;
    private GameObject cursor;
    private GestureRecognizer gestureRecognizer;
    private Text text;

    // Use this for initialization
    void Start () {
        text = GameObject.Find("Text").gameObject.GetComponent<Text>();
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
            if (TestBox != null && Sum(data, height, width) == 21) Destroy(TestBox);
            TestBox = Instantiate(_TestBox, cursor.transform.position, new Quaternion());
        };
        gestureRecognizer.StartCapturingGestures();

    }

    int frame = 0;
    int height = 2;
    int width = 3;
    int number = 0;
    byte[] data = new byte[] { 1, 2, 3, 4, 5, 6 };
    [DllImport("cpplib")]
    public static extern int Sum(byte[] data, int height, int width);
	// Update is called once per frame
	void Update () {
        frame++;
        if (frame > 100) {
            ++number;
            text.text = number.ToString();
            Debug.Log(Sum(data, height, width));
            frame = 0;
        }
	}
    
}
