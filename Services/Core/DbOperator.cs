//using Repositories.Dapper;
using Repositories.EntityFramework;

namespace Services.Core
{
    public class DbOperator<T> : GeneralQuery<T> where T : class
    {

    }
}
