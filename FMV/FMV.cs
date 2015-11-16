using UnityEngine;

namespace UnityHelpers
{
    public class FMV : MonoBehaviour
    {
        public bool interrupt = false;
        public float time = 0f;

        public MovieTexture movie;

        void Start()
        {
            movie.Play();
        }

        void Pause()
        {
            movie.Pause();
        }

        void Stop()
        {
            movie.Stop();
        }

        void Update()
        {
            if (!movie.isPlaying)
            {
                movie.Stop();
                movie.Play();
            }

            if (Input.GetButtonDown("Jump"))
            {
                interrupt = true;
            }
        }

        public void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movie, ScaleMode.StretchToFill);

            if (time > 10.0f)
            {
                interrupt = false;
                time = 0.0f;
            }

            if (interrupt)
            {
                // Skip GUI

                time += Time.deltaTime;
            }

            if (interrupt && Input.GetButtonDown("Jump"))
            {
                // Action after skip
            }
        }

    }
}