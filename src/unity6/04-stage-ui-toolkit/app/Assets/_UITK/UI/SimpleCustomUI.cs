using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.UITK.UI
{
    public class SimpleCustomUI : MonoBehaviour
    {
        private Button _button;
        private Toggle _toggle;

        private int _clickCount;

        //Add logic that interacts with the UI controls in the `OnEnable` methods
        private void OnEnable()
        {
            // The UXML is already instantiated by the UIDocument component
            var uiDocument = GetComponent<UIDocument>();

            // Get the root visual element
            VisualElement root = uiDocument.rootVisualElement;

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            VisualElement label = new Label("Hello World! From UI Script");
            root.Add(label);
        }
    }
}
