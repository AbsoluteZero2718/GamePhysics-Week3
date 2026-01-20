using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RayGun : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int enemies = 5;


    [SerializeField] Camera cam;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float maxDistance;
    [SerializeField] float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
        scoreCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, maxDistance, enemyLayer))
            {
                MeshRenderer mesh = hit.transform.GetComponent<MeshRenderer>();
                mesh.material.color = Color.red;
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                Destroy(hit.transform.gameObject, 0.1f);

                enemies--;
                Scoring(hit.transform.gameObject);
                DisplayScore();
            }
        }
       
    }

    void Scoring(GameObject targets)
    {
        score += 5 * Vector3.Distance(cam.transform.position, targets.transform.position);
        score = Mathf.RoundToInt(score);
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
        if(enemies <= 0)
        {
            scoreCanvas.SetActive(true);
            highScoreText.text = "High Score: " + score.ToString();
        }
    }
}
