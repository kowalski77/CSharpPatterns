using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Factory.Models;

namespace Factory.Support
{
    public interface IQuestionProvider
    {
        Task<IReadOnlyList<Question>> GetAllAsync(Func<Question, bool> predicate);
    }
}