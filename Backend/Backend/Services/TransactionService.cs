using Backend.Db;
using Backend.Dto;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services
{
    public interface ITransactionService
    {
        Task<bool> InsertTrBpkb(TransactionModel data);
        Task<bool> ValidateTransaction(TransactionModel model);
    }

    public class TransactionService : ITransactionService
    {
        private readonly TestDbContext dbContext;
        public TransactionService(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> InsertTrBpkb(TransactionModel data)
        {
            try
            {
                var trBpkb = new TrBpkbDto
                {
                    AgreementNumber = data.AgreementNumber,
                    BpkbNo = data.NoBPKB,
                    BranchId = data.BranchID,
                    BpkbDate = data.TanggalBPKB,
                    FakturNo = data.NoFaktur,
                    FakturDate = data.TanggalFaktur,
                    LocationId = data.LokasiPenyimpanan,
                    PoliceNo = data.NomorPolisi,
                    BpkbDateIn = data.TanggalBPKBIn,
                    CreatedBy = data.User,
                    CreatedOn = DateTime.Now
                };
                dbContext.TrBpkbs.Add(trBpkb);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ValidateTransaction(TransactionModel model)
        {
            var datas = await dbContext.TrBpkbs.AsNoTracking().ToListAsync();
            var data = datas.FirstOrDefault(u => u.AgreementNumber.ToLower() == model.AgreementNumber.ToLower());
            return data != null;
        }
    }
}
