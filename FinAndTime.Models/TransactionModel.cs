using FinAndTime.Core.Models;
using FinAndTime.DataAccess;
using FinAndTime.Entities;
using FinAndTime.Methods;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace FinAndTime.Models
{
    public class TransactionModel : ITransactionModel
    {
        public TransactionEntity ReaderToEntity(SQLiteDataReader reader)
        {
            return new TransactionEntity()
            {
                Id = int.Parse(reader["Id"].ToString()),
                ReferenceNumber = reader["ReferenceNumber"].ToString(),
                TransactionPartyId = int.Parse(reader["TransactionPartyId"].ToString()),
                ScheduledTransactionId = reader["ScheduledTransactionId"] == DBNull.Value ? null : (int?)int.Parse(reader["ScheduledTransactionId"].ToString()),
                IsIncome = Convert.ToBoolean(int.Parse(reader["IsIncome"].ToString())),
                Amount = double.Parse(reader["Amount"].ToString()),
                Remarks = reader["Remarks"].ToString(),
                TransactionDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["TransactionDateTime"].ToString())),
                CreatedDateTime = TimeConverterMethods.ConvertTimeStampToDateTime(int.Parse(reader["CreatedDateTime"].ToString())),
                IsUserPerformed = Convert.ToBoolean(int.Parse(reader["IsUserPerformed"].ToString())),
                IsActive = Convert.ToBoolean(int.Parse(reader["IsActive"].ToString()))
            };
        }


        public async Task<TransactionEntity> GetTransactionByIdAsync(int id)
        {
            string query = "SELECT * FROM `Transaction` WHERE `Id` = @Id";
            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@Id", id)
            };
            return await SqliteConnector.ExecuteQuerySingleOrDefaultAsync(query, ReaderToEntity, parameters);
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsAsync()
        {
            string query = "SELECT * FROM `Transaction`";
            return await SqliteConnector.ExecuteQueryAsync(query, ReaderToEntity);
        }

        public async Task<int> InsertTransactionAsync(TransactionEntity transactionEntity, bool isUserPerformed = false)
        {
            string query = "INSERT INTO `Transaction`" +
                "(`TransactionPartyId`,`Amount`,`IsIncome`,`TransactionDateTime`,`ScheduledTransactionId`,`Remarks`,`CreatedDateTime`,`IsUserPerformed`) " +
                "VALUES (@TransactionPartyId,@Amount,@IsIncome,@TransactionDateTime,@ScheduledTransactionId,@Remarks,@CreatedDateTime,@IsUserPerformed);";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@TransactionPartyId", transactionEntity.TransactionPartyId),
                new KeyValuePair<string, object>("@Amount", transactionEntity.Amount),
                new KeyValuePair<string, object>("@IsIncome", transactionEntity.IsIncome ? 1 : 0),
                new KeyValuePair<string, object>("@TransactionDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.TransactionDateTime)),
                new KeyValuePair<string, object>("@ScheduledTransactionId", transactionEntity.ScheduledTransactionId),
                new KeyValuePair<string, object>("@Remarks", transactionEntity.Remarks),
                new KeyValuePair<string, object>("@CreatedDateTime", TimeConverterMethods.ConvertDateTimeToTimeStamp(transactionEntity.CreatedDateTime)),
                new KeyValuePair<string, object>("@IsUserPerformed", isUserPerformed ? 1 : 0)
            };

            int id = await SqliteConnector.ExecuteInsertQueryAsync(query, parameters, true);

            query = "UPDATE `Transaction` SET `ReferenceNumber`=@ReferenceNumber WHERE `Id`=@Id";

            parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@ReferenceNumber", id.ToString("TC00000000")),
                new KeyValuePair<string, object>("@Id", id)
            };

            await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);

            return id;
        }

        public async Task<int> UpdateTransactionAsync(TransactionEntity transactionEntity)
        {
            string query = "UPDATE `Transaction` " +
                "SET `TransactionPartyId`=@TransactionPartyId,`Amount`=@Amount,`IsIncome`=@IsIncome,`Remarks`=@Remarks " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@TransactionPartyId", transactionEntity.TransactionPartyId),
                new KeyValuePair<string, object>("@Amount", transactionEntity.Amount),
                new KeyValuePair<string, object>("@IsIncome", transactionEntity.IsIncome ? 1 : 0),
                new KeyValuePair<string, object>("@Remarks", transactionEntity.Remarks),
                new KeyValuePair<string, object>("@Id", transactionEntity.Id),
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }

        public async Task<int> DeleteTransactionAsync(int id)
        {
            string query = "UPDATE `Transaction` " +
                "SET `IsActive`=@IsActive " +
                "WHERE `Id` = @Id";

            IEnumerable<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@IsActive", 0),
                new KeyValuePair<string, object>("@Id", id)
            };

            return await SqliteConnector.ExecuteNonQueryAsync(query, parameters, true);
        }
    }
}
