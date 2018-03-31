using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using UnityEngine.EventSystems;

//public class GameBehavior : MonoBehaviour, IInputClickHandler
public class GameBehavior : MonoBehaviour {

    public GameObject _TestBox;
    private GameObject[] TestBox;
    private GestureRecognizer gestureRecognizer;
    private GazeManager gazeManager;
    private FocusManager focusManager;

    /** クリック時の挙動 */
    //public void OnInputClicked(InputClickedEventData eventData)
    //{
    //    // if be notificated from image processing, an object is generated
    //    if (TestBox[2] != null) {
    //        Destroy(TestBox[2]); TestBox[2] = null;
    //    }
    //    for (int i = 0; i < 2; i++) TestBox[i + 1] = TestBox[i];
    //    TestBox[0] = Instantiate(_TestBox);
    //    Debug.LogFormat("OnInputClicked\r\nSource: {0}  SourceId: {1} TapCount: {2}", eventData.InputSource, eventData.SourceId, eventData.TapCount);
    //}

    //public void GestureRecognizer_Tapped(TappedEventArgs args)
    //{
    //    Debug.Log("GestureRecognizer Tapped");
    //}
    //public void OnTappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    //{
    //    Debug.Log("source:aaa ");
    //}

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
            Vector3 position = gazeManager.GazeNormal;
            TestBox[0] = Instantiate(_TestBox, position, new Quaternion());
        };
        gestureRecognizer.StartCapturingGestures();

    }
	
	// Update is called once per frame
	void Update () {
        //InteractionManager.
	}
    
}
