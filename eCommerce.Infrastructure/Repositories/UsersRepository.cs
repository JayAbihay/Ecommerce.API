using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;

        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            // GEBERAR NUEVO GUID PARA EL USUARIO
            user.UserID = Guid.NewGuid();


            // SQL QUERY PARA INSERTAR USER DATA EN USERS TABLE 

            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
            
            
            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
            
            if (rowCountAffected > 0)
            {
                return user;
            } else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {

            // SQL PARA "SELECCIONAR" A UN USUARIO POR EMAIL Y USUARIO 

            string query = "SELECT * FROM public. \"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";

            // PARAMETERS 

            var parameters = new { Email = email, Password = password };



            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return user;
        }
    }
}
