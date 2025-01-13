using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoPause : MonoBehaviour
{
    public VideoPlayer player;
    public Transform supernovaHolder;

    public WeightedRandomList<Transform> lootTable;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPressed();
        }
    }

    public void ButtonPressed()
    {
        if (player.isPlaying == false)
        {
            //als de video weer afgespeeld wordt, wordt de random supernova/bom gedelete
            player.Play();
            HideNova();

            Debug.Log("play + bom weg");
        }
        else
        {
            //als de video gepauzeerd wordt, wordt er ook een random supernova/bom afgespeeld
            player.Pause();  
            ShowNova();

            Debug.Log("pauze + bom");
        }
    }

    public void ShowNova()
    {
        Transform supernova = lootTable.GetRandom();
        Instantiate(supernova, supernovaHolder);
        supernovaHolder.gameObject.SetActive(true);

        Debug.Log("supernova shown");
    }

    public void HideNova()
    {
        supernovaHolder.gameObject.SetActive(false);

        foreach (Transform child in supernovaHolder)
        {
            Destroy(child.gameObject);
            Debug.Log("child aborted.");
        }
    }
}
