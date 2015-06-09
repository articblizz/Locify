using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JariZ;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace SpotifyLibDotNET
{
    class Spotify
    {
        List<string> queue = new List<string>();
        DateTime timeToChange;
        SpotifyAPI API;
        Responses.CFID cfid;
        Responses.Status status;

        DateTime dateWhenPaused;

        bool terminate = false;

        public bool IsPaused = false;

        Thread checkThread;
        Thread checkQueueList;

        private bool playIfPaused = false;

        /// <summary>
        /// New instance of the class. You may need this lele
        /// </summary>
        public Spotify(bool playInstantly)
        {
            try
            {
                // Initialize Spotify
                API = new SpotifyAPI(SpotifyAPI.GetOAuth(), "jariz-example.spotilocal.com");
                cfid = API.CFID;
                status = API.Status;

                playIfPaused = playInstantly;

                // start the thread to check after queue entries
                checkQueueList = new Thread(CheckQueue);
                checkQueueList.Name = "CheckQueueThread";
                checkQueueList.Start();

                Debug.WriteLine("Spotify running..");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }


        /// <summary>
        /// Terminate all threads (This is as good as it gets)
        /// </summary>
        public void Exit()
        {
            checkThread.Abort();
            checkQueueList.Abort();

            terminate = true;

            checkThread = null;
            checkQueueList = null;
        }


        /// <summary>
        /// Remove the song at index in the queue
        /// </summary>
        /// <param name="index">Index in list</param>
        public void RemoveQueueAt(int index)
        {
            try
            {
                queue.RemoveAt(index);
            }
            catch { }
        }

        /// <summary>
        /// Return the Queue list
        /// </summary>
        public List<string> DisplayQueue()
        {
            return queue;
        }

        /// <summary>
        /// Checks queue.txt after new entries to add to the music queue.
        /// </summary>
        private void CheckQueue()
        {
            while (!terminate)
            {
                try
                {
                    Thread.Sleep(500); // sleep thread so we won't refresh so often
                    if (!File.Exists("queue.txt"))
                        File.Create("queue.txt");
                    var songs = File.ReadAllLines("queue.txt"); // read all lines/queue entries
                    if (songs.Length > 0)
                    {
                        for (int i = 0; i < songs.Length; i++)
                        {
                            queue.Add(songs[i]); // add the song URIs to the queue list
                        }
                        File.WriteAllText("queue.txt", string.Empty); // clear the document so we don't double things up

                        Console.WriteLine("Queue refreshed with " + songs.Length + " new items");

                        if (!status.playing && playIfPaused && !IsPaused) 
                            PlaySong();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Plays a song on Spotify
        /// </summary>
        /// <param name="uri">Song URI</param>
        public void PlaySong(string uri)
        {
            try
            {
                API.URI = uri; // set the next song
                status = API.Play; // play the song
            }
            catch
            {
                // If the URI is invalid, play the next int queue
                if (queue.Count > 0)
                    PlaySong(queue[0]);
                return;
            }
            try
            {
                Debug.WriteLine("Playing " + status.track.track_resource.name + " + by " + status.track.artist_resource.name); // write shit down


                // check when it's time to change the song
                timeToChange = DateTime.Now;
                timeToChange = timeToChange.AddMinutes(((double)status.track.length / 60) - (double)(1 / 60));

                // start a new thread to check when it's that time
                checkThread = new Thread(CheckSongs);
                checkThread.Name = "CheckSongThread";
                checkThread.Start();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            try
            {
                using(StreamWriter sw = new StreamWriter("currentlyplaying.txt"))
                {
                    sw.WriteLine(GetPlayingStatus());
                    sw.Close();
                }
            }
            catch { }
        }


        /// <summary>
        /// Pause Spotify
        /// </summary>
        public void Pause()
        {
            if (!status.playing)
                return;

            IsPaused = true;

            // store the date when we paused
            dateWhenPaused = DateTime.Now;
            status = API.Pause;
        }


        /// <summary>
        /// Resume Spotify
        /// </summary>
        public void Resume()
        {
            IsPaused = false;

            // check the difference between the date we paused and now when we resume
            TimeSpan duration = DateTime.Now - dateWhenPaused;
            // add the difference to the timeToChange datetime variable so we know the new time to change the song
            timeToChange = timeToChange.AddMinutes(duration.TotalMinutes);

            status = API.Resume; // resume spotify
        }

        /// <summary>
        /// Force play the next song in Queue.
        /// </summary>
        public void PlaySong()
        {
            try
            {
                // if we're still checking when it's time to change the song, cancel it
                if (checkThread != null)
                    checkThread.Abort();

                if (queue.Count > 0)
                {
                    // play the next song and remove it from the queue
                    var song = queue[0];
                    queue.RemoveAt(0);
                    PlaySong(song);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Adds a song to the queue
        /// </summary>
        /// <param name="uri">Song URI</param>
        public void QueueSong(string uri)
        {
            queue.Add(uri);
        }

        /// <summary>
        /// Returns the track and artist
        /// </summary>
        /// <returns>Track - Artist</returns>
        public string GetPlayingStatus()
        {
            return status.track.track_resource.name + " - " + status.track.artist_resource.name;
        }

        /// <summary>
        /// Checks when the song ends and change the song to next in queue.
        /// </summary>
        private void CheckSongs()
        {
            while (!terminate)
            {
                while (IsPaused) { }

                if (DateTime.Now.ToLongTimeString() == timeToChange.ToLongTimeString()) // compare the time
                {
                    if (queue.Count > 0) // if we got some songs in the queue, play them and remove
                    {
                        PlaySong(queue[0]);
                        queue.RemoveAt(0);
                        break;
                    }
                    break;
                }
            }
        }
    }
}
