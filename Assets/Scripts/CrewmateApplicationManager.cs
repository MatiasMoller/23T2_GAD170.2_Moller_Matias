using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CrewmateApplicationManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI names;
    [SerializeField] TextMeshProUGUI hobbies;
    [SerializeField] TextMeshProUGUI stats;

    public List<CrewmateApplication> crewmates;
    private CrewmateApplication currentApplication;
    private int crewmatesKilled; // variable to track the number of crewmates killed
    private bool isGameOver = false;

    private void Start()
    {
        crewmates = new List<CrewmateApplication>();
        crewmatesKilled = 0; // Initialize the count of crewmates killed = 0
        GenerateNewApplication();
    }

    public void GenerateNewApplication()
    {
        currentApplication = CreateNewApplication();
        names.text = currentApplication?.name; 
        hobbies.text = currentApplication?.hobby;
        // ? checking for null 
    }

    public CrewmateApplication CreateNewApplication()
    {
        int check = Random.Range(0, 2);
        bool isParasite = (check == 1);
        Debug.Log(isParasite);
        return new CrewmateApplication(isParasite);
    }

    public void Hire()
    {
        if (isGameOver)
        {
            Debug.Log("Game over! You cannot hire any more crewmates.");
            return;
        }

        if (currentApplication.hasParasiteHobby)
        {
            KillRandomCrewmate();
            Debug.Log("Parasite hired and killed another crewmate!");
        }
        else
        {
            crewmates.Add(currentApplication);
            Debug.Log("Crewmate hired!");
        }

        UpdateCrewmateCount();

        if (crewmatesKilled >= 5)
        {
            GameOver();
            return; // Stop the game if it's over
        }
        else if (crewmates.Count >= 10)
        {
            Debug.Log("Congratulations! You hired 10 crewmates. You win!");
            GameOver();
            return; // Stop the game if it's over
        }

        GenerateNewApplication();
    }

    private void KillRandomCrewmate()
    {
        if (crewmates.Count > 0)
        {
            int numCrewmatesToKill = Random.Range(1, crewmates.Count + 1);
            for (int i = 0; i < numCrewmatesToKill; i++)
            {
                int index = Random.Range(0, crewmates.Count);
                CrewmateApplication crewmateToKill = crewmates[index];
                crewmates.RemoveAt(index);
                Debug.Log("Crewmate " + crewmateToKill.name + " killed!");
                crewmatesKilled++; // Increment the count of crewmates killed
            }
            Debug.Log("Parasite hired and killed " + numCrewmatesToKill + " crewmate(s)!");
        }
    }

    private void UpdateCrewmateCount()
    {
        int crewmatesHired = crewmates.Count;
        stats.text = "Crewmates Hired: " + crewmatesHired;
        stats.text += "\nCrewmates Killed: " + crewmatesKilled; // count of crewmates killed
    }

    public void Reject()
    {
        if (isGameOver)
        {
            Debug.Log("Game over! You cannot reject any more crewmate applications.");
            return;
        }

        GenerateNewApplication();
    }

    public void GameOver()
    {
        Debug.Log("Game over! The game is now stopped.");

        if (crewmatesKilled >= crewmates.Count / 2)
        {
            // Most of the crewmates have been murdered, switch to "FIRED" scene
            SceneManager.LoadScene("FIRED");
        }
        else
        {
            // Congratulations, switch to "Congratulations" scene
            SceneManager.LoadScene("Congratulations");
        }
    }
}
