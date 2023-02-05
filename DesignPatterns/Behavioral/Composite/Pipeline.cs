﻿namespace DesignPatterns.Behavioral.Composite;

public sealed class Pipeline : ITextProcessor
{
    private IEnumerable<ITextProcessor> Processors { get; }

    public Pipeline(IEnumerable<ITextProcessor> processors)
    {
        this.Processors = processors.ToList();
    }

    public Pipeline(params ITextProcessor[] processors)
        : this((IEnumerable<ITextProcessor>)processors)
    {
    }

    public IEnumerable<string> Execute(IEnumerable<string> text) =>
        this.Processors.Aggregate(text, (current, processor) => processor.Execute(current));
}
