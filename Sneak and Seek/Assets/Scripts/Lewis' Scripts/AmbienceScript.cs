using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceScript : MonoBehaviour
{
    AudioManager audioManager;

    // The delay before the next audio clip plays
    int delay;

    // The time that the last audio clip played
    float lastPlayTime;

    int randomSound;

    int goAheadChance;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the audio manager component
        audioManager = GetComponent<AudioManager>();

        // Sets the first delay
        delay = Random.Range(5, 15);

        // Sets the starting last play time
        lastPlayTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if time has passed the set delay
        if (Time.time > lastPlayTime + delay)
        {
            // Picks a random number for the audio clip (Put the highest index of the ambience sound in the max slot)
            randomSound = Random.Range(0, 25);

            // Checks what type of sound was chosen
            if (randomSound < 11 && randomSound > 5) 
            {
                // Generates a number to see if the chosen sound should actually go head
                goAheadChance = Random.Range(0, 10);

                // Checks if that chosen number is above zero and rechooses sound below the index level if not
                if (goAheadChance > 8)
                {
                    randomSound = Random.Range(0, 5);
                }
            }
            else if (randomSound < 16)
            {
                // Generates a number to see if the chosen sound should actually go head
                goAheadChance = Random.Range(0, 10);

                // Checks if that chosen number is above zero and rechooses sound below the index level if not
                if (goAheadChance > 8)
                {
                    randomSound = Random.Range(0, 10);
                }
            }
            else if (randomSound < 21)
            {
                // Generates a number to see if the chosen sound should actually go head
                goAheadChance = Random.Range(0, 10);

                // Checks if that chosen number is above zero and rechooses sound below the index level if not
                if (goAheadChance > 4)
                {
                    randomSound = Random.Range(0, 15);
                }
            }
            else if (randomSound < 26)
            {
                // Generates a number to see if the chosen sound should actually go head
                goAheadChance = Random.Range(0, 10);

                // Checks if that chosen number is above zero and rechooses sound below the index level if not
                if (goAheadChance > 0)
                {
                    randomSound = Random.Range(0, 20);
                }
            }

            // Searches through the list attached to the audio manager and plays the random sound
            audioManager.Play(audioManager.sounds[randomSound].name);

            // Resets the last play time
            lastPlayTime = Time.time;

            // Randomly chooses a delay
            delay = Random.Range(2, 5);
        }
    }
}
