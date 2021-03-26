using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GraphNode
{
  public Vector2 xyValue;
  public Vector2 xyPosition;
  public GameObject gameObject;
  public string type;
}

public class GraphPanel : MonoBehaviour
{
  public Sprite circleSprite;
  public GameObject yAxis;
  public GameObject xAxis;
  public GameObject graphContainer;
  private ArrayList graphNodes = new ArrayList();
  public GameObject graphKey;
  public GameObject graphKeyItem;
  private ArrayList graphTypes = new ArrayList();

  private ArrayList colorScheme = new ArrayList();

  private float yMax = 4;
  private float xMax = 4;

  public float nodeSize;

  public int cullingLimit;
  public float cullingPercent;
  
  void Start()
  {
    InitColorScheme();
    Resize();
  }

  private void InitColorScheme()
  {
    colorScheme.Add(new Color(0.9f, 0.8f, 0.5f, 1.0f));
    colorScheme.Add(new Color(0.9f, 0.5f, 0.5f, 1.0f));
    colorScheme.Add(new Color(0.5f, 0.9f, 0.5f, 1.0f));
    colorScheme.Add(new Color(0.5f, 0.5f, 0.9f, 1.0f));
    colorScheme.Add(new Color(0.9f, 0.5f, 0.9f, 1.0f));
    colorScheme.Add(new Color(0.5f, 0.9f, 0.9f, 1.0f));
  }

  void Update()
  {
    if (graphNodes.Count > cullingLimit)
      CullNodes();
  }

  private void CullNodes()
  {
    int cullCount = 0;
    int originalCount = graphNodes.Count;
    ArrayList toCull = new ArrayList();

    for (int i = 0; i < originalCount; i++)
    {
      if (((float)cullCount) / ((float)i) >= cullingPercent)
        continue;
      cullCount++;
      toCull.Add(graphNodes[i]);
    }

    foreach (GraphNode n in toCull)
    {
      CullNode(n);
    }
  }

  private void CullNode(GraphNode node)
  {
    graphNodes.Remove(node);
    GameObject.Destroy(node.gameObject);
  }

  public void AddNode(float xValue, float yValue, string type)
  {
    if (!graphTypes.Contains(type))
    {
      graphTypes.Add(type);
      AddKey(type);
    }

    bool resize = false;
    if (xValue > xMax)
    {
      xMax = xValue;
      resize = true;
    }
    if (yValue > yMax)
    {
      yMax = yValue;
      resize = true;
    }
    if (resize)
      Resize();

    GraphNode node = CreateNode();
    graphNodes.Add(node);
    node.xyValue = new Vector2(xValue, yValue);
    node.type = type;
    PlaceNode(node);
    ColorNode(node);
  }

  private void MakeNewColor()
  {
    colorScheme.Add(new Color(Random.value, Random.value, Random.value, 1.0f));
  }

  private void AddKey(string type)
  {
    int index = graphTypes.IndexOf(type);
    if (index >= colorScheme.Count)
      MakeNewColor();
    Color color = (Color)colorScheme[index];

    GameObject key = GameObject.Instantiate(graphKeyItem);
    key.transform.SetParent(graphKey.transform, false);
    key.SetActive(true);

    float itemHeight = graphKeyItem.GetComponent<RectTransform>().rect.height;
    float itemPosition = -itemHeight * 0.5f - itemHeight * index;

    key.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, itemPosition);

    Vector2 offsetMin = graphKey.GetComponent<RectTransform>().offsetMin;
    offsetMin.y -= itemHeight;
    graphKey.GetComponent<RectTransform>().offsetMin = offsetMin;

    Text text = key.GetComponentInChildren(typeof(Text)) as Text;
    Image image = key.GetComponentInChildren(typeof(Image)) as Image;

    text.text = type;
    image.color = color;
  }

  private void Resize()
  {
    foreach (GraphNode n in graphNodes)
    {
      PlaceNode(n);
    }
    int yLabels = yAxis.transform.childCount;
    for (int i = 0; i < yLabels; i++)
    {
      Transform label = yAxis.transform.GetChild(i);
      label.gameObject.GetComponent<Text>().text = Mathf.Ceil((float)i / ((float)yLabels - 1) * yMax).ToString();
    }
    int xLabels = xAxis.transform.childCount;
    for (int i = 0; i < xLabels; i++)
    {
      Transform label = xAxis.transform.GetChild(i);
      label.gameObject.GetComponent<Text>().text = Mathf.Ceil((float)i / ((float)xLabels - 1) * xMax).ToString();
    }
  }

  private void PlaceNode(GraphNode node)
  {
    float x = node.xyValue.x;
    x = x / xMax * graphContainer.GetComponent<RectTransform>().rect.width;
    float y = node.xyValue.y;
    y = y / yMax * graphContainer.GetComponent<RectTransform>().rect.height;
    node.xyPosition = new Vector2(x, y);
    node.gameObject.GetComponent<RectTransform>().anchoredPosition = node.xyPosition;
  }

  private void ColorNode(GraphNode node)
  {
    int index = graphTypes.IndexOf(node.type);
    if (index >= colorScheme.Count)
      MakeNewColor();
    Color color = (Color) colorScheme[index];
    node.gameObject.GetComponent<Image>().color = color;
  }

  private GraphNode CreateNode()
  {
    GameObject circle = new GameObject("circle", typeof(Image));
    circle.transform.SetParent(graphContainer.transform, false);
    circle.GetComponent<Image>().sprite = circleSprite;
    RectTransform circleTransform = circle.GetComponent<RectTransform>();
    circleTransform.anchoredPosition = new Vector2(0, 0);
    circleTransform.sizeDelta = new Vector2(nodeSize, nodeSize);
    circleTransform.anchorMin = new Vector2(0, 0);
    circleTransform.anchorMax = new Vector2(0, 0);
    GraphNode newNode = new GraphNode();
    newNode.gameObject = circle;
    return newNode;
  }

}
