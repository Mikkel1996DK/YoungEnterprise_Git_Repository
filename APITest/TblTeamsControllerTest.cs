using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using YoungEnterprise_API.Controllers;
using YoungEnterprise_API.Models;

namespace APITest
{
    //[TestClass]
    public class TblTeamsControllerTest
    {
        //[TestMethod]
        public void GetTblTeamAll()
        {
            // todo put somewhere else. Also use in WPF
            var connection = @"Server=DESKTOP-ACNIRC0;Database=DB_YoungEnterprise;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<DB_YoungEnterpriseContext>();
            optionsBuilder.UseSqlServer(connection);
            DB_YoungEnterpriseContext context = new DB_YoungEnterpriseContext(optionsBuilder.Options);

            // here is the test
            //var controller = new TblTeamsController(context);
            //controller.GetTblTeam(); 
        }
    }
}
