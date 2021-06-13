using System;
using System.Linq;
using System.Reflection;
using Factory.Models;
using Factory.Support;

namespace Factory.FactoryMethod.Factories
{
    public class SimpleExamProviderFactory : ExamProviderFactory
    {
        public override ExamProvider CreateExamProvider(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy => new EasyExamProvider(new QuestionJsonProxy()),
                Difficulty.Medium => new EasyExamProvider(new QuestionJsonProxy()),
                Difficulty.Hard => new HardExamProvider(new QuestionJsonProxy()),
                _ => throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null)
            };
        }
    }
}