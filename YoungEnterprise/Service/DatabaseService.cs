using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using YoungEnterprise_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class DatabaseService
    {
        public DB_YoungEnterpriseContext databaseContext;
        public DatabaseService()
        {
            databaseContext = GetConnection();
        }
    

        public DB_YoungEnterpriseContext GetConnection()
        {
            var connection = @"Server=DESKTOP-ACNIRC0;Database=DB_YoungEnterprise;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<DB_YoungEnterpriseContext>();
            optionsBuilder.UseSqlServer(connection);
            DB_YoungEnterpriseContext context = new DB_YoungEnterpriseContext(optionsBuilder.Options);
            return context;
        }

        public void CreateJudge(int eventID, string judgeUsername, string judgePassword, string judgeName)
        {
            using (databaseContext)
            {
                try
                {
                    // Hard-code data for a new record, for testing.
                    TblJudge judge = new TblJudge()
                    {
                        FldEventId = eventID,
                        FldJudgeUsername = judgeUsername,
                        FldJudgePassword = judgePassword,
                        FldJudgeName = judgeName
                    };
                    databaseContext.TblJudge.Add(judge);
                    databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }

            }
        }

        public List<TblJudge> GetAllJudges()
        {
            using (databaseContext)
            {
                try
                {

                    List<TblJudge> allJudges = new List<TblJudge>();
                    foreach (TblJudge judge in databaseContext.TblJudge)
                    {
                        allJudges.Add(judge);
                    }

                    return allJudges;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return null;
                }
            }
        }
    }
}