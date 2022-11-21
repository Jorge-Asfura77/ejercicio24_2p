using System;
using System.Collections.Generic;
using System.Text;
using ejercicio24_2p.Models;
using SQLite;
using System.Threading.Tasks;

namespace ejercicio24_2p.Controllers
{
    public class VideoDB
    {
        readonly SQLiteAsyncConnection db;

        public VideoDB(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<VideoModel>().Wait();
        }

        public Task<List<VideoModel>> GetVideoList()
        {
            return db.Table<VideoModel>().ToListAsync();
        }

        public Task<VideoModel> GetVideoForId(int pcodigo)
        {
            return db.Table<VideoModel>()
                .Where(i => i.Id == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveVideoRecord(VideoModel videos)
        {
            if (videos.Id != 0)
            {
                return db.UpdateAsync(videos);
            }
            else
            {
                return db.InsertAsync(videos);
            }
        }

        public Task<int> DeleteVideo(VideoModel videos)
        {
            return db.DeleteAsync(videos);
        }
    }
}
