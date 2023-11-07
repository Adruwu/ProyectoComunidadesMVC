using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers._Factory_StrategyFactory;
using ProyectoComunidades.Controllers.Checks;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidades.Controllers.Managements;
using ProyectoComunidadesRelativo.DB;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidadesRelativo.Controllers
{
    public class CheckService
    {
        static DatabaseManagement DBInstance = new DatabaseManagement();
        GenericList<User> userList = DBInstance.GetUsersDB();
        CommunityManagement CMInstance = new CommunityManagement();
        UserManagement UMInstance = new UserManagement();
        Checks _checks = new Checks();
        static StrategyFactory factory = new StrategyFactory();
        ICheckStrategy descriptionLengthChecker = factory.CreateCheckStrategy("DescriptionLength");
        ICheckStrategy emailLengthChecker = factory.CreateCheckStrategy("EmailLength");
        ICheckStrategy passwordLengthChecker = factory.CreateCheckStrategy("PasswordLength");
        ICheckStrategy passwordMatchChecker = factory.CreateCheckStrategy("PasswordMatch");
        ICheckStrategy passwordPatternChecker = factory.CreateCheckStrategy("PasswordPattern");
        ICheckStrategy userAgeChecker = factory.CreateCheckStrategy("UserAge");
        ICheckStrategy userEmailChecker = factory.CreateCheckStrategy("UserEmail");
        ICheckStrategy usernameLengthChecker = factory.CreateCheckStrategy("UsernameLength");
        ICheckStrategy usernamePatternChecker = factory.CreateCheckStrategy("UsernamePattern");

        private readonly ApplicationDbContext _context;

        public CheckService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsValidUser(string username, string password)
        {


            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Pass == password);

            return user != null;
        }
    }

}
