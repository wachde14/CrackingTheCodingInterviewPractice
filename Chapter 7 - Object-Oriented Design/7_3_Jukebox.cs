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
            _playlist = new Queue<Song>();

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

        public int SongsRemaining()
        {
            return _playlist.Count;
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
            //Arrange
            Artist eminem = new Artist("Eminem", Genre.Rap);
            Song eminemSong = new Song("No Love","Recovery", eminem);

            Artist mj = new Artist("Michael Jackson", Genre.Pop);
            Song mjSong = new Song("Thriller", "Thriller", mj);
            Song mjSong2 = new Song("Billie Jean", "Thriller", mj);

            Artist metallica = new Artist("Metallica", Genre.Rock);
            Song metallicaSong = new Song("Fade to Black", "Ride the Lightning", mj);

            List<Song> songList = new List<Song>();
            songList.Add(eminemSong);
            songList.Add(mjSong);
            songList.Add(mjSong2);
            songList.Add(metallicaSong);

            Jukebox testJukebox = new Jukebox(songList);

            Assert.AreEqual(4, testJukebox.SongsRemaining());

            //Act
            testJukebox.Start();

            //Assert 
            Assert.AreEqual(0, testJukebox.SongsRemaining()); 
        }
    }
}
