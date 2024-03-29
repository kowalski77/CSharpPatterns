﻿using DesignPatterns.Behavioral.Chain.Abstraction;

namespace DesignPatterns.Behavioral.Chain.Implementation
{
    public class MultipleOfThreeHandler : HandlerBase<int, string>
    {
        public override string? Run(int request)
        {
            return request.IsDivisibleBy(3) ?
                $"The number: {request} is divisible by 3" :
                base.Run(request);
        }
    }
}