using UploadMusicModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace UploadMusicDL
{
    public class UploadMusicRepoDB : IUploadMusicRepoDB
    {
        private readonly UploadMusicDBContext _context;

        public UploadMusicRepoDB(UploadMusicDBContext context)
        {
            _context = context;
        }
        public async Task<UploadMusic> AddUploadedMusicAsync(UploadMusic newUploadedMusic)
        {
            await _context.UploadMusic.AddAsync(newUploadedMusic);
            await _context.SaveChangesAsync();
            return newUploadedMusic;
        }

        public async Task<UploadMusic> DeleteUploadedMusicAsync(UploadMusic uploadedMusic2BDeleted)
        {
            _context.UploadMusic.Remove(uploadedMusic2BDeleted);
            await _context.SaveChangesAsync();
            return uploadedMusic2BDeleted;
        }

        public async Task<List<UploadMusic>> GetUploadedMusicAsync()
        {
            return await _context.UploadMusic.ToListAsync();
        }

        public async Task<UploadMusic> GetUploadedMusicByIDAsync(int id)
        {
            return await _context.UploadMusic
                .Where(um => um.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UploadMusic>> GetUploadedMusicByUserIDAsync(int userid)
        {
            return await _context.UploadMusic
                .Where(um => um.UserId == userid)
                .ToListAsync();
        }

        public async Task<UploadMusic> UpdateUploadedMusicAsync(UploadMusic uploadedMusic2BUpdated)
        {
            UploadMusic oldUploadedMusic = await _context.UploadMusic.Where(um => um.Id == uploadedMusic2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldUploadedMusic).CurrentValues.SetValues(uploadedMusic2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return uploadedMusic2BUpdated;
        }
    }
}
