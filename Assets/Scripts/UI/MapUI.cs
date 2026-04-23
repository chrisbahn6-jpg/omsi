using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Map-UI für Routenauswahl und Navigation
/// </summary>
public class MapUI : MonoBehaviour
{
    [Header("UI-Elemente")]
    public Canvas mapCanvas;
    public Button[] routeButtons = new Button[4];
    public Text selectedRouteText;
    public RawImage minimapImage;
    
    [Header("Einstellungen")]
    public bool mapVisible = false;
    
    private BusController busController;
    private RouteManager routeManager;
    
    private void Start()
    {
        busController = FindObjectOfType<BusController>();
        routeManager = FindObjectOfType<RouteManager>();
        
        if (mapCanvas == null)
        {
            CreateMapUI();
        }
        else
        {
            mapCanvas.gameObject.SetActive(false);
        }
    }
    
    private void Update()
    {
        // M für Karte anzeigen/verbergen
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMapUI();
        }
    }
    
    private void CreateMapUI()
    {
        // Canvas für Karte
        GameObject canvasObject = new GameObject("Map_Canvas");
        mapCanvas = canvasObject.AddComponent<Canvas>();
        mapCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        mapCanvas.gameObject.SetActive(false);
        
        RectTransform canvasRect = canvasObject.GetComponent<RectTransform>();
        canvasRect.anchorMin = Vector2.zero;
        canvasRect.anchorMax = Vector2.one;
        canvasRect.offsetMin = Vector2.zero;
        canvasRect.offsetMax = Vector2.zero;
        
        // Background
        Image bgImage = canvasObject.AddComponent<Image>();
        bgImage.color = new Color(0, 0, 0, 0.8f);
        
        // Title
        GameObject titleObject = new GameObject("Title");
        titleObject.transform.parent = canvasObject.transform;
        Text titleText = titleObject.AddComponent<Text>();
        titleText.text = "ROUTENAUSWAHL";
        titleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        titleText.fontSize = 36;
        titleText.fontStyle = FontStyle.Bold;
        titleText.color = Color.white;
        titleText.alignment = TextAnchor.MiddleCenter;
        
        RectTransform titleRect = titleObject.GetComponent<RectTransform>();
        titleRect.anchoredPosition = new Vector2(0, 100);
        titleRect.sizeDelta = new Vector2(800, 100);
        
        // Route Buttons
        string[] routeNames = { "Route 100: Spandau", "Route 200: Grunddorf", "Route 300: Metropole Ruhr", "Route 400: Neudorf" };
        
        for (int i = 0; i < 4; i++)
        {
            GameObject buttonObject = CreateRouteButton(canvasObject, routeNames[i], i, -50 + i * 80);
            routeButtons[i] = buttonObject.GetComponent<Button>();
            
            int routeIndex = i; // Lokale Kopie für Closure
            routeButtons[i].onClick.AddListener(() => SelectRoute(routeIndex));
        }
        
        // Selected Route Text
        GameObject selectedObject = new GameObject("SelectedRoute");
        selectedObject.transform.parent = canvasObject.transform;
        selectedRouteText = selectedObject.AddComponent<Text>();
        selectedRouteText.text = "Keine Route ausgewählt";
        selectedRouteText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        selectedRouteText.fontSize = 24;
        selectedRouteText.color = Color.yellow;
        selectedRouteText.alignment = TextAnchor.MiddleCenter;
        
        RectTransform selectedRect = selectedObject.GetComponent<RectTransform>();
        selectedRect.anchoredPosition = new Vector2(0, -150);
        selectedRect.sizeDelta = new Vector2(600, 50);
    }
    
    private GameObject CreateRouteButton(GameObject parent, string buttonText, int index, int yPosition)
    {
        GameObject buttonObject = new GameObject($"RouteButton_{index}");
        buttonObject.transform.parent = parent.transform;
        
        // Button-Image
        Image buttonImage = buttonObject.AddComponent<Image>();
        buttonImage.color = new Color(0.2f, 0.2f, 0.8f);
        
        // Button-Komponente
        Button button = buttonObject.AddComponent<Button>();
        button.targetGraphic = buttonImage;
        
        // Color-Transition
        ColorBlock colors = button.colors;
        colors.normalColor = new Color(0.2f, 0.2f, 0.8f);
        colors.highlightedColor = new Color(0.3f, 0.3f, 1f);
        colors.pressedColor = new Color(0.1f, 0.1f, 0.5f);
        button.colors = colors;
        
        // RectTransform
        RectTransform buttonRect = buttonObject.GetComponent<RectTransform>();
        buttonRect.anchoredPosition = new Vector2(0, yPosition);
        buttonRect.sizeDelta = new Vector2(400, 60);
        
        // Text
        GameObject textObject = new GameObject("Text");
        textObject.transform.parent = buttonObject.transform;
        Text buttonTextComponent = textObject.AddComponent<Text>();
        buttonTextComponent.text = buttonText;
        buttonTextComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        buttonTextComponent.fontSize = 20;
        buttonTextComponent.fontStyle = FontStyle.Bold;
        buttonTextComponent.color = Color.white;
        buttonTextComponent.alignment = TextAnchor.MiddleCenter;
        
        RectTransform textRect = textObject.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;
        
        return buttonObject;
    }
    
    private void SelectRoute(int routeIndex)
    {
        routeManager.SelectRoute(routeIndex);
        
        RouteManager.BusRoute selectedRoute = routeManager.GetCurrentRoute();
        if (selectedRoute != null)
        {
            selectedRouteText.text = $"Route {selectedRoute.routeNumber}: {selectedRoute.routeName}\n(Drücke R zum Starten)";
        }
    }
    
    public void ToggleMapUI()
    {
        mapVisible = !mapVisible;
        if (mapCanvas != null)
        {
            mapCanvas.gameObject.SetActive(mapVisible);
        }
    }
}
