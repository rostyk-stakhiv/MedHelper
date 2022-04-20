using MedHelper.DAL.Entities;
using System.Threading.Tasks;

namespace MedHelper.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; }
        
        IRepository<User> UserRepository { get; }
        
        IRepository<Test> TestRepository { get; }
        
        IRepository<Role> RoleRepository { get; }
        
        IRepository<Answer> AnswerRepository { get; }

        Task<int> SaveAsync();
    }
}