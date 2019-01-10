using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chapter_7___Object_Oriented_Design
{
    /// <summary>
    /// Jukebox: Design a musical jukebox using object-oriented principles.
    /// </summary>
    class Jukebox
    {
        private Queue<Song> _playlist;

        public Jukebox(List<Song> songList)
        {
            foreach (Song song in songList)
            {
                _playlist.Enqueue(song);
            }
        }

        public void Start()
        {
            while (_playlist.Count > 0)
            {
                PlaySong(_playlist.Dequeue());
            }
        }

        private void PlaySong(Song song)
        {
            Console.Write("Now playing " + song.SongName + " by " + song.Artist.Name + " from the album " + song.AlbumName);
        }

        public void Stop()
        {
            Console.Write("Stopping Jukebox");
        }

        public void AddSongToPlaylist(Song song)
        {
            _playlist.Enqueue(song);
        }

        public void SkipCurrentSong()
        {
            Stop();
            _playlist.Dequeue();
            Start();
        }
    }

    class Song
    {
        public string SongName;
        public string AlbumName;
        public Artist Artist;

        public Song(string songName, string albumName, Artist artist)
        {
            SongName = songName;
            AlbumName = albumName;
            Artist = artist;
        }
    }
    public enum Genre { Rap, Country, Rock, Pop };

    class Artist
    {
        public string Name;
        public Genre Genre;

        public Artist(string name, Genre genre)
        {
            Name = name;
            Genre = genre;
        }
    }

    public class _7_3_JukeboxTests
    {
        [Test]
        public void _7_3_Jukebox_WithSongRequests_ShouldPlaySongsSuccessfully()
        {
            Artist eminem = new Artist("Eminem", Genre.Rap);
            Song eminemSong = new Song("No Love","Recovery", eminem);


        }
    }
}
