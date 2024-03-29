﻿namespace Factory.Models;

public class Question
{
    public string Text { get; init; } = string.Empty;

    public Difficulty Difficulty { get; init; }

    public ICollection<Answer> Answers { get; init; } = new List<Answer>();
}